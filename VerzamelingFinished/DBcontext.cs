using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
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
            base.OnModelCreating(modelBuilder);

            // Configure the many-to-many relationship
            modelBuilder.Entity<Card>()
                .HasMany(c => c.Decks)
                .WithMany(d => d.Cards)
                .UsingEntity<Dictionary<string, object>>(
                    "CardDeck", // Name of the join table
                    j => j.HasOne<Deck>().WithMany().HasForeignKey("DeckId"),
                    j => j.HasOne<Card>().WithMany().HasForeignKey("CardId"));


        }

        public DbSet<Card> cards { get; set; }
        public DbSet<Deck> decks { get; set; }
    }
}
 