using Spotify.Models;
using System.Linq;

namespace WebApp.Models
{
    public class GuessResultModel
    {
        public Artist? GuessedArtist { get; set; }
        public Track Track { get; set; }
        public bool IsCorrect => GuessedArtist is not null && Track.Artists.Any(x => x.Id == GuessedArtist.Id);

        public GuessResultModel(Track track, Artist? artist = null)
        {
            Track = track;
            GuessedArtist = artist;
        }
    }
}
