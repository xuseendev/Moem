using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models;
using MoeSystem.Shared.Models.Areas;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]

    public class AreasController : ControllerBase
    {
        private readonly IGenericRepository<Area> _genericRepository;

        public AreasController(IGenericRepository<Area> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        // GET: api/Areas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AreaDto>>> GetAreas()
        {
            return await _genericRepository.GetAllAsync<AreaDto>();
        }

        [HttpGet("LookUp/{id}")]
        public async Task<ActionResult<IEnumerable<BaseLookUpDto>>> LookUp(int id)
        {
            return await _genericRepository.GetAllAsync<BaseLookUpDto>(x => x.CityId == id);
        }

        [HttpGet("LookCheck/{id}")]
        public async Task<ActionResult<IEnumerable<BaseLookUpDto>>> LookCheck(int id)
        {
            return await _genericRepository.GetAllAsync<BaseLookUpDto>(x => x.CityId == id);
        }
        // GET: api/Areas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AreaDto>> GetArea(int id)
        {
            return await _genericRepository.GetAsync<AreaDto>(id);
        }

        // PUT: api/Areas/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Area>> PutArea(int id, UpdateAreaDto updateAreaDto)
        {

            return await _genericRepository.UpdateAsync<UpdateAreaDto>(id, updateAreaDto, HttpContext);
        }

        // POST: api/Areas
        [HttpPost]
        public async Task<ActionResult<Area>> PostArea(CreateAreaDto createAreaDto)
        {
            return await _genericRepository.AddAsync<CreateAreaDto, Area>(createAreaDto, HttpContext);
        }

        // DELETE: api/Areas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArea(int id)
        {
            await _genericRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> AreaExists(int id)
        {
            return await _genericRepository.Exists(id);
        }
    }
}
