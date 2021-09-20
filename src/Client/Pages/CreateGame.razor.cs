using Client.Services;
using Microsoft.AspNetCore.Components;
using Shared.Models;
using System.Threading.Tasks;

namespace Client.Pages
{
    public partial class CreateGame
    {
        [Inject] private GameManager GameManager { get; set; }

        private CreateGameModel CreateGameModel { get; set; } = new();

        private async Task HandleValidSubmit()
        {
            await GameManager.CreateGame(CreateGameModel);
        }
    }
}
