using Microsoft.AspNetCore.Components;
using Spotify.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Components;
using WebApp.Services;

namespace WebApp.Pages
{
    public partial class PlayGame
    {
        private MusicPlayer? _player;

        [Inject] private GameService GameService { get; set; } = null!;

        private List<Track>? Tracks { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                Tracks = await GameService.GetTracksAsync();

                _player?.Play();
                StateHasChanged();
            }
        }

        private async Task NextTrack()
        {
            _player?.Stop();
            GameService.NextTrack();
            await Task.Delay(100);

            _player?.Play();
        }

        private Track? GetCurrentTrack() => Tracks?.ElementAtOrDefault(GameService.Index);
    }
}
