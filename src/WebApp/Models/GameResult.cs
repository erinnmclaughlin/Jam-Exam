namespace WebApp.Models;

public sealed class GameResult
{
    public int Id { get; set; }
    public required string? PlayerName { get; set; }
    public required string PlaylistId { get; set; }
    public required int TotalCorrect { get; set; }
    public required int TotalGuessed { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}
