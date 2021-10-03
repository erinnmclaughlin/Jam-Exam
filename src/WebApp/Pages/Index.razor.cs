using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Spotify.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using WebApp.Services;

namespace WebApp.Pages
{

    public partial class Index : ComponentBase
    {
        [Inject] GameService GameService { get; set; } = null!;

        private string? ErrorMessage { get; set; }
        private List<Playlist>? Playlists { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadPlaylists();
                StateHasChanged();
            }
        }

        private async Task LoadPlaylists()
        {
            if (GameService is null)
                return;

            try
            {
                Playlists = await GameService.GetPlaylistsAsync();
            }
            catch (HttpRequestException ex)
            {
                ErrorMessage = ex.Message;
                //Logger.LogError(ex, ex.Message);
            }
            catch (Exception ex)
            {
                ErrorMessage = "An unexpected error has occurred.";
                //Logger.LogError(ex, ex.Message);
            }
        }
    }
}
