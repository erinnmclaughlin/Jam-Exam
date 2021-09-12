using Microsoft.EntityFrameworkCore;
using Server.Data.Entities;
using System;
using System.Collections.Generic;

namespace Server.Data
{
    public class JamContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<GameAnswer> GameAnswers { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }

        public JamContext(DbContextOptions<JamContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Seed db with some playlists made & owned by Spotify
            builder.Entity<Genre>().HasData(new List<Genre>
            {
                new Genre { Id = Guid.NewGuid(), Name = "Classic Rock", SpotifyPlaylistId = "37i9dQZF1DWXRqgorJj26U" },
                new Genre { Id = Guid.NewGuid(), Name = "Indie", SpotifyPlaylistId = "37i9dQZF1DX2Nc3B70tvx0" },
                new Genre { Id = Guid.NewGuid(), Name = "Pop", SpotifyPlaylistId = "37i9dQZF1DXcBWIGoYBM5M" },
                new Genre { Id = Guid.NewGuid(), Name = "Hip Hop", SpotifyPlaylistId = "37i9dQZF1DX0XUsuxWHRQd" },
                new Genre { Id = Guid.NewGuid(), Name = "Country", SpotifyPlaylistId = "37i9dQZF1DX1lVhptIYRda" },
                new Genre { Id = Guid.NewGuid(), Name = "1960s", SpotifyPlaylistId = "37i9dQZF1DWWzBc3TOlaAV" },
                new Genre { Id = Guid.NewGuid(), Name = "1970s", SpotifyPlaylistId = "37i9dQZF1DWTJ7xPn4vNaz" },
                new Genre { Id = Guid.NewGuid(), Name = "1980s", SpotifyPlaylistId = "37i9dQZF1DX4UtSsGT1Sbe" },
                new Genre { Id = Guid.NewGuid(), Name = "1990s", SpotifyPlaylistId = "37i9dQZF1DXbTxeAdrVG2l" },
                new Genre { Id = Guid.NewGuid(), Name = "2000s", SpotifyPlaylistId = "37i9dQZF1DX4o1oenSJRJd" },
            });
        }
    }
}
