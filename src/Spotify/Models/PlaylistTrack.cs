using System;
using System.Text.Json.Serialization;

namespace Spotify.Models
{
    public class PlaylistTrack : ModelBase
    {
        [JsonPropertyName("added_at")]
        public DateTime AddedAt { get; set; }

        [JsonPropertyName("track")]
        public Track Track { get; set; } = null!;
    }
}
