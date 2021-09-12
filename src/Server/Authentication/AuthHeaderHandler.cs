using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Authentication
{
    public class AuthHeaderHandler : DelegatingHandler
    {
        private readonly IHttpContextAccessor _httpAccessor;

        public AuthHeaderHandler(IHttpContextAccessor httpAccessor)
        {
            _httpAccessor = httpAccessor;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            StringValues token = "";

            if (_httpAccessor.HttpContext?.Request?.Headers.TryGetValue("Authorization", out token) == true)
            {
                var spotifyToken = new JwtSecurityTokenHandler().ReadJwtToken(token.ToString().Replace("Bearer ", ""))
                    .Claims.FirstOrDefault(x => x.Type == ClaimTypes.Authentication)?.Value;

                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", spotifyToken);
            }

            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
