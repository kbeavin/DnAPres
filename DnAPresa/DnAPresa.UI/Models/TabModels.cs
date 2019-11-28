using DnAScreener;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DnAPresa.UI.Models
{
    public class TabModels : LoginModels
    {
        public int TotalActiveDrivers { get; set; }
        public int DriverPoolPercentage { get; set; }
        public int AlchoholPercentage { get; set; }
        public bool PrintActiveDriverList { get; set; }
        public PrintPreviewModels empList { get; set; }
    }
}