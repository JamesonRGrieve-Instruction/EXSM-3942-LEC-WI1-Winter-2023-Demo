using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EXSM3942Demo.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "manufacturer",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_manufacturer", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "model",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    manufacturerid = table.Column<int>(name: "manufacturer_id", type: "int(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_model", x => x.id);
                    table.ForeignKey(
                        name: "FK_Model_Manufacturer",
                        column: x => x.manufacturerid,
                        principalTable: "manufacturer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "vehicle",
                columns: table => new
                {
                    vin = table.Column<string>(type: "char(17)", nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    modelyear = table.Column<int>(name: "model_year", type: "int(10)", nullable: false),
                    colour = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    modelid = table.Column<int>(name: "model_id", type: "int(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_vehicle", x => x.vin);
                    table.ForeignKey(
                        name: "FK_Vehicle_Model",
                        column: x => x.modelid,
                        principalTable: "model",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "manufacturer",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { -2, "Dodge" },
                    { -1, "Ford" }
                });

            migrationBuilder.InsertData(
                table: "model",
                columns: new[] { "id", "manufacturer_id", "name" },
                values: new object[,]
                {
                    { -4, -2, "Stealth" },
                    { -3, -2, "Challenger" },
                    { -2, -1, "Probe" },
                    { -1, -1, "Mustang" }
                });

            migrationBuilder.InsertData(
                table: "vehicle",
                columns: new[] { "vin", "colour", "model_id", "model_year" },
                values: new object[,]
                {
                    { "1FABP2732GF171121", "Yellow", -1, 2008 },
                    { "1ZVBT22L6K5103610", "Blue", -2, 1994 },
                    { "2C3CDZGG0JH112887", "Red", -3, 2012 },
                    { "JB3BM64JXPY011653", "Silver", -4, 1993 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_model_manufacturer_id",
                table: "model",
                column: "manufacturer_id");

            migrationBuilder.CreateIndex(
                name: "IX_vehicle_model_id",
                table: "vehicle",
                column: "model_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "vehicle");

            migrationBuilder.DropTable(
                name: "model");

            migrationBuilder.DropTable(
                name: "manufacturer");
        }
    }
}
