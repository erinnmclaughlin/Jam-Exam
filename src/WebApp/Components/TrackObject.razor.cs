using Microsoft.AspNetCore.Components;
using Spotify.Models;
using WebApp.Models;

namespace WebApp.Components
{
    public partial class TrackObject
    {
        [Parameter] public GuessResultModel Result { get; set; } = null!;

        private Track Track => Result.Track;
    }
}
