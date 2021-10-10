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

        [Inject] private SearchService SearchService { get; set; } = null!;

        [Required] private Artist? SelectedArtist { get; set; }

        public void Dispose()
        {
            GameService.PropertyChanged -= async (o, e) => await InvokeAsync(StateHasChanged);
            GC.SuppressFinalize(this);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                GameService.PropertyChanged += async (o, e) => await InvokeAsync(StateHasChanged);

                if (GameService.Playlist is null)
                    Navigation.NavigateTo("");
                else
                    await GameService.LoadTracksAsync(10);

                await InvokeAsync(StateHasChanged);
            }
        }

        private string GetResultText()
        {
            if (GameService.LastGuessed!.GuessedArtist is null)
                return "Time's Up!";

            if (GameService.LastGuessed!.IsCorrect)
                return "Rock On!";

            return "Oh, Drumsticks!";
        }
    }
}
