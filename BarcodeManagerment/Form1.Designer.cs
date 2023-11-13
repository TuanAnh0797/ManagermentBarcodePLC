namespace BarcodeManagerment
{
    partial class Form1
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
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.mcAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewFunctionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addPartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(893, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setupToolStripMenuItem,
            this.setupToolStripMenuItem1});
            this.menuToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(66, 25);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // setupToolStripMenuItem
            // 
            this.setupToolStripMenuItem.Name = "setupToolStripMenuItem";
            this.setupToolStripMenuItem.Size = new System.Drawing.Size(124, 26);
            this.setupToolStripMenuItem.Text = "Main";
            this.setupToolStripMenuItem.Click += new System.EventHandler(this.setupToolStripMenuItem_Click);
            // 
            // setupToolStripMenuItem1
            // 
            this.setupToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mcAddressToolStripMenuItem,
            this.createNewFunctionToolStripMenuItem,
            this.addPartToolStripMenuItem});
            this.setupToolStripMenuItem1.Name = "setupToolStripMenuItem1";
            this.setupToolStripMenuItem1.Size = new System.Drawing.Size(124, 26);
            this.setupToolStripMenuItem1.Text = "Setup";
            this.setupToolStripMenuItem1.Click += new System.EventHandler(this.setupToolStripMenuItem1_Click);
            // 
            // mcAddressToolStripMenuItem
            // 
            this.mcAddressToolStripMenuItem.Name = "mcAddressToolStripMenuItem";
            this.mcAddressToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.mcAddressToolStripMenuItem.Text = "Mc Address";
            this.mcAddressToolStripMenuItem.Click += new System.EventHandler(this.mcAddressToolStripMenuItem_Click);
            // 
            // createNewFunctionToolStripMenuItem
            // 
            this.createNewFunctionToolStripMenuItem.Name = "createNewFunctionToolStripMenuItem";
            this.createNewFunctionToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.createNewFunctionToolStripMenuItem.Text = "Create or Delete Function";
            this.createNewFunctionToolStripMenuItem.Click += new System.EventHandler(this.createNewFunctionToolStripMenuItem_Click);
            // 
            // addPartToolStripMenuItem
            // 
            this.addPartToolStripMenuItem.Name = "addPartToolStripMenuItem";
            this.addPartToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.addPartToolStripMenuItem.Text = "Create or Delete Part";
            this.addPartToolStripMenuItem.Click += new System.EventHandler(this.addPartToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 550);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Barcode Managerment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem addPartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewFunctionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mcAddressToolStripMenuItem;
    }
}

