using Client.Extensions;
using Microsoft.AspNetCore.Components;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Pages
{
    public partial class Play
    {
        [Inject] private IJamApi Api { get; set; }
        [Inject] private NavigationManager NavigationManager { get; set; }

        private bool IsLoading { get; set; } = true;
        private int NumberCorrect { get; set; } = 0;
        private bool GameOver { get; set; } = false;
        private GenreModel Genre { get; set; }
        private string Guess { get; set; }
        private int CurrentIndex { get; set; } = 0;
        private List<TrackModel> Tracks { get; set; }
        private bool? IsCorrect { get; set; }
        private string Error { get; set; }

        private TrackModel CurrentTrack { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var genreId = NavigationManager.TryGetQueryString("genreId");

            var response = await Api.GetGenre(genreId);

            if (response.IsSuccessStatusCode)
            {
                Genre = response.Content;
                IsLoading = false;
            }
            else
            {
                Error = response.Error.Content;
            }
        }

        private async Task GuessArtist()
        {
            var response = await Api.SearchArtists(Guess, 2);

            if (!response.IsSuccessStatusCode)
            {
                Error = response.Error.Content;
                return;
            }

            IsCorrect = false;
            foreach (var artist in response.Content)
            {
                if (CurrentTrack.ArtistIds.Contains(artist.Id))
                    IsCorrect = true;
            }

            if (IsCorrect == true)
                NumberCorrect++;

            Guess = string.Empty;
        }

        private async Task GetNextTrack()
        {
            IsLoading = true;
            CurrentTrack = null;
            IsCorrect = null;
            StateHasChanged();

            await Task.Delay(100);

            if (CurrentIndex + 1 == Tracks.Count)
                GameOver = true;
            else
            {
                CurrentIndex++;
                CurrentTrack = Tracks?.ElementAt(CurrentIndex);
            }

            IsLoading = false;
            StateHasChanged();
        }

        private void HandleCreate(List<TrackModel> tracks)
        {
            Tracks = tracks;
            CurrentTrack = Tracks.First();
        }
    }
}
