using Microsoft.EntityFrameworkCore;

namespace Adding_Machine.Models
{
    public class AddingMachineDbContext : DbContext
    {
        public AddingMachineDbContext(DbContextOptions<AddingMachineDbContext> options) : base(options)
        {

        }

        public DbSet<History> History { get; set; }
    }
}
