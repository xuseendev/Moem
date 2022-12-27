using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models;
using MoeSystem.Shared.Models.MineralTypes;
using Microsoft.AspNetCore.Authorization;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class MineralTypesController : ControllerBase
    {
        private readonly IGenericRepository<MineralType> _mineralTypeRepository;

        public MineralTypesController(IGenericRepository<MineralType> mineralTypeRepository)
        {
            _mineralTypeRepository = mineralTypeRepository;
        }

        // GET: api/MineralTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MineralTypeDto>>> GetMineralTypes()
        {
            return await _mineralTypeRepository.GetAllAsync<MineralTypeDto>();
        }

        [HttpGet("LookUp")]
        public async Task<ActionResult<IEnumerable<BaseLookUpDto>>> LookUp()
        {
            return await _mineralTypeRepository.GetAllAsync<BaseLookUpDto>();
        }

        // GET: api/MineralTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MineralTypeDto>> GetMineralType(int id)
        {
            return await _mineralTypeRepository.GetAsync<MineralTypeDto>(id);
        }

        // PUT: api/MineralTypes/5
        [HttpPut("{id}")]
        public async Task<ActionResult<MineralType>> PutMineralType(int id, UpdateMineralTypeDto updateMineralTypeDto)
        {
            return await _mineralTypeRepository.UpdateAsync<UpdateMineralTypeDto>(id, updateMineralTypeDto, HttpContext);
        }

        // POST: api/MineralTypes
        [HttpPost]
        public async Task<ActionResult<MineralType>> PostMineralType(CreateMineralTypeDto createMineralTypeDto)
        {
            return await _mineralTypeRepository.AddAsync<CreateMineralTypeDto, MineralType>(createMineralTypeDto, HttpContext);
        }

        // DELETE: api/MineralTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMineralType(int id)
        {
            await _mineralTypeRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> MineralTypeExists(int id)
        {
            return await _mineralTypeRepository.Exists(id);
        }
    }
}
