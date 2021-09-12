using Refit;
using Server.Models;
using System.Threading.Tasks;

namespace Server
{
    public interface ISpotifyApi
    {
        [Get("/me")]
        Task<SpotifyUserModel> GetCurrentUser([Authorize("Bearer")] string token);

        [Get("/playlists/{playlistId}")]
        Task<SpotifyPlaylistModel> GetPlaylist(string playlistId);

        [Get("/playlists/{playlistId}/tracks")]
        Task<PagedResponseModel<SpotifyPlaylistTrackModel>> GetPlaylistTracks(string playlistId);

        [Get("/search")]
        Task<SpotifySearchResultsModel> Search(string q, string type, int limit = 20);
    }
}
