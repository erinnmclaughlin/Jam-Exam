using Refit;
using Shared.Authentication;
using Shared.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Client
{
    public interface IJamApi
    {
        [Get("/authorize-url")]
        Task<string> GetSpotifyAuthUrl();

        [Get("/token")]
        Task<Token> GetToken(string code);

        [Get("/genres")]
        Task<List<GenreModel>> GetGenres();

    }
}
