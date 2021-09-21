using System;

namespace Server.Data.Entities
{
    public class GameAnswer
    {
        public Guid Id { get; set; }

        public string SpotifyGuessId { get; set; }
        public double? GuessedIn { get; set; }

        public int GameQuestionId { get; set; }
        public GameQuestion GameQuestion { get; set; }
    }
}
