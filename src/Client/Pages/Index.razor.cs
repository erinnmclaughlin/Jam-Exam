using Client.Services;
using Microsoft.AspNetCore.Components;
using Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Pages
{
    public partial class Index
    {
        [Inject] private GameManager GameManager { get; set; }

        private int CurrentIndex { get; set; } = 0;
        private List<GenreModel> Genres { get; set; }

        private int NextIndex => (CurrentIndex == Genres.Count - 1) ? 0 : CurrentIndex + 1;
        private int PreviousIndex => (CurrentIndex == 0) ? Genres.Count - 1 : CurrentIndex - 1;
        private GenreModel CurrentGenre => Genres.ElementAt(CurrentIndex);
        private GenreModel NextGenre => Genres.ElementAt(NextIndex);
        private GenreModel PreviousGenre => Genres.ElementAt(PreviousIndex);        

        protected override async Task OnInitializedAsync()
        {
            Genres = await GameManager.GetGenres();            
            await base.OnInitializedAsync();
        }

        private void GoToNextIndex()
        {
            CurrentIndex = NextIndex;
        }

        private void GoToPreviousIndex()
        {
            CurrentIndex = PreviousIndex;
        }
    }
}
