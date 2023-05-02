using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SDI_App.Models;

public class Phone
{
    // Person
    [ForeignKey("PhonePersonId")]
    public int PersonId { get; set; }
    public virtual Person? AbsPerson { get; set; }

    // Tablet
    public virtual ICollection<AccessedWebsite> AbsAccessedWebsites { get; set; } = default!;

    // Phone properties
    [Key]
    public int Id { get; set; }
    public string Color { get; set; } = string.Empty;
    public int ModelNumber { get; set; }
    public string OSType { get; set; } = string.Empty;
    public int ScreenSize { get; set; }
    public int YearOFProduction { get; set; }
    public int NumberOfCameras { get; set; }
}