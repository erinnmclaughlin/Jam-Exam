using Spotify;
using Spotify.Models;

namespace WebApp.Services
{
    public class PlaylistService
    {
        private readonly ISpotifyClient _spotify;

        public PlaylistService(ISpotifyClient spotify)
        {
            _spotify = spotify;
        }

        /// <summary>
        /// The playlists available to choose from
        /// </summary>
        public List<Playlist>? Playlists { get; private set; }

        /// <summary>
        /// Gets a list of playlists supported by the app.
        /// </summary>
        public async Task LoadPlaylists()
        {
            var playlists = new List<Playlist>();

            foreach (var seed in GetPlaylistSeeds())
            {
                var response = await _spotify.GetPlaylistById(seed);
                await response.EnsureSuccessStatusCodeAsync();

                var playlist = response.Content!;
                playlists.Add(playlist);
            }

            Playlists = playlists;
        }

        private static string[] GetPlaylistSeeds()
        {
            return new string[]
            {
                "37i9dQZF1DWXRqgorJj26U", // Classic Rock
                "37i9dQZF1DX2Nc3B70tvx0", // Indie
                "37i9dQZF1DXcBWIGoYBM5M", // Pop
                "37i9dQZF1DX0XUsuxWHRQd", // Hip Hop
                "37i9dQZF1DX1lVhptIYRda", // Country
                "37i9dQZF1DWWzBc3TOlaAV", // 1960's
                "37i9dQZF1DWTJ7xPn4vNaz", // 1970's
                "37i9dQZF1DX4UtSsGT1Sbe", // 1980's
                "37i9dQZF1DXbTxeAdrVG2l", // 1990's
                "37i9dQZF1DX4o1oenSJRJd", // 2000's
                "6i2Qd6OpeRBAzxfscNXeWp", // All Time Hits
            };
        }
    }
}
