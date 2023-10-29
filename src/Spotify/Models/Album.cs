using System.Text.Json.Serialization;

namespace Spotify.Models;

public class Album : ModelBase
{
    [JsonPropertyName("images")]
    public Image[]? Images { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("release_date")]
    public string? ReleaseDate { get; set; }

    [JsonPropertyName("total_tracks")]
    public int TotalTracks { get; set; }
}
