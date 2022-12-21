using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models.CompanyOwnership;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class CompanyOwnershipsController : ControllerBase
    {
        private readonly IGenericRepository<CompanyOwnership> _companyOwnershipRepository;

        public CompanyOwnershipsController(IGenericRepository<CompanyOwnership>  companyOwnershipRepository)
        {
            _companyOwnershipRepository = companyOwnershipRepository;
        }

        // GET: api/CompanyOwnerships
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyOwnershipDto>>> GetCompanyOwnerships()
        {
            return await _companyOwnershipRepository.GetAllAsync< CompanyOwnershipDto>();
        }

        // GET: api/CompanyOwnerships/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyOwnershipDto>> GetCompanyOwnership(int id)
        {
            return await _companyOwnershipRepository.GetAsync< CompanyOwnershipDto>(id);
        }

        // PUT: api/CompanyOwnerships/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyOwnership>> PutCompanyOwnership(int id, UpdateCompanyOwnershipDto updateCompanyOwnershipDto)
        {
            return await _companyOwnershipRepository.UpdateAsync<UpdateCompanyOwnershipDto>(id, updateCompanyOwnershipDto);
        }

        // POST: api/CompanyOwnerships
        [HttpPost]
        public async Task<ActionResult<CompanyOwnership>> PostCompanyOwnership(CreateCompanyOwnershipDto createCompanyOwnershipDto)
        {
            return await _companyOwnershipRepository.AddAsync<CreateCompanyOwnershipDto,CompanyOwnership>(createCompanyOwnershipDto);
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
