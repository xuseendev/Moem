using MoeSystem.Client.Services.Base;

namespace MoeSystem.Client.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> AuthenticateAsync(LoginDto loginModel);
        Task<string> RefreshToken();
        //Task<Response<List<ApplicationUser>>> GetAll();
        //Task<Response<List<IdentityRole>>> GetRoles();
        //Task<Response<UserDto>> Create(UserDto create);
        //Task<Response<UserDto>> ResetPassword(string id,string newPassword);
        //Task<Response<ApplicationUser>> AddRole(string id,string roleName);
        //Task<Response<ApplicationUser>> GetDetails(string id);
        //Task<Response<int>> DeleteRole(string userId,string name);
        //Task<Response<int>> DeactivateOrActivateUser(string userId);
        public Task Logout();

    }
}
