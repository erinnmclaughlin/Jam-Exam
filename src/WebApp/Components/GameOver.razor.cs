using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApp.Database;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Components
{
    public partial class GameOver
    {
        [Inject] private IDbContextFactory<JamDbContext> DbContext { get; set; } = null!;

        [MaxLength(100, ErrorMessage = "Player name cannot exceed 100 characters.")]
        private string? PlayerName { get; set; }

        private bool Saving { get; set; }
        private bool Saved { get; set; }

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
            if (Saving) return;

            Saving = true;
            await InvokeAsync(StateHasChanged);

            using (var context = DbContext.CreateDbContext())
            {
                var playlistId = await context.Playlists.SingleAsync(x => x.SpotifyId == GameService.Playlist!.Id);

                context.GameResults.Add(new GameResult
                {
                    PlayerName = string.IsNullOrWhiteSpace(PlayerName) ? null : PlayerName,
                    TotalCorrect = GameService.Score,
                    TotalGuessed = GameService.Tracks!.Count
                });

                await context.SaveChangesAsync();
            }
                
            Saved = true;
            Saving = false;

            GameService.OnScoreSaved.Invoke();
        }
    }
}
