using PhoneBook.Hillgrove.Models.Enums;
using Spectre.Console;

namespace PhoneBook.Hillgrove.Views;

internal static class MenuView
{
    public static MainMenu GetMainMenuOption()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<MainMenu>()
                .Title("Phonebook Mainmenu")
                .AddChoices(
                    MainMenu.Contacts,
                    MainMenu.Categories,
                    MainMenu.SendEmail,
                    MainMenu.Quit
                )
        );
    }

    public static ContactMenu GetContactMenuOption()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<ContactMenu>()
                .Title("Contacts Menu")
                .AddChoices(
                    ContactMenu.AddContact,
                    ContactMenu.UpdateContact,
                    ContactMenu.ShowContact,
                    ContactMenu.ShowContacts,
                    ContactMenu.ShowContactsByCategory,
                    ContactMenu.DeleteContact,
                    ContactMenu.Back
                )
        );
    }

    public static CategoryMenu GetCategoryMenuOption()
    {
        return AnsiConsole.Prompt(
            new SelectionPrompt<CategoryMenu>()
                .Title("Categories Menu")
                .AddChoices(
                    CategoryMenu.AddCategory,
                    CategoryMenu.UpdateCategory,
                    CategoryMenu.ShowCategories,
                    CategoryMenu.DeleteCategory,
                    CategoryMenu.Back
                )
        );
    }
}
