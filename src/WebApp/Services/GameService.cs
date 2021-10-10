using Microsoft.AspNetCore.Components;
using Spotify;
using Spotify.Models;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Extensions;
using WebApp.Models;

namespace WebApp.Services
{
    public class GameService : INotifyPropertyChanged
    {
        private readonly NavigationManager _nav;
        private readonly ISpotifyClient _spotify;

        private bool _gameOver;
        private bool _guessing;
        private int _index;
        private bool _playTrack = true;

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// The track that is currently playing
        /// </summary>
        public Track? CurrentTrack => Tracks?.ElementAtOrDefault(Index);

        /// <summary>
        /// The result of the last guess
        /// </summary>
        public GuessResultModel? LastGuessed => Guesses.LastOrDefault();

        /// <summary>
        /// The current score of the game
        /// </summary>
        public int Score => Guesses.Count(x => x.IsCorrect);

        public bool GameOver
        {
            get => _gameOver;
            private set
            {
                _gameOver = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GameOver)));
            }
        }

        /// <summary>
        /// Indicates whether the app is in the process of guessing. Controls should be disabled when this is true
        /// to prevent duplicate submissions.
        /// </summary>
        public bool Guessing
        {
            get => _guessing;
            private set
            {
                _guessing = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Guessing)));
            }
        }

        /// <summary>
        /// The index of the current track within <see cref="Tracks">Tracks</see>
        /// </summary>
        public int Index
        {
            get => _index;
            private set
            {
                _index = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Index)));
            }
        }

        /// <summary>
        /// Indicates whether the track's audio preview is currently playing
        /// </summary>
        public bool PlayTrack
        {
            get => _playTrack;
            private set
            {
                _playTrack = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PlayTrack)));
            }
        }

        /// <summary>
        /// The playlist selected by the user
        /// </summary>
        public Playlist? Playlist { get; private set; }

        /// <summary>
        /// The history of guesses made by the user
        /// </summary>
        public List<GuessResultModel> Guesses { get; set; } = new();

        /// <summary>
        /// The tracks selected from the playlist to include in the game
        /// </summary>
        public List<Track>? Tracks { get; private set; }

        public GameService(NavigationManager nav, ISpotifyClient spotify)
        {
            _nav = nav;
            _spotify = spotify;
        }

        /// <summary>
        /// Starts a new game.
        /// </summary>
        /// <param name="playlistId"></param>
        /// <returns></returns>
        public async Task CreateGame(string playlistId)
        {
            // Get the playlist details
            var response = await _spotify.GetPlaylistById(playlistId);
            Playlist = response.Content;

            // Reset game items
            Reset();

            // Navigate to the play game page
            _nav.NavigateTo("play-game");
        }

        /// <summary>
        /// Gets a list of playlists supported by the app.
        /// </summary>
        /// <returns>A list of playlists</returns>
        public async Task<List<Playlist>> GetPlaylistsAsync()
        {
            var playlists = new List<Playlist>();

            foreach (var seed in GetPlaylistSeeds())
            {
                var response = await _spotify.GetPlaylistById(seed);
                await response.EnsureSuccessStatusCodeAsync();

                var playlist = response.Content!;
                playlists.Add(playlist);
            }

            return playlists;
        }

        /// <summary>
        /// Gets a random set of 10 tracks from the selected playlist
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task LoadTracksAsync(int quantity)
        {
            // Get the tracks for the selected playlist
            var response = await _spotify.GetPlaylistTracks(Playlist!.Id);

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

            Guesses.Add(new GuessResultModel(CurrentTrack, artists.First(x => x.Id == artistId)));

            PlayTrack = false;
            Guessing = false;
        }

        public void NextTrack()
        {
            if (Index == Tracks!.Count - 1)
            {
                GameOver = true;
            }
            else
            {
                Index++;
                PlayTrack = true;
            }  
        }

        public void Reset()
        {
            // Reset game items
            Index = 0;
            Tracks = null;
            Guesses = new();
            GameOver = false;
            Guessing = false;
            PlayTrack = true;
        }

        public async Task Timeout()
        {
            Guessing = true;

            var artists = await GetArtistDetails(CurrentTrack!.Artists.Select(x => x.Id));

            CurrentTrack.Album = await GetAlbumDetails(CurrentTrack.Album!.Id);
            CurrentTrack.Artists = artists.Where(x => CurrentTrack.Artists.Any(a => a.Id == x.Id)).ToArray();

            Guesses.Add(new GuessResultModel(CurrentTrack));

            PlayTrack = false;
            Guessing = false;
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
