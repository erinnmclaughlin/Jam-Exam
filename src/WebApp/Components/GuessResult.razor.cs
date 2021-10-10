using Spotify.Models;
using WebApp.Models;

namespace WebApp.Components
{
    public partial class GuessResult
    {
        private GuessResultModel Result => GameService.LastGuessed!;
        public Track Track => Result.Track;

        private string GetResultText()
        {
            if (Result.GuessedArtist is null)
                return "Times up!";

            return Result.IsCorrect ? "You guessed it!" : "Womp womp.";
        }
    }
}
