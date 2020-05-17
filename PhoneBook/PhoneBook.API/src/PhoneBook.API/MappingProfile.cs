using AutoMapper;
using PhoneBook.API.Commands;
using PhoneBook.API.Models;

namespace PhoneBook.API
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Entities.PhoneBook, PhoneBookViewModel>();
            CreateMap<UpdatePhoneBook, Entities.PhoneBook>();
        }
    }
}