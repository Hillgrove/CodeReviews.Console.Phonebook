using PhoneBook.Hillgrove.Models;
using PhoneBook.Hillgrove.Validation;

namespace PhoneBook.Hillgrove.Services;

internal static class EmailService
{
    public static EmailMessage CreateEmailMessage(string subject, string body)
    {
        Validators.ValidateSubject(subject);
        Validators.ValidateBody(body);

        return new EmailMessage(subject, body);
    }
}
