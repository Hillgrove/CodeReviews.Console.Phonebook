using PhoneBook.Hillgrove;
using PhoneBook.Hillgrove.Data;
using PhoneBook.Hillgrove.Views;

try
{
    using var context = new PhoneBookContext();
    context.Database.EnsureDeleted();
    context.Database.EnsureCreated();
}
catch (Exception)
{
    MessageView.ShowError("Failed to set up the database. Please try again.");
    return;
}

AppRunner.Run();
