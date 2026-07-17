using PhoneBook.Hillgrove.Data;
using PhoneBook.Hillgrove.Models;

namespace PhoneBook.Hillgrove.Repositories;

internal static class CategoryRepository
{
    public static void AddCategory(Category category)
    {
        using var db = new PhoneBookContext();

        db.Categories.Add(category);
        db.SaveChanges();
    }

    public static void UpdateCategory(Category category)
    {
        using var db = new PhoneBookContext();

        db.Categories.Update(category);
        db.SaveChanges();
    }

    public static List<Category> GetCategories()
    {
        using var db = new PhoneBookContext();
        return db.Categories.ToList();
    }

    public static void DeleteCategory(Category category)
    {
        using var db = new PhoneBookContext();

        db.Categories.Remove(category);
        db.SaveChanges();
    }
}
