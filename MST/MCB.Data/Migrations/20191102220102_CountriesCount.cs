using Microsoft.EntityFrameworkCore.Migrations;

namespace MCB.Data.Migrations
{
    public partial class CountriesCount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountriesCount",
                table: "Region",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CountryCount",
                table: "Continent",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CountriesCount",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "CountryCount",
                table: "Continent");
        }
    }
}
