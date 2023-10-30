using Spotify.Models;

namespace WebApp.Services;

public sealed class Game
{
    private readonly Playlist _playlist;

    public Game(Playlist playlist)
    {
        _playlist = playlist;
    }


}
