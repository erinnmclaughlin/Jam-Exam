using Spotify;
using Spotify.Models;
using System.ComponentModel;
using WebApp.Extensions;
using WebApp.Models;

namespace WebApp.Services;

/// <summary>
/// Service for holding current state of game
/// </summary>
public class GameService : INotifyPropertyChanged
{
    private readonly ISpotifyClient _spotify;

    private bool _gameOver;
    private bool _guessing;
    private int _index;
    private bool _playTrack = true;

    public event PropertyChangedEventHandler? PropertyChanged;
    public Action? OnScoreSaved;

    /// <summary>
    /// The track that is currently playing
    /// </summary>
    public Track? CurrentTrack => Tracks?.ElementAtOrDefault(Index);

    /// <summary>
    /// The result of the last guess
    /// </summary>
    public GuessResult? LastGuessed => Guesses.LastOrDefault();

    /// <summary>
    /// The current score of the game
    /// </summary>
    public int Score => Guesses.Count(x => x.IsCorrect);

    /// <summary>
    /// Indicates if the game has ended
    /// </summary>
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
    public Spotify.Models.Playlist? Playlist { get; private set; }

    /// <summary>
    /// The history of guesses made by the user
    /// </summary>
    public List<GuessResult> Guesses { get; set; } = new();

    /// <summary>
    /// The tracks selected from the playlist to include in the game
    /// </summary>
    public List<Track>? Tracks { get; private set; }

    public GameService(ISpotifyClient spotify)
    {
        _spotify = spotify;
    }

    /// <summary>
    /// Starts a new game.
    /// </summary>
    /// <param name="playlistId"></param>
    /// <returns></returns>
    public void CreateGame(Spotify.Models.Playlist playlist)
    {
        Playlist = playlist;
        Reset();
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

    /// <summary>
    /// Gets detailed information about the track artist(s) and guessed artist. The two are compared
    /// to determine if the selected artist is a match.
    /// </summary>
    /// <param name="artistId"></param>
    /// <returns></returns>
    public async Task GuessArtist(string artistId)
    {
        Guessing = true;

        var artistIds = CurrentTrack!.Artists.Select(x => x.Id).Append(artistId).Distinct();
        var artists = await GetArtistDetails(artistIds);

        CurrentTrack.Album = await GetAlbumDetails(CurrentTrack.Album!.Id);
        CurrentTrack.Artists = artists.Where(x => CurrentTrack.Artists.Any(a => a.Id == x.Id)).ToArray();            

        Guesses.Add(new GuessResult(CurrentTrack, artists.First(x => x.Id == artistId)));

        PlayTrack = false;
        Guessing = false;
    }

    /// <summary>
    /// Gets the next track in the list, or ends the game if the current track is the last.
    /// </summary>
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

    /// <summary>
    /// Resets game parameters to default values.
    /// </summary>
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

    /// <summary>
    /// Handles case where user fails to guess artist in the given amount of time.
    /// </summary>
    /// <returns></returns>
    public async Task Timeout()
    {
        Guessing = true;

        var artists = await GetArtistDetails(CurrentTrack!.Artists.Select(x => x.Id));

        CurrentTrack.Album = await GetAlbumDetails(CurrentTrack.Album!.Id);
        CurrentTrack.Artists = artists.Where(x => CurrentTrack.Artists.Any(a => a.Id == x.Id)).ToArray();

        Guesses.Add(new GuessResult(CurrentTrack));

        PlayTrack = false;
        Guessing = false;
    }

    /// <summary>
    /// Queries the Spotify API for album details
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    private async Task<Album> GetAlbumDetails(string id)
    {
        var response = await _spotify.GetAlbumById(id);
        return response.Content!;
    }

    /// <summary>
    /// Queries the Spotify API for artist details
    /// </summary>
    /// <param name="ids"></param>
    /// <returns></returns>
    private async Task<Artist[]> GetArtistDetails(IEnumerable<string> ids)
    {
        var response = await _spotify.GetArtists(ids);
        return response.Content!.Artists;
    }

}
