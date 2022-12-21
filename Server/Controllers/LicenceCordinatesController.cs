using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models.LicenceCordinate;
using Microsoft.AspNetCore.Authorization;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class LicenceCordinatesController : ControllerBase
    {
        private readonly IGenericRepository<LicenceCordinates> _licenceCordinateRepository;

        public LicenceCordinatesController(IGenericRepository<LicenceCordinates> licenceCordinateRepository)
        {
            _licenceCordinateRepository = licenceCordinateRepository;
        }

        // GET: api/LicenceCordinates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LicenceCordinateDto>>> GetLicenceCordinates()
        {
            return await _licenceCordinateRepository.GetAllAsync<LicenceCordinateDto>();
        }

        // GET: api/LicenceCordinates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LicenceCordinateDto>> GetLicenceCordinates(int id)
        {
            return await _licenceCordinateRepository.GetAsync<LicenceCordinateDto>(id);
        }

        // PUT: api/LicenceCordinates/5
        [HttpPut("{id}")]
        public async Task<ActionResult<LicenceCordinates>> PutLicenceCordinates(int id, UpdateLicenceCordinateDto updateLicenceCordinateDto)
        {
            return await _licenceCordinateRepository.UpdateAsync<UpdateLicenceCordinateDto>(id, updateLicenceCordinateDto);
        }

        // POST: api/LicenceCordinates
        [HttpPost]
        public async Task<ActionResult<LicenceCordinates>> PostLicenceCordinates(CreateLicenceCordinateDto createLicenceCordinateDto)
        {
            return await _licenceCordinateRepository.AddAsync<CreateLicenceCordinateDto, LicenceCordinates>(createLicenceCordinateDto);
        }

        // DELETE: api/LicenceCordinates/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLicenceCordinates(int id)
        {
           await _licenceCordinateRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> LicenceCordinatesExists(int id)
        {
            return await _licenceCordinateRepository.Exists(id);
        }
    }
}
