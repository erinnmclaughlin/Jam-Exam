using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Server.Authentication;
using Server.Data;
using Shared.Models;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController, JamAuthorizationFilter]
    public class GenresController : ControllerBase
    {
        private readonly JamContext _context;

        public GenresController(JamContext context)
        {
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
    }
}
