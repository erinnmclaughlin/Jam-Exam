using Shared.Enums;

namespace Shared.Models
{
    public class CreateGameModel
    {
        public Difficulty? Difficulty { get; set; }
        public int NumberOfQuestions { get; set; }
    }
}
