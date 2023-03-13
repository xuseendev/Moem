using MoeSystem.Client.Providers;
using MoeSystem.Client.Services.Authentication;

namespace Client.Services.Authentication
{
    public class RefreshTokenService
    {
        private readonly ApiAuthenticationStateProvider _authProvider;
        private readonly IAuthenticationService _authService;
        public RefreshTokenService(ApiAuthenticationStateProvider authProvider, IAuthenticationService authService)
        {
            _authProvider = authProvider;
            _authService = authService;
        }
        public async Task<string> TryRefreshToken()
        {
            var authState = await _authProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var exp = user.FindFirst(c => c.Type.Equals("exp")).Value;
            var expTime = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(exp));
            var timeUTC = DateTime.UtcNow;
            var diff = expTime - timeUTC;
            if (diff.TotalMinutes <= 2)
                return await _authService.RefreshToken();
            return string.Empty;
        }
    }
}