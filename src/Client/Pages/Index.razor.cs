using Microsoft.AspNetCore.Components;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Pages
{
    public partial class Index
    {
        [Inject] private IJamApi Api { get; set; }

        private int CurrentIndex { get; set; } = 0;

        private int NextIndex => (CurrentIndex == Genres.Count - 1) ? 0 : CurrentIndex + 1;
        private int PreviousIndex => (CurrentIndex == 0) ? Genres.Count - 1 : CurrentIndex - 1;


        private string GetCss(GenreModel genre)
        {
            if (genre == PreviousGenre)
                return "prev";

            if (genre == CurrentGenre)
                return "active";

            if (genre == NextGenre)
                return "next";

            return "";
        }

        private void GoToNextIndex()
        {
            CurrentIndex = NextIndex;
        }

        private void GoToPreviousIndex()
        {
            CurrentIndex = PreviousIndex;
        }

        private string Error { get; set; }
        private List<GenreModel> Genres { get; set; }

        private GenreModel CurrentGenre => Genres.ElementAt(CurrentIndex);
        private GenreModel NextGenre => Genres.ElementAt(NextIndex);
        private GenreModel PreviousGenre => Genres.ElementAt(PreviousIndex);

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
