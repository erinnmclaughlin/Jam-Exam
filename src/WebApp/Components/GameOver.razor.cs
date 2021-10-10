using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebApp.Database;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Components
{
    public partial class GameOver
    {
        [Inject] private IDbContextFactory<JamDbContext> DbContext { get; set; } = null!;

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

            using var context = DbContext.CreateDbContext();
            context.HighScores.Add(ScoreModel!);
            await context.SaveChangesAsync();
            Saved = true;

            GameService.OnScoreSaved.Invoke();
        }
    }
}
