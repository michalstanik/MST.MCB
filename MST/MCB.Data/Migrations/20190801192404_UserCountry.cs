using Microsoft.EntityFrameworkCore.Migrations;

namespace MCB.Data.Migrations
{
    public partial class UserCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCountry",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false),
                    TUserId = table.Column<string>(nullable: false),
                    AreaLevelAssessment = table.Column<long>(nullable: false),
                    CountryKnowledgeType = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCountry", x => new { x.CountryId, x.TUserId });
                    table.ForeignKey(
                        name: "FK_UserCountry_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserCountry_TUser_TUserId",
                        column: x => x.TUserId,
                        principalTable: "TUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserCountry_TUserId",
                table: "UserCountry",
                column: "TUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserCountry");

            migrationBuilder.DropTable(
                name: "TUser");
        }
    }
}
