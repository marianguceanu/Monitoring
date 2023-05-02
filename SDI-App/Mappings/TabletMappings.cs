using AutoMapper;
using SDI_App.DTO.TableDTOs;
using SDI_App.Models;

namespace SDI_App.Mappings
{
    public class TabletMappings : Profile
    {
        public TabletMappings()
        {
            CreateMap<Tablet, TabletDTO>();
            CreateMap<TabletDTO, Tablet>();
            CreateMap<EditTabletDTO, Tablet>();
            CreateMap<AddTabletDTO, Tablet>();
            CreateMap<Tablet, AddTabletDTO>();
            CreateMap<TabletInClass, Tablet>();
            CreateMap<Tablet, TabletInClass>();
        }
    }
}