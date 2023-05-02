using AutoMapper;
using SDI_App.DTO.PhoneDTOs;
using SDI_App.Models;

namespace SDI_App.Mappings;

public class PhoneMappings : Profile
{
    public PhoneMappings()
    {
        CreateMap<Phone, PhoneDTO>();
        CreateMap<AddPhoneDTO, Phone>();
        CreateMap<EditPhoneDTO, Phone>();
        CreateMap<Phone, PhoneInClass>();
        CreateMap<PhoneInClass, Phone>();
    }
}