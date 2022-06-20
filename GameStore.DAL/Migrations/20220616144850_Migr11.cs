using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameStore.DAL.Migrations
{
    public partial class Migr11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Publichers_PublicherId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "PublicherId",
                table: "Games",
                newName: "DeveloperId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_PublicherId",
                table: "Games",
                newName: "IX_Games_DeveloperId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Developers_DeveloperId",
                table: "Games",
                column: "DeveloperId",
                principalTable: "Developers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Developers_DeveloperId",
                table: "Games");

            migrationBuilder.RenameColumn(
                name: "DeveloperId",
                table: "Games",
                newName: "PublicherId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_DeveloperId",
                table: "Games",
                newName: "IX_Games_PublicherId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Publichers_PublicherId",
                table: "Games",
                column: "PublicherId",
                principalTable: "Publichers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
