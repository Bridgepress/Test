using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Test.Domain.Entities;
using Test.Domain.Entities.Views;
using Test.Infrastructure.Persistence.Configurations;
using Test.Infrastructure.Persistence.SeedData;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Test.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<OrderView> OrderView { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderViewConfiguration());
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            SeedData(modelBuilder, this.Database);
        }

        private static void SeedData(ModelBuilder modelBuilder, DatabaseFacade database)
        {
            modelBuilder.Entity<Customer>().HasData(CustomerSeedData.Customers);
            modelBuilder.Entity<Order>().HasData(CustomerSeedData.Orders);
        }
    }
}
