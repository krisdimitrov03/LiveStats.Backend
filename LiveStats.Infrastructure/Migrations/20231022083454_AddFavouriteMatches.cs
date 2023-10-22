using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiveStats.Infrastructure.Migrations
{
    public partial class AddFavouriteMatches : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fb_UsersMatches",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MatchId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fb_UsersMatches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fb_UsersMatches_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fb_UsersMatches_Fb_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Fb_Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fb_UsersMatches_MatchId",
                table: "Fb_UsersMatches",
                column: "MatchId");

            migrationBuilder.CreateIndex(
                name: "IX_Fb_UsersMatches_UserId",
                table: "Fb_UsersMatches",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fb_UsersMatches");
        }
    }
}
