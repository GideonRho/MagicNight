using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicNight.Migrations.Cards
{
    public partial class AddPriceAndRanking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Cards",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "Cards",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "Rank",
                table: "Cards");
        }
    }
}
