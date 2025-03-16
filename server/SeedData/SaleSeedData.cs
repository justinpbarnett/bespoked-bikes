using server.Models;

namespace server.Data.SeedData;

public static class SaleSeedData
{
    public static List<Sale> GetSales()
    {
        return new List<Sale>
        {
            // Sales without discounts
            new Sale
            {
                Id = 1,
                ProductId = 1,
                SalespersonId = 1,
                CustomerId = 1,
                SalesDate = new DateTime(2023, 5, 15),
                SalePrice = 1499.99m,
                CommissionAmount = 157.50m, // 10.5% of 1499.99
                OriginalPrice = 1499.99m,
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 2,
                ProductId = 2,
                SalespersonId = 2,
                CustomerId = 2,
                SalesDate = new DateTime(2023, 5, 20),
                SalePrice = 2199.99m,
                CommissionAmount = 264.00m, // 12% of 2199.99
                OriginalPrice = 2199.99m,
                AppliedDiscountPercentage = 0.0m
            },
            
            // Sales with product-specific automatic discounts
            new Sale
            {
                Id = 3,
                ProductId = 3,
                SalespersonId = 3,
                CustomerId = 3,
                SalesDate = new DateTime(2023, 8, 15),
                OriginalPrice = 1499.99m,
                SalePrice = 1312.49m, // 12.5% off
                CommissionAmount = 111.56m, // 8.5% of discounted price
                AppliedDiscountId = 3,
                AppliedDiscountPercentage = 12.5m
            },
            new Sale
            {
                Id = 4,
                ProductId = 4,
                SalespersonId = 1,
                CustomerId = 4,
                SalesDate = new DateTime(2023, 9, 10),
                OriginalPrice = 1599.99m,
                SalePrice = 1471.99m, // 8% off
                CommissionAmount = 132.48m, // 9% of discounted price
                AppliedDiscountId = 4,
                AppliedDiscountPercentage = 8.0m
            },
            new Sale
            {
                Id = 5,
                ProductId = 5,
                SalespersonId = 2,
                CustomerId = 5,
                SalesDate = new DateTime(2023, 10, 15),
                OriginalPrice = 2499.99m,
                SalePrice = 1999.99m, // 20% off
                CommissionAmount = 220.00m, // 11% of discounted price
                AppliedDiscountId = 5,
                AppliedDiscountPercentage = 20.0m
            },
            
            // Sales with global automatic discounts
            new Sale
            {
                Id = 6,
                ProductId = 6,
                SalespersonId = 3,
                CustomerId = 6,
                SalesDate = new DateTime(2023, 11, 27),
                OriginalPrice = 2999.99m,
                SalePrice = 2699.99m, // 10% off (Black Friday)
                CommissionAmount = 364.50m, // 13.5% of discounted price
                AppliedDiscountId = 16,
                AppliedDiscountPercentage = 10.0m
            },
            new Sale
            {
                Id = 7,
                ProductId = 7,
                SalespersonId = 4,
                CustomerId = 7,
                SalesDate = new DateTime(2023, 12, 25),
                OriginalPrice = 3599.99m,
                SalePrice = 3168.00m, // 12% off (Christmas)
                CommissionAmount = 475.20m, // 15% of discounted price
                AppliedDiscountId = 17,
                AppliedDiscountPercentage = 12.0m
            },
            
            // Sales with product-specific code-based discounts
            new Sale
            {
                Id = 8,
                ProductId = 3,
                SalespersonId = 5,
                CustomerId = 8,
                SalesDate = new DateTime(2023, 8, 25),
                OriginalPrice = 1499.99m,
                SalePrice = 1274.99m, // 15% off with code
                CommissionAmount = 95.62m, // 7.5% of discounted price
                AppliedDiscountId = 22,
                AppliedDiscountPercentage = 15.0m,
                AppliedDiscountCode = "BIKE3DEAL"
            },
            new Sale
            {
                Id = 9,
                ProductId = 5,
                SalespersonId = 6,
                CustomerId = 9,
                SalesDate = new DateTime(2023, 9, 20),
                OriginalPrice = 2499.99m,
                SalePrice = 2049.99m, // 18% off with code
                CommissionAmount = 164.00m, // 8% of discounted price
                AppliedDiscountId = 23,
                AppliedDiscountPercentage = 18.0m,
                AppliedDiscountCode = "BIKE5FALL"
            },
            
            // Sales with global code-based discounts
            new Sale
            {
                Id = 10,
                ProductId = 10,
                SalespersonId = 7,
                CustomerId = 10,
                SalesDate = new DateTime(2023, 12, 1),
                OriginalPrice = 1899.99m,
                SalePrice = 1614.99m, // 15% off with code
                CommissionAmount = 185.72m, // 11.5% of discounted price
                AppliedDiscountId = 25,
                AppliedDiscountPercentage = 15.0m,
                AppliedDiscountCode = "CYBERMONDAY"
            },
            new Sale
            {
                Id = 11,
                ProductId = 11,
                SalespersonId = 8,
                CustomerId = 11,
                SalesDate = new DateTime(2023, 12, 22),
                OriginalPrice = 1599.99m,
                SalePrice = 1280.00m, // 20% off with code
                CommissionAmount = 128.00m, // 10% of discounted price
                AppliedDiscountId = 26,
                AppliedDiscountPercentage = 20.0m,
                AppliedDiscountCode = "HOLIDAY2023"
            },
            
            // Additional sales with various discount types
            new Sale
            {
                Id = 12,
                ProductId = 12,
                SalespersonId = 9,
                CustomerId = 12,
                SalesDate = new DateTime(2023, 8, 10),
                OriginalPrice = 2299.99m,
                SalePrice = 2299.99m, // No discount
                CommissionAmount = 287.50m, // 12.5% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 13,
                ProductId = 13,
                SalespersonId = 10,
                CustomerId = 13,
                SalesDate = new DateTime(2023, 8, 15),
                OriginalPrice = 499.99m,
                SalePrice = 499.99m, // No discount
                CommissionAmount = 30.00m, // 6% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 14,
                ProductId = 14,
                SalespersonId = 11,
                CustomerId = 14,
                SalesDate = new DateTime(2023, 9, 5),
                OriginalPrice = 2399.99m,
                SalePrice = 2399.99m, // No discount
                CommissionAmount = 312.00m, // 13% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 15,
                ProductId = 15,
                SalespersonId = 12,
                CustomerId = 15,
                SalesDate = new DateTime(2023, 9, 10),
                OriginalPrice = 2299.99m,
                SalePrice = 2299.99m, // No discount
                CommissionAmount = 287.50m, // 12.5% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 16,
                ProductId = 16,
                SalespersonId = 13,
                CustomerId = 16,
                SalesDate = new DateTime(2023, 10, 5),
                OriginalPrice = 2999.99m,
                SalePrice = 2999.99m, // No discount
                CommissionAmount = 420.00m, // 14% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 17,
                ProductId = 17,
                SalespersonId = 14,
                CustomerId = 17,
                SalesDate = new DateTime(2023, 10, 10),
                OriginalPrice = 1999.99m,
                SalePrice = 1999.99m, // No discount
                CommissionAmount = 220.00m, // 11% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 18,
                ProductId = 18,
                SalespersonId = 15,
                CustomerId = 18,
                SalesDate = new DateTime(2023, 11, 5),
                OriginalPrice = 2599.99m,
                SalePrice = 2599.99m, // No discount
                CommissionAmount = 351.00m, // 13.5% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 19,
                ProductId = 19,
                SalespersonId = 1,
                CustomerId = 19,
                SalesDate = new DateTime(2023, 11, 10),
                OriginalPrice = 799.99m,
                SalePrice = 799.99m, // No discount
                CommissionAmount = 56.00m, // 7% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 20,
                ProductId = 20,
                SalespersonId = 2,
                CustomerId = 20,
                SalesDate = new DateTime(2023, 12, 5),
                OriginalPrice = 3299.99m,
                SalePrice = 3299.99m, // No discount
                CommissionAmount = 511.50m, // 15.5% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 21,
                ProductId = 21,
                SalespersonId = 3,
                CustomerId = 21,
                SalesDate = new DateTime(2023, 12, 10),
                OriginalPrice = 3899.99m,
                SalePrice = 3899.99m, // No discount
                CommissionAmount = 624.00m, // 16% of price
                AppliedDiscountPercentage = 0.0m
            },
            
            // Product-specific automatic discount
            new Sale
            {
                Id = 22,
                ProductId = 7,
                SalespersonId = 4,
                CustomerId = 22,
                SalesDate = new DateTime(2024, 1, 20),
                OriginalPrice = 3599.99m,
                SalePrice = 2699.99m, // 25% off
                CommissionAmount = 189.00m, // 7% of discounted price
                AppliedDiscountId = 7,
                AppliedDiscountPercentage = 25.0m
            },
            new Sale
            {
                Id = 23,
                ProductId = 7,
                SalespersonId = 5,
                CustomerId = 23,
                SalesDate = new DateTime(2024, 1, 25),
                OriginalPrice = 3599.99m,
                SalePrice = 2519.99m, // 30% off with code
                CommissionAmount = 214.20m, // 8.5% of discounted price
                AppliedDiscountId = 24,
                AppliedDiscountPercentage = 30.0m,
                AppliedDiscountCode = "WINTER7"
            },
            new Sale
            {
                Id = 24,
                ProductId = 8,
                SalespersonId = 6,
                CustomerId = 24,
                SalesDate = new DateTime(2024, 2, 15),
                OriginalPrice = 2799.99m,
                SalePrice = 2519.99m, // 10% off
                CommissionAmount = 352.80m, // 14% of discounted price
                AppliedDiscountId = 8,
                AppliedDiscountPercentage = 10.0m
            },
            new Sale
            {
                Id = 25,
                ProductId = 9,
                SalespersonId = 7,
                CustomerId = 25,
                SalesDate = new DateTime(2024, 3, 10),
                OriginalPrice = 1899.99m,
                SalePrice = 1671.99m, // 12% off
                CommissionAmount = 183.92m, // 11% of discounted price
                AppliedDiscountId = 9,
                AppliedDiscountPercentage = 12.0m
            },
            
            // Additional sales continuing into 2024
            new Sale
            {
                Id = 26,
                ProductId = 1,
                SalespersonId = 8,
                CustomerId = 26,
                SalesDate = new DateTime(2024, 3, 5),
                OriginalPrice = 1499.99m,
                SalePrice = 1499.99m, // No discount
                CommissionAmount = 157.50m, // 10.5% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 27,
                ProductId = 2,
                SalespersonId = 9,
                CustomerId = 27,
                SalesDate = new DateTime(2024, 3, 10),
                OriginalPrice = 2199.99m,
                SalePrice = 2199.99m, // No discount
                CommissionAmount = 264.00m, // 12% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 28,
                ProductId = 3,
                SalespersonId = 10,
                CustomerId = 28,
                SalesDate = new DateTime(2024, 4, 5),
                OriginalPrice = 1299.99m,
                SalePrice = 1299.99m, // No discount
                CommissionAmount = 110.50m, // 8.5% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 29,
                ProductId = 4,
                SalespersonId = 11,
                CustomerId = 29,
                SalesDate = new DateTime(2024, 4, 10),
                OriginalPrice = 1399.99m,
                SalePrice = 1399.99m, // No discount
                CommissionAmount = 126.00m, // 9% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 30,
                ProductId = 5,
                SalespersonId = 12,
                CustomerId = 30,
                SalesDate = new DateTime(2024, 5, 5),
                OriginalPrice = 1999.99m,
                SalePrice = 1999.99m, // No discount
                CommissionAmount = 220.00m, // 11% of price
                AppliedDiscountPercentage = 0.0m
            },
            
            // Summer sales with discount from 2024
            new Sale
            {
                Id = 31,
                ProductId = 6,
                SalespersonId = 13,
                CustomerId = 1,
                SalesDate = new DateTime(2024, 7, 5),
                OriginalPrice = 2499.99m,
                SalePrice = 2299.99m, // 8% off (Summer sale)
                CommissionAmount = 310.50m, // 13.5% of discounted price
                AppliedDiscountId = 18,
                AppliedDiscountPercentage = 8.0m
            },
            new Sale
            {
                Id = 32,
                ProductId = 7,
                SalespersonId = 14,
                CustomerId = 2,
                SalesDate = new DateTime(2024, 7, 6),
                OriginalPrice = 3599.99m,
                SalePrice = 3311.99m, // 8% off (Summer sale)
                CommissionAmount = 496.80m, // 15% of discounted price
                AppliedDiscountId = 18,
                AppliedDiscountPercentage = 8.0m
            },
            
            // Additional regular sales
            new Sale
            {
                Id = 33,
                ProductId = 8,
                SalespersonId = 15,
                CustomerId = 3,
                SalesDate = new DateTime(2024, 7, 10),
                OriginalPrice = 999.99m,
                SalePrice = 999.99m, // No discount
                CommissionAmount = 75.00m, // 7.5% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 34,
                ProductId = 9,
                SalespersonId = 1,
                CustomerId = 4,
                SalesDate = new DateTime(2024, 7, 10),
                OriginalPrice = 1199.99m,
                SalePrice = 1199.99m, // No discount
                CommissionAmount = 96.00m, // 8% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 35,
                ProductId = 10,
                SalespersonId = 2,
                CustomerId = 5,
                SalesDate = new DateTime(2024, 8, 5),
                OriginalPrice = 1899.99m,
                SalePrice = 1899.99m, // No discount
                CommissionAmount = 218.50m, // 11.5% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 36,
                ProductId = 11,
                SalespersonId = 3,
                CustomerId = 6,
                SalesDate = new DateTime(2024, 8, 10),
                OriginalPrice = 1599.99m,
                SalePrice = 1599.99m, // No discount
                CommissionAmount = 160.00m, // 10% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 37,
                ProductId = 12,
                SalespersonId = 4,
                CustomerId = 7,
                SalesDate = new DateTime(2024, 9, 5),
                OriginalPrice = 2299.99m,
                SalePrice = 2299.99m, // No discount
                CommissionAmount = 287.50m, // 12.5% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 38,
                ProductId = 13,
                SalespersonId = 5,
                CustomerId = 8,
                SalesDate = new DateTime(2024, 9, 10),
                OriginalPrice = 499.99m,
                SalePrice = 499.99m, // No discount
                CommissionAmount = 30.00m, // 6% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 39,
                ProductId = 14,
                SalespersonId = 6,
                CustomerId = 9,
                SalesDate = new DateTime(2024, 10, 5),
                OriginalPrice = 2399.99m,
                SalePrice = 2399.99m, // No discount
                CommissionAmount = 312.00m, // 13% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 40,
                ProductId = 15,
                SalespersonId = 7,
                CustomerId = 10,
                SalesDate = new DateTime(2024, 10, 10),
                OriginalPrice = 2299.99m,
                SalePrice = 2299.99m, // No discount
                CommissionAmount = 287.50m, // 12.5% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 41,
                ProductId = 16,
                SalespersonId = 8,
                CustomerId = 11,
                SalesDate = new DateTime(2024, 11, 5),
                OriginalPrice = 2999.99m,
                SalePrice = 2999.99m, // No discount
                CommissionAmount = 420.00m, // 14% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 42,
                ProductId = 17,
                SalespersonId = 9,
                CustomerId = 12,
                SalesDate = new DateTime(2024, 11, 10),
                OriginalPrice = 1999.99m,
                SalePrice = 1999.99m, // No discount
                CommissionAmount = 220.00m, // 11% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 43,
                ProductId = 18,
                SalespersonId = 10,
                CustomerId = 13,
                SalesDate = new DateTime(2024, 12, 5),
                OriginalPrice = 2599.99m,
                SalePrice = 2599.99m, // No discount
                CommissionAmount = 351.00m, // 13.5% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 44,
                ProductId = 19,
                SalespersonId = 11,
                CustomerId = 14,
                SalesDate = new DateTime(2024, 12, 10),
                OriginalPrice = 799.99m,
                SalePrice = 799.99m, // No discount
                CommissionAmount = 56.00m, // 7% of price
                AppliedDiscountPercentage = 0.0m
            },
            
            // Recent sales with active discounts
            new Sale
            {
                Id = 45,
                ProductId = 11,
                SalespersonId = 12,
                CustomerId = 15,
                SalesDate = new DateTime(2025, 1, 20),
                OriginalPrice = 3299.99m,
                SalePrice = 2804.99m, // 15% off
                CommissionAmount = 434.77m, // 15.5% of discounted price
                AppliedDiscountId = 11,
                AppliedDiscountPercentage = 15.0m
            },
            new Sale
            {
                Id = 46,
                ProductId = 12,
                SalespersonId = 13,
                CustomerId = 16,
                SalesDate = new DateTime(2025, 2, 15),
                OriginalPrice = 3899.99m,
                SalePrice = 3412.49m, // 12.5% off
                CommissionAmount = 546.00m, // 16% of discounted price
                AppliedDiscountId = 12,
                AppliedDiscountPercentage = 12.5m
            },
            
            // Valentine's Day sales with global discount
            new Sale
            {
                Id = 47,
                ProductId = 22,
                SalespersonId = 14,
                CustomerId = 17,
                SalesDate = new DateTime(2025, 2, 14),
                OriginalPrice = 899.99m,
                SalePrice = 832.49m, // 7.5% off (Valentine's Day)
                CommissionAmount = 58.27m, // 7% of discounted price
                AppliedDiscountId = 19,
                AppliedDiscountPercentage = 7.5m
            },
            new Sale
            {
                Id = 48,
                ProductId = 23,
                SalespersonId = 15,
                CustomerId = 18,
                SalesDate = new DateTime(2025, 2, 15),
                OriginalPrice = 1299.99m,
                SalePrice = 1202.49m, // 7.5% off (Valentine's Day)
                CommissionAmount = 102.21m, // 8.5% of discounted price
                AppliedDiscountId = 19,
                AppliedDiscountPercentage = 7.5m
            },
            
            // March 2025 sales with current active discounts (automatic)
            new Sale
            {
                Id = 49,
                ProductId = 13,
                SalespersonId = 1,
                CustomerId = 19,
                SalesDate = new DateTime(2025, 3, 5),
                OriginalPrice = 2799.99m,
                SalePrice = 2239.99m, // 20% off
                CommissionAmount = 313.60m, // 14% of discounted price
                AppliedDiscountId = 13,
                AppliedDiscountPercentage = 20.0m
            },
            new Sale
            {
                Id = 50,
                ProductId = 14,
                SalespersonId = 2,
                CustomerId = 20,
                SalesDate = new DateTime(2025, 3, 10),
                OriginalPrice = 1899.99m,
                SalePrice = 1709.99m, // 10% off
                CommissionAmount = 188.10m, // 11% of discounted price
                AppliedDiscountId = 14,
                AppliedDiscountPercentage = 10.0m
            },
            
            // March 2025 sales with global spring discount
            new Sale
            {
                Id = 51,
                ProductId = 15,
                SalespersonId = 3,
                CustomerId = 21,
                SalesDate = new DateTime(2025, 3, 20),
                OriginalPrice = 2099.99m,
                SalePrice = 1994.99m, // 5% off (Spring discount)
                CommissionAmount = 219.45m, // 11% of discounted price
                AppliedDiscountId = 20,
                AppliedDiscountPercentage = 5.0m
            },
            new Sale
            {
                Id = 52,
                ProductId = 17,
                SalespersonId = 4,
                CustomerId = 22,
                SalesDate = new DateTime(2025, 3, 22),
                OriginalPrice = 1799.99m,
                SalePrice = 1709.99m, // 5% off (Spring discount)
                CommissionAmount = 119.70m, // 7% of discounted price
                AppliedDiscountId = 20,
                AppliedDiscountPercentage = 5.0m
            },
            
            // March 2025 sales with code-based discounts
            new Sale
            {
                Id = 53,
                ProductId = 16,
                SalespersonId = 5,
                CustomerId = 23,
                SalesDate = new DateTime(2025, 3, 8),
                OriginalPrice = 3299.99m,
                SalePrice = 2474.99m, // 25% off with code
                CommissionAmount = 210.37m, // 8.5% of discounted price
                AppliedDiscountId = 27,
                AppliedDiscountPercentage = 25.0m,
                AppliedDiscountCode = "PRO16DEAL"
            },
            new Sale
            {
                Id = 54,
                ProductId = 18,
                SalespersonId = 6,
                CustomerId = 24,
                SalesDate = new DateTime(2025, 3, 15),
                OriginalPrice = 2599.99m,
                SalePrice = 2027.99m, // 22% off with code
                CommissionAmount = 273.78m, // 13.5% of discounted price
                AppliedDiscountId = 28,
                AppliedDiscountPercentage = 22.0m,
                AppliedDiscountCode = "ELITE18"
            },
            new Sale
            {
                Id = 55,
                ProductId = 20,
                SalespersonId = 7,
                CustomerId = 25,
                SalesDate = new DateTime(2025, 3, 18),
                OriginalPrice = 3299.99m,
                SalePrice = 2705.99m, // 18% off with code
                CommissionAmount = 311.19m, // 11.5% of discounted price
                AppliedDiscountId = 29,
                AppliedDiscountPercentage = 18.0m,
                AppliedDiscountCode = "BIKE20SPRING"
            },
            
            // March 2025 sales with global code-based discounts
            new Sale
            {
                Id = 56,
                ProductId = 21,
                SalespersonId = 8,
                CustomerId = 26,
                SalesDate = new DateTime(2025, 3, 10),
                OriginalPrice = 1599.99m,
                SalePrice = 1439.99m, // 10% off with code
                CommissionAmount = 144.00m, // 10% of discounted price
                AppliedDiscountId = 30,
                AppliedDiscountPercentage = 10.0m,
                AppliedDiscountCode = "MARCH2025"
            },
            new Sale
            {
                Id = 57,
                ProductId = 22,
                SalespersonId = 9,
                CustomerId = 27,
                SalesDate = new DateTime(2025, 3, 20),
                OriginalPrice = 2299.99m,
                SalePrice = 1954.99m, // 15% off with code
                CommissionAmount = 244.37m, // 12.5% of discounted price
                AppliedDiscountId = 31,
                AppliedDiscountPercentage = 15.0m,
                AppliedDiscountCode = "SPRING2025"
            },
            new Sale
            {
                Id = 58,
                ProductId = 24,
                SalespersonId = 10,
                CustomerId = 28,
                SalesDate = new DateTime(2025, 3, 25),
                OriginalPrice = 1299.99m,
                SalePrice = 1104.99m, // 15% off with code
                CommissionAmount = 94.92m, // 8.5% of discounted price
                AppliedDiscountId = 31,
                AppliedDiscountPercentage = 15.0m,
                AppliedDiscountCode = "SPRING2025"
            },
            
            // Additional recent sales without discounts (March 2025)
            new Sale
            {
                Id = 59,
                ProductId = 1,
                SalespersonId = 11,
                CustomerId = 29,
                SalesDate = new DateTime(2025, 3, 2),
                OriginalPrice = 1499.99m,
                SalePrice = 1499.99m, // No discount
                CommissionAmount = 135.00m, // 9% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 60,
                ProductId = 2,
                SalespersonId = 12,
                CustomerId = 30,
                SalesDate = new DateTime(2025, 3, 12),
                OriginalPrice = 2199.99m,
                SalePrice = 2199.99m, // No discount
                CommissionAmount = 242.00m, // 11% of price
                AppliedDiscountPercentage = 0.0m
            },
            
            // More sales with a mix of discount types for March 2025
            new Sale
            {
                Id = 61,
                ProductId = 3,
                SalespersonId = 13,
                CustomerId = 1,
                SalesDate = new DateTime(2025, 3, 1),
                OriginalPrice = 1899.99m,
                SalePrice = 1899.99m, // No discount
                CommissionAmount = 247.00m, // 13% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 62,
                ProductId = 4,
                SalespersonId = 14,
                CustomerId = 2,
                SalesDate = new DateTime(2025, 3, 5),
                OriginalPrice = 1399.99m,
                SalePrice = 1399.99m, // No discount
                CommissionAmount = 154.00m, // 11% of price
                AppliedDiscountPercentage = 0.0m
            },
            new Sale
            {
                Id = 63,
                ProductId = 5,
                SalespersonId = 15,
                CustomerId = 3,
                SalesDate = new DateTime(2025, 3, 7),
                OriginalPrice = 2299.99m,
                SalePrice = 2299.99m, // No discount
                CommissionAmount = 299.00m, // 13% of price
                AppliedDiscountPercentage = 0.0m
            },
            
            // More code-based discount sales
            new Sale
            {
                Id = 64,
                ProductId = 6,
                SalespersonId = 1,
                CustomerId = 4,
                SalesDate = new DateTime(2025, 3, 18),
                OriginalPrice = 1799.99m,
                SalePrice = 1529.99m, // 15% off with code
                CommissionAmount = 176.00m, // 11.5% of discounted price
                AppliedDiscountId = 31,
                AppliedDiscountPercentage = 15.0m,
                AppliedDiscountCode = "SPRING2025"
            },
            new Sale
            {
                Id = 65,
                ProductId = 7,
                SalespersonId = 2,
                CustomerId = 5,
                SalesDate = new DateTime(2025, 3, 20),
                OriginalPrice = 2199.99m,
                SalePrice = 1979.99m, // 10% off with code
                CommissionAmount = 237.60m, // 12% of discounted price
                AppliedDiscountId = 30,
                AppliedDiscountPercentage = 10.0m,
                AppliedDiscountCode = "MARCH2025"
            },
            
            // More sales with automatic product-specific discounts
            new Sale
            {
                Id = 66,
                ProductId = 15,
                SalespersonId = 3,
                CustomerId = 6,
                SalesDate = new DateTime(2025, 3, 22),
                OriginalPrice = 1799.99m,
                SalePrice = 1529.99m, // 15% off
                CommissionAmount = 214.20m, // 14% of discounted price
                AppliedDiscountId = 15,
                AppliedDiscountPercentage = 15.0m
            },
            new Sale
            {
                Id = 67,
                ProductId = 13,
                SalespersonId = 4,
                CustomerId = 7,
                SalesDate = new DateTime(2025, 3, 25),
                OriginalPrice = 2499.99m,
                SalePrice = 1999.99m, // 20% off
                CommissionAmount = 200.00m, // 10% of discounted price
                AppliedDiscountId = 13,
                AppliedDiscountPercentage = 20.0m
            },
            
            // A few more sales to reach 70 total
            new Sale
            {
                Id = 68,
                ProductId = 8,
                SalespersonId = 5,
                CustomerId = 8,
                SalesDate = new DateTime(2025, 3, 28),
                OriginalPrice = 999.99m,
                SalePrice = 949.99m, // 5% off (Spring discount)
                CommissionAmount = 71.25m, // 7.5% of discounted price
                AppliedDiscountId = 20,
                AppliedDiscountPercentage = 5.0m
            },
            new Sale
            {
                Id = 69,
                ProductId = 9,
                SalespersonId = 6,
                CustomerId = 9,
                SalesDate = new DateTime(2025, 3, 29),
                OriginalPrice = 1199.99m,
                SalePrice = 1139.99m, // 5% off (Spring discount)
                CommissionAmount = 91.20m, // 8% of discounted price
                AppliedDiscountId = 20,
                AppliedDiscountPercentage = 5.0m
            },
            new Sale
            {
                Id = 70,
                ProductId = 10,
                SalespersonId = 7,
                CustomerId = 10,
                SalesDate = new DateTime(2025, 3, 30),
                OriginalPrice = 1899.99m,
                SalePrice = 1804.99m, // 5% off (Spring discount)
                CommissionAmount = 207.57m, // 11.5% of discounted price
                AppliedDiscountId = 20,
                AppliedDiscountPercentage = 5.0m
            }
        };
    }
}