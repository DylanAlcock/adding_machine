using Microsoft.EntityFrameworkCore;

namespace AddingMachine.Models
{
    public class HistoryDbContext : DbContext
    {
        public HistoryDbContext(DbContextOptions<HistoryDbContext> options) : base(options)
        {

        }

        public DbSet<History> History { get; set; }
    }
}
