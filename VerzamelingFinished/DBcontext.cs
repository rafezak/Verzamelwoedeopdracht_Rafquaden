using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using VerzamelingFinished.Config;
using VerzamelingFinished.Models;


namespace VerzamelingFinished
{
    public class DBcontext : DbContext, IDBcontext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=.;Initial Catalog=pokemonverzamelingfinal;Integrated Security=True;Trust Server Certificate=True;";
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CardConfig());
            modelBuilder.ApplyConfiguration(new DeckConfig());


        }

            







        public DbSet<Card> cards { get; set; }

        public DbSet<Deck> decks { get; set; }
    }
}
 