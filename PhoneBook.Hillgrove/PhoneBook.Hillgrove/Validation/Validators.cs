using System.Text.RegularExpressions;

namespace PhoneBook.Hillgrove.Validation;

internal static class Validators
{
    private static readonly Regex EmailPattern = new(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    private static readonly Regex PhonePattern = new(@"^\d{8}$");

    public static void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.");
    }

    public static void ValidateEmail(string email)
    {
        if (!EmailPattern.IsMatch(email))
            throw new ArgumentException("Invalid email format. Expected: name@example.com");
    }

    public static void ValidatePhoneNumber(string phoneNumber)
    {
        if (!PhonePattern.IsMatch(phoneNumber))
            throw new ArgumentException("Invalid phone number. Expected: 8 digits, e.g. 12345678");
    }

    public static void ValidateSubject(string subject)
    {
        if (string.IsNullOrWhiteSpace(subject))
            throw new ArgumentException("Subject cannot be empty.");
    }

    public static void ValidateBody(string body)
    {
        if (string.IsNullOrWhiteSpace(body))
            throw new ArgumentException("Message cannot be empty.");
    }

    public static void ValidateCategoryName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Category name cannot be empty.");
    }
}
