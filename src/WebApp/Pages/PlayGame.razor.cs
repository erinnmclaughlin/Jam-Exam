using Microsoft.AspNetCore.Components;
using Spotify.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using WebApp.Components;
using WebApp.Services;

namespace WebApp.Pages
{
    public partial class PlayGame : IDisposable
    {
        private MusicPlayer _player = new();

        [Inject] private GameService GameService { get; set; } = null!;
        [Inject] private NavigationManager Navigation { get; set; } = null!;
        [Inject] private SearchService SearchService { get; set; } = null!;

        [Required] private Artist? SelectedArtist { get; set; }

        public void Dispose()
        {
            GameService.PropertyChanged -= (o, e) => StateHasChanged();
            GC.SuppressFinalize(this);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                GameService.PropertyChanged += (o,e) => StateHasChanged();

                if (GameService.Playlist is null)
                    Navigation.NavigateTo("");
                else
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
