namespace PhoneBook.Exceptions
{
    public class NotFoundException(string message = "Not Found") : ApplicationException(message)
    {

    }
}
