using PhoneBook.Hillgrove.Models;
using Spectre.Console;

namespace PhoneBook.Hillgrove.Views;

internal class CategoryView
{
    public static void ShowCategories(List<Category> categories)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");

        foreach (var category in categories)
        {
            table.AddRow(category.CategoryId.ToString(), category.Name);
        }

        AnsiConsole.Write(table);
    }
}
