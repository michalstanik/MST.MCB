using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MCB.Data.Migrations
{
    public partial class WorldHeritage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorldHeritageId",
                table: "Stop",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "WorldHeritage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UnescoId = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    IsoCodes = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    Latitude = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Region = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldHeritage", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorldHeritageCountry",
                columns: table => new
                {
                    WorldHeritageId = table.Column<int>(nullable: false),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorldHeritageCountry", x => new { x.WorldHeritageId, x.CountryId });
                    table.ForeignKey(
                        name: "FK_WorldHeritageCountry_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorldHeritageCountry_WorldHeritage_WorldHeritageId",
                        column: x => x.WorldHeritageId,
                        principalTable: "WorldHeritage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Stop_WorldHeritageId",
                table: "Stop",
                column: "WorldHeritageId");

            migrationBuilder.CreateIndex(
                name: "IX_WorldHeritageCountry_CountryId",
                table: "WorldHeritageCountry",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Stop_WorldHeritage_WorldHeritageId",
                table: "Stop",
                column: "WorldHeritageId",
                principalTable: "WorldHeritage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stop_WorldHeritage_WorldHeritageId",
                table: "Stop");

            migrationBuilder.DropTable(
                name: "WorldHeritageCountry");

            migrationBuilder.DropTable(
                name: "WorldHeritage");

            migrationBuilder.DropIndex(
                name: "IX_Stop_WorldHeritageId",
                table: "Stop");

            migrationBuilder.DropColumn(
                name: "WorldHeritageId",
                table: "Stop");
        }
    }
}
