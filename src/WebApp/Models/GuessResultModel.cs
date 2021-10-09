using Spotify.Models;
using System.Linq;

namespace WebApp.Models
{
    public class GuessResultModel
    {
        public Artist GuessedArtist { get; set; }
        public Track Track { get; set; }
        public bool IsCorrect => Track.Artists.Any(x => x.Id == GuessedArtist.Id);

        public GuessResultModel(Artist artist, Track track)
        {
            GuessedArtist = artist;
            Track = track;
        }
    }
}
