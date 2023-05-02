using System.ComponentModel.DataAnnotations;
using SDI_App.Models;

namespace SDI_App.DTO.PersonDTOs
{
    public class AddPersonDTO
    {
        [Required]
        public string CNP { get; set; } = string.Empty;
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}