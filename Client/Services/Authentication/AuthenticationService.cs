using Blazored.LocalStorage;
using MoeSystem.Client.Providers;
using MoeSystem.Client.Services.Authentication;
using MoeSystem.Client.Services.Base;
using Microsoft.AspNetCore.Components.Authorization;


namespace MoeSystem.Client.Services.Authentication
{
    public class AuthenticationService : BaseHttpService, IAuthenticationService
    {
        private readonly IClient _client;
        private readonly ILocalStorageService localStorage;
        private readonly AuthenticationStateProvider authenticationStateProvider;

        public AuthenticationService(IClient client, ILocalStorageService localStorage, AuthenticationStateProvider authenticationStateProvider) : base(client, localStorage)
        {
            this._client = client;
            this.localStorage = localStorage;
            this.authenticationStateProvider = authenticationStateProvider;
        }
        public async Task<bool> AuthenticateAsync(LoginDto loginModel)
        {
            try
            {
                //await Task.Delay(5000);
                var response = await _client.LoginAsync(loginModel);

                //Store Token
                await localStorage.SetItemAsync("accessToken", response.Token);
                await localStorage.SetItemAsync("refreshToken", response.RefreshToken);

                //Change auth state of app
                await ((ApiAuthenticationStateProvider)authenticationStateProvider).LoggedIn();
                return true;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> RefreshToken()
        {
            var token = await localStorage.GetItemAsync<string>("accessToken");
            var refreshToken = await localStorage.GetItemAsync<string>("refreshToken");
            var authResponseDto = new AuthResponseDto { Token = token, RefreshToken = refreshToken };
            var response = await _client.RefreshtokenAsync(authResponseDto);
            await localStorage.SetItemAsync("accessToken", response.Token);
            await localStorage.SetItemAsync("refreshToken", response.RefreshToken);
            return response.Token;

        }

        //public async Task<Response<List<ApplicationUser>>> GetAll()
        //{
        //    Response<List<ApplicationUser>> response;
        //    try
        //    {
        //        await GetBearerToken();
        //        var data = await _client.GetUsersAsync();

        //        response = new Response<List<ApplicationUser>>
        //        {
        //            Data = data.ToList(),
        //            Success = true
        //        };
        //    }
        //    catch (ApiException exception)
        //    {
        //        response = ConvertApiExceptions<List<ApplicationUser>>(exception);


        //    }
        //    return response;
        //}

        //public async Task<Response<List<IdentityRole>>> GetRoles()
        //{
        //    Response<List<IdentityRole>> response;
        //    try
        //    {
        //        await GetBearerToken();
        //        var data = await _client.GetRolesAsync();

        //        response = new Response<List<IdentityRole>>
        //        {
        //            Data = data.ToList(),
        //            Success = true
        //        };
        //    }
        //    catch (ApiException exception)
        //    {
        //        response = ConvertApiExceptions<List<IdentityRole>>(exception);


        //    }
        //    return response;
        //}

        //public async Task<Response<UserDto>> Create(UserDto userDto)
        //{
        //    Response<UserDto> response;
        //    try
        //    {
        //        await GetBearerToken();
        //        await _client.RegisterAsync(userDto);
        //        response = new Response<UserDto>
        //        {
        //            Success = true
        //        };

        //    }
        //    catch (ApiException exception)
        //    {

        //        response = ConvertApiExceptions<UserDto>(exception);
        //    }
        //    return response;
        //}

        //public async Task<Response<UserDto>> ResetPassword(string id,string newPassword)
        //{
        //    Response<UserDto> response;
        //    try
        //    {
        //        await GetBearerToken();
        //        await _client.ResetPasswordAsync(id,newPassword);
        //        response = new Response<UserDto>
        //        {
        //            Success = true
        //        };

        //    }
        //    catch (ApiException exception)
        //    {

        //        response = ConvertApiExceptions<UserDto>(exception);
        //    }
        //    return response;
        //}
        //public async Task<Response<ApplicationUser>> AddRole(string id,string role)
        //{
        //    Response<ApplicationUser> response;
        //    try
        //    {
        //        await GetBearerToken();
        //        await _client.AddRolesAsync(id,role);
        //        response = new Response<ApplicationUser>
        //        {
        //            Success = true
        //        };

        //    }
        //    catch (ApiException exception)
        //    {

        //        response = ConvertApiExceptions<ApplicationUser>(exception);
        //    }
        //    return response;
        //}
        //public async Task<Response<int>> DeleteRole(string userId,string role)
        //{
        //    Response<int> response;
        //    try
        //    {
        //        await GetBearerToken();
        //        await _client.DeleteRoleAsync(userId,role);
        //        response = new Response<int>
        //        {
        //            Success = true
        //        };

        //    }
        //    catch (ApiException exception)
        //    {

        //        response = ConvertApiExceptions<int>(exception);
        //    }
        //    return response;
        //}
        //public async Task<Response<int>> DeactivateOrActivateUser(string userId)
        //{
        //    Response<int> response;
        //    try
        //    {
        //        await GetBearerToken();
        //        await _client.DeactivateOrActivateUserAsync(userId);
        //        response = new Response<int>
        //        {
        //            Success = true
        //        };

        //    }
        //    catch (ApiException exception)
        //    {

        //        response = ConvertApiExceptions<int>(exception);
        //    }
        //    return response;
        //}

        //public async Task<Response<ApplicationUser>> GetDetails(string id)
        //{
        //    Response<ApplicationUser> response;
        //    try
        //    {

        //        await GetBearerToken();
        //        var data = await _client.GetDetailAsync(id);

        //        response = new Response<ApplicationUser>
        //        {
        //            Data = data,
        //            Success = true
        //        };
        //    }
        //    catch (ApiException exception)
        //    {
        //        response = ConvertApiExceptions<ApplicationUser>(exception);


        //    }
        //    return response;
        //}



        public async Task Logout()
        {
            await localStorage.RemoveItemAsync("accessToken");
            await localStorage.RemoveItemAsync("refreshToken");
            await ((ApiAuthenticationStateProvider)authenticationStateProvider).LoggedOut();
        }
    }
}
