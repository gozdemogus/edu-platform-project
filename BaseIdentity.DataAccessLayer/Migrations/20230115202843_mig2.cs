using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseIdentity.DataAccessLayer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_AspNetUsers_AppUserId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_AppUserId",
                table: "Account");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Account",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AccountNumber",
                table: "Account",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "SiteAccount",
                table: "Account",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Account_AppUserId",
                table: "Account",
                column: "AppUserId",
                unique: true,
                filter: "[AppUserId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Account_AspNetUsers_AppUserId",
                table: "Account",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Account_AspNetUsers_AppUserId",
                table: "Account");

            migrationBuilder.DropIndex(
                name: "IX_Account_AppUserId",
                table: "Account");

            migrationBuilder.DropColumn(
                name: "SiteAccount",
                table: "Account");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Account",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AccountNumber",
                table: "Account",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Account_AppUserId",
                table: "Account",
                column: "AppUserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Account_AspNetUsers_AppUserId",
                table: "Account",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
