using Client.Authentication;
using Microsoft.AspNetCore.Components;

namespace Client.Components
{
    public partial class NavMenu
    {
        [Inject] private AuthService AuthService { get; set; }

        private bool IsOpen { get; set; }

        private void ToggleMenu() => IsOpen = !IsOpen;
    }
}
