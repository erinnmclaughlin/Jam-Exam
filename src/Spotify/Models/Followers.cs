using System.Text.Json.Serialization;

namespace Spotify.Models;

public class Followers
{
    [JsonPropertyName("total")]
    public int Total { get; set; }
}
