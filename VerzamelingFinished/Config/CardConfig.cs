//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using VerzamelingFinished.Models;

//namespace VerzamelingFinished.Config
//{
//    public class CardConfig : IEntityTypeConfiguration<Card>
//    {
//        public void Configure(EntityTypeBuilder<Card> builder)
//        {
//            builder.ToTable("Cards");
//            builder.HasKey(c => c.Id);
//            builder.Property(c => c.Id).UseIdentityColumn();

//            builder.Property(c => c.Name).IsRequired().HasMaxLength(50);

//            builder.HasData(new List<Card>()
//            {
//                new Card()
//                {
//                    Id = 1,
//                    Name = "Pikachu",
//                    Description = "An electric-type Pokémon",
//                    Element = "Electric",
//                    Price = 10,
//                    Quantity = 1
//                }

//            });

//            builder.HasOne(c => c.de)
//                .WithMany(d => d.Cards)
//                .HasForeignKey(c => c.DeckId)
//                .HasConstraintName("FK_Cards_Decks");

//        }
//    }
// }

