using Microsoft.AspNetCore.Components;
using Spotify.Models;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WebApp.Components;
using WebApp.Services;

namespace WebApp.Pages
{
    public partial class PlayGame
    {
        private MusicPlayer _player = new();

        [Inject] private GameService GameService { get; set; } = null!;
        [Inject] private SearchService SearchService { get; set; } = null!;

        [Required] private Artist? SelectedArtist { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await GameService.LoadTracksAsync(10);
                StateHasChanged();
            }
        }

        private void NextTrack()
        {
            SelectedArtist = null;
            GameService.NextTrack();
        }
    }
}
