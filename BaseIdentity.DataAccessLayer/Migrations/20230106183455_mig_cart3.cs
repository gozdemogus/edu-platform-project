using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseIdentity.DataAccessLayer.Migrations
{
    public partial class mig_cart3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Carts_CartId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CartId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Courses");

            migrationBuilder.CreateTable(
                name: "CartCourse",
                columns: table => new
                {
                    CartsId = table.Column<int>(type: "int", nullable: false),
                    CoursesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartCourse", x => new { x.CartsId, x.CoursesId });
                    table.ForeignKey(
                        name: "FK_CartCourse_Carts_CartsId",
                        column: x => x.CartsId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartCourse_Courses_CoursesId",
                        column: x => x.CoursesId,
                        principalTable: "Courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartCourse_CoursesId",
                table: "CartCourse",
                column: "CoursesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartCourse");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CartId",
                table: "Courses",
                column: "CartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Carts_CartId",
                table: "Courses",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
