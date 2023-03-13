using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using Microsoft.AspNetCore.Authorization;
using MoeSystem.Shared.Models.LicenceTypeTemplate;
using MoeSystem.Shared.Models;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class LicenceTypeTemplatesController : ControllerBase
    {
        private readonly IGenericRepository<LicenceTypeTemplate> _licenceTypeRepository;

        public LicenceTypeTemplatesController(IGenericRepository<LicenceTypeTemplate> licenceTypeRepository)
        {
            _licenceTypeRepository = licenceTypeRepository;
        }

        // GET: api/LicenceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LicenceTypeTemplateDto>>> GetLicenceTypeTemplate()
        {
            return await _licenceTypeRepository.GetAllAsync<LicenceTypeTemplateDto>();
        }

        [HttpGet("LookUp")]
        public async Task<ActionResult<IEnumerable<BaseLookUpDto>>> LookUp()
        {
            return await _licenceTypeRepository.GetAllAsync<BaseLookUpDto>();
        }


        // GET: api/LicenceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LicenceTypeTemplateDto>> GetLicenceTypeTemplate(int id)
        {
            return await _licenceTypeRepository.GetAsync<LicenceTypeTemplateDto>(id);
        }

        // PUT: api/LicenceTypes/5
        [HttpPut("{id}")]
        public async Task<ActionResult<LicenceTypeTemplate>> PutLicenceTypeTemplate(int id, CreateUpdateLicenceTypeTemplateDto updateLicenceTypeDto)
        {
            return await _licenceTypeRepository.UpdateAsync<CreateUpdateLicenceTypeTemplateDto>(id, updateLicenceTypeDto, HttpContext);
        }

        // POST: api/LicenceTypes
        [HttpPost]
        public async Task<ActionResult<LicenceTypeTemplate>> PostLicenceTypeTemplate(CreateUpdateLicenceTypeTemplateDto createLicenceTypeDto)
        {
            return await _licenceTypeRepository.AddAsync<CreateUpdateLicenceTypeTemplateDto, LicenceTypeTemplate>(createLicenceTypeDto, HttpContext);
        }

        // DELETE: api/LicenceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLicenceTypeTemplate(int id)
        {
            await _licenceTypeRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> LicenceTypeTemplateExists(int id)
        {
            return await _licenceTypeRepository.Exists(id);
        }
    }
}
