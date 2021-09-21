using Microsoft.AspNetCore.Components;

namespace Client.Components
{
    public class RedirectToLogin : ComponentBase
    {
        [Inject] private NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            NavigationManager.NavigateTo("login");
        }
    }
}
