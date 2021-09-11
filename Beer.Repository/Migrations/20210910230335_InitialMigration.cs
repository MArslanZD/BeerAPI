using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Beer.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beers",
                columns: table => new
                {
                    BeerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    AverageRatings = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beers", x => x.BeerId);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeerId = table.Column<int>(nullable: false),
                    Ratings = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                });

            migrationBuilder.InsertData(
                table: "Beers",
                columns: new[] { "BeerId", "AverageRatings", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 0m, "Three Floyds Zombie Dust", "Pale Ale" },
                    { 2, 0m, "Sierra Nevada Pale Ale", "Pale Ale" },
                    { 3, 0m, "DRY IRISH STOUT ", "Stout" },
                    { 4, 0m, "MILK STOUT", "Stout" }
                });

            migrationBuilder.InsertData(
                table: "Ratings",
                columns: new[] { "RatingId", "BeerId", "Ratings" },
                values: new object[,]
                {
                    { 1, 1, 5 },
                    { 2, 1, 5 },
                    { 3, 1, 5 },
                    { 4, 1, 5 },
                    { 5, 1, 3 },
                    { 6, 2, 5 },
                    { 7, 2, 5 },
                    { 8, 3, 5 },
                    { 9, 4, 4 },
                    { 10, 4, 5 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beers");

            migrationBuilder.DropTable(
                name: "Ratings");
        }
    }
}
