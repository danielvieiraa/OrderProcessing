using Microsoft.EntityFrameworkCore;
using OrderProcessing.Domain.Entities;

namespace OrderProcessing.Infrastructure.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders => Set<Order>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(o => o.Id);

                entity.Property(o => o.CustomerName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(o => o.TotalAmount)
                    .IsRequired();
                
                entity.Property(o => o.Status)
                    .IsRequired();

                entity.Property(o => o.CreatedAt)
                    .IsRequired();
            });
        }
    }
}