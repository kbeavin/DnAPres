using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnAPresa.Common.Enumerations
{
    public class Enumerations
    {
        public enum EmpClass
        {
            [Description("Drivers")]
            Drivers = 1,
            [Description("Dukes Employee")]
            Dukes = 2,
            [Description("Express Office")]
            Office = 3,
            [Description("Express Warehoue")]
            Warehouse = 4,
            [Description("Carter Logistics")]
            Logistics = 5
        }

        public enum EmpTerminal
        {
            [Description("Anderson")]
            AND = 1,
            [Description("Romulus")]
            ROM = 2,
            [Description("Dayton")]
            DAY = 3,
            [Description("Hebron")]
            HEB = 4,
            [Description("Knoxville")]
            KNO = 5,
            [Description("Paragould")]
            PAR = 6,
            [Description("Canton")]
            CW = 7,
            [Description("Laredo")]
            LAR = 8
        }
    }
}
