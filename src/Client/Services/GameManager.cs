using Blazored.SessionStorage;
using Microsoft.AspNetCore.Components;
using Shared.Models;
using System;
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
        private List<TrackModel> _tracks;

        public GameManager(IJamApi api, NavigationManager navigationManager, ISessionStorageService sessionStorage)
        {
            _api = api;
            _navigationManager = navigationManager;
            _sessionStorage = sessionStorage;
        }

        public async Task CreateGame(CreateGameModel model)
        {
            Console.WriteLine("Creating game...");
            var genreId = await _sessionStorage.GetItemAsync<string>("je-genreId");
            Console.WriteLine("Genre Id is " + genreId);
            var response = await _api.CreateGame(genreId, model);

            Console.WriteLine("Success is " + response.IsSuccessStatusCode);
            Console.WriteLine("Content is " + response.Content);

            if (response.IsSuccessStatusCode)
            {
                _tracks = response.Content;
                _navigationManager.NavigateTo("play");
            }
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
