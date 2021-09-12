using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Server.Authentication;
using Server.Settings;
using System.Collections.Generic;
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

        [HttpGet, Route("api/login")]
        public async Task<IActionResult> LoginUser([FromQuery] string code)
        {
            var token = await _tokenManager.LoginUser(code);
            return Ok(token);
        }
    }
}
