using SDI_App.DTO.PersonDTOs;

namespace SDI_App.DTO.TableDTOs
{
    public class TabletDTO
    {
        public int Id { get; set; } = default!;
        public PersonInClass? Person { get; set; }
        public string Manufacturer { get; set; } = string.Empty;
        public int ScreenSize { get; set; }
        public int UnitsSold { get; set; }
        public bool HasPen { get; set; }
    }
}