using Blazored.LocalStorage;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Authentication
{
    public class JamHeaderHandler : DelegatingHandler
    {
        private readonly ILocalStorageService _localStorage;

        public JamHeaderHandler(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await _localStorage.GetItemAsync<string>("token", cancellationToken);
            request.Headers.Authorization = string.IsNullOrWhiteSpace(token) ? null : new AuthenticationHeaderValue("Bearer", token);
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
