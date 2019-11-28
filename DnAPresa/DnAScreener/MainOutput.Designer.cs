
namespace DnAScreener
{
    partial class MainOutput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainOutput));

            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDriver = new System.Windows.Forms.TabPage();
            this.myDriverTab = new DnAScreener.DriverTab(myDataMgr);
            this.tabExpOffice = new System.Windows.Forms.TabPage();
            this.myCEXPOfficeTab = new DnAScreener.CEXPOffice(myDataMgr);
            this.tabExpWhrh = new System.Windows.Forms.TabPage();
            this.cexpWarehouseTab1 = new DnAScreener.CEXPWarehouseTab(myDataMgr);
            this.tabLogistics = new System.Windows.Forms.TabPage();
            this.cllTab1 = new DnAScreener.CLLTab(myDataMgr);
            this.tabDukes = new System.Windows.Forms.TabPage();
            this.dukeTab1 = new DnAScreener.DukeTab(myDataMgr);
            this.crystalReport11 = new DnAScreener.CrystalReport1();
            this.tabControl1.SuspendLayout();
            this.tabDriver.SuspendLayout();
            this.tabExpOffice.SuspendLayout();
            this.tabExpWhrh.SuspendLayout();
            this.tabLogistics.SuspendLayout();
            this.tabDukes.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDriver);
            this.tabControl1.Controls.Add(this.tabExpOffice);
            this.tabControl1.Controls.Add(this.tabExpWhrh);
            this.tabControl1.Controls.Add(this.tabLogistics);
            this.tabControl1.Controls.Add(this.tabDukes);
            this.tabControl1.Location = new System.Drawing.Point(5, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(347, 185);
            this.tabControl1.TabIndex = 0;
            // 
            // tabDriver
            // 
            this.tabDriver.Controls.Add(this.myDriverTab);
            this.tabDriver.Location = new System.Drawing.Point(4, 22);
            this.tabDriver.Name = "tabDriver";
            this.tabDriver.Padding = new System.Windows.Forms.Padding(3);
            this.tabDriver.Size = new System.Drawing.Size(339, 159);
            this.tabDriver.TabIndex = 1;
            this.tabDriver.Text = "Driver";
            this.tabDriver.UseVisualStyleBackColor = true;
            // 
            // myDriverTab
            // 
            this.myDriverTab.Location = new System.Drawing.Point(0, 0);
            this.myDriverTab.Name = "myDriverTab";
            this.myDriverTab.Size = new System.Drawing.Size(336, 159);
            this.myDriverTab.TabIndex = 2;
            // 
            // tabExpOffice
            // 
            this.tabExpOffice.Controls.Add(this.myCEXPOfficeTab);
            this.tabExpOffice.Location = new System.Drawing.Point(4, 22);
            this.tabExpOffice.Name = "tabExpOffice";
            this.tabExpOffice.Padding = new System.Windows.Forms.Padding(3);
            this.tabExpOffice.Size = new System.Drawing.Size(339, 159);
            this.tabExpOffice.TabIndex = 1;
            this.tabExpOffice.Text = "Express(Office)";
            this.tabExpOffice.UseVisualStyleBackColor = true;
            // 
            // myCEXPOfficeTab
            // 
            this.myCEXPOfficeTab.Location = new System.Drawing.Point(0, 0);
            this.myCEXPOfficeTab.Name = "myCEXPOfficeTab";
            this.myCEXPOfficeTab.Size = new System.Drawing.Size(336, 159);
            this.myCEXPOfficeTab.TabIndex = 2;
            // 
            // tabExpWhrh
            // 
            this.tabExpWhrh.Controls.Add(this.cexpWarehouseTab1);
            this.tabExpWhrh.Location = new System.Drawing.Point(4, 22);
            this.tabExpWhrh.Name = "tabExpWhrh";
            this.tabExpWhrh.Padding = new System.Windows.Forms.Padding(3);
            this.tabExpWhrh.Size = new System.Drawing.Size(339, 159);
            this.tabExpWhrh.TabIndex = 1;
            this.tabExpWhrh.Text = "Express(Warehouse)";
            this.tabExpWhrh.UseVisualStyleBackColor = true;
            // 
            // cexpWarehouseTab1
            // 
            this.cexpWarehouseTab1.Location = new System.Drawing.Point(0, 0);
            this.cexpWarehouseTab1.Name = "cexpWarehouseTab1";
            this.cexpWarehouseTab1.Size = new System.Drawing.Size(336, 159);
            this.cexpWarehouseTab1.TabIndex = 2;
            // 
            // tabLogistics
            // 
            this.tabLogistics.Controls.Add(this.cllTab1);
            this.tabLogistics.Location = new System.Drawing.Point(4, 22);
            this.tabLogistics.Name = "tabLogistics";
            this.tabLogistics.Size = new System.Drawing.Size(339, 159);
            this.tabLogistics.TabIndex = 1;
            this.tabLogistics.Text = "Logistics";
            this.tabLogistics.UseVisualStyleBackColor = true;
            // 
            // cllTab1
            // 
            this.cllTab1.Location = new System.Drawing.Point(0, 0);
            this.cllTab1.Name = "cllTab1";
            this.cllTab1.Size = new System.Drawing.Size(331, 155);
            this.cllTab1.TabIndex = 2;
            // 
            // tabDukes
            // 
            this.tabDukes.Controls.Add(this.dukeTab1);
            this.tabDukes.Location = new System.Drawing.Point(4, 22);
            this.tabDukes.Name = "tabDukes";
            this.tabDukes.Size = new System.Drawing.Size(339, 159);
            this.tabDukes.TabIndex = 1;
            this.tabDukes.Text = "Dukes";
            this.tabDukes.UseVisualStyleBackColor = true;
            // 
            // dukeTab1
            // 
            this.dukeTab1.Location = new System.Drawing.Point(0, 0);
            this.dukeTab1.Name = "dukeTab1";
            this.dukeTab1.Size = new System.Drawing.Size(331, 155);
            this.dukeTab1.TabIndex = 2;
        

            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(355, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // MainOutput
            // 
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabDriver.ResumeLayout(false);
            this.tabExpOffice.ResumeLayout(false);
            this.tabExpWhrh.ResumeLayout(false);
            this.tabLogistics.ResumeLayout(false);
            this.tabDukes.ResumeLayout(false);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 210);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainOutput";
            this.Text = "DnA PRESA";

            this.ResumeLayout(false);
        }

        #endregion

        private DnAScreener.DriverTab myDriverTab;
        private DnAScreener.CEXPOffice myCEXPOfficeTab;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabDriver;
        private System.Windows.Forms.TabPage tabExpOffice;
        private System.Windows.Forms.TabPage tabExpWhrh;
        private System.Windows.Forms.TabPage tabLogistics;
        private System.Windows.Forms.TabPage tabDukes;
        private CrystalReport1 crystalReport11;
        private CEXPWarehouseTab cexpWarehouseTab1;
        private CLLTab cllTab1;
        private DukeTab dukeTab1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;

    }
}

