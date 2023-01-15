using Microsoft.EntityFrameworkCore;
using ShekelAPI.Entities.Models;

namespace ShekelAPI.DAL.Data
{
    public class ShekelDbContext : DbContext, IShekelDbContext
    {
        public ShekelDbContext(DbContextOptions<ShekelDbContext> options) : base(options) { }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<FactoriesToCustomer> FactoriesToCustomers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().ToTable("Groups").HasKey(g => g.GroupName);
            modelBuilder.Entity<Customer>().ToTable("Customers").HasKey(c => c.CustomerId);
            modelBuilder.Entity<Factory>().ToTable("Factories").HasKey(f => f.FactoryCode);
            modelBuilder.Entity<FactoriesToCustomer>().HasKey(f => new { f.GroupCode, f.FactoryCode, f.CustomerId });
        }
    }
}
