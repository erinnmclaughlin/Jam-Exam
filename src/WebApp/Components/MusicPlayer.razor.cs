using Microsoft.AspNetCore.Components;

namespace WebApp.Components
{
    public partial class MusicPlayer
    {
        private bool _play;

        [Parameter] public string? Url { get; set; }

        public void Play()
        {
            _play = true;
            StateHasChanged();
        }

        public void Stop()
        {
            _play = false;
            StateHasChanged();
        }
    }
}
