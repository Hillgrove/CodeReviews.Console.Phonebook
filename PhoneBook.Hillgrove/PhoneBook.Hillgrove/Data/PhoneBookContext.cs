using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
                (context, _, CancellationToken) => SeedData.SeedAsync(context, CancellationToken)
            )
            // .EnableSensitiveDataLogging()
            // .UseLoggerFactory(GetLoggerFactory())
        ;
    }

    private ILoggerFactory? GetLoggerFactory()
    {
        var loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
            builder.AddFilter(
                (category, level) =>
                    category == DbLoggerCategory.Database.Command.Name
                    && level == LogLevel.Information
            );
        });

        return loggerFactory;
    }
}
