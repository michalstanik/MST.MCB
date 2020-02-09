using Microsoft.EntityFrameworkCore.Migrations;

namespace MCB.Data.Migrations
{
    public partial class AviationAddAirlineCodes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IATA",
                table: "Airline",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ICAO",
                table: "Airline",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IATA",
                table: "Airline");

            migrationBuilder.DropColumn(
                name: "ICAO",
                table: "Airline");
        }
    }
}
