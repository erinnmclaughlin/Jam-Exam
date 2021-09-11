using System;

namespace Server.Data.Entities
{
    public class Game
    {
        public Guid Id { get; set; }
        public DateTime StartedOn { get; set; }
        public DateTime? EndedOn { get; set; }

        public Guid GenreId { get; set; }
        public Genre Genre { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
