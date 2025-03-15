using server.Models;

namespace server.Data.SeedData;

public static class SaleSeedData
{
    public static List<Sale> GetSales()
    {
        return new List<Sale>
        {
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
            },
            // Additional mock sales for pagination testing
            // June 2023
            new Sale
            {
                Id = 4,
                ProductId = 4,
                SalespersonId = 1,
                CustomerId = 4,
                SalesDate = new DateTime(2023, 6, 10),
                SalePrice = 1399.99m,
                CommissionAmount = 126.00m // 9% of 1399.99
            },
            new Sale
            {
                Id = 5,
                ProductId = 5,
                SalespersonId = 2,
                CustomerId = 5,
                SalesDate = new DateTime(2023, 6, 15),
                SalePrice = 1999.99m,
                CommissionAmount = 220.00m // 11% of 1999.99
            },
            new Sale
            {
                Id = 6,
                ProductId = 6,
                SalespersonId = 3,
                CustomerId = 6,
                SalesDate = new DateTime(2023, 6, 20),
                SalePrice = 2499.99m,
                CommissionAmount = 337.50m // 13.5% of 2499.99
            },
            // July 2023
            new Sale
            {
                Id = 7,
                ProductId = 7,
                SalespersonId = 4,
                CustomerId = 7,
                SalesDate = new DateTime(2023, 7, 5),
                SalePrice = 3599.99m,
                CommissionAmount = 540.00m // 15% of 3599.99
            },
            new Sale
            {
                Id = 8,
                ProductId = 8,
                SalespersonId = 5,
                CustomerId = 8,
                SalesDate = new DateTime(2023, 7, 10),
                SalePrice = 999.99m,
                CommissionAmount = 75.00m // 7.5% of 999.99
            },
            new Sale
            {
                Id = 9,
                ProductId = 9,
                SalespersonId = 6,
                CustomerId = 9,
                SalesDate = new DateTime(2023, 7, 15),
                SalePrice = 1199.99m,
                CommissionAmount = 96.00m // 8% of 1199.99
            },
            new Sale
            {
                Id = 10,
                ProductId = 10,
                SalespersonId = 7,
                CustomerId = 10,
                SalesDate = new DateTime(2023, 7, 20),
                SalePrice = 1899.99m,
                CommissionAmount = 218.50m // 11.5% of 1899.99
            },
            // August 2023
            new Sale
            {
                Id = 11,
                ProductId = 11,
                SalespersonId = 8,
                CustomerId = 11,
                SalesDate = new DateTime(2023, 8, 5),
                SalePrice = 1599.99m,
                CommissionAmount = 160.00m // 10% of 1599.99
            },
            new Sale
            {
                Id = 12,
                ProductId = 12,
                SalespersonId = 9,
                CustomerId = 12,
                SalesDate = new DateTime(2023, 8, 10),
                SalePrice = 2299.99m,
                CommissionAmount = 287.50m // 12.5% of 2299.99
            },
            new Sale
            {
                Id = 13,
                ProductId = 13,
                SalespersonId = 10,
                CustomerId = 13,
                SalesDate = new DateTime(2023, 8, 15),
                SalePrice = 499.99m,
                CommissionAmount = 30.00m // 6% of 499.99
            },
            // September 2023
            new Sale
            {
                Id = 14,
                ProductId = 14,
                SalespersonId = 11,
                CustomerId = 14,
                SalesDate = new DateTime(2023, 9, 5),
                SalePrice = 2399.99m,
                CommissionAmount = 312.00m // 13% of 2399.99
            },
            new Sale
            {
                Id = 15,
                ProductId = 15,
                SalespersonId = 12,
                CustomerId = 15,
                SalesDate = new DateTime(2023, 9, 10),
                SalePrice = 2299.99m,
                CommissionAmount = 287.50m // 12.5% of 2299.99
            },
            // October 2023
            new Sale
            {
                Id = 16,
                ProductId = 16,
                SalespersonId = 13,
                CustomerId = 16,
                SalesDate = new DateTime(2023, 10, 5),
                SalePrice = 2999.99m,
                CommissionAmount = 420.00m // 14% of 2999.99
            },
            new Sale
            {
                Id = 17,
                ProductId = 17,
                SalespersonId = 14,
                CustomerId = 17,
                SalesDate = new DateTime(2023, 10, 10),
                SalePrice = 1999.99m,
                CommissionAmount = 220.00m // 11% of 1999.99
            },
            // November 2023
            new Sale
            {
                Id = 18,
                ProductId = 18,
                SalespersonId = 15,
                CustomerId = 18,
                SalesDate = new DateTime(2023, 11, 5),
                SalePrice = 2599.99m,
                CommissionAmount = 351.00m // 13.5% of 2599.99
            },
            new Sale
            {
                Id = 19,
                ProductId = 19,
                SalespersonId = 1,
                CustomerId = 19,
                SalesDate = new DateTime(2023, 11, 10),
                SalePrice = 799.99m,
                CommissionAmount = 56.00m // 7% of 799.99
            },
            // December 2023
            new Sale
            {
                Id = 20,
                ProductId = 20,
                SalespersonId = 2,
                CustomerId = 20,
                SalesDate = new DateTime(2023, 12, 5),
                SalePrice = 3299.99m,
                CommissionAmount = 511.50m // 15.5% of 3299.99
            },
            new Sale
            {
                Id = 21,
                ProductId = 21,
                SalespersonId = 3,
                CustomerId = 21,
                SalesDate = new DateTime(2023, 12, 10),
                SalePrice = 3899.99m,
                CommissionAmount = 624.00m // 16% of 3899.99
            },
            // January 2024
            new Sale
            {
                Id = 22,
                ProductId = 22,
                SalespersonId = 4,
                CustomerId = 22,
                SalesDate = new DateTime(2024, 1, 5),
                SalePrice = 899.99m,
                CommissionAmount = 63.00m // 7% of 899.99
            },
            new Sale
            {
                Id = 23,
                ProductId = 23,
                SalespersonId = 5,
                CustomerId = 23,
                SalesDate = new DateTime(2024, 1, 10),
                SalePrice = 1299.99m,
                CommissionAmount = 110.50m // 8.5% of 1299.99
            },
            // February 2024
            new Sale
            {
                Id = 24,
                ProductId = 24,
                SalespersonId = 6,
                CustomerId = 24,
                SalesDate = new DateTime(2024, 2, 5),
                SalePrice = 2799.99m,
                CommissionAmount = 392.00m // 14% of 2799.99
            },
            new Sale
            {
                Id = 25,
                ProductId = 25,
                SalespersonId = 7,
                CustomerId = 25,
                SalesDate = new DateTime(2024, 2, 10),
                SalePrice = 1899.99m,
                CommissionAmount = 209.00m // 11% of 1899.99
            },
            // March 2024
            new Sale
            {
                Id = 26,
                ProductId = 1,
                SalespersonId = 8,
                CustomerId = 26,
                SalesDate = new DateTime(2024, 3, 5),
                SalePrice = 1499.99m,
                CommissionAmount = 157.50m // 10.5% of 1499.99
            },
            new Sale
            {
                Id = 27,
                ProductId = 2,
                SalespersonId = 9,
                CustomerId = 27,
                SalesDate = new DateTime(2024, 3, 10),
                SalePrice = 2199.99m,
                CommissionAmount = 264.00m // 12% of 2199.99
            },
            // April 2024
            new Sale
            {
                Id = 28,
                ProductId = 3,
                SalespersonId = 10,
                CustomerId = 28,
                SalesDate = new DateTime(2024, 4, 5),
                SalePrice = 1299.99m,
                CommissionAmount = 110.50m // 8.5% of 1299.99
            },
            new Sale
            {
                Id = 29,
                ProductId = 4,
                SalespersonId = 11,
                CustomerId = 29,
                SalesDate = new DateTime(2024, 4, 10),
                SalePrice = 1399.99m,
                CommissionAmount = 126.00m // 9% of 1399.99
            },
            // May 2024
            new Sale
            {
                Id = 30,
                ProductId = 5,
                SalespersonId = 12,
                CustomerId = 30,
                SalesDate = new DateTime(2024, 5, 5),
                SalePrice = 1999.99m,
                CommissionAmount = 220.00m // 11% of 1999.99
            },
            // June 2024
            new Sale
            {
                Id = 31,
                ProductId = 6,
                SalespersonId = 13,
                CustomerId = 1,
                SalesDate = new DateTime(2024, 6, 5),
                SalePrice = 2499.99m,
                CommissionAmount = 337.50m // 13.5% of 2499.99
            },
            new Sale
            {
                Id = 32,
                ProductId = 7,
                SalespersonId = 14,
                CustomerId = 2,
                SalesDate = new DateTime(2024, 6, 10),
                SalePrice = 3599.99m,
                CommissionAmount = 540.00m // 15% of 3599.99
            },
            // July 2024
            new Sale
            {
                Id = 33,
                ProductId = 8,
                SalespersonId = 15,
                CustomerId = 3,
                SalesDate = new DateTime(2024, 7, 5),
                SalePrice = 999.99m,
                CommissionAmount = 75.00m // 7.5% of 999.99
            },
            new Sale
            {
                Id = 34,
                ProductId = 9,
                SalespersonId = 1,
                CustomerId = 4,
                SalesDate = new DateTime(2024, 7, 10),
                SalePrice = 1199.99m,
                CommissionAmount = 96.00m // 8% of 1199.99
            },
            // August 2024
            new Sale
            {
                Id = 35,
                ProductId = 10,
                SalespersonId = 2,
                CustomerId = 5,
                SalesDate = new DateTime(2024, 8, 5),
                SalePrice = 1899.99m,
                CommissionAmount = 218.50m // 11.5% of 1899.99
            },
            new Sale
            {
                Id = 36,
                ProductId = 11,
                SalespersonId = 3,
                CustomerId = 6,
                SalesDate = new DateTime(2024, 8, 10),
                SalePrice = 1599.99m,
                CommissionAmount = 160.00m // 10% of 1599.99
            },
            // September 2024
            new Sale
            {
                Id = 37,
                ProductId = 12,
                SalespersonId = 4,
                CustomerId = 7,
                SalesDate = new DateTime(2024, 9, 5),
                SalePrice = 2299.99m,
                CommissionAmount = 287.50m // 12.5% of 2299.99
            },
            new Sale
            {
                Id = 38,
                ProductId = 13,
                SalespersonId = 5,
                CustomerId = 8,
                SalesDate = new DateTime(2024, 9, 10),
                SalePrice = 499.99m,
                CommissionAmount = 30.00m // 6% of 499.99
            },
            // October 2024
            new Sale
            {
                Id = 39,
                ProductId = 14,
                SalespersonId = 6,
                CustomerId = 9,
                SalesDate = new DateTime(2024, 10, 5),
                SalePrice = 2399.99m,
                CommissionAmount = 312.00m // 13% of 2399.99
            },
            new Sale
            {
                Id = 40,
                ProductId = 15,
                SalespersonId = 7,
                CustomerId = 10,
                SalesDate = new DateTime(2024, 10, 10),
                SalePrice = 2299.99m,
                CommissionAmount = 287.50m // 12.5% of 2299.99
            },
            // November 2024
            new Sale
            {
                Id = 41,
                ProductId = 16,
                SalespersonId = 8,
                CustomerId = 11,
                SalesDate = new DateTime(2024, 11, 5),
                SalePrice = 2999.99m,
                CommissionAmount = 420.00m // 14% of 2999.99
            },
            new Sale
            {
                Id = 42,
                ProductId = 17,
                SalespersonId = 9,
                CustomerId = 12,
                SalesDate = new DateTime(2024, 11, 10),
                SalePrice = 1999.99m,
                CommissionAmount = 220.00m // 11% of 1999.99
            },
            // December 2024
            new Sale
            {
                Id = 43,
                ProductId = 18,
                SalespersonId = 10,
                CustomerId = 13,
                SalesDate = new DateTime(2024, 12, 5),
                SalePrice = 2599.99m,
                CommissionAmount = 351.00m // 13.5% of 2599.99
            },
            new Sale
            {
                Id = 44,
                ProductId = 19,
                SalespersonId = 11,
                CustomerId = 14,
                SalesDate = new DateTime(2024, 12, 10),
                SalePrice = 799.99m,
                CommissionAmount = 56.00m // 7% of 799.99
            },
            // January 2025
            new Sale
            {
                Id = 45,
                ProductId = 20,
                SalespersonId = 12,
                CustomerId = 15,
                SalesDate = new DateTime(2025, 1, 5),
                SalePrice = 3299.99m,
                CommissionAmount = 511.50m // 15.5% of 3299.99
            },
            new Sale
            {
                Id = 46,
                ProductId = 21,
                SalespersonId = 13,
                CustomerId = 16,
                SalesDate = new DateTime(2025, 1, 10),
                SalePrice = 3899.99m,
                CommissionAmount = 624.00m // 16% of 3899.99
            },
            // February 2025
            new Sale
            {
                Id = 47,
                ProductId = 22,
                SalespersonId = 14,
                CustomerId = 17,
                SalesDate = new DateTime(2025, 2, 5),
                SalePrice = 899.99m,
                CommissionAmount = 63.00m // 7% of 899.99
            },
            new Sale
            {
                Id = 48,
                ProductId = 23,
                SalespersonId = 15,
                CustomerId = 18,
                SalesDate = new DateTime(2025, 2, 10),
                SalePrice = 1299.99m,
                CommissionAmount = 110.50m // 8.5% of 1299.99
            },
            // March 2025 (Current month)
            new Sale
            {
                Id = 49,
                ProductId = 24,
                SalespersonId = 1,
                CustomerId = 19,
                SalesDate = new DateTime(2025, 3, 5),
                SalePrice = 2799.99m,
                CommissionAmount = 392.00m // 14% of 2799.99
            },
            new Sale
            {
                Id = 50,
                ProductId = 25,
                SalespersonId = 2,
                CustomerId = 20,
                SalesDate = new DateTime(2025, 3, 10),
                SalePrice = 1899.99m,
                CommissionAmount = 209.00m // 11% of 1899.99
            }
        };
    }
}