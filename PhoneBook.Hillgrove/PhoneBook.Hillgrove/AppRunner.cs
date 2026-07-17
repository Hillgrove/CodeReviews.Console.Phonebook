using PhoneBook.Hillgrove.Controllers;
using PhoneBook.Hillgrove.Models.Enums;
using PhoneBook.Hillgrove.Views;

namespace PhoneBook.Hillgrove;

internal static class AppRunner
{
    public static void Run()
    {
        var isRunning = true;

        while (isRunning)
        {
            var option = MenuView.GetMainMenuOption();

            switch (option)
            {
                case MainMenu.Contacts:
                    RunContactsMenu();
                    break;

                case MainMenu.Categories:
                    RunCategoriesMenu();
                    break;

                case MainMenu.SendEmail:
                    EmailController.SendEmail();
                    break;

                case MainMenu.Quit:
                    isRunning = false;
                    break;
            }
        }
    }

    private static void RunContactsMenu()
    {
        var inContactsMenu = true;

        while (inContactsMenu)
        {
            var option = MenuView.GetContactMenuOption();

            switch (option)
            {
                case ContactMenu.AddContact:
                    ContactController.AddContact();
                    break;

                case ContactMenu.UpdateContact:
                    ContactController.UpdateContact();
                    break;

                case ContactMenu.ShowContact:
                    ContactController.ShowContact();
                    break;

                case ContactMenu.ShowContacts:
                    ContactController.ShowContacts();
                    break;

                case ContactMenu.ShowContactsByCategory:
                    ContactController.ShowContactsByCategory();
                    break;

                case ContactMenu.DeleteContact:
                    ContactController.DeleteContact();
                    break;

                case ContactMenu.Back:
                    inContactsMenu = false;
                    break;
            }
        }
    }

    private static void RunCategoriesMenu()
    {
        var inCategoriesMenu = true;

        while (inCategoriesMenu)
        {
            var option = MenuView.GetCategoryMenuOption();

            switch (option)
            {
                case CategoryMenu.AddCategory:
                    CategoryController.AddCategory();
                    break;

                case CategoryMenu.UpdateCategory:
                    CategoryController.UpdateCategory();
                    break;

                case CategoryMenu.ShowCategories:
                    CategoryController.ShowCategories();
                    break;

                case CategoryMenu.DeleteCategory:
                    CategoryController.DeleteCategory();
                    break;

                case CategoryMenu.Back:
                    inCategoriesMenu = false;
                    break;
            }
        }
    }
}
