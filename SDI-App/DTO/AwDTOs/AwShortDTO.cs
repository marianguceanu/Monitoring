using System.ComponentModel.DataAnnotations;

namespace SDI_App.DTO.AwDTOs
{
    public class AwShortDTO
    {
        public int Id { get; set; }
        [Required]
        public string Url { get; set; } = string.Empty;
        [Required]
        public string Title { get; set; } = string.Empty;
        public int PhoneId { get; set; }
        public int TabletId { get; set; }
    }
}