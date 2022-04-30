using Microsoft.EntityFrameworkCore;

namespace HighGradeInventory.API.Models.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)    
        {

        }

        public DbSet<Account>? Accounts { get; set; }
        public DbSet<Inventory>? Inventories { get; set; }
        public DbSet<Stock>? Stocks { get; set; }
    }
}