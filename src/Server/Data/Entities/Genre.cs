using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Entities
{
    public class Genre
    {
        public Guid Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public string SpotifyPlaylistId { get; set; }
    }
}
