using System;
using System.ComponentModel.DataAnnotations;

namespace Server.Data.Entities
{
    public class UserToken
    {
        public Guid Id { get; set; }
        [Required] public string Token { get; set; }
        public DateTime ExpiresOn { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
