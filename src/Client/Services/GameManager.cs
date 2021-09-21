using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client.Services
{
    public class GameManager
    {
        private readonly IJamApi _api;
        private readonly NavigationManager _navigationManager;
        private readonly ISessionStorageService _sessionStorage;

        private int _currentIndex = 0;
        private int _difficulty = 0;

        private List<TrackModel> _tracks;

        public TrackModel CurrentTrack => _tracks[_currentIndex];

        public GameManager(IJamApi api, NavigationManager navigationManager, ISessionStorageService sessionStorage)
        {
            _api = api;
            _navigationManager = navigationManager;
            _sessionStorage = sessionStorage;
        }

        public async Task CreateGame(CreateGameModel model)
        {
            await _sessionStorage.SetItemAsync("je-gameIndex", 0);
            var genreId = await _sessionStorage.GetItemAsync<string>("je-genreId");
            var response = await _api.GetTracksByGenre(genreId, model.NumberOfQuestions);

            if (response.IsSuccessStatusCode)
            {
                _difficulty = model.Difficulty.Value;
                _tracks = response.Content;
                _navigationManager.NavigateTo("play");
            }
        }

        public void NextTrack()
        {
            _currentIndex++; // TODO: if last track do something else
        }

        public async Task<List<GenreModel>> GetGenres()
        {
            var response = await _api.GetGenres();
            return response.Content;
        }

        public async Task SelectGenre(string genreId)
        {
            await _sessionStorage.SetItemAsync("je-genreId", genreId);
            _navigationManager.NavigateTo("create-game");
        }
    }
}
