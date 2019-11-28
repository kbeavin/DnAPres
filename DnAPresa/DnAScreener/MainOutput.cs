using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Reflection;

namespace DnAScreener
{
    /// <summary>
    /// The Application's Main Output
    /// </summary>
    public partial class MainOutput : Form
    {
        Login myLogin = new Login();
        DataMgr myDataMgr = new DataMgr();


        /// <summary>
        /// Returns the empty table to be output by the application.
        /// </summary>
        public static DataTable HistTableSchema {
            get {
                DataTable myTable = new DataTable();
                myTable.Columns.Add("EmployID");
                myTable.Columns.Add("lastname");
                myTable.Columns.Add("frstname");
                myTable.Columns.Add("midlname");
                myTable.Columns.Add("emplclas");
                myTable.Columns.Add("db");
                myTable.Columns.Add("testsel");
                myTable.Columns.Add("Report_DateTime");
                myTable.Columns.Add("TMWDriverID");
                return myTable;
            }
        }

        /// <summary>
        /// Launches the login prompt.
        /// </summary>
        public MainOutput()
        {
            
            myLogin.ShowDialog();
            if (myLogin.DialogResult == DialogResult.OK)
            {
                myDataMgr = new DataMgr(myLogin.UName, myLogin.Password);
            }
            InitializeComponent();
            if (myLogin.DialogResult == DialogResult.Cancel) { }            
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout myAbout = new frmAbout();
            myAbout.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }

    /// <summary>
    /// A list of employees.
    /// </summary>
    public class EmployeeList : ArrayList
    {
        public EmployeeList(DataTable inputTable) {
            Employee myEmp;

            foreach (DataRow row in inputTable.Rows)
            {
                myEmp = new Employee(row);
                this.Add(myEmp);
            }
        }

        /// <summary>
        /// Returns the DataTable represeented by the data stored in the array
        /// </summary>
        public DataTable getTable(){
            DataTable myTable = DnAScreener.MainOutput.HistTableSchema.Clone();

            foreach (Employee myEmp in this) {
                myTable.Rows.Add(myEmp.getRow().ItemArray);
            }

            return myTable;
        }
    }

    /// <summary>
    /// Employee class for all your employee needs.
    /// </summary>
    public class Employee {

        /// <summary>
        /// Enumerator describing the employee class.
        /// </summary>
        public enum EmpClass {
            [Description("Driver")]
            Driver = 1,
            [Description("Non Driver")]
            NonDriver = 2,
            [Description("Express Office Employee")]
            ExpressOffice = 3,
            [Description("Express Warehoue Employee")]
            ExpressWarehouse = 4,
            [Description("Carter Logistics Employee")]
            Logistics = 5,
            [Description("Dukes Employee")]
            Dukes = 6
        };

        public string ID;
        public string FName;
        public string LName;
        public string MI;
        public string DB;
        public bool Drug, Alcohol, Substitute;
        private string SSN;
        public string TMWDriverID;
        EmpClass EmployeeClass;

        /// <summary>
        /// Gets the Description property from the enumerator EmpClass.
        /// </summary>
        /// <param name="value">Value of EmpClass that needs its description retrieved.</param>
        /// <returns>The Description of value.</returns>
        public static string GetEnumDescription(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes =
              (DescriptionAttribute[])fi.GetCustomAttributes
              (typeof(DescriptionAttribute), false);
            return (attributes.Length > 0) ? attributes[0].Description : value.ToString();
        }
        
        /// <summary>
        /// Constructor that assigns the employee based on a DataRow.
        /// </summary>
        /// <param name="Row">The DataRow from which the Employee is drawing data.</param>
        public Employee(DataRow Row) {
            SSN = Row["SSN"].ToString();
            FName = Row["FName"].ToString();
            LName = Row["LName"].ToString();
            ID = Row["EmployeeID"].ToString();
            MI = Row["MI"].ToString();
            DB = Row["DB"].ToString();
            EmployeeClass = getEmpClass(Row["EmplClass"].ToString().ToUpper().Trim(), Row["DB"].ToString().ToUpper());
            TMWDriverID = (string)Row["TMWDriverID"];
        }

        /// <summary>
        /// Gets the EmpClass Enumeratoin based on the value of EmployClass and DB.
        /// </summary>
        private EmpClass getEmpClass(string EmployClass, string DB)
        {
            if (EmployClass.ToLower() == "drivers")
                return EmpClass.Driver;
            switch (DB) { 
                case "CEXPL":
                    if (EmployClass == "Office")
                        return EmpClass.ExpressOffice;
                    if(EmployClass == "Warehouse")
                        return EmpClass.ExpressWarehouse;
                    break;
                case "Logistics":
                    return EmpClass.Logistics;
                case "Dukes":
                    return EmpClass.Dukes;
            }
            return EmpClass.NonDriver;
        }

        public string MiddleInitial
        {
            get { return MI; }
        }

        public string FullName {
            get { return FName + " " + MI + " " + LName; }
        }

        public EmpClass Class {
            get { return EmployeeClass; }
        }

        public string EmpID {
            get { return ID; }
        }

        /// <summary>
        /// Returns a string bast on the TestSel column of the data table.
        /// </summary>
        public string TestSel {
            get {
                string returnValue="";
                if (Drug) {
                    returnValue += 'D';
                }
                if (Alcohol) {
                    returnValue += 'A';
                }
                if (Substitute) {
                    returnValue += 'S';
                }
                return returnValue;
            }
        }

        /// <summary>
        /// For expansion.
        /// </summary>
        internal string SocSec {
            get { return SSN; }
        }

        /// <summary>
        /// Returns the containing data in the form of the DataRow (EmployID, lastname, frstname, midlname, emplclas, db, testsel, Report_DateTime)
        /// </summary>
        /// <returns>The containing data of the object in the form of the DataRow (EmployID, lastname, frstname, midlname, emplclas, db, testsel, Report_DateTime)</returns>
        public DataRow getRow() {
            DataRow newRow = DnAScreener.MainOutput.HistTableSchema.NewRow();

            //newRow.ItemArray = new object[]{EmpID, LName, FName, MI, EmployeeClass.ToString(), DB,TestSel, DateTime.Now};
            newRow["EmployID"] = EmpID;
            newRow["lastname"] = LName;
            newRow["frstname"] = FName;
            newRow["midlname"] = MI;
            newRow["emplclas"] = Employee.GetEnumDescription(EmployeeClass);
            newRow["testsel"] = TestSel;
            newRow["db"] = DB;            
            newRow["Report_DateTime"] = DateTime.Now;
            newRow["TMWDriverID"] = TMWDriverID;
            
            return newRow;
        }
    }
}