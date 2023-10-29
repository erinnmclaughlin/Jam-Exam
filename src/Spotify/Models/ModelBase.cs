using System.Text.Json.Serialization;

namespace Spotify.Models;

public class ModelBase
{
    [JsonPropertyName("href")]
    public string Href { get; set; } = null!;

    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("uri")]
    public string Uri { get; set; } = null!;
}
