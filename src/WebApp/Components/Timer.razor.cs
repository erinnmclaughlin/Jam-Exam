using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace WebApp.Components
{
    public partial class Timer
    {
        [Parameter] public int TotalSeconds { get; set; }
        [Parameter] public EventCallback OnTimeOut { get; set; }

        private int CurrentSeconds { get; set; }
        private string TimerText => new DateTime().AddSeconds(CurrentSeconds).ToString("mm:ss");

        protected override async Task OnInitializedAsync()
        {
            CurrentSeconds = TotalSeconds;
            await Countdown();
        }

        private async Task Countdown()
        {
            await Task.Delay(1000);
            CurrentSeconds--;
            StateHasChanged();

            if (CurrentSeconds == 0)
                await OnTimeOut.InvokeAsync();
            else
                await Countdown();
        }

        private int GetDashArray()
        {
            var timeFraction = (double)CurrentSeconds / TotalSeconds;
            return (int)(283 * timeFraction - (1.0 / TotalSeconds) * (1.0 - timeFraction));
        }
    }
}
