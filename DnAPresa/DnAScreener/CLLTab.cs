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
    /// Accesses the database and retrieves CLL employees.
    /// </summary>
    public partial class CLLTab : DnAScreener.BaseTab
    {
        public CLLTab() {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the textbox inside the control to be the number of CLL employees.
        /// </summary>
        /// <remarks>
        /// This constructor prevents editing the main form in the form editor. Future improvements require this to be called inside the Load event.
        /// </remarks>
        public CLLTab(DataMgr myDataMgr)
        {

            InitializeComponent();
            try
            {
                DataManager = myDataMgr;
                EmpTable = myDataMgr.getCLL();
                textBoxTotalDrivers.Text = EmpTable.Rows.Count.ToString();
            }
            catch { 
                //Crafty sql login failure.
                this.label4.Visible = true; }
        }
    }
}

