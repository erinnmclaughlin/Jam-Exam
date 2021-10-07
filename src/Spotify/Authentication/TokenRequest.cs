using Refit;

namespace Spotify.Authentication
{
    internal class TokenRequest
    {
        [AliasAs("grant_type")]
        public string GrantType { get; } = "client_credentials";
    }
}
