using System.ComponentModel.DataAnnotations;

namespace SDI_App.DTO.PhoneDTOs
{
    public class EditPhoneDTO
    {
        [Required]
        public string OSType { get; set; } = string.Empty; // Android/iOS
        [Required]
        public string Color { get; set; } = string.Empty;
    }
}