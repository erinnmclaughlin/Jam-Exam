using Microsoft.AspNetCore.Components;
using Spotify.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Components;
using WebApp.Services;

namespace WebApp.Pages
{
    public partial class Index : ComponentBase
    {
        private List<Playlist>? Playlists { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                GameService.Reset();
                await LoadPlaylists();
                StateHasChanged();
            }
        }

        private List<CarouselItem> GetCarouselItems()
        {
            return Playlists?.Select(x => new CarouselItem { Id = x.Id, ImageUrl = x.Images!.First().Url }).ToList()!;
        }

        private async Task LoadPlaylists()
        {
            Playlists = await GameService.GetPlaylistsAsync();
        }
    }
}
