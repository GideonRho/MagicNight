using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicNight.Migrations
{
    public partial class AddForeignKeyToSetCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetCards_Sets_SetCode",
                table: "SetCards");

            migrationBuilder.RenameColumn(
                name: "SetCode",
                table: "SetCards",
                newName: "SetName");

            migrationBuilder.RenameIndex(
                name: "IX_SetCards_SetCode",
                table: "SetCards",
                newName: "IX_SetCards_SetName");

            migrationBuilder.AddForeignKey(
                name: "FK_SetCards_Sets_SetName",
                table: "SetCards",
                column: "SetName",
                principalTable: "Sets",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SetCards_Sets_SetName",
                table: "SetCards");

            migrationBuilder.RenameColumn(
                name: "SetName",
                table: "SetCards",
                newName: "SetCode");

            migrationBuilder.RenameIndex(
                name: "IX_SetCards_SetName",
                table: "SetCards",
                newName: "IX_SetCards_SetCode");

            migrationBuilder.AddForeignKey(
                name: "FK_SetCards_Sets_SetCode",
                table: "SetCards",
                column: "SetCode",
                principalTable: "Sets",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
