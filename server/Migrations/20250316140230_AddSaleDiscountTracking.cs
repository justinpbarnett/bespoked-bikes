using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Migrations
{
    /// <inheritdoc />
    public partial class AddSaleDiscountTracking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Salespersons_FirstName_LastName",
                table: "Salespersons");

            migrationBuilder.AddColumn<int>(
                name: "AppliedDiscountId",
                table: "Sales",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AppliedDiscountPercentage",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "OriginalPrice",
                table: "Sales",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "Style",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Manufacturer",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "QuantityOnHand",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 24,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 25,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 26,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 27,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 28,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 29,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 30,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 31,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 32,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 34,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 35,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 41,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.UpdateData(
                table: "Sales",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "AppliedDiscountId", "AppliedDiscountPercentage", "OriginalPrice" },
                values: new object[] { null, 0m, 0m });

            migrationBuilder.CreateIndex(
                name: "IX_Salespersons_FirstName_LastName_Address",
                table: "Salespersons",
                columns: new[] { "FirstName", "LastName", "Address" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salespersons_FirstName_LastName_Phone",
                table: "Salespersons",
                columns: new[] { "FirstName", "LastName", "Phone" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sales_AppliedDiscountId",
                table: "Sales",
                column: "AppliedDiscountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sales_Discounts_AppliedDiscountId",
                table: "Sales",
                column: "AppliedDiscountId",
                principalTable: "Discounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sales_Discounts_AppliedDiscountId",
                table: "Sales");

            migrationBuilder.DropIndex(
                name: "IX_Salespersons_FirstName_LastName_Address",
                table: "Salespersons");

            migrationBuilder.DropIndex(
                name: "IX_Salespersons_FirstName_LastName_Phone",
                table: "Salespersons");

            migrationBuilder.DropIndex(
                name: "IX_Sales_AppliedDiscountId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "AppliedDiscountId",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "AppliedDiscountPercentage",
                table: "Sales");

            migrationBuilder.DropColumn(
                name: "OriginalPrice",
                table: "Sales");

            migrationBuilder.AlterColumn<string>(
                name: "Style",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Manufacturer",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                column: "QuantityOnHand",
                value: 3);

            migrationBuilder.CreateIndex(
                name: "IX_Salespersons_FirstName_LastName",
                table: "Salespersons",
                columns: new[] { "FirstName", "LastName" },
                unique: true);
        }
    }
}
