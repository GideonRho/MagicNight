using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicNight.Migrations
{
    public partial class AddSetRoll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SetRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetRolls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SetRollEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SetRollId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProfileName = table.Column<string>(type: "TEXT", nullable: true),
                    SetCode = table.Column<string>(type: "TEXT", nullable: true),
                    DeckId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetRollEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetRollEntries_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SetRollEntries_Profiles_ProfileName",
                        column: x => x.ProfileName,
                        principalTable: "Profiles",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SetRollEntries_SetRolls_SetRollId",
                        column: x => x.SetRollId,
                        principalTable: "SetRolls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SetRollEntries_Sets_SetCode",
                        column: x => x.SetCode,
                        principalTable: "Sets",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SetRollEntries_DeckId",
                table: "SetRollEntries",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_SetRollEntries_ProfileName",
                table: "SetRollEntries",
                column: "ProfileName");

            migrationBuilder.CreateIndex(
                name: "IX_SetRollEntries_SetCode",
                table: "SetRollEntries",
                column: "SetCode");

            migrationBuilder.CreateIndex(
                name: "IX_SetRollEntries_SetRollId",
                table: "SetRollEntries",
                column: "SetRollId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetRollEntries");

            migrationBuilder.DropTable(
                name: "SetRolls");
        }
    }
}
