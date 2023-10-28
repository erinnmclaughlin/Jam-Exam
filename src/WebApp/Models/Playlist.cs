namespace WebApp.Models;

public sealed class Playlist
{
    public int Id { get; set; }
    public required string SpotifyId { get; set; }
    public required string Name { get; set; }
}
