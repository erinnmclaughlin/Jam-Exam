using Client.Authentication;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Client.Pages.Authorization
{
    public partial class Login
    {
        [Inject] private AuthService AuthService { get; set; }

        private bool IsLoggingIn { get; set; }

        private async Task LoginUser()
        {
            IsLoggingIn = true;

            try
            {
                await AuthService.RequestSpotifyAuthorization();
            }
            catch
            {
                IsLoggingIn = false;
            }
        }
    }
}
