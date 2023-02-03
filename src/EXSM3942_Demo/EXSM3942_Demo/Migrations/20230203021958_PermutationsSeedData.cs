using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXSM3942Demo.Migrations
{
    /// <inheritdoc />
    public partial class PermutationsSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_id", "description", "name" },
                values: new object[,]
                {
                    { -28, -1, "A 4L bottle of Honey.", "Honey, 4L" },
                    { -27, -1, "A 3L bottle of Honey.", "Honey, 3L" },
                    { -26, -1, "A 2L bottle of Honey.", "Honey, 2L" },
                    { -25, -1, "A 1L bottle of Honey.", "Honey, 1L" },
                    { -24, -1, "A 0.5L bottle of Honey.", "Honey, 0.5L" },
                    { -23, -1, "A 4L bottle of Water.", "Water, 4L" },
                    { -22, -1, "A 3L bottle of Water.", "Water, 3L" },
                    { -21, -1, "A 2L bottle of Water.", "Water, 2L" },
                    { -20, -1, "A 1L bottle of Water.", "Water, 1L" },
                    { -19, -1, "A 0.5L bottle of Water.", "Water, 0.5L" },
                    { -18, -1, "A 4L bottle of Cola.", "Cola, 4L" },
                    { -17, -1, "A 3L bottle of Cola.", "Cola, 3L" },
                    { -16, -1, "A 2L bottle of Cola.", "Cola, 2L" },
                    { -15, -1, "A 1L bottle of Cola.", "Cola, 1L" },
                    { -14, -1, "A 0.5L bottle of Cola.", "Cola, 0.5L" },
                    { -13, -1, "A 4L bottle of Coffee.", "Coffee, 4L" },
                    { -12, -1, "A 3L bottle of Coffee.", "Coffee, 3L" },
                    { -11, -1, "A 2L bottle of Coffee.", "Coffee, 2L" },
                    { -10, -1, "A 1L bottle of Coffee.", "Coffee, 1L" },
                    { -9, -1, "A 0.5L bottle of Coffee.", "Coffee, 0.5L" },
                    { -8, -1, "A 4L bottle of Milk.", "Milk, 4L" },
                    { -7, -1, "A 3L bottle of Milk.", "Milk, 3L" },
                    { -6, -1, "A 2L bottle of Milk.", "Milk, 2L" },
                    { -5, -1, "A 1L bottle of Milk.", "Milk, 1L" },
                    { -4, -1, "A 0.5L bottle of Milk.", "Milk, 0.5L" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -28);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -27);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -26);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -25);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -24);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -23);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -22);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -21);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -20);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -19);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -18);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -17);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -16);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -15);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -14);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -13);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -12);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -11);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -10);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -9);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -8);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -7);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -6);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -5);

            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -4);
        }
    }
}
