using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DnAScreener
{
    /// <summary>
    /// Control that most directly inherits BaseTab. Accesses the database and retrieves all drivers.
    /// </summary>
    public partial class DriverTab : DnAScreener.BaseTab
    {
        public DriverTab()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the textbox inside the control to be the number of Driver.
        /// </summary>
        /// <remarks>
        /// This constructor prevents editing the main form in the form editor. Future improvements require this to be called inside the Load event.
        /// </remarks>
        public DriverTab(DataMgr myDataMgr)
        {
            InitializeComponent();
            //try
            {
                DataManager = myDataMgr;
                EmpTable = myDataMgr.getDrivers();
                this.textBoxTotalDrivers.Text = EmpTable.Rows.Count.ToString();
                Alternates = 15;
            }
            //catch { this.label4.Visible = true; }
        }

        public override void button1_Click(object sender, EventArgs e)
        {
            if (checkBoxPrintDriverList.Checked) {
                ActiveDriver DriverRpt = new ActiveDriver();
                DriverRpt.Load();
                DriverRpt.SetDataSource(DataManager.getActiveDriverList());

                PrintPreview myPPvw = new PrintPreview(DriverRpt);
                myPPvw.ShowDialog();
                return;
            }
            
            base.button1_Click(sender, e);
        }

    }
}

