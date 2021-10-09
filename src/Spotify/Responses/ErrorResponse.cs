using System.Text.Json.Serialization;

namespace Spotify.Responses
{
    public class ErrorResponse
    {
        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }
    }
}
