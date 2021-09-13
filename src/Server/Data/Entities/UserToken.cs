using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Entities
{
    public class UserToken
    {
        public Guid Id { get; set; }
        [Required] public string Value { get; set; }
        public DateTime ExpiresOn { get; set; }
        public string RefreshToken { get; set; }
        [Required] public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
