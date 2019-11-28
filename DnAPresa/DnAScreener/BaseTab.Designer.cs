namespace DnAScreener
{
    partial class BaseTab
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.checkBoxPrintDriverList = new System.Windows.Forms.CheckBox();
            this.textBoxTotalDrivers = new System.Windows.Forms.TextBox();
            this.textBoxAlchoholPerc = new System.Windows.Forms.TextBox();
            this.textBoxDriverPoolPerc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ui_labelTotalDrivers = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelDrugPerc = new System.Windows.Forms.Label();
            this.labelAlchPerc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(102, 118);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Print Driver Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBoxPrintDriverList
            // 
            this.checkBoxPrintDriverList.AutoSize = true;
            this.checkBoxPrintDriverList.Location = new System.Drawing.Point(82, 95);
            this.checkBoxPrintDriverList.Name = "checkBoxPrintDriverList";
            this.checkBoxPrintDriverList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.checkBoxPrintDriverList.Size = new System.Drawing.Size(139, 17);
            this.checkBoxPrintDriverList.TabIndex = 4;
            this.checkBoxPrintDriverList.Text = "Print Active Driver List:  ";
            this.checkBoxPrintDriverList.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.checkBoxPrintDriverList.UseVisualStyleBackColor = true;
            this.checkBoxPrintDriverList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseTab_KeyDown);
            // 
            // textBoxTotalDrivers
            // 
            this.textBoxTotalDrivers.Location = new System.Drawing.Point(194, 13);
            this.textBoxTotalDrivers.Name = "textBoxTotalDrivers";
            this.textBoxTotalDrivers.ReadOnly = true;
            this.textBoxTotalDrivers.Size = new System.Drawing.Size(63, 20);
            this.textBoxTotalDrivers.TabIndex = 1;
            this.textBoxTotalDrivers.TabStop = false;
            this.textBoxTotalDrivers.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseTab_KeyDown);
            // 
            // textBoxAlchoholPerc
            // 
            this.textBoxAlchoholPerc.Location = new System.Drawing.Point(194, 69);
            this.textBoxAlchoholPerc.MaxLength = 2;
            this.textBoxAlchoholPerc.Name = "textBoxAlchoholPerc";
            this.textBoxAlchoholPerc.Size = new System.Drawing.Size(63, 20);
            this.textBoxAlchoholPerc.TabIndex = 3;
            this.textBoxAlchoholPerc.TextChanged += new System.EventHandler(this.textBoxAlchoholPerc_TextChanged);
            this.textBoxAlchoholPerc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseTab_KeyDown);
            // 
            // textBoxDriverPoolPerc
            // 
            this.textBoxDriverPoolPerc.Location = new System.Drawing.Point(194, 40);
            this.textBoxDriverPoolPerc.MaxLength = 2;
            this.textBoxDriverPoolPerc.Name = "textBoxDriverPoolPerc";
            this.textBoxDriverPoolPerc.Size = new System.Drawing.Size(63, 20);
            this.textBoxDriverPoolPerc.TabIndex = 2;
            this.textBoxDriverPoolPerc.TextChanged += new System.EventHandler(this.textBoxDriverPoolPerc_TextChanged);
            this.textBoxDriverPoolPerc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseTab_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Alchohol Percentage:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Driver Pool Percentage:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ui_labelTotalDrivers
            // 
            this.ui_labelTotalDrivers.Location = new System.Drawing.Point(194, 13);
            this.ui_labelTotalDrivers.Name = "ui_labelTotalDrivers";
            this.ui_labelTotalDrivers.Size = new System.Drawing.Size(45, 23);
            this.ui_labelTotalDrivers.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Total Active Drivers:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelDrugPerc
            // 
            this.labelDrugPerc.Location = new System.Drawing.Point(264, 46);
            this.labelDrugPerc.Name = "labelDrugPerc";
            this.labelDrugPerc.Size = new System.Drawing.Size(49, 14);
            this.labelDrugPerc.TabIndex = 18;
            // 
            // labelAlchPerc
            // 
            this.labelAlchPerc.Location = new System.Drawing.Point(264, 75);
            this.labelAlchPerc.Name = "labelAlchPerc";
            this.labelAlchPerc.Size = new System.Drawing.Size(50, 14);
            this.labelAlchPerc.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(314, 148);
            this.label4.TabIndex = 20;
            this.label4.Text = "Login failed. Please check your login information and restart the application to " +
                "login.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label4.UseWaitCursor = true;
            this.label4.Visible = false;
            // 
            // BaseTab
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelAlchPerc);
            this.Controls.Add(this.labelDrugPerc);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.checkBoxPrintDriverList);
            this.Controls.Add(this.textBoxTotalDrivers);
            this.Controls.Add(this.textBoxAlchoholPerc);
            this.Controls.Add(this.textBoxDriverPoolPerc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ui_labelTotalDrivers);
            this.Controls.Add(this.label1);
            this.Name = "BaseTab";
            this.Size = new System.Drawing.Size(331, 155);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaseTab_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAlchoholPerc;
        private System.Windows.Forms.TextBox textBoxDriverPoolPerc;
        private System.Windows.Forms.Label ui_labelTotalDrivers;
        protected System.Windows.Forms.CheckBox checkBoxPrintDriverList;
        protected System.Windows.Forms.Label label3;
        protected System.Windows.Forms.Label label2;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.Button button1;
        protected System.Windows.Forms.TextBox textBoxTotalDrivers;
        private System.Windows.Forms.Label labelDrugPerc;
        private System.Windows.Forms.Label labelAlchPerc;
        protected System.Windows.Forms.Label label4;
    }
}
