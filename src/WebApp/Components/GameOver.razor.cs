using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Threading.Tasks;
using WebApp.Database;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Components
{
    public partial class GameOver
    {
        [Inject] private JamDbContext DbContext { get; set; } = null!;

        private EditContext? EditContext { get; set; }
        private HighScoreModel? ScoreModel { get; set; }

        private bool Saving { get; set; }
        private bool Saved { get; set; }

        protected override void OnInitialized()
        {
            if (GameService.Playlist is null)
                Navigation.NavigateTo("");

            ScoreModel = new HighScoreModel(GameService.Playlist!.Id, GameService.Score, GameService.Tracks!.Count);
            EditContext = new(ScoreModel);

            base.OnInitialized();
        }

        private string GetButtonCss()
        {
            if (Saving)
            {
                return "opacity-50 cursor-not-allowed";
            }
            else
            {
                return "hover:bg-green-400";
            }
        }

        private async Task OnValidSubmit()
        {
            Saving = true;
            await InvokeAsync(StateHasChanged);

            DbContext.HighScores.Add(ScoreModel!);
            await DbContext.SaveChangesAsync();
            Saved = true;
        }
    }
}
