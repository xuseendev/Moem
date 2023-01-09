using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MoeSystem.Server.Contracts;
using MoeSystem.Server.Data;
using MoeSystem.Shared.Models.User;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MoeSystem.Server.Repository
{
    public class AuthManager : IAuthManger
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User _user;
        private static string _loginProvider = "MOEAPI";
        private static string _refreshToken = "RefreshToken";
        private readonly RoleManager<IdentityRole> roleManager;
        public AuthManager(IMapper mapper, UserManager<User> userManager, IConfiguration configuration, RoleManager<IdentityRole> roleManager)
        {
            this._mapper = mapper;
            this._userManager = userManager;
            this._configuration = configuration;
            this.roleManager = roleManager;
        }

        public async Task<string> CreateRefreshToken()
        {
            await _userManager.RemoveAuthenticationTokenAsync(_user, _loginProvider, _refreshToken);
            var newRefreshToken = await _userManager.GenerateUserTokenAsync(_user, _loginProvider, _refreshToken);
            var result = await _userManager.SetAuthenticationTokenAsync(_user, _loginProvider, _refreshToken, newRefreshToken);
            return newRefreshToken;
        }

        public async Task<string> GenerateToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

            var roles = await _userManager.GetRolesAsync(_user);

            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList();
            var userClaims = await _userManager.GetClaimsAsync(_user);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub,_user.Email),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email,_user.Email),
                new Claim(JwtRegisteredClaimNames.Name,_user.FirstName),
                new Claim("userGroup",_user.UserGroupId.ToString()),
                new Claim("uid",_user.Id),
            }.Union(userClaims).Union(roleClaims);

            var token = new JwtSecurityToken(
               issuer: _configuration["JwtSettings:Issuer"],
               audience: _configuration["JwtSettings:Audience"],
               claims: claims,
               expires: DateTime.Now.AddHours(Convert.ToInt32(_configuration["JwtSettings:DurationInMinutes"])),
               signingCredentials: credentials

                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        public async Task<AuthResponseDto> Login(LoginDto loginDto)
        {
            _user = await _userManager.FindByEmailAsync(loginDto.Email);
            var isValidUser = await _userManager.CheckPasswordAsync(_user, loginDto.Password);

            if (_user == null || isValidUser == false)
            {
                return null;
            }
            return new AuthResponseDto { Token = await GenerateToken(), RefreshToken = await CreateRefreshToken() };

        }

        public async Task<IEnumerable<IdentityError>> Register(ApiUserDto userDto)
        {
            _user = _mapper.Map<User>(userDto);
            _user.UserName = userDto.Email;

            var result = await _userManager.CreateAsync(_user, userDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(_user, "User");
            }
            return result.Errors;

        }

        public async Task<AuthResponseDto> VerifyRefreshToken(AuthResponseDto request)
        {
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenContent = jwtSecurityTokenHandler.ReadJwtToken(request.Token);
            var username = tokenContent.Claims.ToList().FirstOrDefault(q => q.Type == JwtRegisteredClaimNames.Email)?.Value;
            _user = await _userManager.FindByEmailAsync(username);

            if (_user == null)
            {
                return null;

            }
            var isValidRefreshToken = await _userManager.VerifyUserTokenAsync(_user, _loginProvider, _refreshToken, request.RefreshToken);

            if (isValidRefreshToken)
            {
                var token = await GenerateToken();
                return new AuthResponseDto
                {
                    Token = token,
                    RefreshToken = await CreateRefreshToken()
                };
            }
            await _userManager.UpdateSecurityStampAsync(_user);
            return null;
        }

        public async Task<User> GetById(string id)
        {
            return await _userManager.FindByIdAsync(id);

        }

        public async Task<UserDto> GetUser(string id)
        {
            return _mapper.Map<UserDto>(await _userManager.FindByIdAsync(id));

        }

        public List<string> GetUserByRoles(User user)
        {
            return _userManager.GetRolesAsync(user).Result.ToList();

        }

        public async Task<User> AddToRolesAsync(string id, string role)
        {
            var user = await GetById(id);
            await _userManager.AddToRoleAsync(user, role);
            return user;
        }

        public async Task<List<UserDto>> GetUsers()
        {
            return _mapper.Map<List<UserDto>>(await _userManager.Users.ToListAsync());
        }

        public async Task<List<IdentityRole>> GetRoles()
        {
            return await roleManager.Roles.ToListAsync();
        }

        public async Task<UserDto> DeactivateUser(string id)
        {
            var user = await GetById(id);

            user.LockoutEnd = DateTime.Now;
            user.LockoutEnabled = !user.LockoutEnabled;
            await _userManager.UpdateAsync(user);
            return _mapper.Map<UserDto>(user);
        }

        public async Task DeleteUserRoles(string id, string name)
        {
            var user = await GetById(id);
            await _userManager.RemoveFromRoleAsync(user, name);
        }

        public async Task<List<string>> GetUserRoles(string userId)
        {
            var user = await GetById(userId);
            return _userManager.GetRolesAsync(user).Result.ToList();
        }
    }
}
