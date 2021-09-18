using Client.Authentication;
using Microsoft.AspNetCore.Components;

namespace Client.Components
{
    public partial class ProfileDropdown
    {
        [Inject] private AuthService AuthService { get; set; }

        private bool ShowDropdown { get; set; }

        private void ToggleDropdown() => ShowDropdown = !ShowDropdown;
    }
}
