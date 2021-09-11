using Client.Authentication;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Client.Pages.Authorization
{
    public partial class Token
    {
        [Inject] private AuthService AuthService { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await AuthService.RequestToken();
            await base.OnInitializedAsync();
        }
    }
}
