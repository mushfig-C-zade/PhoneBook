namespace PhoneBook.Models;

public class Phone
{
    public int Id { get; set; }
    public int ContactId { get; set; }
    public string PhoneNumber { get; set; } = default!;

    public Contact? Contact { get; set; }
}