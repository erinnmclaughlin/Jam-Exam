using Client.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using Refit;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Pages
{
    public partial class Play
    {
        [Inject] private IJamApi Api { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        private GenreModel Genre { get; set; }
        private List<TrackModel> Tracks { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var genreId = NavigationManager.TryGetQueryString("genreId");

            try
            {
                Genre = await Api.GetGenre(genreId);
            }
            catch (ApiException)
            {
                var message = "There was an error loading the genre. Please try again later.";
                NavigationManager.NavigateTo(QueryHelpers.AddQueryString("", "error", message));
            }
        }

        private void HandleCreate(List<TrackModel> tracks)
        {
            Tracks = tracks;
        }
    }
}
