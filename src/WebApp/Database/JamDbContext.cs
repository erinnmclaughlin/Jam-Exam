using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Database
{
    public class JamDbContext : DbContext
    {
        public DbSet<HighScoreModel> HighScores => Set<HighScoreModel>();

        public JamDbContext(DbContextOptions<JamDbContext> options) : base(options)
        {
        }
    }
}
