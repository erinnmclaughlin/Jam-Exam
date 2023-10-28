using Spotify.Models;
using System.Linq;

namespace WebApp.Models
{
    public class GuessResult
    {
        public Artist? GuessedArtist { get; set; }
        public Track Track { get; set; }
        public bool IsCorrect => GuessedArtist is not null && Track.Artists.Any(x => x.Id == GuessedArtist.Id);

        public GuessResult(Track track, Artist? artist = null)
        {
            Track = track;
            GuessedArtist = artist;
        }

        public string GetEmoji()
        {
            if (GuessedArtist is null)
                return "⏱️";

            return IsCorrect ? "✔️" : "❌";
        }
    }
}
