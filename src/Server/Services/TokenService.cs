using Server.Authentication;
using System;

namespace Server.Services
{
    public class TokenService
    {
        public string Token { get; private set; }
        public DateTime? ExpiresOn { get; private set; }

        public bool IsExpired() => DateTime.UtcNow > ExpiresOn;

        public void SetToken(SpotifyTokenResponse response)
        {
            Token = response.Access_Token;
            ExpiresOn = DateTime.UtcNow.AddSeconds(response.Expires_In - 60);
        }
    }
}
