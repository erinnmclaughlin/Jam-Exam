using System.Text.Json.Serialization;

namespace Spotify.Models;

public class Playlist : ModelBase
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("images")]
    public Image[]? Images { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("followers.total")]
    public int TotalFollowers { get; set; }

    [JsonPropertyName("tracks.total")]
    public int TotalTracks { get; set; }
}
