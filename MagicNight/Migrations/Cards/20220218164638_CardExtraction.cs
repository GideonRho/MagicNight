using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicNight.Migrations.Cards
{
    public partial class CardExtraction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Cost = table.Column<int>(type: "INTEGER", nullable: false),
                    Power = table.Column<int>(type: "INTEGER", nullable: false),
                    Toughness = table.Column<int>(type: "INTEGER", nullable: false),
                    Colors = table.Column<int>(type: "INTEGER", nullable: false),
                    Types = table.Column<int>(type: "INTEGER", nullable: false),
                    ProducedMana = table.Column<int>(type: "INTEGER", nullable: false),
                    Legalities = table.Column<int>(type: "INTEGER", nullable: false),
                    Thumbnail = table.Column<string>(type: "TEXT", nullable: true),
                    Image = table.Column<string>(type: "TEXT", nullable: true),
                    Uri = table.Column<string>(type: "TEXT", nullable: true),
                    Id = table.Column<string>(type: "TEXT", nullable: true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    ReleaseDate = table.Column<string>(type: "TEXT", nullable: true),
                    PartnerString = table.Column<string>(type: "TEXT", nullable: true),
                    PartnerName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Cards_Cards_PartnerName",
                        column: x => x.PartnerName,
                        principalTable: "Cards",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CardKeyword",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardName = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardKeyword", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardKeyword_Cards_CardName",
                        column: x => x.CardName,
                        principalTable: "Cards",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CardMinorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardName = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardMinorTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardMinorTypes_Cards_CardName",
                        column: x => x.CardName,
                        principalTable: "Cards",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CardSynergies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardName = table.Column<string>(type: "TEXT", nullable: true),
                    Type = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardSynergies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CardSynergies_Cards_CardName",
                        column: x => x.CardName,
                        principalTable: "Cards",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commander",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CardName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commander", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commander_Cards_CardName",
                        column: x => x.CardName,
                        principalTable: "Cards",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardKeyword_CardName",
                table: "CardKeyword",
                column: "CardName");

            migrationBuilder.CreateIndex(
                name: "IX_CardMinorTypes_CardName",
                table: "CardMinorTypes",
                column: "CardName");

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PartnerName",
                table: "Cards",
                column: "PartnerName");

            migrationBuilder.CreateIndex(
                name: "IX_CardSynergies_CardName",
                table: "CardSynergies",
                column: "CardName");

            migrationBuilder.CreateIndex(
                name: "IX_Commander_CardName",
                table: "Commander",
                column: "CardName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardKeyword");

            migrationBuilder.DropTable(
                name: "CardMinorTypes");

            migrationBuilder.DropTable(
                name: "CardSynergies");

            migrationBuilder.DropTable(
                name: "Commander");

            migrationBuilder.DropTable(
                name: "Cards");
        }
    }
}
