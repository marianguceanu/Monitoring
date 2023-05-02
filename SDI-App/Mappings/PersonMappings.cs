using AutoMapper;
using SDI_App.DTO.PersonDTOs;
using SDI_App.Models;

namespace SDI_App.Mappings
{
    public class PersonMappings : Profile
    {
        public PersonMappings()
        {

            CreateMap<Person, PersonDTO>().ReverseMap();
            CreateMap<AddPersonDTO, Person>().ReverseMap();
            CreateMap<EditPersonDTO, Person>().ReverseMap();
            CreateMap<PersonInClass, Person>().ReverseMap();
        }
    }
}