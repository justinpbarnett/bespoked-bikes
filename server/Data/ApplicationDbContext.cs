using Microsoft.EntityFrameworkCore;
using server.Models;

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

        // Seed data
        SeedData(modelBuilder);
    }

    private void SeedData(ModelBuilder modelBuilder)
    {
        // Seed Products
        modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Mountain Explorer 5000",
                Manufacturer = "Trek",
                Style = "Mountain",
                PurchasePrice = 899.99m,
                SalePrice = 1499.99m,
                QuantityOnHand = 10,
                CommissionPercentage = 10.5m
            },
            new Product
            {
                Id = 2,
                Name = "Road Master Elite",
                Manufacturer = "Specialized",
                Style = "Road",
                PurchasePrice = 1200m,
                SalePrice = 2199.99m,
                QuantityOnHand = 7,
                CommissionPercentage = 12.0m
            },
            new Product
            {
                Id = 3,
                Name = "City Cruiser Deluxe",
                Manufacturer = "Giant",
                Style = "Urban",
                PurchasePrice = 750m,
                SalePrice = 1299.99m,
                QuantityOnHand = 15,
                CommissionPercentage = 8.5m
            },
            new Product
            {
                Id = 4,
                Name = "Hybrid Sport 700C",
                Manufacturer = "Cannondale",
                Style = "Hybrid",
                PurchasePrice = 850m,
                SalePrice = 1399.99m,
                QuantityOnHand = 12,
                CommissionPercentage = 9.0m
            }
        );

        // Seed Salespersons
        modelBuilder.Entity<Salesperson>().HasData(
            new Salesperson
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                Address = "123 Main St, Seattle, WA 98101",
                Phone = "206-555-1234",
                StartDate = new DateTime(2020, 1, 15),
                Manager = "Emily Brown"
            },
            new Salesperson
            {
                Id = 2,
                FirstName = "Sarah",
                LastName = "Johnson",
                Address = "456 Oak Ave, Seattle, WA 98102",
                Phone = "206-555-2345",
                StartDate = new DateTime(2019, 5, 20),
                Manager = "Emily Brown"
            },
            new Salesperson
            {
                Id = 3,
                FirstName = "Michael",
                LastName = "Davis",
                Address = "789 Pine St, Seattle, WA 98103",
                Phone = "206-555-3456",
                StartDate = new DateTime(2021, 3, 10),
                Manager = "Emily Brown"
            }
        );

        // Seed Customers
        modelBuilder.Entity<Customer>().HasData(
            new Customer
            {
                Id = 1,
                FirstName = "Robert",
                LastName = "Anderson",
                Address = "234 Elm St, Seattle, WA 98104",
                Phone = "206-555-4567",
                StartDate = new DateTime(2021, 2, 15)
            },
            new Customer
            {
                Id = 2,
                FirstName = "Jennifer",
                LastName = "Wilson",
                Address = "567 Cedar Ln, Seattle, WA 98105",
                Phone = "206-555-5678",
                StartDate = new DateTime(2020, 11, 8)
            },
            new Customer
            {
                Id = 3,
                FirstName = "David",
                LastName = "Thompson",
                Address = "890 Maple Dr, Seattle, WA 98106",
                Phone = "206-555-6789",
                StartDate = new DateTime(2021, 5, 22)
            }
        );

        // Seed Discounts
        modelBuilder.Entity<Discount>().HasData(
            new Discount
            {
                Id = 1,
                ProductId = 1,
                BeginDate = new DateTime(2023, 6, 1),
                EndDate = new DateTime(2023, 6, 30),
                DiscountPercentage = 15.0m
            },
            new Discount
            {
                Id = 2,
                ProductId = 2,
                BeginDate = new DateTime(2023, 7, 1),
                EndDate = new DateTime(2023, 7, 15),
                DiscountPercentage = 10.0m
            }
        );

        // Seed Sales
        modelBuilder.Entity<Sale>().HasData(
            new Sale
            {
                Id = 1,
                ProductId = 1,
                SalespersonId = 1,
                CustomerId = 1,
                SalesDate = new DateTime(2023, 5, 15),
                SalePrice = 1499.99m,
                CommissionAmount = 157.50m // 10.5% of 1499.99
            },
            new Sale
            {
                Id = 2,
                ProductId = 2,
                SalespersonId = 2,
                CustomerId = 2,
                SalesDate = new DateTime(2023, 5, 20),
                SalePrice = 2199.99m,
                CommissionAmount = 264.00m // 12% of 2199.99
            },
            new Sale
            {
                Id = 3,
                ProductId = 3,
                SalespersonId = 3,
                CustomerId = 3,
                SalesDate = new DateTime(2023, 6, 5),
                SalePrice = 1299.99m,
                CommissionAmount = 110.50m // 8.5% of 1299.99
            }
        );
    }
}