using Microsoft.EntityFrameworkCore.Migrations;

namespace MCB.Data.Migrations
{
    public partial class TripAndFlightsRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "Flight",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Flight_TripId",
                table: "Flight",
                column: "TripId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Trip_TripId",
                table: "Flight",
                column: "TripId",
                principalTable: "Trip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Trip_TripId",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_TripId",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "Flight");
        }
    }
}
