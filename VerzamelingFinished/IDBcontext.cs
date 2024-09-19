
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using VerzamelingFinished.Models;

namespace VerzamelingFinished
{
    public interface IDBcontext
    {
        DbSet<Card> cards { get; set; }

        DbSet<Deck> decks { get; set; }

        DatabaseFacade Database { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        //Round the code video  Entity Framework Core migrations: Add a migration. Hier ben je aan begonnen maar nog niet afgemaakt. bij 4:40 minuten.

    }
}
