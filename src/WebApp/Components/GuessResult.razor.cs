using Spotify.Models;

namespace WebApp.Components
{
    public partial class GuessResult
    {
        private Models.GuessResult Result => GameService.LastGuessed!;
        public Track Track => Result.Track;
    }
}
