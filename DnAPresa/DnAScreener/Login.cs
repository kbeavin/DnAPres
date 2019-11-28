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
    /// Simple Login dialog.
    /// </summary>
    /// <remarks>
    /// Probably should be called in the DataMgr rather than the main window.
    /// </remarks>
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        internal string UName
        {
            get { return textBoxUserName.Text; }
        }
        
        internal string Password
        {
            get { return textBoxPassword.Text; }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}