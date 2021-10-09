using Microsoft.AspNetCore.Components;
using WebApp.Services;

namespace WebApp.Pages
{
    public partial class GameOver
    {
        [Inject] private GameService GameService { get; set; } = null!;
    }
}
