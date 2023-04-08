using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Server.Exceptions;
using MoeSystem.Server.Static;
using MoeSystem.Shared.Models;
using MoeSystem.Shared.Models.Licence;
using MoeSystem.Shared.Models.LicenceComment;
using MoeSystem.Shared.Models.LicenceCordinate;
using MoeSystem.Shared.Models.LicenceDocument;
using MoeSystem.Shared.Models.LicenceWorkflow;
using MoeSystem.Shared.Models.Logs;
using MoeSystem.Shared.Models.Messages;
using static MudBlazor.CategoryTypes;

namespace MoeSystem.Server.Repository
{
    public class LicenceRepository : GenericRepository<Licence>, ILicenceRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Logs> logsRepository;
        private readonly ISendMessage sendMessage;

        public LicenceRepository(ApplicationDbContext context, IMapper mapper, IGenericRepository<Logs> logsRepository, ISendMessage sendMessage, UserManager<User> userManager) : base(context, mapper, userManager)
        {
            _context = context;
            _mapper = mapper;
            this.logsRepository = logsRepository;
            this.sendMessage = sendMessage;
        }
        public async Task<LicenceWorkFlow> GetLicenceWorkFlow(int? id)
        {
            if (id is null)
            {
                return null;
            }
            return await _context.LicenceWorkFlows.FindAsync(id);
        }
        public async Task<MessageDto> GetMessage(string type)
        {
            var message = await _context.Messages.Where(x => x.Type == type).FirstOrDefaultAsync();
            if (message is null)
            {
                return null;
            }
            return _mapper.Map<MessageDto>(message);

        }
        public async Task<LicenceWorkFlowDto> ApproveLicence(int? id, HttpContext context)
        {
            var workflow = await GetLicenceWorkFlow(id);
            var licence = await GetAsync(workflow.LicenceId);
            if (workflow is null)
            {
                throw new NotFoundException(typeof(Licence).Name, id);
            }
            workflow.Status = true;
            workflow.Reject = false;
            workflow.CompletedOn = DateTime.Now;
            var step = workflow.Step;
            step++;
            var licenceWorkFlow = await _context.WorkFlow.Include(x => x.LicenceStatus).Where(x => x.LicenceTypeId == licence.LicenceTypeId && x.Step == step).FirstOrDefaultAsync();
            if (!licenceWorkFlow.LastStep)
            {

                await _context.LicenceWorkFlows.AddAsync(new LicenceWorkFlow
                {
                    WorkFlowId = licenceWorkFlow.Id,
                    LicenceId = workflow.LicenceId,
                    UserGroupId = licenceWorkFlow.UserGroupId.Value,
                    Step = step,
                    Activity = licenceWorkFlow.Activity,
                    CreatedOn = DateTime.Now,


                });
            }
            else
            {
                licence.LicenceStatus = licenceWorkFlow.LicenceStatus.Name;
                await SendMessage("Licence Finished", licence.Id);
            }
            licence.Status = licenceWorkFlow.LicenceStatus.Name;
            await logsRepository.AddAsync(new Logs { Description = $"Approved workflow of {licence.Status} on {DateTime.Now}", Dated = DateTime.Now, LicenceId = licence.Id }, context);
            await _context.SaveChangesAsync();
            return _mapper.Map<LicenceWorkFlowDto>(workflow);


        }
        public async Task<LicenceWorkFlowDto> RejectLicence(int? id, HttpContext context)
        {
            var workflow = await GetLicenceWorkFlow(id);
            if (workflow is null)
            {
                throw new NotFoundException(typeof(Licence).Name, id);
            }
            workflow.Status = false;
            workflow.Reject = true;
            await _context.SaveChangesAsync();
            await SendMessage("Licence Rejected", workflow.LicenceId.Value);
            await logsRepository.AddAsync(new Logs { Description = $"Rejected licence id of {workflow.LicenceId} on {DateTime.Now}", Dated = DateTime.Now, LicenceId = workflow.LicenceId }, context);
            return _mapper.Map<LicenceWorkFlowDto>(workflow);
        }
        public async Task<LicenceWorkFlowDto> ApproveRejectLicence(int? id, HttpContext context)
        {
            var workflow = await GetLicenceWorkFlow(id);
            if (workflow is null)
            {
                throw new NotFoundException(typeof(Licence).Name, id);
            }
            workflow.Reject = false;
            await _context.SaveChangesAsync();
            await logsRepository.AddAsync(new Logs { Description = $"Approved from rejected licence on {DateTime.Now}", Dated = DateTime.Now, LicenceId = workflow.LicenceId }, context);
            return _mapper.Map<LicenceWorkFlowDto>(workflow);
        }
        public async Task<CreateLicenceDto> CreateLicence(CreateLicenceDto createLicenceDto, HttpContext context)
        {
            //using var transaction = _context.Database.BeginTransaction();
            createLicenceDto.LicenceId = await GetLastId();
            var licence = _mapper.Map<Licence>(createLicenceDto);
            licence.CompanyId = createLicenceDto.CompanyId;
            // licence.Company = null;
            await _context.Licences.AddAsync(licence);
            await Save(context);
            var licenceWorkFlow = await _context.WorkFlow.Include(x => x.LicenceStatus).Where(x => x.LicenceTypeId == licence.LicenceTypeId && x.Step == Stepper.StepOne).FirstOrDefaultAsync();
            await _context.LicenceWorkFlows.AddAsync(new LicenceWorkFlow
            {
                WorkFlowId = licenceWorkFlow.Id,
                LicenceId = licence.Id,
                UserGroupId = licenceWorkFlow.UserGroupId.Value,
                Step = licenceWorkFlow.Step,
                Activity = licenceWorkFlow.Activity,
                CreatedOn = DateTime.Now
            });
            licence.Status = licenceWorkFlow.LicenceStatus.Name;
            await Save(context);
            await logsRepository.AddAsync(new Logs
            {
                Description = $"Licence registered workflow of {licenceWorkFlow.LicenceStatus.Name} on {DateTime.Now}",
                Dated = DateTime.Now,
                LicenceId = licence.Id
            }, context);
            //transaction.Commit();
            await SendMessage("Licence Registration", licence.Id);
            return _mapper.Map<CreateLicenceDto>(licence);

        }

