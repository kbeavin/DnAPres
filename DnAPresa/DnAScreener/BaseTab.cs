using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace DnAScreener
{
    /// <summary>
    /// Base control to which all tabs inherit their content fields.
    /// </summary>
    public partial class BaseTab : UserControl
    {
        protected CrystalReport1 myReport;
        protected DataTable EmpTable;
        private DataTable myEmpTable;
        EmployeeList myEmpList;
        protected int Alternates = 0;
        protected DataMgr DataManager;

        public BaseTab()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Print button press event.
        /// </summary>
        public virtual void button1_Click(object sender, EventArgs e)
        {
            if (textBoxAlchoholPerc.Text == "")
                return;
            textBoxDriverPoolPerc_TextChanged(sender, e);
            //SetAlternates(Alternates);
            launchprintpreview();
        }

        /// <summary>
        /// Called to assign given number of Alternates to the list of selected drivers.
        /// </summary>
        /// <param name="p">Number of alternates to add</param>
        protected virtual void SetAlternates(int p, DataMgr sender)
        {
            Random myRand = new Random(System.DateTime.Now.Second * System.DateTime.Now.Millisecond);

            for (int i = 0; i < p; i++)
            {
                int t = myRand.Next(sender.empList.Rows.Count);
                Employee myEmp = new Employee(sender.empList.Rows[t]);
                myEmp.Substitute = true;
                sender.myEmpList.Add(myEmp);
                sender.empList.Rows.RemoveAt(t);
            }
        }

        /// <summary>
        /// Prepares and launches the PrintPreview class and its containing report.
        /// </summary>
        private void launchprintpreview()
        {
            PrintPreview myPPvw;
            myReport = new CrystalReport1();
            myReport.Load();

            if (textBoxDriverPoolPerc.Text != "")
            {
                DataSet myDS = new DataSet("DnAPRESA Schema");
                myDS.Tables.Add(myEmpList.getTable());
                myDS.Tables[0].TableName = "DrugPool";
                myDS.Tables.Add("CountData");
                myDS.Tables["CountData"].Columns.Add("TotalActive");
                myDS.Tables["CountData"].Columns.Add("PoolPerc");
                myDS.Tables["CountData"].Columns.Add("AlchPerc");
                myDS.Tables["CountData"].Rows.Add(new object[] { this.EmpTable.Rows.Count, textBoxDriverPoolPerc.Text, textBoxAlchoholPerc.Text });
                //myDS.WriteXml("c:\\dnadata.xml");
                //myDS.WriteXmlSchema("c:\\dnaschema.xsd");
                myReport.SetDataSource(myDS);
                if (myDS.Tables["DrugPool"].Rows[0]["emplclas"].ToString() == "Driver")
                    ((CrystalDecisions.CrystalReports.Engine.TextObject)this.myReport.Section3.ReportObjects["Text4"]).Text = "Driver ID";
                else if (myDS.Tables["DrugPool"].Rows[0]["emplclas"].ToString() == "Carter Logistics Employee")
                {
                    ((CrystalDecisions.CrystalReports.Engine.TextObject)this.myReport.Section3.ReportObjects["Text19"]).Text = "";
                }
                myDS.Tables["DrugPool"].DefaultView.Sort = "lastname asc";
                myPPvw = new PrintPreview(myReport);
                myPPvw.ShowDialog();
            }

            ConfirmPrompt myCP = new ConfirmPrompt();
            if (myCP.ShowDialog() == DialogResult.OK)
                DataManager.insertHistory(myEmpList.getTable());
        }

        /// <summary>
        /// TextChanged event. Randomly populates an EmployeeList:ArrayList with Employees if the input is valid.
        /// </summary>
        private void textBoxDriverPoolPerc_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDriverPoolPerc.Text == "")
                return;
            int Percent;
            try
            {
                Percent = Convert.ToInt32(textBoxDriverPoolPerc.Text);
            }
            catch
            {
                MessageBox.Show("Input only accepts integer values", "Error");
                return;
            }

            labelDrugPerc.Text = ((Percent * EmpTable.Rows.Count) / 100).ToString();

            Random myRand = new Random(System.DateTime.Now.Second * System.DateTime.Now.Millisecond);

            DataTable newTable = EmpTable.Clone();
            myEmpTable = EmpTable.Copy();


            for (int i = 0; i < (Percent * EmpTable.Rows.Count) / 100; i++)
            {
                int t = myRand.Next(myEmpTable.Rows.Count);
                newTable.ImportRow(myEmpTable.Rows[t]);
                myEmpTable.Rows.RemoveAt(t);
            }


            myEmpList = new EmployeeList(newTable);

            foreach (Employee Emp in myEmpList)
            {
                Emp.Drug = true;
            }

            textBoxAlchoholPerc_TextChanged(sender, e);
        }

        /// <summary>
        /// Randomly assigns the value of true to Employee.Alchohol in the EmployeeList.
        /// </summary>
        private void textBoxAlchoholPerc_TextChanged(object sender, EventArgs e)
        {
            if (textBoxDriverPoolPerc.Text == "")
            {
                return;
            }

            if (textBoxAlchoholPerc.Text == "")
                textBoxAlchoholPerc.Text = "0";

            int Percent;
            try
            {
                Percent = Convert.ToInt32(textBoxAlchoholPerc.Text);
            }
            catch
            {
                MessageBox.Show("Input only accepts integer values", "Error");
                return;
            }

            labelAlchPerc.Text = ((Percent * myEmpList.Count) / 100).ToString();

            //Rare Case but make sure it doesn't happen
            if (Percent >= 100)
            {
                foreach (Employee Emp in myEmpList)
                {
                    Emp.Alcohol = false;
                }
                return;
            }

            //Make sure no one is in the alchohol pool before adding them
            foreach (Employee Emp in myEmpList)
            {
                Emp.Alcohol = false;
            }

            //Assign random employees to take alchohol tests
            Random myRand = new Random(System.DateTime.Now.Second * System.DateTime.Now.Millisecond);
            for (int i = 0; i < (Percent * myEmpList.Count) / 100; i++)
            {
                int t = myRand.Next(myEmpList.Count);
                if (((Employee)myEmpList[t]).Alcohol)
                    i--;
                else ((Employee)myEmpList[t]).Alcohol = true;
            }
        }

        /// <summary>
        /// Easier than assigning the AcceptKey.
        /// </summary>
        private void BaseTab_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        public EmployeeList button1_Click(DataMgr sender, EventArgs e)
        {
            EmployeeList myFilteredEmpList = textBoxDriverPoolPerc_TextChanged(sender, e);
            SetAlternates(Alternates, sender);

            return sender.myEmpList;
        }
        private EmployeeList textBoxDriverPoolPerc_TextChanged(DataMgr sender, EventArgs e)
        {
            
            int Percent;
            Percent = Convert.ToInt32(sender.DriverPoolPercentage);

            Random myRand = new Random(System.DateTime.Now.Second * System.DateTime.Now.Millisecond);

            DataTable newTable = EmpTable.Clone();
            myEmpTable = EmpTable.Copy();

            for (int i = 0; i < (Percent * sender.empList.Rows.Count) / 100; i++)
            {
                int t = myRand.Next(sender.empList.Rows.Count);
                newTable.ImportRow(sender.empList.Rows[t]);
                sender.empList.Rows.RemoveAt(t);
            }


            sender.myEmpList = new EmployeeList(newTable);

            foreach (Employee Emp in sender.myEmpList)
            {
                Emp.Drug = true;
            }

            return textBoxAlchoholPerc_TextChanged(sender, e, sender.myEmpList);
        }
        private EmployeeList textBoxAlchoholPerc_TextChanged(DataMgr sender, EventArgs e, EmployeeList myFilteredEmpList)
        {

            int Percent;
            Percent = Convert.ToInt32(sender.AlchoholPercentage);

            //Make sure no one is in the alchohol pool before adding them
            foreach (Employee Emp in myFilteredEmpList)
            {
                Emp.Alcohol = false;
            }

            //Assign random employees to take alchohol tests
            Random myRand = new Random(System.DateTime.Now.Second * System.DateTime.Now.Millisecond);
            for (int i = 0; i < (Percent * sender.myEmpList.Count) / 100; i++)
            {
                int t = myRand.Next(myFilteredEmpList.Count);
                if (((Employee)myFilteredEmpList[t]).Alcohol)
                    i--;
                else ((Employee)myFilteredEmpList[t]).Alcohol = true;
            }

            return myFilteredEmpList;
        }

    }
}
