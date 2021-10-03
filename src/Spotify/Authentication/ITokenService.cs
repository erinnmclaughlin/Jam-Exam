using System.Threading.Tasks;

namespace Spotify.Authentication
{
    public interface ITokenService
    {
        Task<TokenResponse> GetTokenAsync();
    }
}