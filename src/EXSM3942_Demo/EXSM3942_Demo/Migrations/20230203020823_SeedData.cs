using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXSM3942Demo.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product_category",
                columns: new[] { "id", "description", "name" },
                values: new object[,]
                {
                    { -3, "Lettuce, tomatoes and stuff.", "Garden" },
                    { -2, "Meats and stuff.", "Deli" },
                    { -1, "Milk, cheese and stuff.", "Dairy" }
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_id", "description", "name" },
                values: new object[,]
                {
                    { -3, -3, "A head of lettuce.", "Lettuce" },
                    { -2, -2, "A slice of salami.", "Salami, Slice" },
                    { -1, -1, "A 4L bottle of 1% milk.", "Milk 1%, 4L" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "product_category",
                keyColumn: "id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "product_category",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "product_category",
                keyColumn: "id",
                keyValue: -1);
        }
    }
}
