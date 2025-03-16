using server.Models;

namespace server.Data.SeedData;

public static class ProductSeedData
{
    public static List<Product> GetProducts()
    {
        return new List<Product>
        {
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
            },
            new Product
            {
                Id = 5,
                Name = "Electric City Pro",
                Manufacturer = "Rad Power Bikes",
                Style = "Electric",
                PurchasePrice = 1200m,
                SalePrice = 1999.99m,
                QuantityOnHand = 8,
                CommissionPercentage = 11.0m
            },
            new Product
            {
                Id = 6,
                Name = "Mountain Trail X2",
                Manufacturer = "Santa Cruz",
                Style = "Mountain",
                PurchasePrice = 1500m,
                SalePrice = 2499.99m,
                QuantityOnHand = 5,
                CommissionPercentage = 13.5m
            },
            new Product
            {
                Id = 7,
                Name = "Speed Demon Racing",
                Manufacturer = "Cervélo",
                Style = "Road",
                PurchasePrice = 2000m,
                SalePrice = 3599.99m,
                QuantityOnHand = 0,
                CommissionPercentage = 15.0m
            },
            new Product
            {
                Id = 8,
                Name = "Comfort Cruiser Plus",
                Manufacturer = "Electra",
                Style = "Cruiser",
                PurchasePrice = 600m,
                SalePrice = 999.99m,
                QuantityOnHand = 20,
                CommissionPercentage = 7.5m
            },
            new Product
            {
                Id = 9,
                Name = "Urban Commuter X3",
                Manufacturer = "Trek",
                Style = "Urban",
                PurchasePrice = 700m,
                SalePrice = 1199.99m,
                QuantityOnHand = 14,
                CommissionPercentage = 8.0m
            },
            new Product
            {
                Id = 10,
                Name = "Trail Blazer Pro",
                Manufacturer = "Specialized",
                Style = "Mountain",
                PurchasePrice = 1100m,
                SalePrice = 1899.99m,
                QuantityOnHand = 6,
                CommissionPercentage = 11.5m
            },
            new Product
            {
                Id = 11,
                Name = "Folding City Bike",
                Manufacturer = "Brompton",
                Style = "Folding",
                PurchasePrice = 950m,
                SalePrice = 1599.99m,
                QuantityOnHand = 9,
                CommissionPercentage = 10.0m
            },
            new Product
            {
                Id = 12,
                Name = "Gravel Adventure X1",
                Manufacturer = "Salsa",
                Style = "Gravel",
                PurchasePrice = 1300m,
                SalePrice = 2299.99m,
                QuantityOnHand = 7,
                CommissionPercentage = 12.5m
            },
            new Product
            {
                Id = 13,
                Name = "Kids Explorer 24",
                Manufacturer = "Giant",
                Style = "Kids",
                PurchasePrice = 300m,
                SalePrice = 499.99m,
                QuantityOnHand = 25,
                CommissionPercentage = 6.0m
            },
            new Product
            {
                Id = 14,
                Name = "Cargo Hauler Max",
                Manufacturer = "Surly",
                Style = "Cargo",
                PurchasePrice = 1400m,
                SalePrice = 2399.99m,
                QuantityOnHand = 4,
                CommissionPercentage = 13.0m
            },
            new Product
            {
                Id = 15,
                Name = "Fat Tire Beast",
                Manufacturer = "Salsa",
                Style = "Fat Tire",
                PurchasePrice = 1350m,
                SalePrice = 2299.99m,
                QuantityOnHand = 6,
                CommissionPercentage = 12.5m
            },
            new Product
            {
                Id = 16,
                Name = "Road Racer Elite",
                Manufacturer = "Cannondale",
                Style = "Road",
                PurchasePrice = 1800m,
                SalePrice = 2999.99m,
                QuantityOnHand = 4,
                CommissionPercentage = 14.0m
            },
            new Product
            {
                Id = 17,
                Name = "Touring Adventure",
                Manufacturer = "Trek",
                Style = "Touring",
                PurchasePrice = 1200m,
                SalePrice = 1999.99m,
                QuantityOnHand = 8,
                CommissionPercentage = 11.0m
            },
            new Product
            {
                Id = 18,
                Name = "Electric Cruiser E1",
                Manufacturer = "Specialized",
                Style = "Electric",
                PurchasePrice = 1500m,
                SalePrice = 2599.99m,
                QuantityOnHand = 7,
                CommissionPercentage = 13.5m
            },
            new Product
            {
                Id = 19,
                Name = "BMX Stunt Pro",
                Manufacturer = "Haro",
                Style = "BMX",
                PurchasePrice = 450m,
                SalePrice = 799.99m,
                QuantityOnHand = 18,
                CommissionPercentage = 7.0m
            },
            new Product
            {
                Id = 20,
                Name = "Mountain Downhill Expert",
                Manufacturer = "Santa Cruz",
                Style = "Mountain",
                PurchasePrice = 1900m,
                SalePrice = 3299.99m,
                QuantityOnHand = 3,
                CommissionPercentage = 15.5m
            },
            new Product
            {
                Id = 21,
                Name = "Triathlon Champion",
                Manufacturer = "Cervélo",
                Style = "Triathlon",
                PurchasePrice = 2200m,
                SalePrice = 3899.99m,
                QuantityOnHand = 2,
                CommissionPercentage = 16.0m
            },
            new Product
            {
                Id = 22,
                Name = "Comfort City Plus",
                Manufacturer = "Electra",
                Style = "Urban",
                PurchasePrice = 550m,
                SalePrice = 899.99m,
                QuantityOnHand = 22,
                CommissionPercentage = 7.0m
            },
            new Product
            {
                Id = 23,
                Name = "Mountain Trail Lite",
                Manufacturer = "Giant",
                Style = "Mountain",
                PurchasePrice = 800m,
                SalePrice = 1299.99m,
                QuantityOnHand = 13,
                CommissionPercentage = 8.5m
            },
            new Product
            {
                Id = 24,
                Name = "Road Speed RS7",
                Manufacturer = "Trek",
                Style = "Road",
                PurchasePrice = 1650m,
                SalePrice = 2799.99m,
                QuantityOnHand = 5,
                CommissionPercentage = 14.0m
            },
            new Product
            {
                Id = 25,
                Name = "Electric City Commuter",
                Manufacturer = "Rad Power Bikes",
                Style = "Electric",
                PurchasePrice = 1100m,
                SalePrice = 1899.99m,
                QuantityOnHand = 9,
                CommissionPercentage = 11.0m
            }
        };
    }
}