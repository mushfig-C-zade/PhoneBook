namespace PhoneBook.Dtos;

public record SearchContactDto(
    string? Name,
    string? Surname,
    string? Email,
    string? Phone
);
