using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class HighScoreModel
    {
        [Required (ErrorMessage = "You must enter a value!")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters!")]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters!")]
        [RegularExpression("^[a-zA-Z -]*$", ErrorMessage = "Name can contain only letters, whitespace, or hyphens.")]
        public string? Name { get; set; }

        public string PlaylistId { get; private set; }
        public int Correct { get; private set; }
        public int Total { get; private set; }

        public HighScoreModel(string playlistId, int correct, int total)
        {
            PlaylistId = playlistId;
            Correct = correct;
            Total = total;
        }
    }
}
