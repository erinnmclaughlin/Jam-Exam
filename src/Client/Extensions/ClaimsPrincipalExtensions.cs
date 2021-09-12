using System.Security.Claims;

namespace Client.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetSpotifyToken(this ClaimsPrincipal user)
        {
            return user.FindFirst("SpotifyToken")?.Value;
        }
        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }

    }
}
