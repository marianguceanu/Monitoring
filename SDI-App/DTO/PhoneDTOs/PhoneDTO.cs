using SDI_App.DTO.PersonDTOs;

namespace SDI_App.DTO.PhoneDTOs;

public class PhoneDTO
{
    public int Id { get; set; } = default!;
    public int PersonId { get; set; }
    public PersonInClass Person { get; set; } = default!;
    public string Color { get; set; } = string.Empty;
    public string OSType { get; set; } = string.Empty;
    public int ScreenSize { get; set; }
    public int YearOFProduction { get; set; }
    public int NumberOfCameras { get; set; }
}