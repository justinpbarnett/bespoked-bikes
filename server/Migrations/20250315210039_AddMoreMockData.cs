using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreMockData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Address", "FirstName", "LastName", "Phone", "StartDate" },
                values: new object[,]
                {
                    { 4, "123 Oak St, Seattle, WA 98107", "Lisa", "Martinez", "206-555-7890", new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "456 Pine Ln, Seattle, WA 98108", "Michael", "Brown", "206-555-8901", new DateTime(2021, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "789 Cedar Ave, Seattle, WA 98109", "Sarah", "Davis", "206-555-9012", new DateTime(2020, 6, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "321 Birch Rd, Seattle, WA 98110", "Daniel", "Taylor", "206-555-0123", new DateTime(2022, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, "654 Maple St, Seattle, WA 98111", "Amanda", "Johnson", "206-555-1234", new DateTime(2021, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, "987 Elm Dr, Seattle, WA 98112", "Christopher", "Miller", "206-555-2345", new DateTime(2020, 9, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, "159 Spruce Ave, Seattle, WA 98113", "Jessica", "Williams", "206-555-3456", new DateTime(2022, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, "357 Cedar Ln, Seattle, WA 98114", "Matthew", "Jones", "206-555-4567", new DateTime(2021, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, "852 Pine St, Seattle, WA 98115", "Emily", "Garcia", "206-555-5678", new DateTime(2020, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, "953 Oak Dr, Seattle, WA 98116", "Joshua", "Smith", "206-555-6789", new DateTime(2021, 4, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, "147 Maple Rd, Seattle, WA 98117", "Ashley", "Rodriguez", "206-555-7890", new DateTime(2022, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, "258 Elm Ave, Seattle, WA 98118", "Andrew", "Martinez", "206-555-8901", new DateTime(2021, 1, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, "369 Birch St, Seattle, WA 98119", "Nicole", "Hernandez", "206-555-9012", new DateTime(2020, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "741 Cedar Dr, Seattle, WA 98120", "William", "Moore", "206-555-0123", new DateTime(2022, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, "852 Pine Ln, Seattle, WA 98121", "Stephanie", "Martin", "206-555-1234", new DateTime(2021, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, "963 Oak Ave, Seattle, WA 98122", "Joseph", "Jackson", "206-555-2345", new DateTime(2020, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "159 Maple St, Seattle, WA 98123", "Elizabeth", "Thompson", "206-555-3456", new DateTime(2022, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, "357 Elm Rd, Seattle, WA 98124", "Ryan", "White", "206-555-4567", new DateTime(2021, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, "753 Birch Ave, Seattle, WA 98125", "Megan", "Lopez", "206-555-5678", new DateTime(2020, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, "951 Cedar St, Seattle, WA 98126", "Kevin", "Lee", "206-555-6789", new DateTime(2022, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, "147 Pine Dr, Seattle, WA 98127", "Rachel", "Gonzalez", "206-555-7890", new DateTime(2021, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, "258 Oak Ln, Seattle, WA 98128", "Brian", "Nelson", "206-555-8901", new DateTime(2020, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, "369 Maple Ave, Seattle, WA 98129", "Lauren", "Hill", "206-555-9012", new DateTime(2022, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, "741 Elm St, Seattle, WA 98130", "Justin", "Ramirez", "206-555-0123", new DateTime(2021, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, "852 Birch Rd, Seattle, WA 98131", "Samantha", "Campbell", "206-555-1234", new DateTime(2020, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, "963 Cedar Ave, Seattle, WA 98132", "Brandon", "Baker", "206-555-2345", new DateTime(2022, 8, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, "159 Pine St, Seattle, WA 98133", "Melissa", "Rivera", "206-555-3456", new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeginDate", "DiscountPercentage", "EndDate", "ProductId" },
                values: new object[,]
                {
                    { 3, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.5m, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 8.0m, new DateTime(2023, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CommissionPercentage", "Manufacturer", "Name", "PurchasePrice", "QuantityOnHand", "SalePrice", "Style" },
                values: new object[,]
                {
                    { 5, 11.0m, "Rad Power Bikes", "Electric City Pro", 1200m, 8, 1999.99m, "Electric" },
                    { 6, 13.5m, "Santa Cruz", "Mountain Trail X2", 1500m, 5, 2499.99m, "Mountain" },
                    { 7, 15.0m, "Cervélo", "Speed Demon Racing", 2000m, 3, 3599.99m, "Road" },
                    { 8, 7.5m, "Electra", "Comfort Cruiser Plus", 600m, 20, 999.99m, "Cruiser" },
                    { 9, 8.0m, "Trek", "Urban Commuter X3", 700m, 14, 1199.99m, "Urban" },
                    { 10, 11.5m, "Specialized", "Trail Blazer Pro", 1100m, 6, 1899.99m, "Mountain" },
                    { 11, 10.0m, "Brompton", "Folding City Bike", 950m, 9, 1599.99m, "Folding" },
                    { 12, 12.5m, "Salsa", "Gravel Adventure X1", 1300m, 7, 2299.99m, "Gravel" },
                    { 13, 6.0m, "Giant", "Kids Explorer 24", 300m, 25, 499.99m, "Kids" },
                    { 14, 13.0m, "Surly", "Cargo Hauler Max", 1400m, 4, 2399.99m, "Cargo" },
                    { 15, 12.5m, "Salsa", "Fat Tire Beast", 1350m, 6, 2299.99m, "Fat Tire" },
                    { 16, 14.0m, "Cannondale", "Road Racer Elite", 1800m, 4, 2999.99m, "Road" },
                    { 17, 11.0m, "Trek", "Touring Adventure", 1200m, 8, 1999.99m, "Touring" },
                    { 18, 13.5m, "Specialized", "Electric Cruiser E1", 1500m, 7, 2599.99m, "Electric" },
                    { 19, 7.0m, "Haro", "BMX Stunt Pro", 450m, 18, 799.99m, "BMX" },
                    { 20, 15.5m, "Santa Cruz", "Mountain Downhill Expert", 1900m, 3, 3299.99m, "Mountain" },
                    { 21, 16.0m, "Cervélo", "Triathlon Champion", 2200m, 2, 3899.99m, "Triathlon" },
                    { 22, 7.0m, "Electra", "Comfort City Plus", 550m, 22, 899.99m, "Urban" },
                    { 23, 8.5m, "Giant", "Mountain Trail Lite", 800m, 13, 1299.99m, "Mountain" },
                    { 24, 14.0m, "Trek", "Road Speed RS7", 1650m, 5, 2799.99m, "Road" },
                    { 25, 11.0m, "Rad Power Bikes", "Electric City Commuter", 1100m, 9, 1899.99m, "Electric" }
                });

            migrationBuilder.InsertData(
                table: "Salespersons",
                columns: new[] { "Id", "Address", "FirstName", "LastName", "Manager", "Phone", "StartDate", "TerminationDate" },
                values: new object[,]
                {
                    { 4, "321 Cedar Rd, Seattle, WA 98104", "Jessica", "Wilson", "Emily Brown", "206-555-4567", new DateTime(2021, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 5, "654 Birch Ave, Seattle, WA 98105", "David", "Martinez", "Emily Brown", "206-555-5678", new DateTime(2022, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 6, "987 Walnut St, Seattle, WA 98106", "Emily", "Taylor", "Marcus Johnson", "206-555-6789", new DateTime(2020, 8, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 7, "147 Spruce Dr, Seattle, WA 98107", "James", "Anderson", "Marcus Johnson", "206-555-7890", new DateTime(2019, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 8, "258 Maple Ln, Seattle, WA 98108", "Amanda", "Thomas", "Marcus Johnson", "206-555-8901", new DateTime(2022, 3, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 9, "369 Elm Pl, Seattle, WA 98109", "Daniel", "Rodriguez", "Marcus Johnson", "206-555-9012", new DateTime(2021, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 10, "741 Oak Ct, Seattle, WA 98110", "Ashley", "Garcia", "Marcus Johnson", "206-555-0123", new DateTime(2020, 5, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 11, "852 Cedar Pl, Seattle, WA 98111", "Robert", "Martinez", "Sophia Reynolds", "206-555-1234", new DateTime(2018, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 12, "963 Pine Rd, Seattle, WA 98112", "Jennifer", "Brown", "Sophia Reynolds", "206-555-2345", new DateTime(2019, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 13, "159 Birch Dr, Seattle, WA 98113", "Christopher", "Lee", "Sophia Reynolds", "206-555-3456", new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 14, "357 Walnut Ave, Seattle, WA 98114", "Elizabeth", "Harris", "Sophia Reynolds", "206-555-4567", new DateTime(2021, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 15, "258 Spruce St, Seattle, WA 98115", "Matthew", "Clark", "Sophia Reynolds", "206-555-5678", new DateTime(2020, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 16, "753 Maple Ave, Seattle, WA 98116", "Lauren", "Lewis", "William Phillips", "206-555-6789", new DateTime(2022, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, "951 Elm St, Seattle, WA 98117", "Kevin", "Walker", "William Phillips", "206-555-7890", new DateTime(2019, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 18, "357 Oak Rd, Seattle, WA 98118", "Michelle", "Young", "William Phillips", "206-555-8901", new DateTime(2021, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 19, "864 Cedar St, Seattle, WA 98119", "Jason", "Allen", "William Phillips", "206-555-9012", new DateTime(2018, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, "159 Pine Dr, Seattle, WA 98120", "Kimberly", "Scott", "William Phillips", "206-555-0123", new DateTime(2022, 4, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeginDate", "DiscountPercentage", "EndDate", "ProductId" },
                values: new object[,]
                {
                    { 5, new DateTime(2023, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.0m, new DateTime(2023, 10, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 6, new DateTime(2023, 11, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0m, new DateTime(2023, 12, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 7, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 25.0m, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 8, new DateTime(2024, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0m, new DateTime(2024, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 9, new DateTime(2024, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.0m, new DateTime(2024, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 10, new DateTime(2024, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 18.0m, new DateTime(2024, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 11, new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0m, new DateTime(2025, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 12, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 12.5m, new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 13, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 20.0m, new DateTime(2025, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 14, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10.0m, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 15, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 15.0m, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 }
                });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "CommissionAmount", "CustomerId", "ProductId", "SalePrice", "SalesDate", "SalespersonId" },
                values: new object[,]
                {
                    { 4, 126.00m, 4, 4, 1399.99m, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 5, 220.00m, 5, 5, 1999.99m, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 6, 337.50m, 6, 6, 2499.99m, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 7, 540.00m, 7, 7, 3599.99m, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 8, 75.00m, 8, 8, 999.99m, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 9, 96.00m, 9, 9, 1199.99m, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 10, 218.50m, 10, 10, 1899.99m, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 11, 160.00m, 11, 11, 1599.99m, new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 12, 287.50m, 12, 12, 2299.99m, new DateTime(2023, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 13, 30.00m, 13, 13, 499.99m, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 14, 312.00m, 14, 14, 2399.99m, new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 15, 287.50m, 15, 15, 2299.99m, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 16, 420.00m, 16, 16, 2999.99m, new DateTime(2023, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 17, 220.00m, 17, 17, 1999.99m, new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 18, 351.00m, 18, 18, 2599.99m, new DateTime(2023, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 19, 56.00m, 19, 19, 799.99m, new DateTime(2023, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 20, 511.50m, 20, 20, 3299.99m, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 21, 624.00m, 21, 21, 3899.99m, new DateTime(2023, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 22, 63.00m, 22, 22, 899.99m, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 23, 110.50m, 23, 23, 1299.99m, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 24, 392.00m, 24, 24, 2799.99m, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 25, 209.00m, 25, 25, 1899.99m, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 26, 157.50m, 26, 1, 1499.99m, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 27, 264.00m, 27, 2, 2199.99m, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 28, 110.50m, 28, 3, 1299.99m, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 29, 126.00m, 29, 4, 1399.99m, new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 30, 220.00m, 30, 5, 1999.99m, new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 31, 337.50m, 1, 6, 2499.99m, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 32, 540.00m, 2, 7, 3599.99m, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 33, 75.00m, 3, 8, 999.99m, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 34, 96.00m, 4, 9, 1199.99m, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 35, 218.50m, 5, 10, 1899.99m, new DateTime(2024, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 36, 160.00m, 6, 11, 1599.99m, new DateTime(2024, 8, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 37, 287.50m, 7, 12, 2299.99m, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 38, 30.00m, 8, 13, 499.99m, new DateTime(2024, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 39, 312.00m, 9, 14, 2399.99m, new DateTime(2024, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 40, 287.50m, 10, 15, 2299.99m, new DateTime(2024, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 41, 420.00m, 11, 16, 2999.99m, new DateTime(2024, 11, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 42, 220.00m, 12, 17, 1999.99m, new DateTime(2024, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 43, 351.00m, 13, 18, 2599.99m, new DateTime(2024, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 44, 56.00m, 14, 19, 799.99m, new DateTime(2024, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 45, 511.50m, 15, 20, 3299.99m, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 46, 624.00m, 16, 21, 3899.99m, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 47, 63.00m, 17, 22, 899.99m, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 48, 110.50m, 18, 23, 1299.99m, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 49, 392.00m, 19, 24, 2799.99m, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 50, 209.00m, 20, 25, 1899.99m, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salespersons_FirstName_LastName",
                table: "Salespersons",
                columns: new[] { "FirstName", "LastName" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Salespersons_FirstName_LastName",
                table: "Salespersons");

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Salespersons",
                keyColumn: "Id",
                keyValue: 15);
        }
    }
}
