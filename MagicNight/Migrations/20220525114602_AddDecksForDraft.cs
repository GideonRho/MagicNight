using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicNight.Migrations
{
    public partial class AddDecksForDraft : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DeckId",
                table: "DraftProfiles",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_DraftProfiles_DeckId",
                table: "DraftProfiles",
                column: "DeckId");

            migrationBuilder.AddForeignKey(
                name: "FK_DraftProfiles_Decks_DeckId",
                table: "DraftProfiles",
                column: "DeckId",
                principalTable: "Decks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DraftProfiles_Decks_DeckId",
                table: "DraftProfiles");

            migrationBuilder.DropIndex(
                name: "IX_DraftProfiles_DeckId",
                table: "DraftProfiles");

            migrationBuilder.DropColumn(
                name: "DeckId",
                table: "DraftProfiles");
        }
    }
}
