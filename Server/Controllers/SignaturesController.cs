
using Microsoft.AspNetCore.Mvc;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models;
using MoeSystem.Shared.Models.Signature;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    //[Authorize]
    public class SignaturesController : ControllerBase
    {
        private readonly IGenericRepository<Signature> _signatureRepository;

        public SignaturesController(IGenericRepository<Signature> signatureRepository)
        {
            _signatureRepository = signatureRepository;
        }

        // GET: api/LicenceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SignatureDto>>> GetSignatures()
        {
            return await _signatureRepository.GetAllAsync<SignatureDto>();
        }
        [HttpGet("LookUp")]
        public async Task<ActionResult<IEnumerable<BaseLookUpDto>>> LookUp()
        {
            return await _signatureRepository.GetAllAsync<BaseLookUpDto>();
        }

        // GET: api/LicenceTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SignatureDto>> GetSignature(int id)
        {
            return await _signatureRepository.GetAsync<SignatureDto>(id);
        }

        [HttpGet("Details/{id}")]
        public async Task<ActionResult<SignatureDetailDto>> Details(int id)
        {
            return await _signatureRepository.GetAsync<SignatureDetailDto>(id);
        }

        // PUT: api/LicenceTypes/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Signature>> PutSignature(int id, CreateUpdateSignatureDto updateSignatureDto)
        {
            return await _signatureRepository.UpdateAsync<CreateUpdateSignatureDto>(id, updateSignatureDto, HttpContext);
        }

        // POST: api/LicenceTypes
        [HttpPost]
        public async Task<ActionResult<Signature>> PostSignature(CreateUpdateSignatureDto createUpdateSignatureDto)
        {
            return await _signatureRepository.AddAsync<CreateUpdateSignatureDto, Signature>(createUpdateSignatureDto, HttpContext);
        }

        // DELETE: api/LicenceTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSignature(int id)
        {
            await _signatureRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> SignatureExists(int id)
        {
            return await _signatureRepository.Exists(id);
        }
    }
}