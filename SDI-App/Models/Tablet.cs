using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SDI_App.DTO.PersonDTOs;

namespace SDI_App.Models
{
    public class Tablet
    {

        // Many to many with Phone
        public virtual ICollection<AccessedWebsite> AbsAccessedWebsites { get; set; } = default!;

        // One to one with Person
        [ForeignKey("TabletPersonId")]
        public int PersonId { get; set; } = default!;
        public virtual Person? AbsPerson { get; set; }

        // Actual properties
        [Key]
        public int Id { get; set; }
        public string Manufacturer { get; set; } = string.Empty;
        public int ScreenSize { get; set; } = default!;
        public int UnitsSold { get; set; } = default!;
        public bool HasPen { get; set; } = default!;
    }
}
