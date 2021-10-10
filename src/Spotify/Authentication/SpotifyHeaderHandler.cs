using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Spotify.Authentication
{
    /// <summary>
    /// Intercepts the API call & ensures a valid auth token is obtained and attached to the request header
    /// </summary>
    internal class SpotifyHeaderHandler : DelegatingHandler
    {
        private readonly TokenService _tokenService;

        public SpotifyHeaderHandler(TokenService tokenService)
        {
            _tokenService = tokenService;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _tokenService.GetTokenAsync();
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token.Value);
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
