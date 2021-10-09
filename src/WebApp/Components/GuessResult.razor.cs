using Microsoft.AspNetCore.Components;
using Spotify.Models;
using WebApp.Models;

namespace WebApp.Components
{
    public partial class GuessResult
    {
        [Parameter] public EventCallback OnContinue { get; set; }
        [Parameter] public GuessResultModel Result { get; set; } = null!;

        public Track Track => Result.Track;

        private string GetResultText() => Result!.IsCorrect ? "You guessed it!" : "Womp womp.";
    }
}
