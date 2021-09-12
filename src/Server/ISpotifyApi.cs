using Refit;
using Server.Models;
using System.Threading.Tasks;

namespace Server
{
    public interface ISpotifyApi
    {
        [Get("me")]
        Task<SpotifyUserModel> GetCurrentUser();
    }
}
