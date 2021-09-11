using Client.Authentication;
using Microsoft.AspNetCore.Components;

namespace Client.Pages.Authorization
{
    public partial class Login
    {
        [Inject] private AuthService AuthService { get; set; }
    }
}
