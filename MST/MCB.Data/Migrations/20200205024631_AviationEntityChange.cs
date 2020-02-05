using Microsoft.EntityFrameworkCore.Migrations;

namespace MCB.Data.Migrations
{
    public partial class AviationEntityChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Airplane_AirplaneModel_AircraftModelId",
                table: "Airplane");

            migrationBuilder.DropForeignKey(
                name: "FK_AirplaneFactory_Country_AircraftFactoryCountryId",
                table: "AirplaneFactory");

            migrationBuilder.DropForeignKey(
                name: "FK_AirplaneModel_AirplaneFactory_AircraftFactoryId",
                table: "AirplaneModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Airplane_AircraftId",
                table: "Flight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AirplaneModel",
                table: "AirplaneModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AirplaneFactory",
                table: "AirplaneFactory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Airplane",
                table: "Airplane");

            migrationBuilder.RenameTable(
                name: "AirplaneModel",
                newName: "AircraftModel");

            migrationBuilder.RenameTable(
                name: "AirplaneFactory",
                newName: "AircraftFactory");

            migrationBuilder.RenameTable(
                name: "Airplane",
                newName: "Aircraft");

            migrationBuilder.RenameIndex(
                name: "IX_AirplaneModel_AircraftFactoryId",
                table: "AircraftModel",
                newName: "IX_AircraftModel_AircraftFactoryId");

            migrationBuilder.RenameIndex(
                name: "IX_AirplaneFactory_AircraftFactoryCountryId",
                table: "AircraftFactory",
                newName: "IX_AircraftFactory_AircraftFactoryCountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Airplane_AircraftModelId",
                table: "Aircraft",
                newName: "IX_Aircraft_AircraftModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AircraftModel",
                table: "AircraftModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AircraftFactory",
                table: "AircraftFactory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aircraft",
                table: "Aircraft",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aircraft_AircraftModel_AircraftModelId",
                table: "Aircraft",
                column: "AircraftModelId",
                principalTable: "AircraftModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AircraftFactory_Country_AircraftFactoryCountryId",
                table: "AircraftFactory",
                column: "AircraftFactoryCountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AircraftModel_AircraftFactory_AircraftFactoryId",
                table: "AircraftModel",
                column: "AircraftFactoryId",
                principalTable: "AircraftFactory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Aircraft_AircraftId",
                table: "Flight",
                column: "AircraftId",
                principalTable: "Aircraft",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aircraft_AircraftModel_AircraftModelId",
                table: "Aircraft");

            migrationBuilder.DropForeignKey(
                name: "FK_AircraftFactory_Country_AircraftFactoryCountryId",
                table: "AircraftFactory");

            migrationBuilder.DropForeignKey(
                name: "FK_AircraftModel_AircraftFactory_AircraftFactoryId",
                table: "AircraftModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Aircraft_AircraftId",
                table: "Flight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AircraftModel",
                table: "AircraftModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AircraftFactory",
                table: "AircraftFactory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aircraft",
                table: "Aircraft");

            migrationBuilder.RenameTable(
                name: "AircraftModel",
                newName: "AirplaneModel");

            migrationBuilder.RenameTable(
                name: "AircraftFactory",
                newName: "AirplaneFactory");

            migrationBuilder.RenameTable(
                name: "Aircraft",
                newName: "Airplane");

            migrationBuilder.RenameIndex(
                name: "IX_AircraftModel_AircraftFactoryId",
                table: "AirplaneModel",
                newName: "IX_AirplaneModel_AircraftFactoryId");

            migrationBuilder.RenameIndex(
                name: "IX_AircraftFactory_AircraftFactoryCountryId",
                table: "AirplaneFactory",
                newName: "IX_AirplaneFactory_AircraftFactoryCountryId");

            migrationBuilder.RenameIndex(
                name: "IX_Aircraft_AircraftModelId",
                table: "Airplane",
                newName: "IX_Airplane_AircraftModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AirplaneModel",
                table: "AirplaneModel",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AirplaneFactory",
                table: "AirplaneFactory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Airplane",
                table: "Airplane",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Airplane_AirplaneModel_AircraftModelId",
                table: "Airplane",
                column: "AircraftModelId",
                principalTable: "AirplaneModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AirplaneFactory_Country_AircraftFactoryCountryId",
                table: "AirplaneFactory",
                column: "AircraftFactoryCountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AirplaneModel_AirplaneFactory_AircraftFactoryId",
                table: "AirplaneModel",
                column: "AircraftFactoryId",
                principalTable: "AirplaneFactory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Airplane_AircraftId",
                table: "Flight",
                column: "AircraftId",
                principalTable: "Airplane",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
