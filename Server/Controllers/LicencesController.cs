using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models;
using MoeSystem.Shared.Models.Licence;
using Microsoft.AspNetCore.Authorization;
using MoeSystem.Shared.Models.Logs;
using MoeSystem.Shared.Models.LicenceDocument;
using MoeSystem.Shared.Models.LicenceComment;
using MoeSystem.Shared.Models.LicenceCordinate;
using MoeSystem.Shared.Models.LicenceWorkflow;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class LicencesController : ControllerBase
    {
        private readonly ILicenceRepository _licenceRepository;

        public LicencesController(ILicenceRepository licenceRepository)
        {
            _licenceRepository = licenceRepository;
        }

        // GET: api/Licences
        [HttpGet]
        public async Task<ActionResult<PagedResult<LicenceDto>>> GetLicences([FromQuery] SearchLicenceDto queryParameters)
        {
            return await _licenceRepository.GetPagedResult(queryParameters);
        }

        [HttpGet("GetExpiredLicences")]
        public async Task<ActionResult<PagedResult<LicenceDto>>> GetExpiredLicences([FromQuery] SearchLicenceDto queryParameters)
        {
            return await _licenceRepository.GetExpiredLicences(queryParameters);
        }

        [HttpGet("GetExpiringLicences")]
        public async Task<ActionResult<PagedResult<LicenceDto>>> GetExpiringLicences([FromQuery] SearchLicenceDto queryParameters)
        {
            return await _licenceRepository.GetExpiredLicences(queryParameters);
        }

        [HttpGet("GetLatestLicences")]
        public async Task<ActionResult<List<LicenceDto>>> GetLatestLicences(CancellationToken cancellationToken)
        {
            return await _licenceRepository.GetLastLicences(cancellationToken);
        }

        [HttpGet("GetLicenceWithIds")]
        public async Task<ActionResult<List<LicenceOnlyDto>>> GetLicenceWithIds(CancellationToken cancellationToken)
        {
            return await _licenceRepository.GetLicenceWithIds(cancellationToken);
        }

        [HttpGet("GetLicenceCompletedWithIds")]
        public async Task<ActionResult<List<LicenceOnlyDto>>> GetLicenceCompletedWithIds(CancellationToken cancellationToken)
        {
            return await _licenceRepository.GetLicenceCompletedWithIds(cancellationToken);
        }

        [HttpGet("GetLicencePendingWithIds")]
        public async Task<ActionResult<List<LicenceOnlyDto>>> GetLicencePendingWithIds(CancellationToken cancellationToken)
        {
            return await _licenceRepository.GetLicencePendingWithIds(cancellationToken);
        }

        [HttpGet("ProgressLicences")]
        public async Task<ActionResult<PagedResult<LicenceDto>>> ProgressLicences([FromQuery] SearchLicenceDto queryParameters)
        {
            return await _licenceRepository.ProgressLicences(queryParameters);
        }

        [HttpGet("FinishedLicences")]
        public async Task<ActionResult<PagedResult<LicenceDto>>> FinishedLicences([FromQuery] SearchLicenceDto queryParameters)
        {
            return await _licenceRepository.FinishedLicences(queryParameters);
        }

        [HttpGet("SearchLicence")]
        public async Task<ActionResult<List<LicenceDto>>> SearchLicence([FromQuery] SearchLicenceDetailDto search)
        {
            return await _licenceRepository.SearchLicence(search);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<LicenceDto>>> GetAll()
        {
            return await _licenceRepository.GetAllAsync<LicenceDto>();
        }

        // GET: api/Licences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LicenceDto>> GetLicence(int id)
        {
            return await _licenceRepository.GetAsync<LicenceDto>(id);
        }

        [HttpGet("GetLicenceDetail/{id}")]
        public async Task<ActionResult<LicenceDetailDto>> GetLicenceDetail(int id)
        {
            return await _licenceRepository.GetLicenceDetail(id);
        }

        [HttpGet("GetLicencePrintDetail/{id}")]
        public async Task<ActionResult<LicenceDetailPrintDto>> GetLicencePrintDetail(int id)
        {
            return await _licenceRepository.GetLicenceDetailPrint(id);
        }

        [HttpGet("GetLogs/{id}")]
        public async Task<ActionResult<List<BaseLogsDto>>> GetLogs(int id)
        {
            return await _licenceRepository.GetLogs(id);
        }

        [HttpGet("GetLicenceDocuments/{id}")]
        public async Task<ActionResult<List<LicenceDocumentDto>>> GetLicenceDocuments(int id)
        {
            return await _licenceRepository.GetLicenceDocuments(id);
        }
        [HttpGet("GetLicenceComments/{id}")]
        public async Task<ActionResult<List<LicenceCommentDto>>> GetLicenceComments(int id)
        {
            return await _licenceRepository.GetLicenceComments(id);
        }
        [HttpGet("GetLicenceCordinates/{id}")]
        public async Task<ActionResult<List<LicenceCordinateDto>>> GetLicenceCordinates(int id)
        {
            return await _licenceRepository.GetLicenceCordinates(id);
        }
        [HttpGet("GetLicenceWorkflows/{id}")]
        public async Task<ActionResult<List<LicenceWorkFlowDto>>> GetLicenceWorkflows(int id)
        {
            return await _licenceRepository.GetLicenceWorkflows(id);
        }

        [HttpGet("GetTopLicences")]
        public async Task<ActionResult<IEnumerable<TopLicenceGrouping>>> GetTopLicences()
        {
            return await _licenceRepository.TopLicences();
        }

        // PUT: api/Licences/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Licence>> PutLicence(int id, UpdateLicenceDto updateLicenceDto)
        {
            return await _licenceRepository.UpdateAsync<UpdateLicenceDto>(id, updateLicenceDto, HttpContext);
        }
        // POST: api/Licences
        [HttpPost]
        public async Task<ActionResult<Licence>> PostLicence(CreateLicenceDto createLicenceDto)
        {
            return await _licenceRepository.AddAsync<CreateLicenceDto, Licence>(createLicenceDto, HttpContext);
        }

        // POST: api/Licences/GenerateLicence
        [HttpPost("GenerateLicence")]
        public async Task<ActionResult<CreateLicenceDto>> GenerateLicence(CreateLicenceDto createLicenceDto)
        {
            return await _licenceRepository.CreateLicence(createLicenceDto, HttpContext);
        }

        // DELETE: api/Licences/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLicence(int id)
        {
            await _licenceRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> LicenceExists(int id)
        {
            return await _licenceRepository.Exists(id);
        }
    }
}
