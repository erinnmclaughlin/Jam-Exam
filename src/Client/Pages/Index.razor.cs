using Microsoft.AspNetCore.Components;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Pages
{
    public partial class Index
    {
        [Inject] private IJamApi Api { get; set; }

        private string Error { get; set; }
        private List<GenreModel> Genres { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var response = await Api.GetGenres();

            if (response.IsSuccessStatusCode)
                Genres = response.Content;
            else
                Error = response.Error.Content;

            await base.OnInitializedAsync();
        }
    }
}
