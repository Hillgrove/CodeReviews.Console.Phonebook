using Microsoft.EntityFrameworkCore;
using PhoneBook.Hillgrove.Models;

namespace PhoneBook.Hillgrove.Data;

internal class SeedData
{
    public static void Seed(DbContext context)
    {
        if (context.Set<Contact>().Any())
            return;

        var categories = GetCategories();
        context.Set<Category>().AddRange(categories);
        context.Set<Contact>().AddRange(GetContacts(categories));

        context.SaveChanges();
    }

    internal static async Task SeedAsync(DbContext context, CancellationToken cancellationToken)
    {
        if (await context.Set<Contact>().AnyAsync(cancellationToken))
            return;

        var categories = GetCategories();
        context.Set<Category>().AddRange(categories);
        context.Set<Contact>().AddRange(GetContacts(categories));

        await context.SaveChangesAsync(cancellationToken);
    }

    private static List<Category> GetCategories()
    {
        return new List<Category>()
        {
            new() { Name = "Family" },
            new() { Name = "Friends" },
            new() { Name = "Work" },
        };
    }

    private static List<Contact> GetContacts(List<Category> categories)
    {
        var family = categories[0];
        var friends = categories[1];
        var work = categories[2];

        return new List<Contact>()
        {
            new()
            {
                Name = "Alice Johnson",
                Email = "alice.johnson@example.com",
                PhoneNumber = "555-0101",
                Categories = [family, friends],
            },
            new()
            {
                Name = "Bob Smith",
                Email = "bob.smith@example.com",
                PhoneNumber = "555-0102",
                Categories = [work],
            },
            new()
            {
                Name = "Carol Williams",
                Email = "carol.williams@example.com",
                PhoneNumber = "555-0103",
                Categories = [family],
            },
            new()
            {
                Name = "David Brown",
                Email = "david.brown@example.com",
                PhoneNumber = "555-0104",
                Categories = [work, friends],
            },
            new()
            {
                Name = "Emma Davis",
                Email = "emma.davis@example.com",
                PhoneNumber = "555-0105",
                Categories = [family],
            },
            new()
            {
                Name = "Frank Miller",
                Email = "frank.miller@example.com",
                PhoneNumber = "555-0106",
                Categories = [work],
            },
            new()
            {
                Name = "Grace Wilson",
                Email = "grace.wilson@example.com",
                PhoneNumber = "555-0107",
                Categories = [friends],
            },
            new()
            {
                Name = "Henry Moore",
                Email = "henry.moore@example.com",
                PhoneNumber = "555-0108",
                Categories = [work, family],
            },
            new()
            {
                Name = "Isabel Taylor",
                Email = "isabel.taylor@example.com",
                PhoneNumber = "555-0109",
                Categories = [friends],
            },
            new()
            {
                Name = "Jack Anderson",
                Email = "jack.anderson@example.com",
                PhoneNumber = "555-0110",
                Categories = [],
            },
        };
    }
}
