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
    /// Simple prompt to confirm comits to history table in DB.
    /// </summary>
    public partial class ConfirmPrompt : Form
    {
        public ConfirmPrompt()
        {
            InitializeComponent();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}