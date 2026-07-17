using PhoneBook.Hillgrove.Models;
using PhoneBook.Hillgrove.Repositories;
using PhoneBook.Hillgrove.Validation;

namespace PhoneBook.Hillgrove.Services;

internal static class CategoryService
{
    public static void AddCategory(string name)
    {
        Validators.ValidateCategoryName(name);

        var category = new Category { Name = name };
        CategoryRepository.AddCategory(category);
    }

    public static void UpdateCategory(Category category, string? newName = null)
    {
        if (newName != null)
        {
            Validators.ValidateCategoryName(newName);
            category.Name = newName;
        }

        CategoryRepository.UpdateCategory(category);
    }

    public static void DeleteCategory(Category category)
    {
        CategoryRepository.DeleteCategory(category);
    }

    public static List<Category> GetCategories()
    {
        return CategoryRepository.GetCategories();
    }
}
