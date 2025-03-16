using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class EnhancedSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 11,
                column: "EndDate",
                value: new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 12,
                column: "EndDate",
                value: new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 13,
                column: "EndDate",
                value: new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 14,
                column: "EndDate",
                value: new DateTime(2025, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 15,
                column: "BeginDate",
                value: new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Discounts",
                columns: new[] { "Id", "BeginDate", "DiscountCode", "DiscountPercentage", "EndDate", "ProductId" },
                values: new object[,]
                {
                    { 16, new DateTime(2023, 11, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10.0m, new DateTime(2023, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 17, new DateTime(2023, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 12.0m, new DateTime(2023, 12, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 18, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 8.0m, new DateTime(2024, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 19, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 7.5m, new DateTime(2025, 2, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 20, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 5.0m, new DateTime(2025, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 21, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 10.0m, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 22, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIKE3DEAL", 15.0m, new DateTime(2023, 8, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 23, new DateTime(2023, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIKE5FALL", 18.0m, new DateTime(2023, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 24, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "WINTER7", 30.0m, new DateTime(2024, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 25, new DateTime(2023, 11, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "CYBERMONDAY", 15.0m, new DateTime(2023, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 26, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "HOLIDAY2023", 20.0m, new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 27, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "PRO16DEAL", 25.0m, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 16 },
                    { 28, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ELITE18", 22.0m, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 18 },
                    { 29, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIKE20SPRING", 18.0m, new DateTime(2025, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 20 },
                    { 30, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MARCH2025", 10.0m, new DateTime(2025, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 31, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "SPRING2025", 15.0m, new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 32, new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "BIKESEASON", 12.0m, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null },
                    { 33, new DateTime(2025, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "MAY2025SALE", 20.0m, new DateTime(2025, 5, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), null }
                });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "OriginalPrice",
                value: 1499.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "OriginalPrice",
                value: 2199.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { 3, 12.5m, 111.56m, 1499.99m, 1312.49m, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { 4, 8.0m, 132.48m, 1599.99m, 1471.99m, new DateTime(2023, 9, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice", "SalesDate" },
                values: new object[] { 5, 20.0m, 2499.99m, new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { 16, 10.0m, 364.50m, 2999.99m, 2699.99m, new DateTime(2023, 11, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { 17, 12.0m, 475.20m, 3599.99m, 3168.00m, new DateTime(2023, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AppliedDiscountCode", "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice", "SalesDate" },
                values: new object[] { "BIKE3DEAL", 22, 15.0m, 95.62m, 1499.99m, 3, 1274.99m, new DateTime(2023, 8, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AppliedDiscountCode", "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice", "SalesDate" },
                values: new object[] { "BIKE5FALL", 23, 18.0m, 164.00m, 2499.99m, 5, 2049.99m, new DateTime(2023, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AppliedDiscountCode", "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { "CYBERMONDAY", 25, 15.0m, 185.72m, 1899.99m, 1614.99m, new DateTime(2023, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AppliedDiscountCode", "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { "HOLIDAY2023", 26, 20.0m, 128.00m, 1599.99m, 1280.00m, new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 12,
                column: "OriginalPrice",
                value: 2299.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 13,
                column: "OriginalPrice",
                value: 499.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 14,
                column: "OriginalPrice",
                value: 2399.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 15,
                column: "OriginalPrice",
                value: 2299.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 16,
                column: "OriginalPrice",
                value: 2999.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 17,
                column: "OriginalPrice",
                value: 1999.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 18,
                column: "OriginalPrice",
                value: 2599.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 19,
                column: "OriginalPrice",
                value: 799.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 20,
                column: "OriginalPrice",
                value: 3299.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 21,
                column: "OriginalPrice",
                value: 3899.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice", "SalesDate" },
                values: new object[] { 7, 25.0m, 189.00m, 3599.99m, 7, 2699.99m, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AppliedDiscountCode", "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice", "SalesDate" },
                values: new object[] { "WINTER7", 24, 30.0m, 214.20m, 3599.99m, 7, 2519.99m, new DateTime(2024, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice", "SalesDate" },
                values: new object[] { 8, 10.0m, 352.80m, 2799.99m, 8, 2519.99m, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice", "SalesDate" },
                values: new object[] { 9, 12.0m, 183.92m, 1899.99m, 9, 1671.99m, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 26,
                column: "OriginalPrice",
                value: 1499.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 27,
                column: "OriginalPrice",
                value: 2199.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 28,
                column: "OriginalPrice",
                value: 1299.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 29,
                column: "OriginalPrice",
                value: 1399.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 30,
                column: "OriginalPrice",
                value: 1999.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { 18, 8.0m, 310.50m, 2499.99m, 2299.99m, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { 18, 8.0m, 496.80m, 3599.99m, 3311.99m, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "OriginalPrice", "SalesDate" },
                values: new object[] { 999.99m, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 34,
                column: "OriginalPrice",
                value: 1199.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 35,
                column: "OriginalPrice",
                value: 1899.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 36,
                column: "OriginalPrice",
                value: 1599.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 37,
                column: "OriginalPrice",
                value: 2299.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 38,
                column: "OriginalPrice",
                value: 499.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 39,
                column: "OriginalPrice",
                value: 2399.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 40,
                column: "OriginalPrice",
                value: 2299.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 41,
                column: "OriginalPrice",
                value: 2999.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 42,
                column: "OriginalPrice",
                value: 1999.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 43,
                column: "OriginalPrice",
                value: 2599.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 44,
                column: "OriginalPrice",
                value: 799.99m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice", "SalesDate" },
                values: new object[] { 11, 15.0m, 434.77m, 3299.99m, 11, 2804.99m, new DateTime(2025, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice", "SalesDate" },
                values: new object[] { 12, 12.5m, 546.00m, 3899.99m, 12, 3412.49m, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { 19, 7.5m, 58.27m, 899.99m, 832.49m, new DateTime(2025, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { 19, 7.5m, 102.21m, 1299.99m, 1202.49m, new DateTime(2025, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice" },
                values: new object[] { 13, 20.0m, 313.60m, 2799.99m, 13, 2239.99m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice" },
                values: new object[] { 14, 10.0m, 188.10m, 1899.99m, 14, 1709.99m });

            migrationBuilder.InsertData(
                table: "Sales",
                columns: new[] { "Id", "AppliedDiscountCode", "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "CustomerId", "OriginalPrice", "ProductId", "SalePrice", "SalesDate", "SalespersonId" },
                values: new object[,]
                {
                    { 59, null, null, 0.0m, 135.00m, 29, 1499.99m, 1, 1499.99m, new DateTime(2025, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 11 },
                    { 60, null, null, 0.0m, 242.00m, 30, 2199.99m, 2, 2199.99m, new DateTime(2025, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 12 },
                    { 61, null, null, 0.0m, 247.00m, 1, 1899.99m, 3, 1899.99m, new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 13 },
                    { 62, null, null, 0.0m, 154.00m, 2, 1399.99m, 4, 1399.99m, new DateTime(2025, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 14 },
                    { 63, null, null, 0.0m, 299.00m, 3, 2299.99m, 5, 2299.99m, new DateTime(2025, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), 15 },
                    { 66, null, 15, 15.0m, 214.20m, 6, 1799.99m, 15, 1529.99m, new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 67, null, 13, 20.0m, 200.00m, 7, 2499.99m, 13, 1999.99m, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 51, null, 20, 5.0m, 219.45m, 21, 2099.99m, 15, 1994.99m, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 52, null, 20, 5.0m, 119.70m, 22, 1799.99m, 17, 1709.99m, new DateTime(2025, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 53, "PRO16DEAL", 27, 25.0m, 210.37m, 23, 3299.99m, 16, 2474.99m, new DateTime(2025, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 54, "ELITE18", 28, 22.0m, 273.78m, 24, 2599.99m, 18, 2027.99m, new DateTime(2025, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 55, "BIKE20SPRING", 29, 18.0m, 311.19m, 25, 3299.99m, 20, 2705.99m, new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 },
                    { 56, "MARCH2025", 30, 10.0m, 144.00m, 26, 1599.99m, 21, 1439.99m, new DateTime(2025, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 8 },
                    { 57, "SPRING2025", 31, 15.0m, 244.37m, 27, 2299.99m, 22, 1954.99m, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 9 },
                    { 58, "SPRING2025", 31, 15.0m, 94.92m, 28, 1299.99m, 24, 1104.99m, new DateTime(2025, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 10 },
                    { 64, "SPRING2025", 31, 15.0m, 176.00m, 4, 1799.99m, 6, 1529.99m, new DateTime(2025, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 65, "MARCH2025", 30, 10.0m, 237.60m, 5, 2199.99m, 7, 1979.99m, new DateTime(2025, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 68, null, 20, 5.0m, 71.25m, 8, 999.99m, 8, 949.99m, new DateTime(2025, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5 },
                    { 69, null, 20, 5.0m, 91.20m, 9, 1199.99m, 9, 1139.99m, new DateTime(2025, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 6 },
                    { 70, null, 20, 5.0m, 207.57m, 10, 1899.99m, 10, 1804.99m, new DateTime(2025, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 7 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 11,
                column: "EndDate",
                value: new DateTime(2025, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 12,
                column: "EndDate",
                value: new DateTime(2025, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 13,
                column: "EndDate",
                value: new DateTime(2025, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 14,
                column: "EndDate",
                value: new DateTime(2025, 4, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Discounts",
                keyColumn: "Id",
                keyValue: 15,
                column: "BeginDate",
                value: new DateTime(2025, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { null, 0m, 110.50m, 0m, 1299.99m, new DateTime(2023, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { null, 0m, 126.00m, 0m, 1399.99m, new DateTime(2023, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice", "SalesDate" },
                values: new object[] { null, 0m, 0m, new DateTime(2023, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { null, 0m, 337.50m, 0m, 2499.99m, new DateTime(2023, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { null, 0m, 540.00m, 0m, 3599.99m, new DateTime(2023, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AppliedDiscountCode", "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice", "SalesDate" },
                values: new object[] { null, null, 0m, 75.00m, 0m, 8, 999.99m, new DateTime(2023, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AppliedDiscountCode", "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice", "SalesDate" },
                values: new object[] { null, null, 0m, 96.00m, 0m, 9, 1199.99m, new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AppliedDiscountCode", "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { null, null, 0m, 218.50m, 0m, 1899.99m, new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AppliedDiscountCode", "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { null, null, 0m, 160.00m, 0m, 1599.99m, new DateTime(2023, 8, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 12,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 13,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 14,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 15,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 16,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 17,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 18,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 19,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 20,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 21,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice", "SalesDate" },
                values: new object[] { null, 0m, 63.00m, 0m, 22, 899.99m, new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AppliedDiscountCode", "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice", "SalesDate" },
                values: new object[] { null, null, 0m, 110.50m, 0m, 23, 1299.99m, new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice", "SalesDate" },
                values: new object[] { null, 0m, 392.00m, 0m, 24, 2799.99m, new DateTime(2024, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice", "SalesDate" },
                values: new object[] { null, 0m, 209.00m, 0m, 25, 1899.99m, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 26,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 27,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 28,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 29,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 30,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { null, 0m, 337.50m, 0m, 2499.99m, new DateTime(2024, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { null, 0m, 540.00m, 0m, 3599.99m, new DateTime(2024, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "OriginalPrice", "SalesDate" },
                values: new object[] { 0m, new DateTime(2024, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 34,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 35,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 36,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 37,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 38,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 39,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 40,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 41,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 42,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 43,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 44,
                column: "OriginalPrice",
                value: 0m);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice", "SalesDate" },
                values: new object[] { null, 0m, 511.50m, 0m, 20, 3299.99m, new DateTime(2025, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice", "SalesDate" },
                values: new object[] { null, 0m, 624.00m, 0m, 21, 3899.99m, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { null, 0m, 63.00m, 0m, 899.99m, new DateTime(2025, 2, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "SalePrice", "SalesDate" },
                values: new object[] { null, 0m, 110.50m, 0m, 1299.99m, new DateTime(2025, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice" },
                values: new object[] { null, 0m, 392.00m, 0m, 24, 2799.99m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "CommissionAmount", "OriginalPrice", "ProductId", "SalePrice" },
                values: new object[] { null, 0m, 209.00m, 0m, 25, 1899.99m });
        }
    }
}
