namespace PhoneBook.Dtos;

public record EditContactDto(
    int Id,
    string Name,
    string Surname,
    string Email,
    ICollection<string> Phones
);
