using Spectre.Console;

namespace PhoneBook.Hillgrove.Views;

internal static class MessageView
{
    public static void ShowMessage(string message)
    {
        AnsiConsole.MarkupLine($"[yellow]{message}[/]");
    }

    public static void ShowSuccess(string message)
    {
        AnsiConsole.MarkupLine($"[green]{message}[/]");
    }

    public static void ShowError(string message)
    {
        AnsiConsole.MarkupLine($"[red]{message}[/]");
    }
}
