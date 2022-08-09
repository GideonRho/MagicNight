using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicNight.Migrations
{
    public partial class AddSetSettings : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SetSettings",
                columns: table => new
                {
                    Code = table.Column<string>(type: "TEXT", nullable: false),
                    CanRoll = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SetSettings", x => x.Code);
                    table.ForeignKey(
                        name: "FK_SetSettings_Sets_Code",
                        column: x => x.Code,
                        principalTable: "Sets",
                        principalColumn: "Code",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SetSettings");
        }
    }
}
