using Client.Services;
using Microsoft.AspNetCore.Components;
using Shared.Models;
using System.Threading.Tasks;

namespace Client.Pages
{
    public partial class CreateGame
    {
        [Inject] private GameManager GameManager { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        private bool IsSubmitting { get; set; }
        private CreateGameModel CreateGameModel { get; set; } = new();

        private string DisabledCss() => IsSubmitting ? "opacity-50 cursor-not-allowed" : "";

        private async Task HandleValidSubmit()
        {
            if (IsSubmitting)
                return;

            IsSubmitting = true;
            await GameManager.CreateGame(CreateGameModel);
            IsSubmitting = false;
        }

        private void GoToSelectGenre()
        {
            if (!IsSubmitting)
                NavigationManager.NavigateTo("");
        }
    }
}
