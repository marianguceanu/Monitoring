using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SDI_App.Models
{
    public class Person
    {

        // Phones
        public virtual ICollection<Phone> AbsPhones { get; set; } = default!;
        // Tablet
        [ForeignKey("TabletId")]
        public int TabletId { get; set; }
        public virtual Tablet? AbsTablet { get; set; }

        // Person properties
        [Key]
        public int Id { get; set; }
        public string CNP { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}