using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models;
using MoeSystem.Shared.Models.CompanyTypes;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class CompanyTypesController : ControllerBase
    {
        private readonly IGenericRepository<CompanyType> _companyTypeRepository;

        public CompanyTypesController(IGenericRepository<CompanyType> companyTypeRepository)
        {
            _companyTypeRepository = companyTypeRepository;
        }

        // GET: api/CompanyTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyTypeDto>>> GetCompanyTypes()
        {
            return await _companyTypeRepository.GetAllAsync<CompanyTypeDto>();
        }

        [HttpGet("LookUp")]
        public async Task<ActionResult<IEnumerable<BaseLookUpDto>>> LookUp()
        {
            return await _companyTypeRepository.GetAllAsync<BaseLookUpDto>();
        }

        // GET: api/CompanyTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyTypeDto>> GetCompanyType(int id)
        {
            return await _companyTypeRepository.GetAsync<CompanyTypeDto>(id);
        }

        // PUT: api/CompanyTypes/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyType>> PutCompanyType(int id, UpdateCompanyTypeDto updateCompanyTypeDto)
        {
            return await _companyTypeRepository.UpdateAsync<UpdateCompanyTypeDto>(id, updateCompanyTypeDto);
        }


        [HttpPost]
        public async Task<ActionResult<CompanyType>> PostCompanyType(CreateCompanyTypeDto createCompanyTypeDto)
        {
            return await _companyTypeRepository.AddAsync<CreateCompanyTypeDto,CompanyType>(createCompanyTypeDto);
        }

        // DELETE: api/CompanyTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyType(int id)
        {
            await _companyTypeRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CompanyTypeExists(int id)
        {
            return await _companyTypeRepository.Exists(id);
        }
    }
}
