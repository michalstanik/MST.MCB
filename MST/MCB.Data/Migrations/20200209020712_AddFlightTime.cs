using Microsoft.EntityFrameworkCore.Migrations;

namespace MCB.Data.Migrations
{
    public partial class AddFlightTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "FlightTime",
                table: "Flight",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightTime",
                table: "Flight");
        }
    }
}
