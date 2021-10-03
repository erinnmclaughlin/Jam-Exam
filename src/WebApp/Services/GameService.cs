using Spotify;
using Spotify.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class GameService
    {
        private readonly ISpotifyApi _api;

        public GameService(ISpotifyApi api)
        {
            _api = api;
        }

        public async Task<List<Playlist>> GetPlaylistsAsync()
        {
            var playlists = new List<Playlist>();

            foreach (var seed in GetPlaylistSeeds())
            {
                var response = await _api.GetPlaylistById(seed.Value);
                await response.EnsureSuccessStatusCodeAsync();

                var playlist = response.Content!;
                playlist.Name = seed.Key;
                playlists.Add(playlist);
            }

            return playlists;
        }

        private static Dictionary<string, string> GetPlaylistSeeds()
        {
            return new Dictionary<string, string>
            {
                { "Classic Rock", "37i9dQZF1DWXRqgorJj26U" },
                { "Indie", "37i9dQZF1DX2Nc3B70tvx0" },
                { "Pop", "37i9dQZF1DXcBWIGoYBM5M" },
                { "Hip Hop", "37i9dQZF1DX0XUsuxWHRQd" },
                { "Country", "37i9dQZF1DX1lVhptIYRda" },
                { "1960s", "37i9dQZF1DWWzBc3TOlaAV" },
                { "1970s", "37i9dQZF1DWTJ7xPn4vNaz" },
                { "1980s", "37i9dQZF1DX4UtSsGT1Sbe" },
                { "1990s", "37i9dQZF1DXbTxeAdrVG2l" },
                { "2000s", "37i9dQZF1DX4o1oenSJRJd" }
            };
        }
    }
}
