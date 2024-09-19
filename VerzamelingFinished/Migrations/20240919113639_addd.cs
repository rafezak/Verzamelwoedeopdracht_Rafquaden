using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VerzamelingFinished.Migrations
{
    /// <inheritdoc />
    public partial class addd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Decks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Decks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Element = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DeckId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cards_Decks_DeckId",
                        column: x => x.DeckId,
                        principalTable: "Decks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "cards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeckId", "Description", "Element", "Name", "Quantity" },
                values: new object[] { 0, "An electric-type Pokémon", "Electric", "Pikachu", 1 });

            migrationBuilder.UpdateData(
                table: "decks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "A deck full of electric-type Pokémon", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.pinterest.com%2Fpin%2Felectric-energy-card-vector-symbol-by-biochao-on-deviantart--635852041162050260%2F&psig=AOvVaw1VhoMWHjxJd-1TAgrQrnv9&ust=1726831793197000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCICN3vLzzogDFQAAAAAdAAAAABAJ", "Electric Deck" });

            migrationBuilder.CreateIndex(
                name: "IX_Cards_DeckId",
                table: "Cards",
                column: "DeckId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "Decks");

            migrationBuilder.UpdateData(
                table: "Cards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DeckId", "Description", "Element", "Name", "Quantity" },
                values: new object[] { 1, "Description 1", "Element 1", "Card 1", 5 });

            migrationBuilder.InsertData(
                table: "Cards",
                columns: new[] { "Id", "DeckId", "Description", "Element", "Name", "Price", "Quantity" },
                values: new object[] { 2, 1, "Description 2", "Element 2", "Card 2", 20, 10 });

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

            migrationBuilder.CreateIndex(
                name: "IX_Cards_DeckId",
                table: "Cards",
                column: "DeckId");

            migrationBuilder.CreateIndex(
                name: "IX_Decks_Id",
                table: "Decks",
                column: "Id");
        }
    }
}
