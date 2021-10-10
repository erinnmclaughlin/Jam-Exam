using Spotify.Models;
using WebApp.Models;

namespace WebApp.Components
{
    public partial class GuessResult
    {
        private GuessResultModel Result => GameService.LastGuessed!;
        public Track Track => Result.Track;
    }
}
