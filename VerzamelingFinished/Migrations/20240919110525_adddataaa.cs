using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VerzamelingFinished.Migrations
{
    /// <inheritdoc />
    public partial class adddataaa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cards_decks_DeckId",
                table: "cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_decks",
                table: "decks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_cards",
                table: "cards");

            migrationBuilder.RenameTable(
                name: "decks",
                newName: "Decks");

            migrationBuilder.RenameTable(
                name: "cards",
                newName: "Cards");

            migrationBuilder.RenameIndex(
                name: "IX_cards_DeckId",
                table: "Cards",
                newName: "IX_Cards_DeckId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Cards",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Decks",
                table: "Decks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cards",
                table: "Cards",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "DeckId", "Description", "Element", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Description 1", "Element 1", "Card 1", 10, 5 },
                    { 2, 1, "Description 2", "Element 2", "Card 2", 20, 10 }
                });

            migrationBuilder.UpdateData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Description 1", "Image 1", "Deck 1" });

            migrationBuilder.InsertData(
                table: "Decks",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[] { 2, "Description 2", "Image 2", "Deck 2" });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "DeckId", "Description", "Element", "Name", "Price", "Quantity" },
                values: new object[] { 3, 2, "Description 3", "Element 3", "Card 3", 30, 15 });

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Decks_DeckId",
                table: "Cards",
                column: "DeckId",
                principalTable: "Decks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Decks_DeckId",
                table: "Cards");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Decks",
                table: "Decks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cards",
                table: "Cards");

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Decks",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.RenameTable(
                name: "Decks",
                newName: "decks");

            migrationBuilder.RenameTable(
                name: "Cards",
                newName: "cards");

            migrationBuilder.RenameIndex(
                name: "IX_Cards_DeckId",
                table: "cards",
                newName: "IX_cards_DeckId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "cards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_decks",
                table: "decks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_cards",
                table: "cards",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "decks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "This is a deck for fire-type pokémon", "https://www.google.com/imgres?q=fire%20type%20pokemon&imgurl=https%3A%2F%2Fwww.giantbomb.com%2Fa%2Fuploads%2Fscale_medium%2F16%2F164924%2F3083931-8746743194-flat%252C.jpg&imgrefurl=https%3A%2F%2Fwww.giantbomb.com%2Ffire-type-pokemon%2F3015-9335%2Fconcepts%2F&docid=WLY_uPa4-K5oGM&tbnid=kS_yRrWBHuHJCM&vet=12ahUKEwiT3ZbF0s6IAxWJygIHHRW-CAUQM3oECGQQAA..i&w=960&h=960&hcb=2&ved=2ahUKEwiT3ZbF0s6IAxWJygIHHRW-CAUQM3oECGQQAA", "Fire-Types" });

            migrationBuilder.AddForeignKey(
                name: "FK_cards_decks_DeckId",
                table: "cards",
                column: "DeckId",
                principalTable: "decks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
