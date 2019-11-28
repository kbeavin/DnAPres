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
    /// Accesses the database and retrieves Dukes employees.
    /// </summary>
    public partial class DukeTab : DnAScreener.BaseTab
    {
        public DukeTab()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the textbox inside the control to be the number of all Dukes employees.
        /// </summary>
        /// <remarks>
        /// This constructor prevents editing the main form in the form editor. Future improvements require this to be called inside the Load event.
        /// </remarks>
        public DukeTab(DataMgr myDataMgr)
        {
            InitializeComponent();
            try
            {
                DataManager = myDataMgr;
                EmpTable = myDataMgr.getDukel();
                textBoxTotalDrivers.Text = EmpTable.Rows.Count.ToString();
            }
            catch {
                this.label4.Visible = true;
            }
        }
    }
}

