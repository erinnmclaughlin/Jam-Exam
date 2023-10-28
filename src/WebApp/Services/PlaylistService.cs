using Microsoft.EntityFrameworkCore;
using Spotify;
using Spotify.Models;
using WebApp.Database;

namespace WebApp.Services;

public sealed class PlaylistService
{
    private readonly List<Playlist> _inMemoryCache = new(); //TODO: Use local storage

    private readonly IDbContextFactory<JamDbContext> _dbContextFactory;
    private readonly ISpotifyClient _spotify;

    public PlaylistService(IDbContextFactory<JamDbContext> dbContextFactory, ISpotifyClient spotify)
    {
        _dbContextFactory = dbContextFactory;
        _spotify = spotify;
    }

    /// <summary>
    /// Gets a list of playlists supported by the app.
    /// </summary>
    public async Task<Playlist[]> LoadPlaylistsAsync()
    {
        if (_inMemoryCache.Count == 0)
        {
            var playlistIds = await GetPlaylistIdsAsync();

            foreach (var id in playlistIds)
            {
                var response = await _spotify.GetPlaylistById(id);

                if (response.Content is not null)
                    _inMemoryCache.Add(response.Content);
            }
        }

        return _inMemoryCache.ToArray();
    }

    private async Task<string[]> GetPlaylistIdsAsync()
    {
        using var dbContext = _dbContextFactory.CreateDbContext();
        return await dbContext.Playlists.Select(p => p.SpotifyId).ToArrayAsync();
    }
}
