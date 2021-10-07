using Microsoft.AspNetCore.Components;
using Spotify;
using Spotify.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Extensions;

namespace WebApp.Services
{
    public class GameService
    {
        private readonly NavigationManager _nav;
        private readonly ISpotifyClient _spotify;

        private string? _playlistId;
        public int _index = 0;

        public int Index => _index;

        public GameService(NavigationManager nav, ISpotifyClient spotify)
        {
            _nav = nav;
            _spotify = spotify;
        }

        public void CreateGame(string playlistId)
        {
            _playlistId = playlistId;
            _nav.NavigateTo("play-game");
        }

        public async Task<List<Playlist>> GetPlaylistsAsync()
        {
            var playlists = new List<Playlist>();

            foreach (var seed in GetPlaylistSeeds())
            {
                var response = await _spotify.GetPlaylistById(seed.Value);
                await response.EnsureSuccessStatusCodeAsync();

                var playlist = response.Content!;
                playlist.Name = seed.Key;
                playlists.Add(playlist);
            }

            return playlists;
        }

        public async Task<List<Track>?> GetTracksAsync()
        {
            if (_playlistId is null)
            {
                _nav.NavigateTo("");
                return await Task.FromResult<List<Track>?>(null);
            }

            var response = await _spotify.GetPlaylistTracks(_playlistId);

            return response.Content!.Items.Select(x => x.Track)
                .Where(x => !string.IsNullOrWhiteSpace(x.PreviewUrl))
                .Shuffle().Take(10).ToList();
        }

        public void NextTrack() => _index++;

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
