using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Server.Data;
using Server.Data.Entities;
using Server.Models;
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
        private readonly JamContext _context;
        private readonly HttpClient _httpClient;
        private readonly JwtSettings _jwtSettings;
        private readonly SpotifySettings _spotifySettings;

        public TokenManager(JamContext context, IHttpClientFactory httpClientFactory, IOptions<JwtSettings> jwtOptions, IOptions<SpotifySettings> spotifyOptions)
        {
            _context = context;
            _httpClient = httpClientFactory.CreateClient("Spotify");
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

            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", spotifyToken.Access_Token);

            var user = await GetCurrentUser();

            _context.UserTokens.Add(new UserToken { ExpiresOn = spotifyToken.Expires_On, Value = spotifyToken.Access_Token, UserId = user.Id });
            await _context.SaveChangesAsync();

            return GenerateToken(spotifyToken, user);
        }

        public bool VerifyToken(string token)
        {
            token = token.Replace("Bearer ", "");
            var claims = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;
            var spotifyToken = claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication)?.Value;
            var userId = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            return _context.UserTokens.Any(x => x.UserId.ToString() == userId && x.Value == spotifyToken && x.ExpiresOn > DateTime.UtcNow);
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

        private async Task<User> GetCurrentUser()
        {            
            var response = await _httpClient.GetAsync("me");
            var content = await response.Content.ReadAsStringAsync();
            var spotifyUser = JsonConvert.DeserializeObject<SpotifyUserModel>(content);
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
    }
}
