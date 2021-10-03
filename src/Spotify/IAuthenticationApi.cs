using Refit;
using Spotify.Authentication;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spotify
{
    public interface IAuthenticationApi
    {
        [Post("/token")]
        Task<ApiResponse<TokenResponse>> RequestToken([Body(BodySerializationMethod.UrlEncoded)] TokenRequest request, [HeaderCollection] IDictionary<string, string> headers);
    }
}
