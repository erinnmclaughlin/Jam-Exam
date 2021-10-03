using Spotify.Enums;
using System;
using System.Text.Json.Serialization;

namespace Spotify.Models
{
    public class Track : ModelBase
    {
        private int _duration;

        [JsonPropertyName("artists")]
        public Artist[] Artists { get; set; } = null!;

        [JsonPropertyName("duration_ms")]
        public int Duration
        {
            set => _duration = value;
        }

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("preview_url")]
        public string? PreviewUrl { get; set; }

        public double GetDuration(TimeUnit unit)
        {
            return unit switch
            {
                TimeUnit.Milliseconds => _duration,
                TimeUnit.Seconds =>      _duration / 1000.0,
                TimeUnit.Minutes =>      _duration / 1000.0 / 60.0,
                TimeUnit.Hours =>        _duration / 1000.0 / 60.0 / 60.0,
                _ => throw new NotSupportedException("Unit type not supported.")
            };
        }
    }
}
