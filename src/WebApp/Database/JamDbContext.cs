using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Database
{
    public class JamDbContext : DbContext
    {
        public DbSet<HighScore> HighScores => Set<HighScore>();

        public JamDbContext(DbContextOptions<JamDbContext> options) : base(options)
        {
        }
    }
}
