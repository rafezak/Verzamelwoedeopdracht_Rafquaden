using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VerzamelingFinished.Migrations
{
    /// <inheritdoc />
    public partial class adddecktodatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "cards",
                keyColumn: "Id",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "cards",
                columns: new[] { "Id", "DeckId", "Description", "Element", "Name", "Price", "Quantity" },
                values: new object[] { 1, 0, "An electric-type Pokémon", "Electric", "Pikachu", 10, 1 });
        }
    }
}
