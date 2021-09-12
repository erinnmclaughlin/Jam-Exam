using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Client.Authentication
{
    public class AuthService
    {
        private readonly IJamApi _api;
        private readonly ILocalStorageService _localStorage;
        private readonly NavigationManager _navManager;

        public event EventHandler AuthenticationStateChanged;

        public AuthService(IJamApi api, ILocalStorageService localStorage,NavigationManager navManager)
        {
            _api = api;
            _localStorage = localStorage;
            _navManager = navManager;
        }

        public async Task<bool> IsAuthenticated()
        {
            var token = await _localStorage.GetItemAsync<string>("token");
            var expiry = await _localStorage.GetItemAsync<DateTime?>("expiry");
            var isAuthenticated = token is not null && expiry is not null && DateTime.UtcNow <= expiry;

            return isAuthenticated;
        }

        public async Task RequestSpotifyAuthorization()
        {
            var url = await _api.GetSpotifyAuthUrl();
            _navManager.NavigateTo(url);
        }

        public async Task RequestToken()
        {
            var uri = _navManager.ToAbsoluteUri(_navManager.Uri);
            var qs = QueryHelpers.ParseQuery(uri.Query);

            if (!qs.TryGetValue("code", out var code))
                return;

            var token = await _api.GetToken(code);

            await _localStorage.SetItemAsync("token", token.Value);
            await _localStorage.SetItemAsync("expiry", token.Expiry);

            AuthenticationStateChanged.Invoke(this, new EventArgs());
            _navManager.NavigateTo("");
        }

        public async Task<ClaimsPrincipal> GetClaimsPrincipal()
        {
            if (await IsAuthenticated() == false)
                return new ClaimsPrincipal(new ClaimsIdentity());

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "Test User"),
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
