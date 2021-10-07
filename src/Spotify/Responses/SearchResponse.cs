using Spotify.Models;

namespace Spotify.Responses
{
    public class SearchResponse
    {
        public PagedResponse<Artist>? Artists { get; set; }
    }
}
