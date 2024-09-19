using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VerzamelingFinished.Migrations
{
    /// <inheritdoc />
    public partial class VerzamelingFinishes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "cards",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "DeckId",
                table: "cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "decks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_decks", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "cards",
                keyColumn: "Id",
                keyValue: 1,
                column: "DeckId",
                value: 0);

            migrationBuilder.InsertData(
                table: "decks",
                columns: new[] { "Id", "Description", "Image", "Name" },
                values: new object[] { 1, "This is a deck for fire-type pokémon", "https://www.google.com/imgres?q=fire%20type%20pokemon&imgurl=https%3A%2F%2Fwww.giantbomb.com%2Fa%2Fuploads%2Fscale_medium%2F16%2F164924%2F3083931-8746743194-flat%252C.jpg&imgrefurl=https%3A%2F%2Fwww.giantbomb.com%2Ffire-type-pokemon%2F3015-9335%2Fconcepts%2F&docid=WLY_uPa4-K5oGM&tbnid=kS_yRrWBHuHJCM&vet=12ahUKEwiT3ZbF0s6IAxWJygIHHRW-CAUQM3oECGQQAA..i&w=960&h=960&hcb=2&ved=2ahUKEwiT3ZbF0s6IAxWJygIHHRW-CAUQM3oECGQQAA", "Fire-Types" });

            migrationBuilder.CreateIndex(
                name: "IX_cards_DeckId",
                table: "cards",
                column: "DeckId");

            migrationBuilder.AddForeignKey(
                name: "FK_cards_decks_DeckId",
                table: "cards",
                column: "DeckId",
                principalTable: "decks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cards_decks_DeckId",
                table: "cards");

            migrationBuilder.DropTable(
                name: "decks");

            migrationBuilder.DropIndex(
                name: "IX_cards_DeckId",
                table: "cards");

            migrationBuilder.DropColumn(
                name: "DeckId",
                table: "cards");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "cards",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
