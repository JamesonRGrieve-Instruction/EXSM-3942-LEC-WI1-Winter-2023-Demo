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
                name: "classroom",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    roomnumber = table.Column<int>(name: "room_number", type: "int(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classroom", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    firstname = table.Column<string>(name: "first_name", type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lastname = table.Column<string>(name: "last_name", type: "varchar(30)", maxLength: 30, nullable: false, collation: "utf8mb4_general_ci")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    classroomid = table.Column<int>(name: "classroom_id", type: "int(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_student", x => x.id);
                    table.ForeignKey(
                        name: "FK_Student_ClassRoom",
                        column: x => x.classroomid,
                        principalTable: "classroom",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "classroom",
                columns: new[] { "id", "room_number" },
                values: new object[,]
                {
                    { -3, 1003 },
                    { -2, 1002 },
                    { -1, 1001 }
                });

            migrationBuilder.InsertData(
                table: "student",
                columns: new[] { "id", "classroom_id", "first_name", "last_name" },
                values: new object[,]
                {
                    { -25, -2, "James", "Jones" },
                    { -24, -3, "James", "Brown" },
                    { -23, -2, "James", "Williams" },
                    { -22, -2, "James", "Johnson" },
                    { -21, -2, "James", "Smith" },
                    { -20, -2, "Elijah", "Jones" },
                    { -19, -1, "Elijah", "Brown" },
                    { -18, -1, "Elijah", "Williams" },
                    { -17, -1, "Elijah", "Johnson" },
                    { -16, -1, "Elijah", "Smith" },
                    { -15, -2, "Oliver", "Jones" },
                    { -14, -2, "Oliver", "Brown" },
                    { -13, -2, "Oliver", "Williams" },
                    { -12, -1, "Oliver", "Johnson" },
                    { -11, -2, "Oliver", "Smith" },
                    { -10, -2, "Noah", "Jones" },
                    { -9, -1, "Noah", "Brown" },
                    { -8, -2, "Noah", "Williams" },
                    { -7, -3, "Noah", "Johnson" },
                    { -6, -1, "Noah", "Smith" },
                    { -5, -3, "Liam", "Jones" },
                    { -4, -3, "Liam", "Brown" },
                    { -3, -1, "Liam", "Williams" },
                    { -2, -1, "Liam", "Johnson" },
                    { -1, -1, "Liam", "Smith" }
                });

            migrationBuilder.CreateIndex(
                name: "FK_Student_ClassRoom",
                table: "student",
                column: "classroom_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "classroom");
        }
    }
}
