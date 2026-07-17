using Microsoft.EntityFrameworkCore;
using PhoneBook.Hillgrove.Data;
using PhoneBook.Hillgrove.Models;

namespace PhoneBook.Hillgrove.Repositories;

internal static class ContactRepository
{
    public static void AddContact(Contact contact, List<int> categoryIds)
    {
        using var db = new PhoneBookContext();

        if (categoryIds.Count > 0)
            contact.Categories = db
                .Categories.Where(c => categoryIds.Contains(c.CategoryId))
                .ToList();

        db.Contacts.Add(contact);
        db.SaveChanges();
    }

    public static void UpdateContact(Contact contact, List<int> categoryIds)
    {
        using var db = new PhoneBookContext();

        var trackedContact = db
            .Contacts.Include(c => c.Categories)
            .Single(c => c.ContactId == contact.ContactId);

        trackedContact.Name = contact.Name;
        trackedContact.Email = contact.Email;
        trackedContact.PhoneNumber = contact.PhoneNumber;

        var selectedCategories = db
            .Categories.Where(c => categoryIds.Contains(c.CategoryId))
            .ToList();
        trackedContact.Categories.Clear();
        trackedContact.Categories.AddRange(selectedCategories);

        db.SaveChanges();
    }

    public static List<Contact> GetContacts()
    {
        using var db = new PhoneBookContext();
        return db.Contacts.Include(c => c.Categories).ToList();
    }

    public static List<Contact> GetContactsByCategory(int categoryId)
    {
        using var db = new PhoneBookContext();
        return db
            .Contacts.Include(c => c.Categories)
            .Where(c => c.Categories.Any(cat => cat.CategoryId == categoryId))
            .ToList();
    }

    public static void DeleteContact(Contact contact)
    {
        using var db = new PhoneBookContext();

        db.Contacts.Remove(contact);
        db.SaveChanges();
    }
}
