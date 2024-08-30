namespace PhoneBook.Dtos;

public record CreationContactDto(
    string Name,
    string Surname,
    string Email,
    ICollection<string> Phones
);
