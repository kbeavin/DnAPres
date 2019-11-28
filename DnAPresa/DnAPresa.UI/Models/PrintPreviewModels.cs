using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DnAPresa.UI.Models
{
    public class PrintPreviewModels
    {
        public PrintPreviewModels()
        {
            DrugPool = new List<DrugScreen>();
        }
        public List<DrugScreen> DrugPool { get; set; }
    }

    public class DrugScreen
    {
        public string ID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string MI { get; set; }
        public string DB { get; set; }
        public bool Drug { get; set; }
        public bool Alcohol { get; set; }
        public bool Substitute { get; set; }
        public string TMWDriverID { get; set; }

    }
}