﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Server.Authentication;
using Server.Settings;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly SpotifySettings _spotifySettings;
        private readonly TokenManager _tokenManager;

        public AuthorizationController(IOptions<SpotifySettings> options, TokenManager tokenManager)
        {
            _spotifySettings = options.Value;
            _tokenManager = tokenManager;
        }

        [HttpGet, Route("api/authorize-url")]
        public IActionResult GetAuthorizationUrl()
        {
            var uri = "https://accounts.spotify.com/authorize";
            uri = QueryHelpers.AddQueryString(uri, new Dictionary<string, string>
            {
                { "client_id", _spotifySettings.ClientId },
                { "response_type", "code" },
                { "redirect_uri", _spotifySettings.RedirectUri }
            });
            return Ok(uri);
        }

        [HttpGet, Route("api/token")]
        public async Task<IActionResult> GetAccessToken([FromQuery] string code)
        {
            var token = await _tokenManager.GenerateToken(code);
            return Ok(token);
        }
    }
}
