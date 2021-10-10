using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Components
{
    public partial class GameOver
    {
        private EditContext? EditContext { get; set; }
        private HighScoreModel? ScoreModel { get; set; }

        private bool Saved { get; set; }

        protected override void OnInitialized()
        {
            if (GameService.Playlist is null)
                Navigation.NavigateTo("");

            ScoreModel = new HighScoreModel(GameService.Playlist!.Id, GameService.Score, GameService.Tracks!.Count);
            EditContext = new(ScoreModel);

            base.OnInitialized();
        }

        private async Task OnValidSubmit()
        {
            Saved = true;
        }
    }
}
