using Microsoft.EntityFrameworkCore.Migrations;

namespace MagicNight.Migrations
{
    public partial class CardExtration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CardKeyword_Cards_CardName",
                table: "CardKeyword");

            migrationBuilder.DropForeignKey(
                name: "FK_CardMinorTypes_Cards_CardName",
                table: "CardMinorTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Cards_PartnerName",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_CardSynergies_Cards_CardName",
                table: "CardSynergies");

            migrationBuilder.DropForeignKey(
                name: "FK_Commanders_Cards_CardName",
                table: "Commanders");

            migrationBuilder.DropForeignKey(
                name: "FK_DeckCards_Cards_CardName",
                table: "DeckCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardSynergies",
                table: "CardSynergies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardMinorTypes",
                table: "CardMinorTypes");

            migrationBuilder.RenameTable(
                name: "CardSynergies",
                newName: "CardSynergy");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "Card");

            migrationBuilder.RenameTable(
                name: "CardMinorTypes",
                newName: "CardMinorType");

            migrationBuilder.RenameIndex(
                name: "IX_CardSynergies_CardName",
                table: "CardSynergy",
                newName: "IX_CardSynergy_CardName");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_PartnerName",
                table: "Card",
                newName: "IX_Card_PartnerName");

            migrationBuilder.RenameIndex(
                name: "IX_CardMinorTypes_CardName",
                table: "CardMinorType",
                newName: "IX_CardMinorType_CardName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardSynergy",
                table: "CardSynergy",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Card",
                table: "Card",
                column: "Name");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardMinorType",
                table: "CardMinorType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Card_Card_PartnerName",
                table: "Card",
                column: "PartnerName",
                principalTable: "Card",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CardKeyword_Card_CardName",
                table: "CardKeyword",
                column: "CardName",
                principalTable: "Card",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CardMinorType_Card_CardName",
                table: "CardMinorType",
                column: "CardName",
                principalTable: "Card",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CardSynergy_Card_CardName",
                table: "CardSynergy",
                column: "CardName",
                principalTable: "Card",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commanders_Card_CardName",
                table: "Commanders",
                column: "CardName",
                principalTable: "Card",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeckCards_Card_CardName",
                table: "DeckCards",
                column: "CardName",
                principalTable: "Card",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Card_Card_PartnerName",
                table: "Card");

            migrationBuilder.DropForeignKey(
                name: "FK_CardKeyword_Card_CardName",
                table: "CardKeyword");

            migrationBuilder.DropForeignKey(
                name: "FK_CardMinorType_Card_CardName",
                table: "CardMinorType");

            migrationBuilder.DropForeignKey(
                name: "FK_CardSynergy_Card_CardName",
                table: "CardSynergy");

            migrationBuilder.DropForeignKey(
                name: "FK_Commanders_Card_CardName",
                table: "Commanders");

            migrationBuilder.DropForeignKey(
                name: "FK_DeckCards_Card_CardName",
                table: "DeckCards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardSynergy",
                table: "CardSynergy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CardMinorType",
                table: "CardMinorType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Card",
                table: "Card");

            migrationBuilder.RenameTable(
                name: "CardSynergy",
                newName: "CardSynergies");

            migrationBuilder.RenameTable(
                name: "CardMinorType",
                newName: "CardMinorTypes");

            migrationBuilder.RenameTable(
                name: "Card",
                newName: "Cards");

            migrationBuilder.RenameIndex(
                name: "IX_CardSynergy_CardName",
                table: "CardSynergies",
                newName: "IX_CardSynergies_CardName");

            migrationBuilder.RenameIndex(
                name: "IX_CardMinorType_CardName",
                table: "CardMinorTypes",
                newName: "IX_CardMinorTypes_CardName");

            migrationBuilder.RenameIndex(
                name: "IX_Card_PartnerName",
                table: "Cards",
                newName: "IX_Cards_PartnerName");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardSynergies",
                table: "CardSynergies",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CardMinorTypes",
                table: "CardMinorTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_CardKeyword_Cards_CardName",
                table: "CardKeyword",
                column: "CardName",
                principalTable: "Cards",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CardMinorTypes_Cards_CardName",
                table: "CardMinorTypes",
                column: "CardName",
                principalTable: "Cards",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Cards_PartnerName",
                table: "Cards",
                column: "PartnerName",
                principalTable: "Cards",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CardSynergies_Cards_CardName",
                table: "CardSynergies",
                column: "CardName",
                principalTable: "Cards",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Commanders_Cards_CardName",
                table: "Commanders",
                column: "CardName",
                principalTable: "Cards",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DeckCards_Cards_CardName",
                table: "DeckCards",
                column: "CardName",
                principalTable: "Cards",
                principalColumn: "Name",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
