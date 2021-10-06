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
        [Inject] GameService GameService { get; set; } = null!;

        private List<Playlist>? Playlists { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await LoadPlaylists();
                StateHasChanged();
            }
        }

        private List<CarouselItem> GetCarouselItems()
        {
            return Playlists?.Select(x => new CarouselItem
            {
                ImageUrl = x.Images?.First().Url ?? "",
                Title = x.Name
            }).ToList()!;
        }

        private async Task LoadPlaylists()
        {
            Playlists = await GameService.GetPlaylistsAsync();
        }
    }
}
