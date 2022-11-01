using Microsoft.EntityFrameworkCore;

namespace AddingMachine.Models
{
    /// <summary>
    /// Context for connecting to the database
    /// </summary>
    public class HistoryDbContext : DbContext
    {
        public HistoryDbContext(DbContextOptions<HistoryDbContext> options) : base(options) { }

        public DbSet<History> History { get; set; }
    }
}
