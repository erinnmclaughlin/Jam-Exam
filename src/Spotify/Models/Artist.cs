﻿using System;
using System.Linq;
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

        public Image? GetImageWithClosestWidth(int width)
        {
            return Images?.Where(x => x.Width != null).OrderBy(x => Math.Abs(x.Width!.Value - width)).First();
        }
    }

    public class ArtistList
    {
        [JsonPropertyName("artists")]
        public Artist[] Artists { get; set; } = null!;
    }
}
