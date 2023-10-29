using Microsoft.AspNetCore.Components;
using Spotify.Models;

namespace WebApp.Components;

public partial class TrackObject
{
    [Parameter] public Models.GuessResult Result { get; set; } = null!;

    private Track Track => Result.Track;
}
