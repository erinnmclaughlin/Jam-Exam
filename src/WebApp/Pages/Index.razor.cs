using Microsoft.AspNetCore.Components;
using WebApp.Components;
using WebApp.Services;

namespace WebApp.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject] private PlaylistService PlaylistService { get; set; } = null!;

        private List<CarouselItem>? Items { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                GameService.Reset();

                if (PlaylistService.Playlists is null)
                    await PlaylistService.LoadPlaylists();

                if (Items is null)
                {
                    var items = PlaylistService.Playlists!.Select(x => new CarouselItem { Id = x.Id, ImageUrl = x.Images!.First().Url }).ToList()!;

                    foreach (var item in items)
                        item.DisplayOrder = items.IndexOf(item);

                    Items = items;
                }

                await InvokeAsync(StateHasChanged);
            }           
        }

        private async Task CreateGame(string playlistId)
        {
            await GameService.CreateGame(playlistId);
            Navigation.NavigateTo("play-game");
        }
    }
}
