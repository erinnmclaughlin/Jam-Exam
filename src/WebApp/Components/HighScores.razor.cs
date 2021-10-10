using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Database;
using WebApp.Models;

namespace WebApp.Components
{
    public partial class HighScores : IDisposable
    {
        [Inject] private JamDbContext DbContext { get; set; } = null!;

        private List<HighScoreModel>? Scores { get; set; }

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
            Scores = await DbContext.HighScores
                .Where(x => x.PlaylistId == GameService.Playlist!.Id)
                .OrderByDescending(x => x.Correct)
                .Take(100)
                .ToListAsync();

            StateHasChanged();
        }
    }
}
