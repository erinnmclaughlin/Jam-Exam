using System.Text.Json.Serialization;

namespace Spotify.Models
{
    public class Artist : ModelBase
    {
        [JsonPropertyName("genres")]
        public string[]? Genres { get; set; }

        [JsonPropertyName("images")]
        public Image[]? Images { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("popularity")]
        public int Popularity { get; set; }

        [JsonPropertyName("followers.total")]
        public int TotalFollowers { get; set; }
    }
}
