using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models.Workflow;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class WorkFlowsController : ControllerBase
    {
        private readonly IGenericRepository<WorkFlow> _workFlowRepository;

        public WorkFlowsController(IGenericRepository<WorkFlow> workFlowRepository)
        {
            _workFlowRepository = workFlowRepository;
        }

        // GET: api/WorkFlows
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WorkFlowDto>>> GetWorkFlow()
        {
            return await _workFlowRepository.GetAllAsync<WorkFlowDto>();
        }

        // GET: api/WorkFlows/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WorkFlowDto>> GetWorkFlow(int id)
        {
            return await _workFlowRepository.GetAsync<WorkFlowDto>(id);
        }

        // PUT: api/WorkFlows/5
        [HttpPut("{id}")]
        public async Task<ActionResult<WorkFlow>> PutWorkFlow(int id, UpdateWorkFlowDto updateWorkFlowDto)
        {
            return await _workFlowRepository.UpdateAsync(id, updateWorkFlowDto);
        }

        // POST: api/WorkFlows
        [HttpPost]
        public async Task<ActionResult<WorkFlow>> PostWorkFlow(CreateWorkFlowDto createWorkFlowDto)
        {
            return await _workFlowRepository.AddAsync<CreateWorkFlowDto,WorkFlow>(createWorkFlowDto);
        }

        // DELETE: api/WorkFlows/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkFlow(int id)
        {
            await _workFlowRepository.DeleteAsync(id);  

            return NoContent();
        }

        private async Task<bool> WorkFlowExists(int id)
        {
            return await _workFlowRepository.Exists(id);
        }
    }
}
