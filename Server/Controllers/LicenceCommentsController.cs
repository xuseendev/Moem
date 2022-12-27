using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models.LicenceComment;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Authorization;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class LicenceCommentsController : ControllerBase
    {
        private readonly IGenericRepository<LicenceComments> _licenceCommentRepository;

        public LicenceCommentsController(IGenericRepository<LicenceComments> licenceCommentRepository)
        {
            _licenceCommentRepository = licenceCommentRepository;
        }

        // GET: api/LicenceComments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LicenceCommentDto>>> GetLicenceComments()
        {
            return await _licenceCommentRepository.GetAllAsync<LicenceCommentDto>();
        }

        // GET: api/LicenceComments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LicenceCommentDto>> GetLicenceComments(int id)
        {
            return await _licenceCommentRepository.GetAsync<LicenceCommentDto>(id);
        }

        // PUT: api/LicenceComments/5
        [HttpPut]
        public async Task<ActionResult<LicenceComments>> PutLicenceComments(int id, UpdateLicenceCommentDto updateLicenceCommentDto)
        {
            return await _licenceCommentRepository.UpdateAsync<UpdateLicenceCommentDto>(id, updateLicenceCommentDto, HttpContext);
        }

        // POST: api/LicenceComments
        [HttpPost]
        public async Task<ActionResult<LicenceComments>> PostLicenceComments(CreateLicenceCommentDto createLicenceCommentDto)
        {
            return await _licenceCommentRepository.AddAsync<CreateLicenceCommentDto, LicenceComments>(createLicenceCommentDto, HttpContext);
        }

        // DELETE: api/LicenceComments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLicenceComments(int id)
        {
            await _licenceCommentRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> LicenceCommentsExists(int id)
        {
            return await _licenceCommentRepository.Exists(id);
        }
    }
}
