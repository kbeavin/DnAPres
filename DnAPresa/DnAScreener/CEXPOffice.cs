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
    /// Accesses the database and retrieves Carter Express Office employees.
    /// </summary>
    public partial class CEXPOffice : DnAScreener.BaseTab
    {
        public CEXPOffice() {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the textbox inside the control to be the number of all CEXP employees.
        /// </summary>
        /// <remarks>
        /// This constructor prevents editing the main form in the form editor. Future improvements require this to be called inside the Load event.
        /// </remarks>
        public CEXPOffice(DataMgr myDataMgr)
        {
            InitializeComponent();
            try
            {
                DataManager = myDataMgr;
                EmpTable = myDataMgr.getCEXPOffice();
                textBoxTotalDrivers.Text = EmpTable.Rows.Count.ToString();
            }
            catch { this.label4.Visible = true; }
        }
    }
}

