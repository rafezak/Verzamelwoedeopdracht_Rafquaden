using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using VerzamelingFinished.Models;


namespace VerzamelingFinished
{
    public class DBcontext : DbContext, IDBcontext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=.;Initial Catalog=pokemonverzameling;Integrated Security=True;Trust Server Certificate=True;";
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // specify 
            modelBuilder.Entity<Card>()
                .Property(c => c.Name)
                .HasMaxLength(50);

            

                Card cardentity = new Card()
                {
                    Id = 1,
                    Name = "Pikachu",
                    Description = "An electric-type Pokémon",
                    Element = "Electric",
                    Price = 10,
                    Quantity = 1
                };

            modelBuilder.Entity<Card>().HasData(cardentity);


            modelBuilder.Entity<Deck>()

                .HasMany(d => d.Cards)
                .WithOne(c => c.Deck)
                .HasForeignKey(c => c.DeckId);

            Deck deckentity = new Deck()
            {
                Id = 1,
                Name = "Electric Deck",
                Description = "A deck full of electric-type Pokémon",
                Image= "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.pinterest.com%2Fpin%2Felectric-energy-card-vector-symbol-by-biochao-on-deviantart--635852041162050260%2F&psig=AOvVaw1VhoMWHjxJd-1TAgrQrnv9&ust=1726831793197000&source=images&cd=vfe&opi=89978449&ved=0CBQQjRxqFwoTCICN3vLzzogDFQAAAAAdAAAAABAJ"

            };

            modelBuilder.Entity<Deck>().HasData(deckentity);




        }

            







        public DbSet<Card> cards { get; set; }

        public DbSet<Deck> decks { get; set; }
    }
}
 