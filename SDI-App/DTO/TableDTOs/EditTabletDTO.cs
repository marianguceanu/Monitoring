using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDI_App.DTO.TableDTOs
{
    public class EditTabletDTO
    {
        public int PersonId { get; set; }
        // Tablet properties
        public string Manufacturer { get; set; } = string.Empty;
        public int ScreenSize { get; set; }
        public int UnitsSold { get; set; }
        public bool HasPen { get; set; }
    }
}