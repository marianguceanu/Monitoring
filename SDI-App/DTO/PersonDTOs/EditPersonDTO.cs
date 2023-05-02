using System.ComponentModel.DataAnnotations;

namespace SDI_App.DTO.PersonDTOs
{
    public class EditPersonDTO
    {
        public int PhoneId { get; set; } = default!;
        public int TabletId { get; set; } = default!;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}