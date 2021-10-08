using Microsoft.AspNetCore.Components;
using WebApp.Models;

namespace WebApp.Components
{
    public partial class GuessResult
    {
        [Parameter] public EventCallback OnContinue { get; set; }
        [Parameter] public GuessResultModel? Result { get; set; }

        private string GetResultText() => Result!.IsCorrect ? "You guessed it!" : "Womp womp.";
    }
}
