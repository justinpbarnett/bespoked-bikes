using Microsoft.EntityFrameworkCore;
using server.Data.SeedData;
using server.Models;

namespace server.Infrastructure.Data.SeedData;

public static class DbSeeder
{
    public static void SeedDatabase(ModelBuilder modelBuilder)
    {
        // Get all seed data from individual seed data files
        var products = ProductSeedData.GetProducts();
        var salespersons = SalespersonSeedData.GetSalespersons();
        var customers = CustomerSeedData.GetCustomers();
        var discounts = DiscountSeedData.GetDiscounts();
        var sales = SaleSeedData.GetSales();

        // Seed the data into the model builder
        modelBuilder.Entity<Product>().HasData(products);
        modelBuilder.Entity<Salesperson>().HasData(salespersons);
        modelBuilder.Entity<Customer>().HasData(customers);
        modelBuilder.Entity<Discount>().HasData(discounts);
        modelBuilder.Entity<Sale>().HasData(sales);
    }
}