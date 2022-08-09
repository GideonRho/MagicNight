using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicNight.Migrations
{
    public partial class AddDraft : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drafts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    State = table.Column<int>(type: "INTEGER", nullable: false),
                    Timer = table.Column<int>(type: "INTEGER", nullable: false),
                    PickTime = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drafts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DraftProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DraftId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProfileName = table.Column<string>(type: "TEXT", nullable: true),
                    NextName = table.Column<string>(type: "TEXT", nullable: true),
                    PreviousName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DraftProfiles_Drafts_DraftId",
                        column: x => x.DraftId,
                        principalTable: "Drafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DraftProfiles_Profiles_NextName",
                        column: x => x.NextName,
                        principalTable: "Profiles",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DraftProfiles_Profiles_PreviousName",
                        column: x => x.PreviousName,
                        principalTable: "Profiles",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DraftProfiles_Profiles_ProfileName",
                        column: x => x.ProfileName,
                        principalTable: "Profiles",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DraftPacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DraftId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProfileId = table.Column<int>(type: "INTEGER", nullable: true),
                    IsPicked = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftPacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DraftPacks_DraftProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "DraftProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DraftPacks_Drafts_DraftId",
                        column: x => x.DraftId,
                        principalTable: "Drafts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DraftPackCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PackId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProfileName = table.Column<string>(type: "TEXT", nullable: true),
                    CardName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DraftPackCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DraftPackCards_Cards_CardName",
                        column: x => x.CardName,
                        principalTable: "Cards",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DraftPackCards_DraftPacks_PackId",
                        column: x => x.PackId,
                        principalTable: "DraftPacks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DraftPackCards_Profiles_ProfileName",
                        column: x => x.ProfileName,
                        principalTable: "Profiles",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DraftPackCards_CardName",
                table: "DraftPackCards",
                column: "CardName");

            migrationBuilder.CreateIndex(
                name: "IX_DraftPackCards_PackId",
                table: "DraftPackCards",
                column: "PackId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftPackCards_ProfileName",
                table: "DraftPackCards",
                column: "ProfileName");

            migrationBuilder.CreateIndex(
                name: "IX_DraftPacks_DraftId",
                table: "DraftPacks",
                column: "DraftId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftPacks_ProfileId",
                table: "DraftPacks",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftProfiles_DraftId",
                table: "DraftProfiles",
                column: "DraftId");

            migrationBuilder.CreateIndex(
                name: "IX_DraftProfiles_NextName",
                table: "DraftProfiles",
                column: "NextName");

            migrationBuilder.CreateIndex(
                name: "IX_DraftProfiles_PreviousName",
                table: "DraftProfiles",
                column: "PreviousName");

            migrationBuilder.CreateIndex(
                name: "IX_DraftProfiles_ProfileName",
                table: "DraftProfiles",
                column: "ProfileName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DraftPackCards");

            migrationBuilder.DropTable(
                name: "DraftPacks");

            migrationBuilder.DropTable(
                name: "DraftProfiles");

            migrationBuilder.DropTable(
                name: "Drafts");
        }
    }
}
