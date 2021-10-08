﻿using Microsoft.AspNetCore.Components;
using Spotify;
using Spotify.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Extensions;
using WebApp.Models;

namespace WebApp.Services
{
    public class GameService
    {
        private readonly NavigationManager _nav;
        private readonly ISpotifyClient _spotify;

        private string? _playlistId;

        public Track? CurrentTrack => Tracks?.ElementAtOrDefault(Index);
        public bool Guessing { get; private set; }
        public int Index { get; private set; } = 0;
        public bool PlayTrack { get; private set; } = true;
        public int Score => Guesses.Count(x => x.IsCorrect);

        public GuessResultModel? LastGuessed => Guesses.LastOrDefault();
        public List<GuessResultModel> Guesses { get; set; } = new();
        public List<Track>? Tracks { get; private set; }

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

        public async Task LoadTracksAsync(int quantity)
        {
            // Go back to home screen if playlist hasn't been selected.
            if (_playlistId is null)
            {
                _nav.NavigateTo("");
                return;
            }

            // Get the tracks for the selected playlist
            var response = await _spotify.GetPlaylistTracks(_playlistId);

            // Randomize track order and select indicated quantity
            Tracks = response.Content!.Items.Select(x => x.Track)
                .Where(x => !string.IsNullOrWhiteSpace(x.PreviewUrl))
                .Shuffle().Take(quantity).ToList();
        }

        public async Task GuessArtist(string artistId)
        {
            Guessing = true;

            var artistIds = CurrentTrack!.Artists.Select(x => x.Id).Append(artistId).Distinct();
            var artists = await GetArtistDetails(artistIds);

            CurrentTrack.Album = await GetAlbumDetails(CurrentTrack.Album!.Id);
            CurrentTrack.Artists = artists.Where(x => CurrentTrack.Artists.Any(a => a.Id == x.Id)).ToArray();            

            Guesses.Add(new GuessResultModel(artists.First(x => x.Id == artistId), CurrentTrack!));

            PlayTrack = false;
            Guessing = false;
        }

        public void NextTrack()
        {
            Index++;
            PlayTrack = true;
        }

        private async Task<Album> GetAlbumDetails(string id)
        {
            var response = await _spotify.GetAlbumById(id);
            return response.Content!;
        }

        private async Task<Artist[]> GetArtistDetails(IEnumerable<string> ids)
        {
            var response = await _spotify.GetArtists(ids);
            return response.Content!.Artists;
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
