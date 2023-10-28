using WebApp.Services;

namespace WebApp.Components
{
    public partial class Timer : IDisposable
    {
        private bool _forceStop;

        private int CurrentSeconds { get; set; }
        private string TimerText => new DateTime().AddSeconds(CurrentSeconds).ToString("mm:ss");

        public void Dispose()
        {
            _forceStop = true;
            GC.SuppressFinalize(this);
        }

        protected override async Task OnInitializedAsync()
        {
            CurrentSeconds = 30;
            await Countdown();
        }

        private async Task Countdown()
        {
            await Task.Delay(1000);
            CurrentSeconds--;
            await InvokeAsync(StateHasChanged);

            if (CurrentSeconds == 0)
            {
                await GameService.Timeout();
                return;
            }
            else if (GameService.PlayTrack == true && !_forceStop)
            {
                await Countdown();
            }
            
        }

        private int GetDashArray()
        {
            var timeFraction = CurrentSeconds / 30.0;
            return (int)(283 * timeFraction - (1.0 / 30.0) * (1.0 - timeFraction));
        }
    }
}
