using Microsoft.EntityFrameworkCore;
using PokemonReviewApp.Models;
using Swiggy.Models;

namespace PokemonReviewApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
      
      
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<OrderItem>()
                    .HasKey(po => new { po.OrderId, po.CustomerId });
            modelBuilder.Entity<OrderItem>()
                    .HasOne(p => p.Order)
                    .WithMany(pc => pc.OrderItems)
                    .HasForeignKey(p => p.OrderId);
            modelBuilder.Entity<OrderItem>()
                    .HasOne(p => p.Customer)
                    .WithMany(pc => pc.OrderItems)
                    .HasForeignKey(c => c.CustomerId);
        }
    }
}
