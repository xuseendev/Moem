using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models;
using MoeSystem.Shared.Models.CompanyDocument;
using MoeSystem.Shared.Models.LicenceDocument;
using Microsoft.AspNetCore.Authorization;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class LicenceDocumentsController : ControllerBase
    {
        private readonly IGenericRepository<LicenceDocument> _licenceDocumentRepository;

        public LicenceDocumentsController(IGenericRepository<LicenceDocument> licenceDocumentRepository)
        {
            _licenceDocumentRepository = licenceDocumentRepository;
        }

        // GET: api/CompanyDocuments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LicenceDocumentDto>>> GetCompanyDocuments()
        {
            return await _licenceDocumentRepository.GetAllAsync<LicenceDocumentDto>();
        }
        [HttpGet("LookUp")]
        public async Task<ActionResult<IEnumerable<BaseLookUpDto>>> LookUp()
        {
            return await _licenceDocumentRepository.GetAllAsync<BaseLookUpDto>();
        }

        // GET: api/CompanyDocuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LicenceDocumentDetailDto>> GetCompanyDocument(int id)
        {
            return await _licenceDocumentRepository.GetAsync<LicenceDocumentDetailDto>(id);
        }

        // PUT: api/CompanyDocuments/5
        [HttpPut("{id}")]
        public async Task<ActionResult<LicenceDocument>> PutCompanyDocument(int id, UpdateLicenceDocumentDto updateCompanyDocumentDto)
        {
            return await _licenceDocumentRepository.UpdateAsync<UpdateLicenceDocumentDto>(id, updateCompanyDocumentDto);
        }

        // POST: api/CompanyDocuments
        [HttpPost]
        public async Task<ActionResult<LicenceDocument>> PostCompanyDocument(CreateLicenceDocumentDto createCompanyDocumentDto)
        {
            return await _licenceDocumentRepository.AddAsync<CreateLicenceDocumentDto, LicenceDocument>(createCompanyDocumentDto);
        }

        // DELETE: api/CompanyDocuments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyDocument(int id)
        {
             await _licenceDocumentRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> CompanyDocumentExists(int id)
        {
            return await _licenceDocumentRepository.Exists(id);
        }
    }
}
