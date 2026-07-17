using PhoneBook.Hillgrove.Services;
using PhoneBook.Hillgrove.Views;

namespace PhoneBook.Hillgrove.Controllers;

internal static class CategoryController
{
    public static void AddCategory()
    {
        var name = PromptView.PromptUserForInput<string>("Category name: ");

        try
        {
            CategoryService.AddCategory(name);
            MessageView.ShowSuccess("Category added.");
        }
        catch (ArgumentException ex)
        {
            MessageView.ShowError(ex.Message);
        }
        catch (Exception)
        {
            MessageView.ShowError("Failed to add category. Please try again.");
        }

        PromptView.WaitForKeyPress();
    }

    public static void UpdateCategory()
    {
        try
        {
            var categories = CategoryService.GetCategories();
            var category = PromptView.PromptUserForItemOrNotify(
                "Select category: ",
                categories,
                c => c.Name,
                "No categories found."
            );
            if (category is null)
                return;

            var newName = PromptView.PromptUserForOptionalInput(
                $"Name ({category.Name}), leave empty to keep: "
            );

            CategoryService.UpdateCategory(
                category,
                string.IsNullOrWhiteSpace(newName) ? null : newName
            );

            MessageView.ShowSuccess("Category updated.");
        }
        catch (ArgumentException ex)
        {
            MessageView.ShowError(ex.Message);
        }
        catch (Exception)
        {
            MessageView.ShowError("Failed to update category. Please try again.");
        }

        PromptView.WaitForKeyPress();
    }

    public static void ShowCategories()
    {
        try
        {
            var categories = CategoryService.GetCategories();

            CategoryView.ShowCategories(categories);
        }
        catch (Exception)
        {
            MessageView.ShowError("Failed to get categories. Please try again.");
        }

        PromptView.WaitForKeyPress();
    }

    public static void DeleteCategory()
    {
        try
        {
            var categories = CategoryService.GetCategories();
            var category = PromptView.PromptUserForItemOrNotify(
                "Select category: ",
                categories,
                c => c.Name,
                "No categories found."
            );
            if (category is null)
                return;

            CategoryService.DeleteCategory(category);
            MessageView.ShowSuccess("Category deleted.");
        }
        catch (Exception)
        {
            MessageView.ShowError("Failed to delete category. Please try again.");
        }

        PromptView.WaitForKeyPress();
    }
}
