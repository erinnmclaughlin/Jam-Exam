using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spotify.Authentication
{
    internal interface ISpotifyAuthClient
    {
        [Post("/token")]
        Task<ApiResponse<TokenResponse>> RequestToken([Body(BodySerializationMethod.UrlEncoded)] TokenRequest request, [HeaderCollection] IDictionary<string, string> headers);
    }
}
