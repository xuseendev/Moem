using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MoeSystem.Server.Extensions
{
    public static class ClaimsPrincipleExtentions
    {
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Email)?.Value;
        }

        public static int GetUserId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
        }
        public static string GetId(this ClaimsPrincipal user)
        {
            return user.FindFirst("sid")?.Value;
        }


        public static string GetUserEmail(this ClaimsPrincipal user)
        {
            return user.FindFirst(JwtRegisteredClaimNames.Email)?.Value;
        }
        public static int GetUserGroupId(this ClaimsPrincipal user)
        {
            return int.Parse(user.FindFirst("userGroup")?.Value);
        }
    }
}
