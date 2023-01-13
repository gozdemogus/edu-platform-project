using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SignalR.Migrations
{
    public partial class DbInitializationWithSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MarketTrends",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Income = table.Column<int>(nullable: false),
                    Expenses = table.Column<int>(nullable: false),
                    WeekDays = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketTrends", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    ViewsCount = table.Column<int>(nullable: false),
                    PageViewsCount = table.Column<int>(nullable: false),
                    NewUsers = table.Column<int>(nullable: false),
                    BuyedCourses = table.Column<int>(nullable: false),
                    BuyedCourseIncreaseRate = table.Column<int>(nullable: false),
                    TotalLikes = table.Column<int>(nullable: false),
                    TotalDislikes = table.Column<int>(nullable: false),
                    UsersCount = table.Column<int>(nullable: false),
                    UsersIncreaseRate = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Traffics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    SocialMedia = table.Column<int>(nullable: false),
                    GoogleSearch = table.Column<int>(nullable: false),
                    Referrals = table.Column<int>(nullable: false),
                    EmailMarketing = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traffics", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketTrends");

            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "Traffics");
        }
    }
}
