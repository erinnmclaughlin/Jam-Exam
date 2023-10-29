using Microsoft.Extensions.Options;
using Spotify;
using Spotify.Models;

namespace WebApp.Services;

public sealed class PlaylistService
{
    private readonly Dictionary<string, Playlist> _playlists = new();

    private readonly IOptionsMonitor<GameSettings> _settings;
    private readonly ISpotifyClient _spotify;

    public PlaylistService(IOptionsMonitor<GameSettings> settings, ISpotifyClient spotify)
    {
        _settings = settings;
        _spotify = spotify;
    }

    /// <summary>
    /// Gets a list of playlists supported by the app.
    /// </summary>
    public async Task<Playlist[]> GetPlaylistsAsync(CancellationToken cancellationToken = default)
    {
        var playlistIds = _settings.CurrentValue.PlaylistIds;

        foreach (var id in playlistIds)
        {
            if (_playlists.ContainsKey(id))
                continue;

            var response = await _spotify.GetPlaylistById(id, cancellationToken);

            if (response.Content is { } playlist)
                _playlists.Add(id, playlist);

            if (cancellationToken.IsCancellationRequested)
                break;
        }

        return _playlists.Select(p => p.Value).ToArray();
    }
}
