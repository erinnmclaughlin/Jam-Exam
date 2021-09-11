using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        [Required] public string SpotifyUserId { get; set; }
        [Required] public string DisplayName { get; set; }
    }
}
