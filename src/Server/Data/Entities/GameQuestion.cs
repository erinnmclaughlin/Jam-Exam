using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Entities
{
    public class GameQuestion
    {
        public Guid Id { get; set; }

        [Required] public string SpotifyTrackId { get; set; }
        [Required] public string SpotifyArtistId { get; set; }

        public Guid GameId { get; set; }
        public Game Game { get; set; }
    }
}
