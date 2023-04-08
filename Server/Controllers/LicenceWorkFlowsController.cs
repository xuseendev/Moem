using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models.Licence;
using MoeSystem.Shared.Models.LicenceWorkflow;
using Microsoft.AspNetCore.Authorization;
using MoeSystem.Server.Extensions;
using MoeSystem.Shared.Models;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class LicenceWorkFlowsController : ControllerBase
    {
        private readonly IGenericRepository<LicenceWorkFlow> _licenceWorkflowRepository;
        private readonly ILicenceRepository _licenceRepository;
        private readonly ILogger<LicenceWorkFlowsController> _logger;

        public LicenceWorkFlowsController(IGenericRepository<LicenceWorkFlow> licenceWorkFlow, ILicenceRepository licenceRepository, ILogger<LicenceWorkFlowsController> logger)
        {
            this._logger = logger;
            _licenceWorkflowRepository = licenceWorkFlow;
            _licenceRepository = licenceRepository;
        }

        // GET: api/LicenceWorkFlows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LicenceWorkFlowDto>>> GetLicenceWorkFlows()
        {
            return await _licenceWorkflowRepository.GetAllAsync<LicenceWorkFlowDto>();
        }


        [HttpGet("GetTaskLicences")]
        public async Task<ActionResult<IEnumerable<LicenceWorkFlowDto>>> GetTaskLicences()
        {
            return await _licenceRepository.GetTaskLicences(User.GetUsername());
        }

        [HttpGet("GetToClaimLicences")]
        public async Task<ActionResult<IEnumerable<LicenceWorkFlowDto>>> GetToClaimLicences()
        {
            return await _licenceRepository.GetToClaimLicences(User.GetUserGroupId());
        }


        [HttpGet("GetSummaryWorkflowLicences")]
        public async Task<ActionResult<IEnumerable<PendingWorkflowsDto>>> GetSummaryWorkflowLicences()
        {
            return await _licenceRepository.CalculateWorkflow();
        }

        [HttpPut("ApproveLicence/{id}")]
        public async Task<ActionResult<LicenceWorkFlowDto>> ApproveLicence(int id)
        {
            return await _licenceRepository.ApproveLicence(id, HttpContext);
        }



        [HttpPut("RejectLicence/{id}")]
        public async Task<ActionResult<LicenceWorkFlowDto>> RejectLicence(int id)
        {
            return await _licenceRepository.RejectLicence(id, HttpContext);
        }
        [HttpPut("AproveRejectLicence/{id}")]
        public async Task<ActionResult<LicenceWorkFlowDto>> AproveRejectLicence(int id)
        {
            return await _licenceRepository.ApproveRejectLicence(id, HttpContext);
        }

        [HttpGet("RejectedLicence")]
        public async Task<ActionResult<List<LicenceWorkFlowDto>>> RejectedLicence()
        {
            return await _licenceRepository.RejectedLicences();
        }


        [HttpGet("ApprovedLicences")]
        public async Task<ActionResult<List<LicenceDto>>> ApprovedLicences()
        {
            return await _licenceRepository.ApprovedLicences();
        }

        // GET: api/LicenceWorkFlows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LicenceWorkFlowDto>> GetLicenceWorkFlow(int id)
        {
            return await _licenceWorkflowRepository.GetAsync<LicenceWorkFlowDto>(id);
        }

        // GET: api/LicenceWorkFlows/Details/5
        [HttpGet("Details/{id}")]
        public async Task<ActionResult<LicenceWorkFlowDetailDto>> Details(int id)
        {
            return await _licenceRepository.GetLicenceWorkFlowDetail(id);
        }

        // PUT: api/LicenceWorkFlows/5
        [HttpPut("{id}")]
        public async Task<ActionResult<LicenceWorkFlow>> PutLicenceWorkFlow(int id, UpdateLicenceWorkFlowDto updateLicenceWorkFlowDto)
        {
            return await _licenceWorkflowRepository.UpdateAsync<UpdateLicenceWorkFlowDto>(id, updateLicenceWorkFlowDto, HttpContext);
        }

        [HttpPut("ClaimTask/{id}")]
        public async Task<ActionResult<LicenceWorkFlowDto>> ClaimTask(int id)
        {
            return await _licenceRepository.ClaimTask(id, User.GetUsername());
        }
        [HttpPut("UnClaimTask/{id}")]
        public async Task<ActionResult<LicenceWorkFlowDto>> UnClaimTask(int id)
        {
            return await _licenceRepository.UnClaimTask(id);
        }

        // POST: api/LicenceWorkFlows
        [HttpPost]
        public async Task<ActionResult<LicenceWorkFlow>> PostLicenceWorkFlow(CreateLicenceWorkFlow createLicenceWorkFlow)
        {
            return await _licenceWorkflowRepository.AddAsync<CreateLicenceWorkFlow, LicenceWorkFlow>(createLicenceWorkFlow, HttpContext);
        }

        // DELETE: api/LicenceWorkFlows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLicenceWorkFlow(int id)
        {
            await _licenceWorkflowRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> LicenceWorkFlowExists(int id)
        {
            return await _licenceWorkflowRepository.Exists(id);
        }
    }
}
