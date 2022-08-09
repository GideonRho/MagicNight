using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicNight.Migrations
{
    public partial class AddSetCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SetCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SetCode = table.Column<string>(type: "TEXT", nullable: true),
                    CardName = table.Column<string>(type: "TEXT", nullable: true),
                    Rarity = table.Column<int>(type: "INTEGER", nullable: false),
                    Thumbnail = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetCards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SetCards_Cards_CardName",
                        column: x => x.CardName,
                        principalTable: "Cards",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SetCards_Sets_SetCode",
                        column: x => x.SetCode,
                        principalTable: "Sets",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SetCards_CardName",
                table: "SetCards",
                column: "CardName");

            migrationBuilder.CreateIndex(
                name: "IX_SetCards_SetCode",
                table: "SetCards",
                column: "SetCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetCards");
        }
    }
}
