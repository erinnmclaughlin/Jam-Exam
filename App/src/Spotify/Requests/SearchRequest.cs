using Refit;
using System;
using System.Collections.Generic;

namespace Spotify.Requests
{
    public class SearchRequest
    {
        private int _limit = 20;

        [AliasAs("q")]
        public string? SearchText { get; set; }

        [AliasAs("type")]
        public List<string> Types { get; set; } = new();

        [AliasAs("limit")]
        public int Limit
        {
            get => _limit;
            set => _limit = Math.Max(Math.Min(value, 50), 1);
        }
    }
}