        private async Task<int> GetLastId()
        {
            var licence = await _context.Licences.OrderByDescending(x => x.Id).FirstOrDefaultAsync();
            if (licence == null)
            {
                return 1000;
            }
            var id = licence.LicenceId;
            id++;
            return id;

        }

        private async Task SendMessage(string type, int licenceId)
        {
            var licence = await GetLicenceDetail(licenceId);
            var message = await GetMessage(type);
            string replace = string.Empty;
            switch (type)
            {
                case "Licence Registration":
                    replace = message.Body.Replace("(CUSTOMERNAME)", licence.Company.Name).Replace("(LICENCEID)", licence.LicenceId.ToString());
                    break;
                case "Licence Finished":
                    replace = message.Body.Replace("(CUSTOMERNAME)", licence.Company.Name).Replace("(LICENCEID)", licence.LicenceId.ToString());
                    break;
                case "Licence Rejected":
                    replace = message.Body.Replace("(CUSTOMERNAME)", licence.Company.Name).Replace("(LICENCEID)", licence.LicenceId.ToString());
                    break;
            }
            //await sendMessage.SendSms(replace, licence.Company.TellPhone);
        }
        public async Task<LicenceDetailDto> GetLicenceDetail(int? id)
        {
            var licence = await _context.Licences.ProjectTo<LicenceDetailDto>(_mapper.ConfigurationProvider).AsNoTracking().FirstOrDefaultAsync(q => q.Id == id.Value);
            if (licence is null)
            {
                throw new NotFoundException(nameof(GetLicenceDetail), id);
            }
            return licence;
        }
        public async Task<LicenceDetailPrintDto> GetLicenceDetailPrint(int? id)
        {
            var licence = await _context.Licences.ProjectTo<LicenceDetailPrintDto>(_mapper.ConfigurationProvider).AsNoTracking().FirstOrDefaultAsync(q => q.Id == id.Value);
            if (licence is null)
            {
                throw new NotFoundException(nameof(GetLicenceDetailPrint), id);
            }
            return licence;
        }

