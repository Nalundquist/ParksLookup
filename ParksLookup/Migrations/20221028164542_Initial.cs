using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ParksLookup.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Parks",
                columns: table => new
                {
                    ParkId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    NatlOrState = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Description = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parks", x => x.ParkId);
                });

            migrationBuilder.InsertData(
                table: "Parks",
                columns: new[] { "ParkId", "Description", "Name", "NatlOrState" },
                values: new object[,]
                {
                    { 1, "Cool Rocks abounds", "Yosemite", "National" },
                    { 2, "Theres a bridge made of naturally formed rock candy, wow", "Fake State Park", "State" },
                    { 3, "This majestic waterfall is actually a bigscreen tv", "False Falls", "National" },
                    { 4, "It's on the ocean, nice breeze", "Jean Genet Memorial State Park", "State" },
                    { 5, "All the rocks here are actually rubbery cushions, you can bounce around.  It rules.", "Floppy Canyon", "National" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Parks");
        }
    }
}
