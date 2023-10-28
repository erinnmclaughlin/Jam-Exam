﻿using Microsoft.AspNetCore.Components;
using Spotify.Models;
using WebApp.Components;
using WebApp.Services;

namespace WebApp.Pages
{
    public partial class Index : ComponentBase
    {
        [Inject] 
        private PlaylistService PlaylistService { get; set; } = null!;

        private Playlist[]? Playlists { get; set; }
        private List<CarouselItem>? Items { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                GameService.Reset();

                Playlists ??= await PlaylistService.LoadPlaylistsAsync();

                if (Items is null)
                {
                    var items = Playlists.Select(x => new CarouselItem { Id = x.Id, ImageUrl = x.Images!.First().Url }).ToList()!;

                    foreach (var item in items)
                        item.DisplayOrder = items.IndexOf(item);

                    Items = items;
                }

                await InvokeAsync(StateHasChanged);
            }           
        }

        private void CreateGame(string playlistId)
        {
            var playlist = Playlists?.Single(p => p.Id == playlistId);

            if (playlist is not null)
            {
                GameService.CreateGame(playlist);
                Navigation.NavigateTo("play-game");
            }
        }
    }
}