        public async Task<LicenceDetailDto> GetLicence(int? id)
        {
            var licence = await _context.Licences.ProjectTo<LicenceDetailDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(q => q.Id == id.Value);
            if (licence is null)
            {
                throw new NotFoundException(nameof(GetLicenceDetail), id);
            }
            return licence;
        }
        public async Task<LicenceWorkFlowDetailDto> GetLicenceWorkFlowDetail(int? id)
        {
            var licence = await _context.LicenceWorkFlows.ProjectTo<LicenceWorkFlowDetailDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(q => q.Id == id.Value);
            if (licence is null)
            {
                throw new NotFoundException(nameof(GetLicenceWorkFlowDetail), id);
            }
            return licence;
        }

        public async Task<LicenceWorkFlowDto> ClaimTask(int? id, string user)
        {
            var licenceWorkflow = await GetLicenceWorkFlow(id);
            if (licenceWorkflow is null)
            {
                throw new NotFoundException(nameof(GetLicenceWorkFlowDetail), id);
            }
            licenceWorkflow.StartedOn = DateTime.Now;
            licenceWorkflow.TaskActualOwner = user;
            await _context.SaveChangesAsync();
            return _mapper.Map<LicenceWorkFlowDto>(licenceWorkflow);
        }
        public async Task<LicenceWorkFlowDto> UnClaimTask(int? id)
        {
            var licenceWorkflow = await GetLicenceWorkFlow(id);
            if (licenceWorkflow is null)
            {
                throw new NotFoundException(nameof(GetLicenceWorkFlowDetail), id);
            }
            licenceWorkflow.StartedOn = null;
            licenceWorkflow.TaskActualOwner = null;
            await _context.SaveChangesAsync();
            return _mapper.Map<LicenceWorkFlowDto>(licenceWorkflow);
        }

        public async Task<List<LicenceWorkFlowDto>> RejectedLicences()
        {
            return await _context.LicenceWorkFlows.ProjectTo<LicenceWorkFlowDto>(_mapper.ConfigurationProvider).Where(x => x.Reject == true).ToListAsync();

        }
        public async Task<List<LicenceDto>> ApprovedLicences()
        {
            return await _context.Licences.ProjectTo<LicenceDto>(_mapper.ConfigurationProvider).Where(x => x.LicenceStatus == "Delivered").ToListAsync();

        }

