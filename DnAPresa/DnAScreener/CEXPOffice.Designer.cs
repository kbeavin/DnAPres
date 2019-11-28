namespace DnAScreener
{
    partial class CEXPOffice
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // checkBoxPrintDriverList
            // 
            this.checkBoxPrintDriverList.TabStop = false;
            this.checkBoxPrintDriverList.Visible = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(79, 69);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(37, 40);
            this.label2.Size = new System.Drawing.Size(151, 13);
            this.label2.Text = "CEXP Office Pool Percentage:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(36, 13);
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(152, 13);
            this.label1.Text = "Total Active CEXP Employees:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(82, 118);
            this.button1.Size = new System.Drawing.Size(154, 23);
            this.button1.Text = "Print CEXP Office Report";
            // 
            // CEXPOffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "CEXPOffice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
