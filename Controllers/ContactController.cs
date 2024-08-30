using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PhoneBook.Context;
using PhoneBook.Dtos;
using PhoneBook.Exceptions;
using PhoneBook.Extentions;
using PhoneBook.Models;
using System.Linq;

namespace PhoneBook.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController(AppDbContext context, IMapper mapper) : ControllerBase
{
    [HttpPost("CreateContact")]
    public IActionResult CreateContact([FromBody] CreationContactDto dto)
    {
        var result = mapper.Map<Contact>(dto);

        context.Add(result);
        context.SaveChanges();

        return Created();
    }

    [HttpPatch("EditContact")]
    public IActionResult EditContact([FromBody] EditContactDto dto)
    {
        var result = mapper.Map<Contact>(dto);

        context.Update(result);
        context.SaveChanges();

        return Ok();
    }

    [HttpDelete("DeleteContact/{id}")]
    public IActionResult DeleteContact([FromRoute] int id)
    {
        context.Remove(id);
        context.SaveChanges();

        return Ok();
    }

    [HttpGet("GetById")]
    public IActionResult GetById([FromQuery] int id)
    {
        var result = context.Contacts.Find(id) 
            ?? throw new NotFoundException();

        return Ok(result);

    }


    [HttpGet("Search")]
    public IActionResult SearchContact([FromBody] SearchContactDto dto)
    {
        static bool IsNotNull(object? obj) => obj != null;

        var query = context.Contacts.Include("Phones")
              .WhereIf(IsNotNull(dto.Name), c => c.Name == dto.Name)
              .WhereIf(IsNotNull(dto.Surname), c => c.Surname == dto.Surname)
              .WhereIf(IsNotNull(dto.Email), c => c.Surname == dto.Email)
              .WhereIf(IsNotNull(dto.Phone), c => c.Phones.Any(c => c.PhoneNumber == dto.Phone));

        var result = query.ToList();

        return Ok(result);
    }
}

