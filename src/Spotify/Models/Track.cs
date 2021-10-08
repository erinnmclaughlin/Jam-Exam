using System.Text.Json.Serialization;

namespace Spotify.Models
{
    public class Track : ModelBase
    {
        [JsonPropertyName("artists")]
        public Artist[] Artists { get; set; } = null!;

        [JsonPropertyName("album")]
        public Album? Album { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("preview_url")]
        public string? PreviewUrl { get; set; }
    }
}
