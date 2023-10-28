using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using WebApp.Database;
using WebApp.Models;

namespace WebApp.Components
{
    public partial class HighScores : IDisposable
    {
        [Inject] private IDbContextFactory<JamDbContext> DbContext { get; set; } = null!;

        private List<GameResult>? Scores { get; set; }

        public void Dispose()
        {
            GameService.OnScoreSaved -= async () => await LoadScores();
            GC.SuppressFinalize(this);
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadScores();
            GameService.OnScoreSaved += async () => await LoadScores();
        }

        private async Task LoadScores()
        {
            using var context = DbContext.CreateDbContext();

            Scores = await context.GameResults
                .Where(x => x.Playlist.SpotifyId == GameService.Playlist!.Id)
                .OrderByDescending(x => x.TotalCorrect)
                .Take(100)
                .ToListAsync();

            StateHasChanged();
        }
    }
}