        public async Task<List<LicenceWorkFlowDto>> GetTaskLicences(string userGroupId)
        {
            return await _context.LicenceWorkFlows.Where(x => x.TaskActualOwner == userGroupId && x.Status == false && x.Reject == false && x.StartedOn != null).ProjectTo<LicenceWorkFlowDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public async Task<List<LicenceWorkFlowDto>> GetToClaimLicences(int? userGroupId)
        {
            return await _context.LicenceWorkFlows.Where(x => x.UserGroupId == userGroupId && x.Status == false && x.Reject == false && x.StartedOn == null).ProjectTo<LicenceWorkFlowDto>(_mapper.ConfigurationProvider).OrderBy(x => x.Id).ToListAsync();
        }
        public async Task<List<BaseLogsDto>> GetLogs(int? licenceId)
        {
            return await _context.Logs.Where(x => x.LicenceId == licenceId).ProjectTo<BaseLogsDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<LicenceDocumentDto>> GetLicenceDocuments(int? licenceId)
        {
            return await _context.LicenceDocument.Where(x => x.LicenceId == licenceId).ProjectTo<LicenceDocumentDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public async Task<List<LicenceCommentDto>> GetLicenceComments(int? licenceId)
        {
            return await _context.LicenceComments.Where(x => x.LicenceId == licenceId).ProjectTo<LicenceCommentDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<List<LicenceCordinateDto>> GetLicenceCordinates(int? licenceId)
        {
            return await _context.LicenceCordinates.Where(x => x.LicenceId == licenceId).ProjectTo<LicenceCordinateDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public async Task<List<LicenceWorkFlowDto>> GetLicenceWorkflows(int? licenceId)
        {
            return await _context.LicenceWorkFlows.Where(x => x.LicenceId == licenceId).ProjectTo<LicenceWorkFlowDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public async Task<PagedResult<LicenceDto>> GetPagedResult(SearchLicenceDto queryParameters)
        {
            var totalSize = await _context.Licences.CountAsync();
            var data = _context.Licences
                .OrderByDescending(x => x.Id)
                .Skip((queryParameters.StartIndex - 1) * queryParameters.PageSize)
                .Take(queryParameters.PageSize)
                .ProjectTo<LicenceDto>(_mapper.ConfigurationProvider)
                .AsQueryable();
            if (queryParameters.LicenceId != null)
            {
                data = data.Where(x => x.LicenceId.ToString().ToLower().Contains($"{queryParameters.Name.ToLower()}"));
            }

            return new PagedResult<LicenceDto>
            {
                Data = await data.ToListAsync(),
                PageNumber = queryParameters.PageNumber,
                RecordNumber = queryParameters.PageSize,
                TotalCount = totalSize

            };

        }
        public async Task<List<LicenceOnlyDto>> GetLicenceWithIds(CancellationToken cancellationToken)
        {
            return await _context.Licences.AsNoTracking().ProjectTo<LicenceOnlyDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }

        public async Task<List<LicenceOnlyDto>> GetLicenceCompletedWithIds(CancellationToken cancellationToken)
        {
            return await _context.Licences.Where(x => x.LicenceStatus == "Completed").AsNoTracking().ProjectTo<LicenceOnlyDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }

        public async Task<List<LicenceOnlyDto>> GetLicencePendingWithIds(CancellationToken cancellationToken)
        {
            return await _context.Licences.Where(x => x.LicenceStatus != "Completed").AsNoTracking().ProjectTo<LicenceOnlyDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }

        public async Task<List<LicenceDto>> GetLastLicences(CancellationToken cancellationToken)
        {
            return await _context.Licences.OrderByDescending(x => x.Id).Take(10).AsNoTracking().ProjectTo<LicenceDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }

        public async Task<PagedResult<LicenceDto>> GetExpiredLicences(SearchLicenceDto queryParameters)
        {
            var totalSize = await _context.Licences.CountAsync();
            var data = _context.Licences
                .Skip(queryParameters.StartIndex)
                .Take(queryParameters.PageSize)
                .ProjectTo<LicenceDto>(_mapper.ConfigurationProvider)
                .AsQueryable();
            data = data.Where(q => q.LicenceEndDate < DateTime.Now);
            if (queryParameters.Name != null)
            {
                data = data.Where(x => x.CompanyName.ToLower().Contains($"{queryParameters.Name.ToLower()}"));
            }
            return new PagedResult<LicenceDto>
            {
                Data = await data.ToListAsync(),
                PageNumber = queryParameters.PageNumber,
                RecordNumber = queryParameters.PageSize,
                TotalCount = totalSize

            };

        }

        public async Task<PagedResult<LicenceDto>> GetExpiringLicences(SearchLicenceDto queryParameters)
        {
            var totalSize = await _context.Licences.CountAsync();
            var data = _context.Licences
                .Skip(queryParameters.StartIndex)
                .Take(queryParameters.PageSize)
                .ProjectTo<LicenceDto>(_mapper.ConfigurationProvider)
                .AsQueryable();
            data = data.Where(q => q.LicenceEndDate.Date.AddMonths(-1) > DateTime.Now.Date);
            if (queryParameters.Name != null)
            {
                data = data.Where(x => x.CompanyName.ToLower().Contains($"{queryParameters.Name.ToLower()}"));
            }
            return new PagedResult<LicenceDto>
            {
                Data = await data.ToListAsync(),
                PageNumber = queryParameters.PageNumber,
                RecordNumber = queryParameters.PageSize,
                TotalCount = totalSize

            };

        }

        public async Task<PagedResult<LicenceDto>> FinishedLicences(SearchLicenceDto queryParameters)
        {
            var totalSize = await _context.Licences.CountAsync();
            var data = _context.Licences
                .OrderByDescending(x => x.Id)
                .Skip((queryParameters.StartIndex - 1) * queryParameters.PageSize)
                .Take(queryParameters.PageSize)
                .ProjectTo<LicenceDto>(_mapper.ConfigurationProvider)
                .AsQueryable();
            if (queryParameters.LicenceId != null)
            {
                data = data.Where(x => x.LicenceId.ToString().ToLower().Contains($"{queryParameters.Name.ToLower()}"));
            }
            data = data.Where(x => x.LicenceStatus == "Completed");

            return new PagedResult<LicenceDto>
            {
                Data = await data.ToListAsync(),
                PageNumber = queryParameters.PageNumber,
                RecordNumber = queryParameters.PageSize,
                TotalCount = totalSize

            };

        }

        public async Task<PagedResult<LicenceDto>> ProgressLicences(SearchLicenceDto queryParameters)
        {
            var totalSize = await _context.Licences.CountAsync();
            var data = _context.Licences
                .OrderByDescending(x => x.Id)
                .Skip((queryParameters.StartIndex - 1) * queryParameters.PageSize)
                .Take(queryParameters.PageSize)
                .ProjectTo<LicenceDto>(_mapper.ConfigurationProvider)
                .AsQueryable();
            if (queryParameters.LicenceId != null)
            {
                data = data.Where(x => x.LicenceId.ToString().ToLower().Contains($"{queryParameters.Name.ToLower()}"));
            }

            data = data.Where(x => x.LicenceStatus != "Completed");

            return new PagedResult<LicenceDto>
            {
                Data = await data.ToListAsync(),
                PageNumber = queryParameters.PageNumber,
                RecordNumber = queryParameters.PageSize,
                TotalCount = totalSize

            };

        }

        public async Task<List<LicenceDto>> SearchLicence(SearchLicenceDetailDto search)
        {
            if (search.From == null && search.To == null) return new List<LicenceDto>();
            var data = _context.Licences
                .ProjectTo<LicenceDto>(_mapper.ConfigurationProvider)
                .AsQueryable();
            data = data.Where(x => x.CreatedOn.Date >= search.From.Value.Date && x.CreatedOn.Date <= search.To.Value.Date);
            if (search.LicenceId != null)
                data = data.Where(x => x.LicenceId.ToString().ToLower().Contains($"{search.LicenceId.ToLower()}"));

            if (search.LicenceStatus != null) data = data.Where(x => x.Status == search.LicenceStatus);

            if (search.CompanyName != null) data = data.Where(x => x.CompanyName.Contains($"{search.CompanyName}"));

            if (search.Phone != null) data = data.Where(x => x.TellPhone.Contains($"{search.Phone}"));
            data = data.OrderByDescending(x => x.Id);
            return await data.ToListAsync();
        }



        public async Task<List<PendingWorkflowsDto>> CalculateWorkflow()
        {

            return await _context.LicenceWorkFlows
        .Select(c => new
        {
            c.WorkFlow.UserGroup.Name,
            c.WorkFlow.UserGroup.InSomali,
            c.StartedOn,
            c.CompletedOn
            //other properties
        })
        .GroupBy(c => c.Name, (k, g) => new PendingWorkflowsDto
        {
            UserGroup = k,
            InClaim = g.Sum(b => b.StartedOn == null && b.CompletedOn == null ? 1 : 0),
            InProgress = g.Sum(b => b.CompletedOn == null ? 1 : 0),
            Completed = g.Sum(b => b.CompletedOn != null ? 1 : 0)
        }).ToListAsync();
        }

        public async Task<List<TopLicenceGrouping>> TopLicences()
        {

            return await _context.Licences
        .Select(c => new
        {
            c.LicenceType.Name,

            //other properties
        })
        .GroupBy(c => c.Name, (k, g) => new TopLicenceGrouping
        {
            Licence = k,
            Total = g.Count()

        }).OrderByDescending(x => x.Licence).ToListAsync();
        }
    }


}
