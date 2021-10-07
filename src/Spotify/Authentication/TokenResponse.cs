using System;
using System.Text.Json.Serialization;

namespace Spotify.Authentication
{
    internal class TokenResponse
    {
        private DateTime _expiresOn;

        [JsonPropertyName("expires_in")]
        public double Expires_In
        {
            get => (_expiresOn - DateTime.UtcNow).TotalSeconds;
            set => _expiresOn = DateTime.UtcNow.AddSeconds(value);
        }

        public bool IsExpired => Expires_In < 0;

        [JsonPropertyName("access_token")]
        public string Value { get; set; } = null!;

    }
}
