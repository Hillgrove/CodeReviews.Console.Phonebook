using PhoneBook.Hillgrove.Services;
using PhoneBook.Hillgrove.Views;

namespace PhoneBook.Hillgrove.Controllers;

internal static class EmailController
{
    public static void SendEmail()
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

            var subject = PromptView.PromptUserForInput<string>("Subject: ");
            var body = PromptView.PromptUserForInput<string>("Message: ");

            var email = EmailService.CreateEmailMessage(subject, body);

            EmailView.ShowSentEmail(contact, email);
            MessageView.ShowSuccess("Email sent.");
        }
        catch (ArgumentException ex)
        {
            MessageView.ShowError(ex.Message);
        }
        catch (Exception)
        {
            MessageView.ShowError("Failed to send email. Please try again.");
        }

        PromptView.WaitForKeyPress();
    }
}
