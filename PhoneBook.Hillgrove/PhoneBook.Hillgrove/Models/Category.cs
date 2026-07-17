namespace PhoneBook.Hillgrove.Models;

public class Category
{
    public int CategoryId { get; set; }
    public required string Name { get; set; }
    public List<Contact> Contacts { get; set; } = [];
}
