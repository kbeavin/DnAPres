using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DnAPresa.Common.Enumerations.Enumerations;

namespace DnAPresa.Web.Models
{
    public class EmployeeModel
    {
        public string EmployeeNumber { get; set; }
        public string EmployeeFullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Tier3 { get; set; }
        public string Terminal { get; set; }
        public bool Drug { get; set; }
        public bool Alcohol { get; set; }
        public bool Substitute { get; set; }
        public int DrugPool { get; set; }
        public int AlcPool { get; set; }

        public string Get_TestSelection(bool drug, bool alc, bool sub)
        {
            StringBuilder testsel = new StringBuilder();

            if (drug == true)
                testsel.Append("D");
            if (alc == true)
                testsel.Append("nA");
            if (sub == true)
                testsel.Append("S");

            return testsel.ToString();
        }
    }

    public class EmployeeHistoryModel
    {
        public string EmployID { get; set; }
        public string lastname { get; set; }
        public string frstname { get; set; }
        public string midlname { get; set; }
        public string emplclas { get; set; }
        public string db { get; set; }
        public string testsel { get; set; }
        public DateTime Report_DateTime { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class EmployeeListModel
    {
        public EmployeeListModel()
        {
            Employees = new List<EmployeeModel>();
        }

        public List<EmployeeModel> Employees { get; set; }
        public int Count { get { return Employees.Count(); } }
    }

    public class EmployeeHistoryListModel
    {
        public EmployeeHistoryListModel()
        {
            Employees = new List<EmployeeHistoryModel>();
        }

        public List<EmployeeHistoryModel> Employees { get; set; }
        public int Count { get { return Employees.Count(); } }
    }
}
