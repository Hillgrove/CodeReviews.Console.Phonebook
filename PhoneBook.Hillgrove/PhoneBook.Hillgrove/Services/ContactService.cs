using PhoneBook.Hillgrove.Models;
using PhoneBook.Hillgrove.Repositories;
using PhoneBook.Hillgrove.Validation;

namespace PhoneBook.Hillgrove.Services;

internal static class ContactService
{
    public static void AddContact(
        string name,
        string email,
        string phoneNumber,
        List<int> categoryIds
    )
    {
        Validators.ValidateName(name);
        Validators.ValidateEmail(email);
        Validators.ValidatePhoneNumber(phoneNumber);

        var contact = new Contact
        {
            Name = name,
            Email = email,
            PhoneNumber = phoneNumber,
        };
        ContactRepository.AddContact(contact, categoryIds);
    }

    public static void UpdateContact(
        Contact contact,
        List<int> categoryIds,
        string? newName = null,
        string? newEmail = null,
        string? newPhoneNumber = null
    )
    {
        if (newName != null)
        {
            Validators.ValidateName(newName);
            contact.Name = newName;
        }

        if (newEmail != null)
        {
            Validators.ValidateEmail(newEmail);
            contact.Email = newEmail;
        }

        if (newPhoneNumber != null)
        {
            Validators.ValidatePhoneNumber(newPhoneNumber);
            contact.PhoneNumber = newPhoneNumber;
        }

        ContactRepository.UpdateContact(contact, categoryIds);
    }

    public static void DeleteContact(Contact contact)
    {
        ContactRepository.DeleteContact(contact);
    }

    public static List<Contact> GetContacts()
    {
        return ContactRepository.GetContacts();
    }

    public static List<Contact> GetContactsByCategory(int categoryId)
    {
        return ContactRepository.GetContactsByCategory(categoryId);
    }
}
