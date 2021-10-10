using Microsoft.AspNetCore.Components;

namespace WebApp.Components
{
    public partial class MusicPlayer
    {
        [Parameter] public string? Url { get; set; }
    }
}
