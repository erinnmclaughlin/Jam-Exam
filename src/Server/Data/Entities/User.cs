using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        [Required] public string SpotifyUserId { get; set; }
        [Required] public string DisplayName { get; set; }
        [NotMapped] public string ProfileImageUrl { get; set; }
    }
}
