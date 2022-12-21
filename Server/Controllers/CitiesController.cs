using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models;
using MoeSystem.Shared.Models.City;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class CitiesController : ControllerBase
    {
        private readonly IGenericRepository<City> _cityRepository;

        public CitiesController(IGenericRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }

        // GET: api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityDto>>> GetCities()
        {

            return await _cityRepository.GetAllAsync<CityDto>();
        }

        [HttpGet("LookUp/{id}")]
        public async Task<ActionResult<IEnumerable<BaseLookUpDto>>> LookUp(int id)
        {
      
            return await _cityRepository.GetAllAsync<BaseLookUpDto>(x=>x.RegionId==id);
        }

        // GET: api/Cities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityDto>> GetCity(int id)
        {
            return await _cityRepository.GetAsync<CityDto>(id);
        }

        // PUT: api/Cities/5
        [HttpPut("{id}")]
        public async Task<ActionResult<City>> PutCity(int id, UpdateCityDto updateCityDto)
        {
            return await _cityRepository.UpdateAsync<UpdateCityDto>(id, updateCityDto);
        }

        // POST: api/Cities
        [HttpPost]
        public async Task<ActionResult<CreateCityDto>> PostCity(CreateCityDto createCityDto)
        {
            return await _cityRepository.AddAsync<CreateCityDto,CreateCityDto>(createCityDto);
        }

        // DELETE: api/Cities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            await _cityRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CityExists(int id)
        {
            return await _cityRepository.Exists(id);
        }
    }
}
