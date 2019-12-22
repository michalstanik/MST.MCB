using Microsoft.EntityFrameworkCore.Migrations;

namespace MCB.Data.Migrations
{
    public partial class FlightsArrivalAndDepartureAirports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ArrivalAirportId",
                table: "Flight",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DepartureAirportId",
                table: "Flight",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flight_ArrivalAirportId",
                table: "Flight",
                column: "ArrivalAirportId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_DepartureAirportId",
                table: "Flight",
                column: "DepartureAirportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_ArrivalAirportId",
                table: "Flight",
                column: "ArrivalAirportId",
                principalTable: "Airport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airport_DepartureAirportId",
                table: "Flight",
                column: "DepartureAirportId",
                principalTable: "Airport",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_ArrivalAirportId",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airport_DepartureAirportId",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_ArrivalAirportId",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_DepartureAirportId",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "ArrivalAirportId",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "DepartureAirportId",
                table: "Flight");
        }
    }
}
