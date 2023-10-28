using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Database
{
    public class JamDbContext : DbContext
    {
        public DbSet<Playlist> Playlists => Set<Playlist>();
        public DbSet<GameResult> GameResults => Set<GameResult>();
        public DbSet<HighScore> HighScores => Set<HighScore>();

        public JamDbContext(DbContextOptions<JamDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Playlist>(builder =>
            {
                builder.Property(x => x.SpotifyId).HasMaxLength(100);
                builder.Property(x => x.Name).HasMaxLength(100);
                builder.HasIndex(x => x.SpotifyId).IsUnique();

                builder.HasData(new Playlist[]
                {
                    new() { Id = 1, SpotifyId = "37i9dQZF1DWXRqgorJj26U", Name = "Classic Rock" },
                    new() { Id = 2, SpotifyId = "37i9dQZF1DX2Nc3B70tvx0", Name = "Indie" },
                    new() { Id = 3, SpotifyId = "37i9dQZF1DXcBWIGoYBM5M", Name = "Pop" },
                    new() { Id = 4, SpotifyId = "37i9dQZF1DX0XUsuxWHRQd", Name = "Hip Hop" },
                    new() { Id = 5, SpotifyId = "37i9dQZF1DX1lVhptIYRda", Name = "Country" },
                    new() { Id = 6, SpotifyId = "37i9dQZF1DWWzBc3TOlaAV", Name = "1960's" },
                    new() { Id = 7, SpotifyId = "37i9dQZF1DWTJ7xPn4vNaz", Name = "1970's" },
                    new() { Id = 8, SpotifyId = "37i9dQZF1DX4UtSsGT1Sbe", Name = "1980's" },
                    new() { Id = 9, SpotifyId = "37i9dQZF1DXbTxeAdrVG2l", Name = "1990's" },
                    new() { Id = 10, SpotifyId = "37i9dQZF1DX4o1oenSJRJd", Name = "2000's" },
                    new() { Id = 11, SpotifyId = "6i2Qd6OpeRBAzxfscNXeWp", Name = "All Time Hits" }
                });
            });

            modelBuilder.Entity<GameResult>(builder =>
            {
                builder.Property(x => x.PlayerName).HasMaxLength(100);
                builder.HasIndex(x => x.PlayerName);
                builder.HasIndex(x => x.Timestamp);
            });
        }
    }
}
