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

        /// <summary>
        /// Queries spotify API for artists.
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Artist>?> SearchArtists(string searchText, int limit = 5)
        {
            if (limit <= 0)
                limit = 1;

            var response = await _spotify.Search(new SearchRequest
            {
                Limit = limit,
                SearchText = searchText,
                Types = new List<string> { "artist" }
            });

            return response.Content?.Artists?.Items;
        }
    }
}
