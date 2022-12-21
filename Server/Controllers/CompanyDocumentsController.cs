using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models;
using MoeSystem.Shared.Models.CompanyDocument;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class CompanyDocumentsController : ControllerBase
    {
        private readonly IGenericRepository<CompanyDocument> _companyDocumentRepository;

        public CompanyDocumentsController(IGenericRepository<CompanyDocument> companyDocumentRepository)
        {
            _companyDocumentRepository = companyDocumentRepository;
        }

        // GET: api/CompanyDocuments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyDocumentDto>>> GetCompanyDocuments()
        {
            return await _companyDocumentRepository.GetAllAsync<CompanyDocumentDto>();
        }
        [HttpGet("LookUp")]
        public async Task<ActionResult<IEnumerable<BaseLookUpDto>>> LookUp()
        {
            return await _companyDocumentRepository.GetAllAsync<BaseLookUpDto>();
        }

        // GET: api/CompanyDocuments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyDocumentDetailDto>> GetCompanyDocument(int id)
        {
            return await _companyDocumentRepository.GetAsync<CompanyDocumentDetailDto>(id);
        }

        // PUT: api/CompanyDocuments/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CompanyDocument>> PutCompanyDocument(int id, UpdateCompanyDocumentDto updateCompanyDocumentDto)
        {
            return await _companyDocumentRepository.UpdateAsync<UpdateCompanyDocumentDto>(id, updateCompanyDocumentDto);
        }

        // POST: api/CompanyDocuments
        [HttpPost]
        public async Task<ActionResult<CompanyDocument>> PostCompanyDocument(CreateCompanyDocumentDto createCompanyDocumentDto)
        {
            return await _companyDocumentRepository.AddAsync<CreateCompanyDocumentDto,CompanyDocument>(createCompanyDocumentDto);
        }

        // DELETE: api/CompanyDocuments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCompanyDocument(int id)
        {
             await _companyDocumentRepository.DeleteAsync(id);
            return NoContent();
        }

        private async Task<bool> CompanyDocumentExists(int id)
        {
            return await _companyDocumentRepository.Exists(id);
        }
    }
}
