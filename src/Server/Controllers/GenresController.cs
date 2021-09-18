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

        [HttpPost("{genreId}/games")]
        public async Task<IActionResult> CreateGame(string genreId, CreateGameModel command, CancellationToken cancellationToken)
        {
            var genre = await _context.Genres.FirstOrDefaultAsync(x => x.Id.ToString() == genreId, cancellationToken);

            if (genre is null)
                return NotFound();

            // TODO: add to db
            //var game = new Game
            //{
            //    MaxAnswerTime = 30,
            //    GenreId = genre.Id,
            //    NumberOfQuestions = command.NumberOfQuestions,
            //    StartedOn = DateTime.UtcNow
            //};

            var playlist = await _api.GetPlaylistTracks(genre.SpotifyPlaylistId);
            var tracks = playlist.Items.Select(x => x.Track)
                .Where(x => x.Preview_Url != null)
                .OrderBy(x => new Random().Next())
                .Take(command.NumberOfQuestions)
                .Select(x => new TrackModel
                {
                    ArtistIds = x.Artists.Select(a => a.Id).ToArray(),
                    Id = x.Id,
                    Name = x.Name,
                    PreviewUrl = x.Preview_Url
                })
                .ToList();

            return Ok(tracks);
        }
    }
}
