using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.Windows.Forms;

namespace DnAScreener
{
    /// <summary>
    /// Simple class to allow for print previewing of Crystal Reports.
    /// </summary>
    public partial class PrintPreview : Form
    {
        //private ReportDocumentBase mybase = new ReportDocumentBase();
        // private DocumentControl myDocCont = new CrystalDecisions.Windows.Forms.DocumentControl(mybase);
        public PrintPreview()
        {
            InitializeComponent();
        }

        public PrintPreview(CrystalDecisions.CrystalReports.Engine.ReportClass EmpAccRpt)
        {
            InitializeComponent();
            this.crystalReportViewer1.ReportSource = EmpAccRpt;
            crystalReportViewer1.Zoom(75);

           // crystalReportViewer1.
        }
    }
}