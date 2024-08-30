﻿namespace PhoneBook.Models;

public class Contact
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Surname { get; set; } = default!;
    public string Email { get; set; } = default!;

    public ICollection<Phone> Phones { get; set; } = [];
}
