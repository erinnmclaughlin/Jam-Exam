using System.Text.Json.Serialization;

namespace Spotify.Responses
{
    public class PagedResponse<T> where T : class
    {
        [JsonPropertyName("href")]
        public string Href { get; set; } = null!;

        [JsonPropertyName("items")]
        public T[] Items { get; set; } = null!;

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("next")]
        public string? NextPage { get; set; }

        [JsonPropertyName("offset")]
        public int Offset { get; set; }

        [JsonPropertyName("previous")]
        public string? PreviousPage { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }
    }
}
