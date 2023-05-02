using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDI_App.Models
{
    public class AccessedWebsite
    {
        // Tablet properties
        [Key]
        public int Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;

        // Phone properties
        [ForeignKey("Phone")]
        public int PhoneId { get; set; }
        public virtual Phone? AbsPhone { get; set; }

        // Tablet properties
        [ForeignKey("Tablet")]
        public int TabletId { get; set; }
        public virtual Tablet? AbsTablet { get; set; }
    }
}