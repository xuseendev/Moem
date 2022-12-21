using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models;
using MoeSystem.Shared.Models.Region;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class RegionsController : ControllerBase
    {
        private readonly IGenericRepository<Region> _regionRepository;

        public RegionsController(IGenericRepository<Region> regionRepository)
        {
            _regionRepository = regionRepository;
        }

        // GET: api/Regions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionDto>>> GetRegion()
        {
            return await _regionRepository.GetAllAsync<RegionDto>();
        }
        [HttpGet("LookUp")]
        public async Task<ActionResult<IEnumerable<BaseLookUpDto>>> LookUp()
        {
            return await _regionRepository.GetAllAsync<BaseLookUpDto>();
        }

        // GET: api/Regions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegionDto>> GetRegion(int id)
        {
            return await _regionRepository.GetAsync<RegionDto>(id);
        }

        // PUT: api/Regions/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Region>> PutRegion(int id, UpdateRegionDto updateRegionDto)
        {
            return await _regionRepository.UpdateAsync<UpdateRegionDto>(id, updateRegionDto);
        }

        // POST: api/Regions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CreateRegionDto>> PostRegion(CreateRegionDto createRegionDto)
        {
            return await _regionRepository.AddAsync<CreateRegionDto,CreateRegionDto>(createRegionDto);
        }

        // DELETE: api/Regions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            await _regionRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> RegionExists(int id)
        {
            return await _regionRepository.Exists(id);
        }
    }
}
