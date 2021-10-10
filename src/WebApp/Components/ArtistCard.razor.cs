using Microsoft.AspNetCore.Components;
using Spotify.Models;

namespace WebApp.Components
{
    public partial class ArtistCard
    {
        [Parameter] public Artist Artist { get; set; } = null!;
    }
}
