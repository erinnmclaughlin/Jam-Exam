using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Spotify.Authentication
{
    public class SpotifyHeaderHandler : DelegatingHandler
    {
        private readonly ITokenService _tokenService;

        public SpotifyHeaderHandler(ITokenService tokenService)
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
