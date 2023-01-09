using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models.User;


namespace MoeSystem.Server.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0", Deprecated = true)]
    public class AccountController : ControllerBase
    {
        private readonly IAuthManger _authManger;
        private readonly ILogger<AccountController> _logger;

        public AccountController(IAuthManger authManger, ILogger<AccountController> logger)
        {
            this._authManger = authManger;
            this._logger = logger;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register([FromBody] ApiUserDto apiUserDto)
        {
            _logger.LogInformation($"Registeration attempt for {apiUserDto.Email}");

            var errors = await _authManger.Register(apiUserDto);

            if (errors.Any())
            {
                foreach (var error in errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok();



        }
        [HttpPost]
        [Route("login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginDto loginDto)
        {

            var authResponse = await _authManger.Login(loginDto);

            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);



        }

        [HttpPost]
        [Route("refreshtoken")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> RefreshToken([FromBody] AuthResponseDto request)
        {
            var authResponse = await _authManger.VerifyRefreshToken(request);

            if (authResponse == null)
            {
                return Unauthorized();
            }

            return Ok(authResponse);
        }


        [HttpGet("getDetail/{id}")]
        public async Task<ActionResult<User>> GetDetail(string id)
        {
            return await _authManger.GetById(id);
        }
        [HttpGet("AddRoles/{id}")]
        public async Task<ActionResult<User>> AddRoles(string id, string role)
        {
            return await _authManger.AddToRolesAsync(id, role);

        }

        // [HttpPost("ResetPassword/{id}")]
        // public async Task<ActionResult<User>> ResetPassword(string id,string password)
        // {
        //     try
        //     {
        //         var user = await _userManager.FindByIdAsync(id);
        //         if (user == null) return NotFound();
        //         var hasher = new PasswordHasher<ApplicationUser>();
        //         var newPassword = hasher.HashPassword(user,password);
        //         user.PasswordHash = newPassword;
        //         var res = await _userManager.UpdateAsync(user);
        //         if (!res.Succeeded) return BadRequest(res.Errors);

        //         return Ok(user);
        //     }
        //     catch (Exception ex)
        //     {

        //         return BadRequest(ex.Message);
        //     }
        // }

        [HttpGet("GetUsers")]
        public async Task<ActionResult<List<UserDto>>> GetUsers()
        {
            return await _authManger.GetUsers();
        }

        [HttpGet("GetRoles")]
        public async Task<ActionResult<List<IdentityRole>>> GetRoles()
        {
            return await _authManger.GetRoles();

        }

        [HttpGet("GetUserRoles/{userId}")]
        public async Task<ActionResult<List<string>>> GetUserRoles(string userId)
        {
            return await _authManger.GetUserRoles(userId);

        }


        [HttpPut("DeactivateOrActivateUser/{id}")]
        public async Task<ActionResult<UserDto>> DeactivateUser(string id)
        {
            return await _authManger.DeactivateUser(id);
        }

        [HttpDelete("DeleteRole/{userId}")]
        public async Task<ActionResult> DeleteRole(string userId, string name)
        {
            await _authManger.DeleteUserRoles(userId, name);
            return Ok();
        }
    }
}
