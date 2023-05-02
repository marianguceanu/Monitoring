using AutoMapper;
using SDI_App.DTO.AwDTOs;
using SDI_App.Models;

namespace SDI_App.Mappings
{
    public class AwMappings : Profile
    {
        public AwMappings()
        {
            CreateMap<AwShortDTO, AccessedWebsite>().ReverseMap();
            CreateMap<AwDTO, AccessedWebsite>().ReverseMap();
            CreateMap<AddAwDTO, AccessedWebsite>().ReverseMap();
            CreateMap<AwShortDTO, AddAwDTO>().ReverseMap();
        }
    }
}