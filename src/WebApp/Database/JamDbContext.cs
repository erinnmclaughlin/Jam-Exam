using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Database;

public class JamDbContext : DbContext
{
    public DbSet<GameResult> GameResults => Set<GameResult>();

    public JamDbContext(DbContextOptions<JamDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GameResult>(builder =>
        {
            builder.Property(x => x.PlayerName).HasMaxLength(100);
            builder.HasIndex(x => x.PlayerName);
            builder.HasIndex(x => x.Timestamp);
        });
    }
}
