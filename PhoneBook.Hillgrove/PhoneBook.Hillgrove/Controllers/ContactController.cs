using PhoneBook.Hillgrove.Services;
using PhoneBook.Hillgrove.Views;

namespace PhoneBook.Hillgrove.Controllers;

internal static class ContactController
{
    public static void AddContact()
    {
        var name = PromptView.PromptUserForInput<string>("Name: ");
        var email = PromptView.PromptUserForInput<string>("Email: ");
        var phoneNumber = PromptView.PromptUserForInput<string>("Phonenumber: ");

        var categories = CategoryService.GetCategories();
        var selectedCategories = PromptView.PromptUserForItems(
            "Select categories (optional): ",
            categories,
            c => c.Name,
            []
        );

        try
        {
            ContactService.AddContact(
                name,
                email,
                phoneNumber,
                selectedCategories.Select(c => c.CategoryId).ToList()
            );
            MessageView.ShowSuccess("Contact added.");
        }
        catch (ArgumentException ex)
        {
            MessageView.ShowError(ex.Message);
        }
        catch (Exception)
        {
            MessageView.ShowError("Failed to add contact. Please try again.");
        }

        PromptView.WaitForKeyPress();
    }

    public static void UpdateContact()
    {
        try
        {
            var contacts = ContactService.GetContacts();
            var contact = PromptView.PromptUserForItemOrNotify(
                "Select contact: ",
                contacts,
                c => c.Name,
                "No contacts found."
            );
            if (contact is null)
                return;

            var newName = PromptView.PromptUserForOptionalInput(
                $"Name ({contact.Name}), leave empty to keep: "
            );
            var newEmail = PromptView.PromptUserForOptionalInput(
                $"Email ({contact.Email}), leave empty to keep: "
            );
            var newPhoneNumber = PromptView.PromptUserForOptionalInput(
                $"Phonenumber ({contact.PhoneNumber}), leave empty to keep: "
            );

            var categories = CategoryService.GetCategories();
            var preSelected = categories
                .Where(c => contact.Categories.Any(cc => cc.CategoryId == c.CategoryId))
                .ToList();
            var selectedCategories = PromptView.PromptUserForItems(
                $"Select categories for {contact.Name}: ",
                categories,
                c => c.Name,
                preSelected
            );

            ContactService.UpdateContact(
                contact,
                selectedCategories.Select(c => c.CategoryId).ToList(),
                string.IsNullOrWhiteSpace(newName) ? null : newName,
                string.IsNullOrWhiteSpace(newEmail) ? null : newEmail,
                string.IsNullOrWhiteSpace(newPhoneNumber) ? null : newPhoneNumber
            );

            MessageView.ShowSuccess("Contact updated.");
        }
        catch (ArgumentException ex)
        {
            MessageView.ShowError(ex.Message);
        }
        catch (Exception)
        {
            MessageView.ShowError("Failed to update contact. Please try again.");
        }

        PromptView.WaitForKeyPress();
    }

    public static void ShowContact()
    {
        try
        {
            var contacts = ContactService.GetContacts();
            var contact = PromptView.PromptUserForItemOrNotify(
                "Select contact: ",
                contacts,
                c => c.Name,
                "No contacts found."
            );
            if (contact is null)
                return;

            ContactView.ShowContact(contact);

            PromptView.WaitForKeyPress();
        }
        catch (ArgumentException ex)
        {
            MessageView.ShowError(ex.Message);
        }
        catch (Exception)
        {
            MessageView.ShowError("Failed to get contact. Please try again.");
        }
    }

    public static void ShowContacts()
    {
        try
        {
            var contacts = ContactService.GetContacts();

            ContactView.ShowContacts(contacts);
        }
        catch (Exception)
        {
            MessageView.ShowError("Failed to get contacts. Please try again.");
        }

        PromptView.WaitForKeyPress();
    }

    public static void ShowContactsByCategory()
    {
        try
        {
            var categories = CategoryService.GetCategories();
            var category = PromptView.PromptUserForItemOrNotify(
                "Filter by category: ",
                categories,
                c => c.Name,
                "No categories found."
            );
            if (category is null)
                return;

            var contacts = ContactService.GetContactsByCategory(category.CategoryId);
            if (contacts.Count == 0)
                MessageView.ShowMessage("No contacts found in this category.");
            else
                ContactView.ShowContacts(contacts);
        }
        catch (Exception)
        {
            MessageView.ShowError("Failed to get contacts. Please try again.");
        }

        PromptView.WaitForKeyPress();
    }

    public static void DeleteContact()
    {
        try
        {
            var contacts = ContactService.GetContacts();
            var contact = PromptView.PromptUserForItemOrNotify(
                "Select contact: ",
                contacts,
                c => c.Name,
                "No contacts found."
            );
            if (contact is null)
                return;

            ContactService.DeleteContact(contact);
            MessageView.ShowSuccess("Contact deleted");
        }
        catch (Exception)
        {
            MessageView.ShowError("Failed to delete contact. Please try again");
        }

        PromptView.WaitForKeyPress();
    }
}
