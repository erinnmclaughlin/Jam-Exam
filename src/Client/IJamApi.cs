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
        Task<PlaylistModel> GetGenrePlaylist(string genreId);
    }
}
