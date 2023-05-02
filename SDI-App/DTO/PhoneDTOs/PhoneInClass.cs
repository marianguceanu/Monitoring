using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SDI_App.DTO.PhoneDTOs
{
    public class PhoneInClass
    {
        public int Id { get; set; } = default!;
        public string Color { get; set; } = string.Empty;
        public int ModelNumber { get; set; }
        public string OSType { get; set; } = string.Empty;
        public int ScreenSize { get; set; }
        public int YearOFProduction { get; set; }
        public int NumberOfCameras { get; set; }
    }
}