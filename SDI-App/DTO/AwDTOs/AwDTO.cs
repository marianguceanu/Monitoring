using SDI_App.DTO.PhoneDTOs;
using SDI_App.DTO.TableDTOs;

namespace SDI_App.DTO.AwDTOs
{
    public class AwDTO
    {
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public int PhoneId { get; set; }
        public PhoneInClass? Phone { get; set; }
        public int TabletId { get; set; }
        public TabletInClass? Tablet { get; set; }
    }
}