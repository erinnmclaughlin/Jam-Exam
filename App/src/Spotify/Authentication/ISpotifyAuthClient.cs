using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spotify.Authentication
{
    /// <summary>
    /// Refit client for the Spotify authentication API. Handles client-side authentication only.
    /// <list>
    /// <listheader>Helpful resources:</listheader>
    /// <item><see href="https://developer.spotify.com/documentation/general/guides/authorization-guide/">Spotify Auth API Documentation</see></item>
    /// <item><see href="https://github.com/reactiveui/refit">Refit</see></item>
    /// </list>
    /// </summary>
    internal interface ISpotifyAuthClient
    {
        [Post("/token")]
        Task<ApiResponse<TokenResponse>> RequestToken([Body(BodySerializationMethod.UrlEncoded)] TokenRequest request, [HeaderCollection] IDictionary<string, string> headers);
    }
}
