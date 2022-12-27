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
using MoeSystem.Shared.Models.DocumentType;
using Microsoft.AspNetCore.Authorization;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class DocumentTypesController : ControllerBase
    {
        private readonly IGenericRepository<DocumentType> _documentTypeRepository;

        public DocumentTypesController(IGenericRepository<DocumentType> documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
        }

        // GET: api/DocumentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentTypeDto>>> GetDocumentTypes()
        {
            return await _documentTypeRepository.GetAllAsync<DocumentTypeDto>();
        }

        [HttpGet("LookUp")]
        public async Task<ActionResult<IEnumerable<BaseLookUpDto>>> LookUp()
        {
            return await _documentTypeRepository.GetAllAsync<BaseLookUpDto>();
        }

        // GET: api/DocumentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentTypeDto>> GetDocumentType(int id)
        {
            return await _documentTypeRepository.GetAsync<DocumentTypeDto>(id);
        }

        // PUT: api/DocumentTypes/5
        [HttpPut("{id}")]
        public async Task<ActionResult<DocumentType>> PutDocumentType(int id, UpdateDocumentTypeDto updateDocumentTypeDto)
        {
            return await _documentTypeRepository.UpdateAsync<UpdateDocumentTypeDto>(id, updateDocumentTypeDto, HttpContext);
        }

        // POST: api/DocumentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DocumentType>> PostDocumentType(CreateDocumentTypeDto createDocumentTypeDto)
        {
            return await _documentTypeRepository.AddAsync<CreateDocumentTypeDto, DocumentType>(createDocumentTypeDto, HttpContext);
        }

        // DELETE: api/DocumentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentType(int id)
        {
            await _documentTypeRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> DocumentTypeExists(int id)
        {
            return await _documentTypeRepository.Exists(id);
        }
    }
}
