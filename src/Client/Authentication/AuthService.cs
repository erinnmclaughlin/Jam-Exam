using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;
using Shared.Authentication;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Client.Authentication
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navManager;

        public event EventHandler AuthenticationStateChanged;

        public AuthService(HttpClient httpClient, ILocalStorageService localStorage,NavigationManager navManager)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _navManager = navManager;
        }

        public async Task<bool> IsAuthenticated()
        {
            var token = await _localStorage.GetItemAsync<string>("token");
            var expiry = await _localStorage.GetItemAsync<DateTime?>("expiry");
            return token is not null && expiry is not null && DateTime.UtcNow <= expiry;
        }

        public async Task RequestSpotifyAuthorization()
        {
            var response = await _httpClient.GetAsync("api/authorize-url");
            var content = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var uri = JsonConvert.DeserializeObject<AuthorizationUrl>(content);
                _navManager.NavigateTo(uri.Url);
            }
        }

        public async Task RequestToken()
        {
            var uri = _navManager.ToAbsoluteUri(_navManager.Uri);
            var qs = QueryHelpers.ParseQuery(uri.Query);

            if (!qs.TryGetValue("code", out var code))
                return;

            var response = await _httpClient.GetAsync(QueryHelpers.AddQueryString("api/token", "code", code));

            if (!response.IsSuccessStatusCode)
                return;

            var content = await response.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<TokenResponse>(content);

            await _localStorage.SetItemAsync("token", token.Token);
            await _localStorage.SetItemAsync("expiry", token.ExpiresOn);

            AuthenticationStateChanged.Invoke(this, new EventArgs());
            _navManager.NavigateTo("");
        }

        public async Task<ClaimsPrincipal> GetClaimsPrincipal()
        {
            var token = await _localStorage.GetItemAsync<string>("token");

            var claims = new List<Claim>
            {
                new Claim("token", token),
            };

            return new ClaimsPrincipal(new ClaimsIdentity(claims, "jamExamAuth"));
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
            await _localStorage.RemoveItemAsync("expiry");
            AuthenticationStateChanged.Invoke(this, new EventArgs());
            _navManager.NavigateTo("login");
        }
    }
}
