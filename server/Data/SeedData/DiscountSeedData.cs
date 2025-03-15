using server.Models;

namespace server.Data.SeedData;

public static class DiscountSeedData
{
    public static List<Discount> GetDiscounts()
    {
        return new List<Discount>
        {
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
            // Additional mock discounts
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
            // Upcoming and current discounts for newer products
            new Discount
            {
                Id = 11,
                ProductId = 11,
                BeginDate = new DateTime(2025, 1, 1),
                EndDate = new DateTime(2025, 1, 31),
                DiscountPercentage = 15.0m
            },
            new Discount
            {
                Id = 12,
                ProductId = 12,
                BeginDate = new DateTime(2025, 2, 1),
                EndDate = new DateTime(2025, 2, 28),
                DiscountPercentage = 12.5m
            },
            new Discount
            {
                Id = 13,
                ProductId = 13,
                BeginDate = new DateTime(2025, 3, 1),
                EndDate = new DateTime(2025, 3, 31),
                DiscountPercentage = 20.0m
            },
            new Discount
            {
                Id = 14,
                ProductId = 14,
                BeginDate = new DateTime(2025, 3, 15),
                EndDate = new DateTime(2025, 4, 15),
                DiscountPercentage = 10.0m
            },
            new Discount
            {
                Id = 15,
                ProductId = 15,
                BeginDate = new DateTime(2025, 4, 1),
                EndDate = new DateTime(2025, 4, 30),
                DiscountPercentage = 15.0m
            }
        };
    }
}