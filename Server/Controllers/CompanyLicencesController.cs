using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models.CompanyLicence;
using MoeSystem.Shared.Models.CompanyOwnership;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class CompanyLicencesController : ControllerBase
    {
        private readonly IGenericRepository<CompanyLicence> _companyOwnershipRepository;

        public CompanyLicencesController(IGenericRepository<CompanyLicence> companyOwnershipRepository)
        {
            _companyOwnershipRepository = companyOwnershipRepository;
        }

        // GET: api/CompanyOwnerships
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyLicenceDto>>> GetCompanyOwnerships()
        {
            return await _companyOwnershipRepository.GetAllAsync<CompanyLicenceDto>();
        }

        // GET: api/CompanyOwnerships/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyLicenceDto>> GetCompanyOwnership(int id)
        {
            return await _companyOwnershipRepository.GetAsync<CompanyLicenceDto>(id);
        }

        // PUT: api/CompanyOwnerships/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyLicence>> PutCompanyOwnership(int id, UpdateCompanyLicenceDto updateCompanyLicence)
        {
            return await _companyOwnershipRepository.UpdateAsync<UpdateCompanyLicenceDto>(id, updateCompanyLicence, HttpContext);
        }

        // POST: api/CompanyOwnerships
        [HttpPost]
        public async Task<ActionResult<CompanyLicence>> PostCompanyOwnership(CreateCompanyLicenceDto createCompanyLicence)
        {
            return await _companyOwnershipRepository.AddAsync<CreateCompanyLicenceDto, CompanyLicence>(createCompanyLicence, HttpContext);
        }

        // DELETE: api/CompanyOwnerships/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyOwnership(int id)
        {
            await _companyOwnershipRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CompanyOwnershipExists(int id)
        {
            return await _companyOwnershipRepository.Exists(id);
        }
    }
}
