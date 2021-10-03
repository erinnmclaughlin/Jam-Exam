using Refit;

namespace Spotify.Authentication
{
    public class TokenRequest
    {
        [AliasAs("grant_type")]
        public string GrantType { get; } = "client_credentials";
    }
}
