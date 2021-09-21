using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Authentication;
using Server.Data;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                .ToListAsync(cancellationToken);

            List<GenreModel> models = new();
            foreach (var genre in genres)
            {
                var images = await _api.GetPlaylistCoverImage(genre.SpotifyPlaylistId);
                var image = images.First();

                models.Add(new GenreModel
                {
                    Id = genre.Id.ToString(),
                    Name = genre.Name,
                    CoverPhoto = new ImageModel
                    {
                        Height = image.Height,
                        Url = image.Url,
                        Width = image.Width
                    }
                });
            }

            return Ok(models);
        }

        [HttpGet("{genreId}")]
        public async Task<IActionResult> GetGenre(string genreId, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id.ToString() == genreId, cancellationToken);

            if (genre is null)
                return NotFound();

            return Ok(new GenreModel { Id = genre.Id.ToString(), Name = genre.Name });
        }

        [HttpGet("{genreId}/tracks")]
        public async Task<IActionResult> GetTracksByGenre(string genreId, [FromQuery] int? count, CancellationToken cancellationToken)
        {
            Console.WriteLine("GenreId is " + genreId);
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id.ToString() == genreId, cancellationToken);

            if (genre is null)
                return NotFound();

            var tracks = await _api.GetPlaylistTracks(genre.SpotifyPlaylistId);

            var models = tracks.Items
                .Where(x => !string.IsNullOrEmpty(x.Track.Preview_Url))
                .OrderBy(x => new Random().Next())
                .Take(count ?? 10)
                .Select(x => new TrackModel
                {
                    ArtistIds = x.Track.Artists.Select(a => a.Id).ToArray(),
                    Id = x.Track.Id,
                    Name = x.Track.Name,
                    PreviewUrl = x.Track.Preview_Url
                });

            return Ok(models);
        }
    }
}
