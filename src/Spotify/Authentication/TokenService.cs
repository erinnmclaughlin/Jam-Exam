using Microsoft.Extensions.Options;
using Spotify.Extensions;
using Spotify.Settings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spotify.Authentication
{
    internal class TokenService
    {
        private readonly ISpotifyAuthClient _api;
        private readonly SpotifySettings _settings;

        private TokenResponse? _currentToken;

        public TokenService(ISpotifyAuthClient api, IOptions<SpotifySettings> spotifyOptions)
        {
            _api = api;
            _settings = spotifyOptions.Value;
        }

        public async Task<TokenResponse> GetTokenAsync()
        {
            if (_currentToken?.IsExpired != false)
                _currentToken = await RequestNewTokenAsync();

            return _currentToken;
        }

        private async Task<TokenResponse> RequestNewTokenAsync()
        {
            var base64 = $"{_settings.ClientId}:{_settings.ClientSecret}".EncodeBase64();
            var headers = new Dictionary<string, string>
            {
                { "Authorization", $"Basic {base64}" }
            };

            var response = await _api.RequestToken(new TokenRequest(), headers);
            return response.Content!;
        }
    }
}
