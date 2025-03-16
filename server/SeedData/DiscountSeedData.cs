using server.Models;

namespace server.Data.SeedData;

public static class DiscountSeedData
{
    public static List<Discount> GetDiscounts()
    {
        return new List<Discount>
        {
            // Product-specific automatic discounts (past)
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
            },
            // Additional product-specific automatic discounts (past)
            new Discount
            {
                Id = 3,
                ProductId = 3,
                BeginDate = new DateTime(2023, 8, 1),
                EndDate = new DateTime(2023, 8, 31),
                DiscountPercentage = 12.5m
            },
            new Discount
            {
                Id = 4,
                ProductId = 4,
                BeginDate = new DateTime(2023, 9, 1),
                EndDate = new DateTime(2023, 9, 15),
                DiscountPercentage = 8.0m
            },
            new Discount
            {
                Id = 5,
                ProductId = 5,
                BeginDate = new DateTime(2023, 10, 1),
                EndDate = new DateTime(2023, 10, 31),
                DiscountPercentage = 20.0m
            },
            new Discount
            {
                Id = 6,
                ProductId = 6,
                BeginDate = new DateTime(2023, 11, 15),
                EndDate = new DateTime(2023, 12, 15),
                DiscountPercentage = 15.0m
            },
            new Discount
            {
                Id = 7,
                ProductId = 7,
                BeginDate = new DateTime(2024, 1, 1),
                EndDate = new DateTime(2024, 1, 31),
                DiscountPercentage = 25.0m
            },
            new Discount
            {
                Id = 8,
                ProductId = 8,
                BeginDate = new DateTime(2024, 2, 1),
                EndDate = new DateTime(2024, 2, 28),
                DiscountPercentage = 10.0m
            },
            new Discount
            {
                Id = 9,
                ProductId = 9,
                BeginDate = new DateTime(2024, 3, 1),
                EndDate = new DateTime(2024, 3, 15),
                DiscountPercentage = 12.0m
            },
            new Discount
            {
                Id = 10,
                ProductId = 10,
                BeginDate = new DateTime(2024, 4, 1),
                EndDate = new DateTime(2024, 4, 30),
                DiscountPercentage = 18.0m
            },
            
            // Recent and current product-specific automatic discounts
            new Discount
            {
                Id = 11,
                ProductId = 11,
                BeginDate = new DateTime(2025, 1, 1),
                EndDate = new DateTime(2025, 4, 30),
                DiscountPercentage = 15.0m
            },
            new Discount
            {
                Id = 12,
                ProductId = 12,
                BeginDate = new DateTime(2025, 2, 1),
                EndDate = new DateTime(2025, 4, 30),
                DiscountPercentage = 12.5m
            },
            new Discount
            {
                Id = 13,
                ProductId = 13,
                BeginDate = new DateTime(2025, 3, 1),
                EndDate = new DateTime(2025, 5, 31),
                DiscountPercentage = 20.0m
            },
            new Discount
            {
                Id = 14,
                ProductId = 14,
                BeginDate = new DateTime(2025, 3, 15),
                EndDate = new DateTime(2025, 5, 15),
                DiscountPercentage = 10.0m
            },
            new Discount
            {
                Id = 15,
                ProductId = 15,
                BeginDate = new DateTime(2025, 3, 1),
                EndDate = new DateTime(2025, 4, 30),
                DiscountPercentage = 15.0m
            },
            
            // Global automatic discounts (past)
            new Discount
            {
                Id = 16,
                ProductId = null, // Global discount
                BeginDate = new DateTime(2023, 11, 25),
                EndDate = new DateTime(2023, 11, 30),
                DiscountPercentage = 10.0m, // Black Friday discount
            },
            new Discount
            {
                Id = 17,
                ProductId = null, // Global discount
                BeginDate = new DateTime(2023, 12, 24),
                EndDate = new DateTime(2023, 12, 26),
                DiscountPercentage = 12.0m, // Christmas discount
            },
            new Discount
            {
                Id = 18,
                ProductId = null, // Global discount
                BeginDate = new DateTime(2024, 7, 1),
                EndDate = new DateTime(2024, 7, 7),
                DiscountPercentage = 8.0m, // Summer sale discount
            },
            
            // Global automatic discounts (active and upcoming)
            new Discount
            {
                Id = 19,
                ProductId = null, // Global discount
                BeginDate = new DateTime(2025, 2, 14),
                EndDate = new DateTime(2025, 2, 16),
                DiscountPercentage = 7.5m, // Valentine's Day discount
            },
            new Discount
            {
                Id = 20,
                ProductId = null, // Global discount
                BeginDate = new DateTime(2025, 3, 15),
                EndDate = new DateTime(2025, 3, 31),
                DiscountPercentage = 5.0m, // Spring discount
            },
            new Discount
            {
                Id = 21,
                ProductId = null, // Global discount
                BeginDate = new DateTime(2025, 5, 1),
                EndDate = new DateTime(2025, 5, 31),
                DiscountPercentage = 10.0m, // Upcoming May discount
            },
            
            // Product-specific code-based discounts (past)
            new Discount
            {
                Id = 22,
                ProductId = 3,
                BeginDate = new DateTime(2023, 8, 15),
                EndDate = new DateTime(2023, 8, 31),
                DiscountPercentage = 15.0m,
                DiscountCode = "BIKE3DEAL"
            },
            new Discount
            {
                Id = 23,
                ProductId = 5,
                BeginDate = new DateTime(2023, 9, 1),
                EndDate = new DateTime(2023, 9, 30),
                DiscountPercentage = 18.0m,
                DiscountCode = "BIKE5FALL"
            },
            new Discount
            {
                Id = 24,
                ProductId = 7,
                BeginDate = new DateTime(2024, 1, 15),
                EndDate = new DateTime(2024, 1, 31),
                DiscountPercentage = 30.0m,
                DiscountCode = "WINTER7"
            },
            
            // Global code-based discounts (past)
            new Discount
            {
                Id = 25,
                ProductId = null, // Global discount
                BeginDate = new DateTime(2023, 11, 28),
                EndDate = new DateTime(2023, 12, 5),
                DiscountPercentage = 15.0m,
                DiscountCode = "CYBERMONDAY"
            },
            new Discount
            {
                Id = 26,
                ProductId = null, // Global discount
                BeginDate = new DateTime(2023, 12, 20),
                EndDate = new DateTime(2023, 12, 31),
                DiscountPercentage = 20.0m,
                DiscountCode = "HOLIDAY2023"
            },
            
            // Product-specific code-based discounts (active)
            new Discount
            {
                Id = 27,
                ProductId = 16,
                BeginDate = new DateTime(2025, 2, 1),
                EndDate = new DateTime(2025, 4, 30),
                DiscountPercentage = 25.0m,
                DiscountCode = "PRO16DEAL"
            },
            new Discount
            {
                Id = 28,
                ProductId = 18,
                BeginDate = new DateTime(2025, 3, 1),
                EndDate = new DateTime(2025, 5, 31),
                DiscountPercentage = 22.0m,
                DiscountCode = "ELITE18"
            },
            new Discount
            {
                Id = 29,
                ProductId = 20,
                BeginDate = new DateTime(2025, 3, 15),
                EndDate = new DateTime(2025, 4, 30),
                DiscountPercentage = 18.0m,
                DiscountCode = "BIKE20SPRING"
            },
            
            // Global code-based discounts (active and upcoming)
            new Discount
            {
                Id = 30,
                ProductId = null, // Global discount
                BeginDate = new DateTime(2025, 3, 1),
                EndDate = new DateTime(2025, 3, 31),
                DiscountPercentage = 10.0m,
                DiscountCode = "MARCH2025"
            },
            new Discount
            {
                Id = 31,
                ProductId = null, // Global discount
                BeginDate = new DateTime(2025, 3, 15),
                EndDate = new DateTime(2025, 4, 15),
                DiscountPercentage = 15.0m,
                DiscountCode = "SPRING2025"
            },
            new Discount
            {
                Id = 32,
                ProductId = null, // Global discount
                BeginDate = new DateTime(2025, 4, 1),
                EndDate = new DateTime(2025, 5, 31),
                DiscountPercentage = 12.0m,
                DiscountCode = "BIKESEASON"
            },
            new Discount
            {
                Id = 33,
                ProductId = null, // Global discount
                BeginDate = new DateTime(2025, 5, 1),
                EndDate = new DateTime(2025, 5, 31),
                DiscountPercentage = 20.0m,
                DiscountCode = "MAY2025SALE"
            }
        };
    }
}