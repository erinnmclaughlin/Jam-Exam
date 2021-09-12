using Client.Extensions;
using Microsoft.AspNetCore.Components;
using Shared.Models;
using System.Threading.Tasks;

namespace Client.Pages
{
    public partial class CreateGame
    {
        [Inject] private IJamApi Api { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        private PlaylistModel Playlist { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var genreId = NavigationManager.TryGetQueryString("genreId");

            if (!string.IsNullOrEmpty(genreId))
            {
                Playlist = await Api.GetGenrePlaylist(genreId);
            }

            await base.OnInitializedAsync();
        }
    }
}
