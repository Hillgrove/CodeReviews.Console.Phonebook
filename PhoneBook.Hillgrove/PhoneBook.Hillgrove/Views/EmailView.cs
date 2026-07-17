using PhoneBook.Hillgrove.Models;
using Spectre.Console;

namespace PhoneBook.Hillgrove.Views;

internal static class EmailView
{
    public static void ShowSentEmail(Contact contact, EmailMessage email)
    {
        var panel = new Panel(
            $@"To: {contact.Name} <{contact.Email}>
Subject: {email.Subject}

{email.Body}"
        );

        panel.Header = new PanelHeader("Email Sent");
        panel.Padding = new Padding(2, 1, 2, 1);

        AnsiConsole.Write(panel);
    }
}
