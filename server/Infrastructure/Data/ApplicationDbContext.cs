using Microsoft.EntityFrameworkCore;
using server.Models;
using server.Infrastructure.Data.SeedData;

namespace server.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products => Set<Product>();
    public DbSet<Salesperson> Salespersons => Set<Salesperson>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Sale> Sales => Set<Sale>();
    public DbSet<Discount> Discounts => Set<Discount>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ConfigureProduct(modelBuilder);
        ConfigureSalesperson(modelBuilder);

        DbSeeder.SeedDatabase(modelBuilder);
    }

    private static void ConfigureProduct(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasIndex(p => p.Name)
            .IsUnique();
    }

    private static void ConfigureSalesperson(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Salesperson>()
            .HasIndex(s => new { s.FirstName, s.LastName, s.Address })
            .IsUnique();

        modelBuilder.Entity<Salesperson>()
            .HasIndex(s => new { s.FirstName, s.LastName, s.Phone })
            .IsUnique();
    }
}