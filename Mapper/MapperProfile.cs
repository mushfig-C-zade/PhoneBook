using AutoMapper;
using PhoneBook.Dtos;
using PhoneBook.Models;

namespace PhoneBook.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<Contact, CreationContactDto>()
                  .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                  .ForMember(d => d.Surname, opt => opt.MapFrom(s => s.Surname))
                  .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                  .ForMember(d => d.Phones, opt => opt.MapFrom(s => s.Phones.Select(p => p.PhoneNumber)))
                  .ReverseMap()
                  .ForMember(s => s.Phones, opt => opt.MapFrom(d => d.Phones.Select(p => new Phone { PhoneNumber = p })));

        CreateMap<Contact, EditContactDto>()
                 .ForMember(d => d.Id, opt => opt.MapFrom(s => s.Id))
                 .ForMember(d => d.Name, opt => opt.MapFrom(s => s.Name))
                 .ForMember(d => d.Surname, opt => opt.MapFrom(s => s.Surname))
                 .ForMember(d => d.Email, opt => opt.MapFrom(s => s.Email))
                 .ForMember(d => d.Phones, opt => opt.MapFrom(s => s.Phones.Select(p => p.PhoneNumber)))
                  .ReverseMap()
                  .ForMember(s => s.Phones, opt => opt.MapFrom(d => d.Phones.Select(p => new Phone { PhoneNumber = p })));
    }
}
