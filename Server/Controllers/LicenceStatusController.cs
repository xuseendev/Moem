using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models;
using MoeSystem.Shared.Models.LicenceStatus;
using Microsoft.AspNetCore.Authorization;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class LicenceStatusController : ControllerBase
    {
        private readonly IGenericRepository<LicenceStatus> _licenceStatusRepository;

        public LicenceStatusController(IGenericRepository<LicenceStatus> licenceStatusRepository)
        {
            _licenceStatusRepository = licenceStatusRepository;
        }

        // GET: api/LicenceStatus
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LicenceStatusDto>>> GetLicenceStatus()
        {
            return await _licenceStatusRepository.GetAllAsync<LicenceStatusDto>();
        }

        [HttpGet("LookUp")]
        public async Task<ActionResult<IEnumerable<BaseLookUpDto>>> LookUp()
        {
            return await _licenceStatusRepository.GetAllAsync<BaseLookUpDto>();
        }

        // GET: api/LicenceStatus/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LicenceStatusDto>> GetLicenceStatus(int id)
        {
            return await _licenceStatusRepository.GetAsync<LicenceStatusDto>(id);
        }

        // PUT: api/LicenceStatus/5
        [HttpPut("{id}")]
        public async Task<ActionResult<LicenceStatus>> PutLicenceStatus(int id, UpdateLicenceStatusDto updateLicenceStatusDto)
        {
            return await _licenceStatusRepository.UpdateAsync<UpdateLicenceStatusDto>(id, updateLicenceStatusDto);
        }

        // POST: api/LicenceStatus
        [HttpPost]
        public async Task<ActionResult<LicenceStatus>> PostLicenceStatus(CreateLicenceStatusDto createLicenceStatusDto)
        {

            return await _licenceStatusRepository.AddAsync<CreateLicenceStatusDto,LicenceStatus>(createLicenceStatusDto);
        }

        // DELETE: api/LicenceStatus/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLicenceStatus(int id)
        {
            await _licenceStatusRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> LicenceStatusExists(int id)
        {
            return await _licenceStatusRepository.Exists(id);
        }
    }
}
