using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Entities
{
    public class GameAnswer
    {
        public Guid Id { get; set; }

        [Required] public string SpotifyTrackId { get; set; }
        [Required] public string SpotifyArtistId { get; set; }
        [Required] public string SpotifyGuessId { get; set; }
        public double? TimeGuessed { get; set; }
        public bool IsCorrect => SpotifyArtistId == SpotifyGuessId;

        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
