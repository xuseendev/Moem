using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models;
using MoeSystem.Shared.Models.UserGroup;

namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    [Authorize]
    public class UserGroupsController : ControllerBase
    {
        private readonly IGenericRepository<UserGroup> _userGroupRepository;

        public UserGroupsController(IGenericRepository<UserGroup> userGroupRepository)
        {
            _userGroupRepository = userGroupRepository;
        }

        // GET: api/UserGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGroupDto>>> GetUserGroups()
        {
            return await _userGroupRepository.GetAllAsync<UserGroupDto>();
        }
        [HttpGet("LookUp")]
        public async Task<ActionResult<IEnumerable<BaseLookUpDto>>> LookUp()
        {
            return await _userGroupRepository.GetAllAsync<BaseLookUpDto>();
        }

        // GET: api/UserGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGroupDto>> GetUserGroup(int id)
        {
            return await _userGroupRepository.GetAsync<UserGroupDto>(id);
        }

        // PUT: api/UserGroups/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserGroup>> PutUserGroup(int id, UpdateUserGroupDto updateUserGroupDto)
        {
            return await _userGroupRepository.UpdateAsync<UpdateUserGroupDto>(id, updateUserGroupDto, HttpContext);
        }

        // POST: api/UserGroups
        [HttpPost]
        public async Task<ActionResult<UserGroup>> PostUserGroup(CreateUserGroupDto createUserGroupDto)
        {
            return await _userGroupRepository.AddAsync<CreateUserGroupDto, UserGroup>(createUserGroupDto, HttpContext);
        }

        // DELETE: api/UserGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserGroup(int id)
        {
            await _userGroupRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> UserGroupExists(int id)
        {
            return await _userGroupRepository.Exists(id);
        }
    }
}
