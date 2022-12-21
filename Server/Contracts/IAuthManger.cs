
using Microsoft.AspNetCore.Identity;
using MoeSystem.Shared.Models.User;

namespace MoeSystem.Server.Contracts
{
    public interface IAuthManger
    {
        public Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto);
        public Task<AuthResponseDto> Login(LoginDto loginDto);
        Task<string> CreateRefreshToken();
        Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request);


    }
}
