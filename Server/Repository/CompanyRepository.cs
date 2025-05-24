using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Server.Exceptions;
using MoeSystem.Shared.Models;
using MoeSystem.Shared.Models.Company;
using MoeSystem.Shared.Models.CompanyDocument;
using MoeSystem.Shared.Models.CompanyLicence;
using MoeSystem.Shared.Models.CompanyOwnership;
using MoeSystem.Shared.Models.Logs;

namespace MoeSystem.Server.Repository
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Logs> logsRepository;



        public CompanyRepository(ApplicationDbContext context, IMapper mapper, IGenericRepository<Logs> logsRepository, UserManager<User> userManager) : base(context, mapper, userManager)
        {
            _context = context;
            _mapper = mapper;
            this.logsRepository = logsRepository;
        }

        public async Task<CompanyDetailDto> GetCompanyDetail(int? id)
        {
            var company = await _context.Companies.ProjectTo<CompanyDetailDto>(_mapper.ConfigurationProvider).FirstOrDefaultAsync(q => q.Id == id.Value);
            if (company is null)
            {
                throw new NotFoundException(nameof(GetCompanyDetail), id);
            }
            return company;
        }

        public async Task<PagedResult<CompanyLicenceDto>> GetExpiredCompany(SearchCompanyDto queryParameters)
        {
            var totalSize = await _context.CompanyLicences.CountAsync();
            var data = _context.CompanyLicences
                .Skip(queryParameters.StartIndex)
                .Take(queryParameters.PageSize)
                .ProjectTo<CompanyLicenceDto>(_mapper.ConfigurationProvider)
                .AsQueryable();
            data = data.Where(q => q.ExpireDate < DateTime.Now);
            if (queryParameters.Name != null)
            {
                data = data.Where(x => x.CompanyName.ToLower().Contains($"{queryParameters.Name.ToLower()}"));
            }
            return new PagedResult<CompanyLicenceDto>
            {
                Data = await data.ToListAsync(),
                PageNumber = queryParameters.PageNumber,
                RecordNumber = queryParameters.PageSize,
                TotalCount = totalSize

            };

        }

        public async Task<PagedResult<CompanyLicenceDto>> GetExpiringCompany(SearchCompanyDto queryParameters)
        {

            var data = _context.CompanyLicences
                .Skip(queryParameters.StartIndex)
                .Take(queryParameters.PageSize)
                .ProjectTo<CompanyLicenceDto>(_mapper.ConfigurationProvider)
                .AsQueryable();
            data = data.Where(q => q.ExpireDate.Value.Date.AddMonths(-1) > DateTime.Now.Date);
            if (queryParameters.Name != null)
            {
                data = data.Where(x => x.CompanyName.ToLower().Contains($"{queryParameters.Name.ToLower()}"));
            }
            return new PagedResult<CompanyLicenceDto>
            {
                Data = await data.ToListAsync(),
                PageNumber = queryParameters.PageNumber,
                RecordNumber = queryParameters.PageSize,
                TotalCount = await data.CountAsync()

            };

        }

        public async Task<List<CompanyDto>> SearchCompanies(SearchCompanyDetailDto search)
        {
            if (search.From == null && search.To == null) return new List<CompanyDto>();
            var data = _context.Companies
                .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
                .AsQueryable();
            data = data.Where(x => x.CreatedOn.Date >= search.From.Value.Date && x.CreatedOn.Date <= search.To.Value.Date);

            if (search.CompanyId.HasValue)
                data = data.Where(x => x.Id.Equals(search.CompanyId));



            if (search.Name != null) data = data.Where(x => x.Name.Contains($"{search.Name}"));

            if (search.Phone != null) data = data.Where(x => x.TellPhone.Contains($"{search.Phone}"));
            data = data.OrderByDescending(x => x.Id);
            return await data.ToListAsync();
        }

        public async Task<List<CompanyDto>> SearchCompanyFilters(CompanyFilterDto search)
        {
            var data = _context.Companies
                .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
                .AsQueryable();

            if (search.CompanyId.HasValue)
                data = data.Where(x => x.Id.Equals(search.CompanyId));

            if (search.Phone != null) data = data.Where(x => x.TellPhone.Contains($"{search.Phone}"));

            data = data.OrderByDescending(x => x.Id);
            return await data.ToListAsync();
        }

        public async Task<List<BaseLogsDto>> GetLogs(int? companyId)
        {
            return await _context.Logs.Where(x => x.CompanyId == companyId).ProjectTo<BaseLogsDto>(_mapper.ConfigurationProvider).ToListAsync();
        }


        public async Task<PagedResult<CompanyDto>> GetPagedResult(SearchCompanyDto queryParameters)
        {
            var totalSize = await _context.Companies.CountAsync();
            var data = _context.Companies
                .OrderByDescending(x => x.Id)
                .Skip((queryParameters.StartIndex - 1) * queryParameters.PageSize)
                .Take(queryParameters.PageSize)
                .ProjectTo<CompanyDto>(_mapper.ConfigurationProvider)
                .AsQueryable();
            if (queryParameters.Name != null)
            {
                data = data.Where(x => x.Name.ToLower().Contains($"{queryParameters.Name.ToLower()}"));
            }
            return new PagedResult<CompanyDto>
            {
                Data = await data.ToListAsync(),
                PageNumber = queryParameters.PageNumber,
                RecordNumber = queryParameters.PageSize,
                TotalCount = totalSize

            };

        }

        public async Task<List<CompanyOnlyDto>> GetCompanyWithIds(CancellationToken cancellationToken)
        {
            return await _context.Companies.AsNoTracking().ProjectTo<CompanyOnlyDto>(_mapper.ConfigurationProvider).ToListAsync(cancellationToken);
        }

        public async Task<List<CompanyDocumentDto>> GetCompanyDocuments(int? companyId)
        {
            return await _context.CompanyDocuments.Where(x => x.CompanyId == companyId).ProjectTo<CompanyDocumentDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public async Task<List<CompanyOwnershipDto>> GetCompanyOwnerships(int? companyId)
        {
            return await _context.CompanyOwnerships.Where(x => x.CompanyId == companyId).ProjectTo<CompanyOwnershipDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
        public async Task<List<CompanyLicenceDto>> GetCompanyLicences(int? companyId)
        {
            return await _context.CompanyLicences.Where(x => x.CompanyId == companyId).ProjectTo<CompanyLicenceDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
