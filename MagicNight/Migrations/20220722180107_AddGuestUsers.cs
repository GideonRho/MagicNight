using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicNight.Migrations
{
    public partial class AddGuestUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommanderRollEntries_Profiles_ProfileName",
                table: "CommanderRollEntries");

            migrationBuilder.DropIndex(
                name: "IX_CommanderRollEntries_ProfileName",
                table: "CommanderRollEntries");

            migrationBuilder.RenameColumn(
                name: "ProfileName",
                table: "CommanderRollEntries",
                newName: "User");

            migrationBuilder.CreateTable(
                name: "CommanderRollLobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Guid = table.Column<string>(type: "TEXT", nullable: true),
                    RollId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommanderRollLobbies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommanderRollLobbies_CommanderRolls_RollId",
                        column: x => x.RollId,
                        principalTable: "CommanderRolls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommanderRollLobbyEntries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LobbyId = table.Column<int>(type: "INTEGER", nullable: true),
                    User = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommanderRollLobbyEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommanderRollLobbyEntries_CommanderRollLobbies_LobbyId",
                        column: x => x.LobbyId,
                        principalTable: "CommanderRollLobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommanderRollLobbies_RollId",
                table: "CommanderRollLobbies",
                column: "RollId");

            migrationBuilder.CreateIndex(
                name: "IX_CommanderRollLobbyEntries_LobbyId",
                table: "CommanderRollLobbyEntries",
                column: "LobbyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommanderRollLobbyEntries");

            migrationBuilder.DropTable(
                name: "CommanderRollLobbies");

            migrationBuilder.RenameColumn(
                name: "User",
                table: "CommanderRollEntries",
                newName: "ProfileName");

            migrationBuilder.CreateIndex(
                name: "IX_CommanderRollEntries_ProfileName",
                table: "CommanderRollEntries",
                column: "ProfileName");

            migrationBuilder.AddForeignKey(
                name: "FK_CommanderRollEntries_Profiles_ProfileName",
                table: "CommanderRollEntries",
                column: "ProfileName",
                principalTable: "Profiles",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
