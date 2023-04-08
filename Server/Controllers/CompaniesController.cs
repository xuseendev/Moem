using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Server.Repository;
using MoeSystem.Shared.Models;
using MoeSystem.Shared.Models.Company;
using MoeSystem.Shared.Models.CompanyDocument;
using MoeSystem.Shared.Models.CompanyLicence;
using MoeSystem.Shared.Models.CompanyOwnership;
using MoeSystem.Shared.Models.Logs;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompaniesController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        // GET: api/Companies
        [HttpGet]
        public async Task<ActionResult<PagedResult<CompanyDto>>> GetCompanies([FromQuery] SearchCompanyDto queryParameters)
        {
            return await _companyRepository.GetPagedResult(queryParameters);
        }

        [HttpGet("GetCompanyWithIds")]
        public async Task<ActionResult<List<CompanyOnlyDto>>> GetCompanyWithIds(CancellationToken cancellationToken)
        {
            return await _companyRepository.GetCompanyWithIds(cancellationToken);
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetAll()
        {
            return await _companyRepository.GetAllAsync<CompanyDto>();
        }

        [HttpGet("SearchCompanies")]
        public async Task<ActionResult<List<CompanyDto>>> SearchCompanies([FromQuery] SearchCompanyDetailDto search)
        {
            return await _companyRepository.SearchCompanies(search);
        }

        [HttpGet("GetExpiredCompany")]
        public async Task<ActionResult<PagedResult<CompanyLicenceDto>>> GetExpiredCompany([FromQuery] SearchCompanyDto queryParameters)
        {
            return await _companyRepository.GetExpiredCompany(queryParameters);
        }

        [HttpGet("GetExpiringCompany")]
        public async Task<ActionResult<PagedResult<CompanyLicenceDto>>> GetExpiringCompany([FromQuery] SearchCompanyDto queryParameters)
        {
            return await _companyRepository.GetExpiringCompany(queryParameters);
        }

        [HttpGet("LookUp")]
        public async Task<ActionResult<IEnumerable<BaseLookUpDto>>> LookUp()
        {
            return await _companyRepository.GetAllAsync<BaseLookUpDto>();
        }


        // GET: api/Companies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(int id)
        {
            return await _companyRepository.GetAsync<CompanyDto>(id);
        }

        [HttpGet("GetCompanyDetail/{id}")]
        public async Task<ActionResult<CompanyDetailDto>> GetCompanyDetail(int id)
        {
            return await _companyRepository.GetCompanyDetail(id);
        }

        // PUT: api/Companies/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Company>> PutCompany(int id, UpdateCompanyDto updateCompanyDto)
        {
            return await _companyRepository.UpdateAsync<UpdateCompanyDto>(id, updateCompanyDto, HttpContext);
        }

        [HttpGet("GetLogs/{id}")]
        public async Task<ActionResult<List<BaseLogsDto>>> GetLogs(int id)
        {
            return await _companyRepository.GetLogs(id);
        }

        [HttpGet("GetCompanyDocuments/{id}")]
        public async Task<ActionResult<List<CompanyDocumentDto>>> GetCompanyDocuments(int id)
        {
            return await _companyRepository.GetCompanyDocuments(id);
        }

        [HttpGet("GetCompanyOwernships/{id}")]
        public async Task<ActionResult<List<CompanyOwnershipDto>>> GetCompanyOwernships(int id)
        {
            return await _companyRepository.GetCompanyOwnerships(id);
        }

        [HttpGet("GetCompanyLicences/{id}")]
        public async Task<ActionResult<List<CompanyLicenceDto>>> GetCompanyLicences(int id)
        {
            return await _companyRepository.GetCompanyLicences(id);
        }



        // POST: api/Companies
        [HttpPost]
        public async Task<ActionResult<Company>> PostCompany(CreateCompanyDto createCompanyDto)
        {
            return await _companyRepository.AddAsync<CreateCompanyDto, Company>(createCompanyDto, HttpContext);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompany(int id)
        {
            await _companyRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CompanyExists(int id)
        {
            return await _companyRepository.Exists(id);
        }
    }
}
