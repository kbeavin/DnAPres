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

    public class EmployeeHistory
    {
        public string EmployID { get; set; }
        public string lastname { get; set; }
        public string frstname { get; set; }
        public string midlname { get; set; }
        public string emplclas { get; set; }
        public string db { get; set; }
        public string testsel { get; set; }
        public DateTime Report_DateTime { get; set; }
    }

    public class EmployeeList
    {
        public EmployeeList()
        {
            Employees = new List<EmployeeHistory>();
        }

        public List<EmployeeHistory> Employees { get; set; }
        public int Count { get { return Employees.Count(); } }
    }
}
