using Client.Services;
using Microsoft.AspNetCore.Components;

namespace Client.Pages
{
    public partial class Play
    {
        [Inject] private GameManager GameManager { get; set; }
    }
}
