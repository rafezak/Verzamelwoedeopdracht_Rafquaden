using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VerzamelingFinished.Models;

namespace VerzamelingFinished.Config
{
    public class DeckConfig : IEntityTypeConfiguration<Deck>
    {
        public void Configure(EntityTypeBuilder<Deck> builder)
        {
            // Configure the entity type mappings for the Deck class
            builder.ToTable("Decks"); // Set the table name for the entity
            builder.HasKey(d => d.Id); // Set the primary key property
            builder.Property(d => d.Name).IsRequired().HasMaxLength(50); // Configure the Name property

            // ... Add more configuration for other properties if needed

            // Optionally, you can also seed data for the entity
            builder.HasData(new Deck
            {
                Id = 1,
                Name = "Sample Deck",
                Description = "This is a sample deck",
                Image = "sample.jpg"
            });
        }
    }
}
