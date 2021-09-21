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

        [Get("/genres/{genreId}/tracks")]
        Task<ApiResponse<List<TrackModel>>> GetTracksByGenre(string genreId, int? count);

    }
}
