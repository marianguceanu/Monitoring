using System.ComponentModel.DataAnnotations;
namespace SDI_App.DTO.PhoneDTOs;
public class AddPhoneDTO
{
    [Required]
    public int PersonId { get; set; }
    [Required]
    public int ModelNumber { get; set; }
    public string OSType { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public int ScreenSize { get; set; }
    public int YearOFProduction { get; set; }
    public int NumberOfCameras { get; set; }
}