using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
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

        public AuthService(IJamApi api, ILocalStorageService localStorage, NavigationManager navManager)
        {
            _api = api;
            _localStorage = localStorage;
            _navManager = navManager;
        }

        public async Task<bool> IsAuthenticated()
        {
            var token = await _localStorage.GetItemAsync<string>("token");

            if (string.IsNullOrEmpty(token))
                return false;

            var expiry = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp)?.Value;
            return expiry is not null && DateTime.TryParse(expiry, out var exp) && exp > DateTime.UtcNow;
        }

        public async Task<ClaimsPrincipal> GetCurrentUser()
        {
            if (!await IsAuthenticated())
                return new ClaimsPrincipal(new ClaimsIdentity());

            var token = await _localStorage.GetItemAsync<string>("token");
            var claims = new JwtSecurityTokenHandler().ReadJwtToken(token).Claims;
            return new ClaimsPrincipal(new ClaimsIdentity(claims, "jwtAuth"));
        }

        public async Task RequestSpotifyAuthorization()
        {
            var url = await _api.GetSpotifyAuthUrl();
            _navManager.NavigateTo(url);
        }

        public async Task LoginUser()
        {
            var uri = _navManager.ToAbsoluteUri(_navManager.Uri);
            var qs = QueryHelpers.ParseQuery(uri.Query);

            if (!qs.TryGetValue("code", out var code))
                return;

            var authResponse = await _api.LoginUser(code);

            await _localStorage.SetItemAsync("token", authResponse);
            AuthenticationStateChanged.Invoke(this, new EventArgs());
            _navManager.NavigateTo("");
        }

        public async Task Logout()
        {
            await _localStorage.RemoveItemAsync("token");
            AuthenticationStateChanged.Invoke(this, new EventArgs());
            _navManager.NavigateTo("login");
        }
    }
}
