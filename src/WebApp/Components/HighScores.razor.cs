using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Database;
using WebApp.Models;

namespace WebApp.Components
{
    public partial class HighScores
    {
        [Inject] private JamDbContext DbContext { get; set; } = null!;

        private List<HighScoreModel>? Scores { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Scores = await DbContext.HighScores
                .Where(x => x.PlaylistId == GameService.Playlist!.Id)
                .OrderByDescending(x => x.Correct)
                .Take(100)
                .ToListAsync();
        }
    }
}
