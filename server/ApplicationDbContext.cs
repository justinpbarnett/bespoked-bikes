using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Data.SeedData;

namespace server.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Salesperson> Salespersons { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<Discount> Discounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Name)
            .IsUnique();

        modelBuilder.Entity<Salesperson>()
            .HasIndex(s => new { s.FirstName, s.LastName, s.Address })
            .IsUnique();

        modelBuilder.Entity<Salesperson>()
            .HasIndex(s => new { s.FirstName, s.LastName, s.Phone })
            .IsUnique();


        DbSeeder.SeedDatabase(modelBuilder);
    }
}