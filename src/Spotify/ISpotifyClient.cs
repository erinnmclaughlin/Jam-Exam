using Refit;
using Spotify.Models;
using Spotify.Requests;
using Spotify.Responses;
using System.Threading.Tasks;

namespace Spotify
{
    public interface ISpotifyClient
    {
        [Get("/artists/{artistId}")]
        Task<ApiResponse<Artist>> GetArtistById(string artistId);

        [Get("/playlists/{playlistId}")]
        Task<ApiResponse<Playlist>> GetPlaylistById(string playlistId);

        [Get("/playlists/{playlistId}/tracks")]
        Task<ApiResponse<PagedResponse<PlaylistTrack>>> GetPlaylistTracks(string playlistId);

        [Get("/search")]
        Task<ApiResponse<SearchResponse>> Search(SearchRequest request);
    }
}
