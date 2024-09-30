using Microsoft.EntityFrameworkCore;
using VerzamelingFinished.Models;


namespace VerzamelingFinished
{
    public class DBcontext : DbContext, IDBcontext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connection = "Data Source=.;Initial Catalog=Pokemoncards;Integrated Security=True;Trust Server Certificate=True;";
            optionsBuilder.UseSqlServer(connection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // specify the table name
            modelBuilder.Entity<Card>()
                .Property(c => c.Name)
                .HasMaxLength(50);

            // data seeding
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
        }

        public DBcontext(DbContextOptions<DBcontext> options) : base(options)
        {
        }

        public DbSet<Card> cards { get; set; }
    }
}
 