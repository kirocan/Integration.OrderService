using Integration.OrderService.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Integration.OrderService.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasIndex(o => o.OrderId)
                .IsUnique();
        }
    }
}
