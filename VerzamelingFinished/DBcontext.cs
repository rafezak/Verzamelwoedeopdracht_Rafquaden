using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using VerzamelingFinished.Config;
using VerzamelingFinished.Models;


namespace VerzamelingFinished
{
    public class DBcontext : DbContext, IDBcontext
    {
        public DBcontext(DbContextOptions<DBcontext> options)
            : base(options)
        {
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
 