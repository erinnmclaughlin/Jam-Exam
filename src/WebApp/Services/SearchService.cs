using Spotify;
using Spotify.Models;
using Spotify.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class SearchService
    {
        private readonly ISpotifyClient _spotify;

        public SearchService(ISpotifyClient spotify)
        {
            _spotify = spotify;
        }

        public async Task<IEnumerable<Artist>?> SearchArtists(string searchText)
        {
            var response = await _spotify.Search(new SearchRequest
            {
                Limit = 5,
                SearchText = searchText,
                Types = new List<string> { "artist" }
            });

            return response.Content?.Artists?.Items;
        }
    }
}
