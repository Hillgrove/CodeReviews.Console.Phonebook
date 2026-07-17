using Microsoft.EntityFrameworkCore;
using PhoneBook.Hillgrove.Models;

namespace PhoneBook.Hillgrove.Data;

internal class PhoneBookContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var dbPath = Path.Combine(AppContext.BaseDirectory, "phonebook.db");

        optionsBuilder
            .UseSqlite($"Data Source={dbPath}")
            .UseSeeding((context, _) => SeedData.Seed(context))
            .UseAsyncSeeding(
                (context, _, cancellationToken) => SeedData.SeedAsync(context, cancellationToken)
            );
    }
}
