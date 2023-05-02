namespace SDI_App.DTO.TableDTOs
{
    public class TabletInClass
    {
        public int Id { get; set; } = default!;
        public string Manufacturer { get; set; } = string.Empty;
        public int ScreenSize { get; set; } = default!;
        public int UnitsSold { get; set; } = default!;
        public bool HasPen { get; set; } = default!;
    }
}