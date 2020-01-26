using Microsoft.EntityFrameworkCore.Migrations;

namespace MCB.Data.Migrations
{
    public partial class RegionMinMaxLatLong : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "MaxLatitude",
                table: "Region",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MaxLongitude",
                table: "Region",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MinLatitude",
                table: "Region",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "MinLongitude",
                table: "Region",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxLatitude",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "MaxLongitude",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "MinLatitude",
                table: "Region");

            migrationBuilder.DropColumn(
                name: "MinLongitude",
                table: "Region");
        }
    }
}
