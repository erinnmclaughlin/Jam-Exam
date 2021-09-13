using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Refit;
using Server.Data;
using Server.Data.Entities;
using Server.Settings;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Server.Authentication
{
    public class TokenManager
    {
        private readonly ISpotifyApi _api;
        private readonly JamContext _context;
        private readonly JwtSettings _jwtSettings;
        private readonly SpotifySettings _spotifySettings;

        public TokenManager(ISpotifyApi api, JamContext context, IOptions<JwtSettings> jwtOptions, IOptions<SpotifySettings> spotifyOptions)
        {
            _api = api;
            _context = context;
            _jwtSettings = jwtOptions.Value;
            _spotifySettings = spotifyOptions.Value;
        }

        public async Task<string> LoginUser(string code)
        {
            var body = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "code", code },
                { "redirect_uri", _spotifySettings.RedirectUri },
                { "client_id", _spotifySettings.ClientId },
                { "client_secret", _spotifySettings.ClientSecret }
            });
            body.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync("https://accounts.spotify.com/api/token", body);

            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            var spotifyToken = JsonConvert.DeserializeObject<SpotifyToken>(content);
            var user = await GetCurrentUser(spotifyToken.Access_Token);

            _context.UserTokens.Add(new UserToken { ExpiresOn = spotifyToken.Expires_On, Value = spotifyToken.Access_Token, RefreshToken = spotifyToken.Refresh_Token, UserId = user.Id });
            await _context.SaveChangesAsync();

            return GenerateToken(spotifyToken, user);
        }

        public async Task<bool> VerifyToken(string token)
        {
            token = token.Replace("Bearer ", "");
            var claims = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;
            var spotifyToken = claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication)?.Value;
            var userId = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            var userToken = _context.UserTokens.FirstOrDefault(x => x.UserId.ToString() == userId && x.Value == spotifyToken);

            if (userToken is null)
                return false;

            if (DateTime.UtcNow < userToken.ExpiresOn)
                return true;

            var result = await RefreshToken(userToken);
            return result != null;

        }

        private string GenerateToken(SpotifyToken spotifyToken, User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.DisplayName),
                new Claim(JwtRegisteredClaimNames.Exp, spotifyToken.Expires_On.ToString()),
                new Claim(ClaimTypes.Authentication, spotifyToken.Access_Token)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(new JwtHeader(signingCredentials), new JwtPayload(claims));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<SpotifyToken> RefreshToken(UserToken userToken)
        {
            var body = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "refresh_token" },
                { "refresh_token", userToken.RefreshToken }
            });
            body.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync("https://accounts.spotify.com/api/token", body);

            if (!response.IsSuccessStatusCode)
                return null;

            var content = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<SpotifyToken>(content);

            _context.UserTokens.Add(new UserToken
            {
                ExpiresOn = token.Expires_On,
                RefreshToken = userToken.RefreshToken,
                UserId = userToken.UserId,
                Value = token.Access_Token
            });

            await _context.SaveChangesAsync();

            return token;
        }

        private async Task<User> GetCurrentUser(string token)
        {
            Console.WriteLine("Getting current user...");
            Console.WriteLine(token);

            try
            {
                var spotifyUser = await _api.GetCurrentUser(token);
                var user = await _context.Users.FirstOrDefaultAsync(x => x.SpotifyUserId == spotifyUser.Id);

                if (user is null)
                {
                    user = new User
                    {
                        DisplayName = spotifyUser.Display_Name,
                        SpotifyUserId = spotifyUser.Id
                    };

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();
                }

                return user;
            }
            catch (ApiException ex)
            {
                Console.WriteLine(ex.Content);
                return null;
            }
        }
    }
}
