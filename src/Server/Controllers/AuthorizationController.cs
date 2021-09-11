using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Server.Authentication;
using Server.Services;
using Shared.Authentication;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly SpotifyOptions _config;
        private readonly TokenService _tokenService;

        public AuthorizationController(IOptions<SpotifyOptions> options, TokenService tokenService)
        {
            _config = options.Value;
            _tokenService = tokenService;
        }

        [HttpGet, Route("api/authorize-url")]
        public IActionResult GetAuthorizationUrl()
        {
            var uri = "https://accounts.spotify.com/authorize";
            uri = QueryHelpers.AddQueryString(uri, new Dictionary<string, string>
            {
                { "client_id", _config.ClientId },
                { "response_type", SpotifyOptions.ResponseType },
                { "redirect_uri", _config.RedirectUri },
                { "scope", SpotifyOptions.Scope }
            });
            return Ok(new AuthorizationUrl { Url = uri });
        }

        [HttpGet, Route("api/token")]
        public async Task<IActionResult> GetAccessToken([FromQuery] string code)
        {
            using var httpClient = new HttpClient();

            var body = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "authorization_code" },
                { "code", code },
                { "redirect_uri", _config.RedirectUri },
                { "client_id", _config.ClientId },
                { "client_secret", _config.ClientSecret }
            });
            body.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");

            var response = await httpClient.PostAsync("https://accounts.spotify.com/api/token", body);
            var content = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                return BadRequest(content);

            var tokenResponse = JsonConvert.DeserializeObject<SpotifyTokenResponse>(content);
            _tokenService.SetToken(tokenResponse);

            return Ok(new TokenResponse { Token = _tokenService.Token, ExpiresOn = _tokenService.ExpiresOn.Value });
        }
    }
}
