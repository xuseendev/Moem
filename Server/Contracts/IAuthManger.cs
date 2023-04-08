
using Microsoft.AspNetCore.Identity;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models.User;


namespace MoeSystem.Server.Contracts
{
    public interface IAuthManger
    {
        Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
        Task<AuthResponseDto> Login(LoginDto loginDto);
        Task<string> CreateRefreshToken();
        Task<User> GetById(string id);
        Task<UserDto> GetUser(string id);
        List<string> GetUserByRoles(User user);
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);
        Task<CreateRoleDto> AddToRolesAsync(CreateRoleDto role);
        Task<ResetPasswordDto> ResetPassword(string id, ResetPasswordDto resetPassword);
        Task<List<UserDto>> GetUsers();
        Task<List<RolesDto>> GetRoles();
        Task<List<string>> GetUserRoles(string userId);
        Task<UserDto> DeactivateUser(string id);
        Task DeleteUserRoles(string id, string name);

        Task<bool> ChangePassword(ChangePasswordDto changePassword, string userId);
        Task<CreateUserRoleDto> AddUserRole(CreateUserRoleDto create);


    }
}
