using Refit;
using Spotify.Models;
using Spotify.Responses;
using System.Threading.Tasks;

namespace Spotify
{
    public interface ISpotifyClient
    {
        [Get("/playlists/{playlistId}")]
        Task<ApiResponse<Playlist>> GetPlaylistById(string playlistId);

        [Get("/playlists/{playlistId}/tracks")]
        Task<ApiResponse<PagedResponse<PlaylistTrack>>> GetPlaylistTracks(string playlistId);
    }
}
