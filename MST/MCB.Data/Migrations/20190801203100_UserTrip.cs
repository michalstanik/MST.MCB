using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MCB.Data.Migrations
{
    public partial class UserTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    TripManagerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trip_TUser_TripManagerId",
                        column: x => x.TripManagerId,
                        principalTable: "TUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTrip",
                columns: table => new
                {
                    TripId = table.Column<int>(nullable: false),
                    TUserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTrip", x => new { x.TripId, x.TUserId });
                    table.ForeignKey(
                        name: "FK_UserTrip_TUser_TUserId",
                        column: x => x.TUserId,
                        principalTable: "TUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTrip_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trip_TripManagerId",
                table: "Trip",
                column: "TripManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTrip_TUserId",
                table: "UserTrip",
                column: "TUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserTrip");

            migrationBuilder.DropTable(
                name: "Trip");
        }
    }
}
