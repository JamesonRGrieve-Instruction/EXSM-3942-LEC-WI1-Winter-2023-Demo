using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EXSM3942Demo.Migrations
{
    /// <inheritdoc />
    public partial class RandomSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "category_id", "description", "name" },
                values: new object[] { -4, -1, "A 2L bottle of Cola.", "Cola, 2L" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "product",
                keyColumn: "id",
                keyValue: -4);
        }
    }
}
