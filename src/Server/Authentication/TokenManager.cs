using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Server.Data;
using Server.Data.Entities;
using Server.Settings;
using Shared.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Server.Authentication
{
    public class TokenManager
    {
        private readonly SpotifySettings _spotifySettings;
        private readonly JamContext _context;

        public TokenManager(JamContext context, IOptions<SpotifySettings> spotifyOptions)
        {
            _spotifySettings = spotifyOptions.Value;
            _context = context;
        }

        public async Task<Token> GenerateToken(string code)
        {
            using var httpClient = new HttpClient();

            var body = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "code", code },
                { "redirect_uri", _spotifySettings.RedirectUri },
                { "client_id", _spotifySettings.ClientId },
                { "client_secret", _spotifySettings.ClientSecret }
            });
            body.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var response = await httpClient.PostAsync("https://accounts.spotify.com/api/token", body);

            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            var spotifyToken = JsonConvert.DeserializeObject<SpotifyToken>(content);
            var token = new Token { Value = spotifyToken.Access_Token, Expiry = spotifyToken.Expires_On };

            _context.UserTokens.Add(new UserToken { ExpiresOn = token.Expiry, Value = token.Value });
            await _context.SaveChangesAsync();

            return token;
        }

        public bool VerifyToken(string token)
        {
            return _context.UserTokens.Any(x => x.Value == token && x.ExpiresOn > DateTime.UtcNow);
        }
    }
}
