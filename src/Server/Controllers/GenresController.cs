using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Server.Authentication;
using Server.Data;
using Server.Models;
using Shared.Models;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController, JamAuthorizationFilter]
    public class GenresController : ControllerBase
    {
        private readonly ISpotifyApi _api;
        private readonly JamContext _context;

        public GenresController(ISpotifyApi api, JamContext context)
        {
            _api = api;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetGenres(CancellationToken cancellationToken)
        {
            var genres = await _context.Genres
                .Select(x => new GenreModel
                {
                    Id = x.Id.ToString(),
                    Name = x.Name
                })
                .ToListAsync(cancellationToken);

            return Ok(genres);
        }

        [HttpGet("{genreId}")]
        public async Task<IActionResult> GetPlaylistByGenre(string genreId, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id.ToString() == genreId, cancellationToken);

            if (genre is null)
                return NotFound();

            var playlist = await _api.GetPlaylist(genre.SpotifyPlaylistId);

            return Ok(new PlaylistModel { Id = playlist.Id, Name = playlist.Name, Description = playlist.Description });
        }
    }
}
