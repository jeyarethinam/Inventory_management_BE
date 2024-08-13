using InventoryManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace InventoryManager.DataContext
{
    public class InventoryDbContext: DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options)
        : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; } = null!;
        public DbSet<Purchase> Purchases { get; set; } = null!;
        public DbSet<Supplier> Supplier { get; set; } = null!;
        public DbSet<Order> Order { get; set; } = null!;

    }
}
