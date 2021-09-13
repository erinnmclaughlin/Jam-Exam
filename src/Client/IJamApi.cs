using Refit;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client
{
    public interface IJamApi
    {
        [Get("/artists")]
        Task<ApiResponse<List<ArtistModel>>> SearchArtists(string searchText, int limit = 20);

        [Get("/authorize-url")]
        Task<ApiResponse<string>> GetSpotifyAuthUrl();

        [Get("/login")]
        Task<ApiResponse<string>> LoginUser(string code);

        [Get("/genres")]
        Task<ApiResponse<List<GenreModel>>> GetGenres();

        [Get("/genres/{genreId}")]
        Task<ApiResponse<GenreModel>> GetGenre(string genreId);

        [Post("/genres/{genreId}/games")]
        Task<ApiResponse<List<TrackModel>>> CreateGame(string genreId, CreateGameModel command);

    }
}
