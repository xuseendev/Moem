using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models;
using MoeSystem.Shared.Models.LicenceTypes;
using Microsoft.AspNetCore.Authorization;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class LicenceTypesController : ControllerBase
    {
        private readonly IGenericRepository<LicenceType> _licenceTypeRepository;

        public LicenceTypesController(IGenericRepository<LicenceType> licenceTypeRepository)
        {
            _licenceTypeRepository = licenceTypeRepository;
        }

        // GET: api/LicenceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LicenceTypeDto>>> GetLicenceType()
        {
            return await _licenceTypeRepository.GetAllAsync<LicenceTypeDto>();
        }
        [HttpGet("LookUp")]
        public async Task<ActionResult<IEnumerable<BaseLookUpDto>>> LookUp()
        {
            return await _licenceTypeRepository.GetAllAsync<BaseLookUpDto>();
        }

        // GET: api/LicenceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LicenceTypeDto>> GetLicenceType(int id)
        {
            return await _licenceTypeRepository.GetAsync<LicenceTypeDto>(id);
        }

        // PUT: api/LicenceTypes/5
        [HttpPut("{id}")]
        public async Task<ActionResult<LicenceType>> PutLicenceType(int id, UpdateLicenceTypeDto updateLicenceTypeDto)
        {
            return await _licenceTypeRepository.UpdateAsync<UpdateLicenceTypeDto>(id, updateLicenceTypeDto);
        }

        // POST: api/LicenceTypes
        [HttpPost]
        public async Task<ActionResult<LicenceType>> PostLicenceType(CreateLicenceTypeDto createLicenceTypeDto)
        {
            return await _licenceTypeRepository.AddAsync<CreateLicenceTypeDto,LicenceType>(createLicenceTypeDto);
        }

        // DELETE: api/LicenceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLicenceType(int id)
        {
            await _licenceTypeRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> LicenceTypeExists(int id)
        {
            return await _licenceTypeRepository.Exists(id);
        }
    }
}
