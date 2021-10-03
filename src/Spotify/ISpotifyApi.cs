using Refit;
using Spotify.Models;
using System.Threading.Tasks;

namespace Spotify
{
    public interface ISpotifyApi
    {
        [Get("/playlists/{playlistId}")]
        Task<ApiResponse<Playlist>> GetPlaylistById(string playlistId);
    }
}
