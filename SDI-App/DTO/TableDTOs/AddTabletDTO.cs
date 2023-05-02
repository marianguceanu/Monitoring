using System.ComponentModel.DataAnnotations;

namespace SDI_App.DTO.TableDTOs
{
    public class AddTabletDTO
    {
        [Required]
        public int PersonId { get; set; }
        [Required]
        public string Manufacturer { get; set; } = string.Empty;
        [Required]
        public int ScreenSize { get; set; }
        [Required]
        public int UnitsSold { get; set; }
        [Required]
        public bool HasPen { get; set; }
    }
}