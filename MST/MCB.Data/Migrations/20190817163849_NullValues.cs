using Microsoft.EntityFrameworkCore.Migrations;

namespace MCB.Data.Migrations
{
    public partial class NullValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stop_Country_CountryId",
                table: "Stop");

            migrationBuilder.DropForeignKey(
                name: "FK_Stop_WorldHeritage_WorldHeritageId",
                table: "Stop");

            migrationBuilder.AlterColumn<int>(
                name: "WorldHeritageId",
                table: "Stop",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Stop",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Stop_Country_CountryId",
                table: "Stop",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Stop_WorldHeritage_WorldHeritageId",
                table: "Stop",
                column: "WorldHeritageId",
                principalTable: "WorldHeritage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stop_Country_CountryId",
                table: "Stop");

            migrationBuilder.DropForeignKey(
                name: "FK_Stop_WorldHeritage_WorldHeritageId",
                table: "Stop");

            migrationBuilder.AlterColumn<int>(
                name: "WorldHeritageId",
                table: "Stop",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Stop",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stop_Country_CountryId",
                table: "Stop",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stop_WorldHeritage_WorldHeritageId",
                table: "Stop",
                column: "WorldHeritageId",
                principalTable: "WorldHeritage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
