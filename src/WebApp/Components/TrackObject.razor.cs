using Microsoft.AspNetCore.Components;
using Spotify.Models;

namespace WebApp.Components
{
    public partial class TrackObject
    {
        [Parameter] public Track Track { get; set; } = null!;
        [Parameter] public bool IsCorrect { get; set; }
    }
}
