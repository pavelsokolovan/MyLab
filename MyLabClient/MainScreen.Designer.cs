namespace MyLabClient
{
    partial class MainScreen
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.orderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tubeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.specimenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.orderToolStripMenuItem,
            this.setupsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(284, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // orderToolStripMenuItem
            // 
            this.orderToolStripMenuItem.Name = "orderToolStripMenuItem";
            this.orderToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.orderToolStripMenuItem.Text = "Order";
            // 
            // setupsToolStripMenuItem
            // 
            this.setupsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tubeToolStripMenuItem,
            this.specimenToolStripMenuItem,
            this.testToolStripMenuItem,
            this.patientToolStripMenuItem});
            this.setupsToolStripMenuItem.Name = "setupsToolStripMenuItem";
            this.setupsToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.setupsToolStripMenuItem.Text = "Setups";
            // 
            // tubeToolStripMenuItem
            // 
            this.tubeToolStripMenuItem.Name = "tubeToolStripMenuItem";
            this.tubeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tubeToolStripMenuItem.Text = "Tube";
            this.tubeToolStripMenuItem.Click += new System.EventHandler(this.tubeToolStripMenuItem_Click);
            // 
            // specimenToolStripMenuItem
            // 
            this.specimenToolStripMenuItem.Name = "specimenToolStripMenuItem";
            this.specimenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.specimenToolStripMenuItem.Text = "Specimen";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testToolStripMenuItem.Text = "Test";
            // 
            // patientToolStripMenuItem
            // 
            this.patientToolStripMenuItem.Name = "patientToolStripMenuItem";
            this.patientToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.patientToolStripMenuItem.Text = "Patient";
            // 
            // MyLabContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MyLabContainer";
            this.Text = "MyLab";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem orderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tubeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem specimenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientToolStripMenuItem;
    }
}