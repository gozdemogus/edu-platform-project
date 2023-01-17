using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseIdentity.DataAccessLayer.Migrations
{
    public partial class mig_add_contact_username : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Contacts");
        }
    }
}
