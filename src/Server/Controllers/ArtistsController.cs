using Microsoft.AspNetCore.Mvc;
using Shared.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private readonly ISpotifyApi _api;

        public ArtistsController(ISpotifyApi api)
        {
            _api = api;
        }

        [HttpGet]
        public async Task<IActionResult> SearchArtist(string searchText, int limit = 20)
        {
            var result = await _api.Search(searchText, "artist", limit);
            
            foreach (var artist in result.Artists.Items)
            {
                Console.WriteLine(artist.Name);
            }

            var artists = result.Artists.Items.Select(x => new ArtistModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return Ok(artists);
        }

        [HttpGet("{artistId}")]
        public async Task<IActionResult> GetArtistDetails(string artistId)
        {
            return NoContent();
        }
    }
}
