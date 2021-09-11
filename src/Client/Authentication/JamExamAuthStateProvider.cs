using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Client.Authentication
{
    public class JamExamAuthStateProvider : AuthenticationStateProvider, IDisposable
    {
        private readonly AuthenticationState _anonymous;
        private readonly AuthService _authService;

        public JamExamAuthStateProvider(AuthService authService)
        {
            _anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            _authService = authService;
            _authService.AuthenticationStateChanged += HandleAuthenticationStateChange;
        }

        public void Dispose()
        {
            _authService.AuthenticationStateChanged -= HandleAuthenticationStateChange;
            GC.SuppressFinalize(this);
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (await _authService.IsAuthenticated() == false)
            {
                return _anonymous;
            }

            var user = await _authService.GetClaimsPrincipal();
            return new AuthenticationState(user);
        }

        private void HandleAuthenticationStateChange(object o, EventArgs e)
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }
    }
}
