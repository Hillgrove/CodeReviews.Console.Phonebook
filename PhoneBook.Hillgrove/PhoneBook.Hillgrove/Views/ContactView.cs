using PhoneBook.Hillgrove.Models;
using Spectre.Console;

namespace PhoneBook.Hillgrove.Views;

internal class ContactView
{
    public static void ShowContacts(List<Contact> contacts)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Email");
        table.AddColumn("Phone Number");
        table.AddColumn("Categories");

        foreach (var contact in contacts)
        {
            table.AddRow(
                contact.ContactId.ToString(),
                contact.Name,
                contact.Email,
                contact.PhoneNumber,
                FormatCategories(contact)
            );
        }

        AnsiConsole.Write(table);
    }

    internal static void ShowContact(Contact contact)
    {
        var panel = new Panel(
            $@"Id: {contact.ContactId}
Name: {contact.Name}
Email: {contact.Email}
Phone Number: {contact.PhoneNumber}
Categories: {FormatCategories(contact)}"
        );

        panel.Header = new PanelHeader("Contact Info");
        panel.Padding = new Padding(2, 1, 2, 1);

        AnsiConsole.Write(panel);
    }

    private static string FormatCategories(Contact contact)
    {
        return contact.Categories.Count > 0
            ? string.Join(", ", contact.Categories.Select(c => c.Name))
            : "-";
    }
}
