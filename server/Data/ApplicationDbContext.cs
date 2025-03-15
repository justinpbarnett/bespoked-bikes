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

        // Configure unique constraints
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Name)
            .IsUnique();

        // Remove unique constraints on phone and address since family members
        // might share the same contact information

        // Set up unique constraint on FirstName and LastName for Salesperson
        modelBuilder.Entity<Salesperson>()
            .HasIndex(s => new { s.FirstName, s.LastName })
            .IsUnique();

        // Seed data from separate seed data files
        DbSeeder.SeedDatabase(modelBuilder);
    }
}