using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Pages
{

    public partial class Index
    {
        [Inject] private IJamApi Api { get; set; }
        [CascadingParameter] private Task<AuthenticationState> AuthStateTask { get; set; }

        private List<GenreModel> Genres { get; set; }
        private PlaylistModel Playlist { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var authState = await AuthStateTask;

            if (authState.User.Identity.IsAuthenticated)
                Genres = await Api.GetGenres();

            await base.OnInitializedAsync();
        }

        private async Task LoadPlaylist(string id)
        {
            Playlist = await Api.GetGenrePlaylist(id);
            StateHasChanged();
        }
    }
}
