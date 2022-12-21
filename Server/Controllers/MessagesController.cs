using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models.Messages;
using Microsoft.AspNetCore.Authorization;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class MessagesController : ControllerBase
    {
        private readonly IGenericRepository<Messages> _messageRepository;

        public MessagesController(IGenericRepository<Messages> messageRepository)
        {
            _messageRepository = messageRepository;
        }

        // GET: api/Messages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageDto>>> GetMessages()
        {
            return await _messageRepository.GetAllAsync<MessageDto>();
        }

        // GET: api/Messages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageDto>> GetMessages(int id)
        {
            return await _messageRepository.GetAsync<MessageDto>(id);
        }

        // PUT: api/Messages/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Messages>> PutMessages(int id, UpdateMessageDto updateMessageDto)
        {
            return await _messageRepository.UpdateAsync<UpdateMessageDto>(id, updateMessageDto);
        }

        // POST: api/Messages

        [HttpPost]
        public async Task<ActionResult<Messages>> PostMessages(CreateMessageDto createMessageDto)
        {
            return await _messageRepository.AddAsync<CreateMessageDto,Messages>(createMessageDto);
        }

        // DELETE: api/Messages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessages(int id)
        {
            await _messageRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> MessagesExists(int id)
        {
            return await _messageRepository.Exists(id);
        }
    }
}
