using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicNight.Migrations
{
    public partial class AddCommanderRoll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommanderRolls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommanderRolls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CommanderRollEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProfileName = table.Column<string>(type: "TEXT", nullable: true),
                    CommanderName = table.Column<string>(type: "TEXT", nullable: true),
                    PartnerName = table.Column<string>(type: "TEXT", nullable: true),
                    CommanderRollId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommanderRollEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommanderRollEntries_Cards_CommanderName",
                        column: x => x.CommanderName,
                        principalTable: "Cards",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommanderRollEntries_Cards_PartnerName",
                        column: x => x.PartnerName,
                        principalTable: "Cards",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommanderRollEntries_CommanderRolls_CommanderRollId",
                        column: x => x.CommanderRollId,
                        principalTable: "CommanderRolls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CommanderRollEntries_Profiles_ProfileName",
                        column: x => x.ProfileName,
                        principalTable: "Profiles",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommanderRollEntries_CommanderName",
                table: "CommanderRollEntries",
                column: "CommanderName");

            migrationBuilder.CreateIndex(
                name: "IX_CommanderRollEntries_CommanderRollId",
                table: "CommanderRollEntries",
                column: "CommanderRollId");

            migrationBuilder.CreateIndex(
                name: "IX_CommanderRollEntries_PartnerName",
                table: "CommanderRollEntries",
                column: "PartnerName");

            migrationBuilder.CreateIndex(
                name: "IX_CommanderRollEntries_ProfileName",
                table: "CommanderRollEntries",
                column: "ProfileName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommanderRollEntries");

            migrationBuilder.DropTable(
                name: "CommanderRolls");
        }
    }
}
