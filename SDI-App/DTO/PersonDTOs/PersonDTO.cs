using SDI_App.DTO.PhoneDTOs;
using SDI_App.DTO.TableDTOs;

namespace SDI_App.DTO.PersonDTOs
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CNP { get; set; } = string.Empty;
        public int TabletId { get; set; }
        public TabletInClass? Tablet { get; set; }
    }
}