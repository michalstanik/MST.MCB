using Microsoft.EntityFrameworkCore.Migrations;

namespace MCB.Data.Migrations
{
    public partial class FlightType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FlightTypeAssessment",
                table: "Flight",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FlightTypeAssessment",
                table: "Flight");
        }
    }
}
