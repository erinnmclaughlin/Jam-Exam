using Refit;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client
{
    public interface IJamApi
    {
        [Get("/authorize-url")]
        Task<string> GetSpotifyAuthUrl();

        [Get("/login")]
        Task<string> LoginUser(string code);

        [Get("/genres")]
        Task<List<GenreModel>> GetGenres();

        [Get("/genres/{genreId}")]
        Task<GenreModel> GetGenre(string genreId);

        [Post("/genres/{genreId}/games")]
        Task<List<TrackModel>> CreateGame(string genreId, CreateGameModel command);

    }
}
