using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnAPresa.Common.Models
{
    public class Employee
    {
        public string EmployeeNumber { get; set; }
        public string EmployeeFullName { get; set; }
        public string Tier3 { get; set; }
        public string Terminal { get; set; }
        public bool Drug { get; set; }
        public bool Alcohol { get; set; }
        public bool Substitute { get; set; }
        public int DrugPool { get; set; }
        public int AlcPool { get; set; }
    }
}
