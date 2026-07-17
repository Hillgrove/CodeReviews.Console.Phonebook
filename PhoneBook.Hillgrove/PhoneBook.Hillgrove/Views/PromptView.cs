using Spectre.Console;

namespace PhoneBook.Hillgrove.Views;

internal static class PromptView
{
    public static T PromptUserForInput<T>(string prompt)
    {
        return AnsiConsole.Ask<T>(prompt);
    }

    public static string PromptUserForOptionalInput(string prompt)
    {
        return AnsiConsole.Prompt(new TextPrompt<string>(prompt).AllowEmpty());
    }

    public static T PromptUserForItem<T>(string title, List<T> items, Func<T, string> display)
        where T : notnull
    {
        var selectedItem = AnsiConsole.Prompt(
            new SelectionPrompt<T>().Title(title).UseConverter(display).AddChoices(items)
        );

        return selectedItem;
    }

    public static T? PromptUserForItemOrNotify<T>(
        string title,
        List<T> items,
        Func<T, string> display,
        string emptyMessage
    )
        where T : class
    {
        if (items.Count == 0)
        {
            MessageView.ShowMessage(emptyMessage);
            WaitForKeyPress();
            return null;
        }

        return PromptUserForItem(title, items, display);
    }

    public static List<T> PromptUserForItems<T>(
        string title,
        List<T> items,
        Func<T, string> display,
        List<T> preSelected
    )
        where T : notnull
    {
        if (items.Count == 0)
            return [];

        var prompt = new MultiSelectionPrompt<T>()
            .Title(title)
            .NotRequired()
            .UseConverter(display)
            .AddChoices(items);

        foreach (var item in preSelected)
        {
            prompt.Select(item);
        }

        return AnsiConsole.Prompt(prompt);
    }

    public static bool PromptUserForConfirmation(string message)
    {
        return AnsiConsole.Confirm(message);
    }

    public static void WaitForKeyPress()
    {
        AnsiConsole.Write("Press any key to continue...");
        Console.ReadKey();
        AnsiConsole.Clear();
    }
}
