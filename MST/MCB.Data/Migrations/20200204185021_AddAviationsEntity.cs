using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MCB.Data.Migrations
{
    public partial class AddAviationsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DepartureDate",
                table: "Flight",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ArrivialDate",
                table: "Flight",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "AircraftId",
                table: "Flight",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AirlineId",
                table: "Flight",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CombinedNextFlightId",
                table: "Flight",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CombinedPreviousFlightId",
                table: "Flight",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Distance",
                table: "Flight",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduleArrivialDate",
                table: "Flight",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ScheduleDepartureDate",
                table: "Flight",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AirLineAlliance",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirLineAlliance", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AirplaneFactory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    AircraftFactoryCountryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirplaneFactory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirplaneFactory_Country_AircraftFactoryCountryId",
                        column: x => x.AircraftFactoryCountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Airline",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    AirlineCountryId = table.Column<int>(nullable: true),
                    AirLineAllianceId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airline", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airline_AirLineAlliance_AirLineAllianceId",
                        column: x => x.AirLineAllianceId,
                        principalTable: "AirLineAlliance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Airline_Country_AirlineCountryId",
                        column: x => x.AirlineCountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AirplaneModel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Model = table.Column<string>(nullable: true),
                    AircraftFactoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AirplaneModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AirplaneModel_AirplaneFactory_AircraftFactoryId",
                        column: x => x.AircraftFactoryId,
                        principalTable: "AirplaneFactory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Airplane",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TailNumber = table.Column<string>(nullable: true),
                    AircraftModelId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Airplane", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Airplane_AirplaneModel_AircraftModelId",
                        column: x => x.AircraftModelId,
                        principalTable: "AirplaneModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AircraftId",
                table: "Flight",
                column: "AircraftId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_AirlineId",
                table: "Flight",
                column: "AirlineId");

            migrationBuilder.CreateIndex(
                name: "IX_Flight_CombinedNextFlightId",
                table: "Flight",
                column: "CombinedNextFlightId",
                unique: true,
                filter: "[CombinedNextFlightId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Airline_AirLineAllianceId",
                table: "Airline",
                column: "AirLineAllianceId");

            migrationBuilder.CreateIndex(
                name: "IX_Airline_AirlineCountryId",
                table: "Airline",
                column: "AirlineCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Airplane_AircraftModelId",
                table: "Airplane",
                column: "AircraftModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AirplaneFactory_AircraftFactoryCountryId",
                table: "AirplaneFactory",
                column: "AircraftFactoryCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_AirplaneModel_AircraftFactoryId",
                table: "AirplaneModel",
                column: "AircraftFactoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airplane_AircraftId",
                table: "Flight",
                column: "AircraftId",
                principalTable: "Airplane",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airline_AirlineId",
                table: "Flight",
                column: "AirlineId",
                principalTable: "Airline",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Flight_CombinedNextFlightId",
                table: "Flight",
                column: "CombinedNextFlightId",
                principalTable: "Flight",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airplane_AircraftId",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airline_AirlineId",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Flight_CombinedNextFlightId",
                table: "Flight");

            migrationBuilder.DropTable(
                name: "Airline");

            migrationBuilder.DropTable(
                name: "Airplane");

            migrationBuilder.DropTable(
                name: "AirLineAlliance");

            migrationBuilder.DropTable(
                name: "AirplaneModel");

            migrationBuilder.DropTable(
                name: "AirplaneFactory");

            migrationBuilder.DropIndex(
                name: "IX_Flight_AircraftId",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_AirlineId",
                table: "Flight");

            migrationBuilder.DropIndex(
                name: "IX_Flight_CombinedNextFlightId",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "AircraftId",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "AirlineId",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "CombinedNextFlightId",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "CombinedPreviousFlightId",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "ScheduleArrivialDate",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "ScheduleDepartureDate",
                table: "Flight");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DepartureDate",
                table: "Flight",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ArrivialDate",
                table: "Flight",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
