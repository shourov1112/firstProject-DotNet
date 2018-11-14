namespace StockManagementSystem
{
    partial class Home
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
            this.categoryMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.companyMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemSetupMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchByDateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.userModifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.categoryMenuItem,
            this.companyMenuItem,
            this.itemSetupMenuItem,
            this.stockInToolStripMenuItem,
            this.stockOutToolStripMenuItem,
            this.searchItemToolStripMenuItem,
            this.searchByDateToolStripMenuItem,
            this.userModifyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1118, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // categoryMenuItem
            // 
            this.categoryMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.categoryMenuItem.Name = "categoryMenuItem";
            this.categoryMenuItem.Size = new System.Drawing.Size(162, 29);
            this.categoryMenuItem.Text = "Category Setup";
            this.categoryMenuItem.Click += new System.EventHandler(this.categoryMenuItem_Click);
            // 
            // companyMenuItem
            // 
            this.companyMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.companyMenuItem.Name = "companyMenuItem";
            this.companyMenuItem.Size = new System.Drawing.Size(166, 29);
            this.companyMenuItem.Text = "Company Setup";
            this.companyMenuItem.Click += new System.EventHandler(this.companyMenuItem_Click);
            // 
            // itemSetupMenuItem
            // 
            this.itemSetupMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.itemSetupMenuItem.Name = "itemSetupMenuItem";
            this.itemSetupMenuItem.Size = new System.Drawing.Size(121, 29);
            this.itemSetupMenuItem.Text = "Item Setup";
            this.itemSetupMenuItem.Click += new System.EventHandler(this.itemSetupMenuItem_Click);
            // 
            // stockInToolStripMenuItem
            // 
            this.stockInToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockInToolStripMenuItem.Name = "stockInToolStripMenuItem";
            this.stockInToolStripMenuItem.Size = new System.Drawing.Size(97, 29);
            this.stockInToolStripMenuItem.Text = "Stock In";
            this.stockInToolStripMenuItem.Click += new System.EventHandler(this.stockInToolStripMenuItem_Click);
            // 
            // stockOutToolStripMenuItem
            // 
            this.stockOutToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stockOutToolStripMenuItem.Name = "stockOutToolStripMenuItem";
            this.stockOutToolStripMenuItem.Size = new System.Drawing.Size(112, 29);
            this.stockOutToolStripMenuItem.Text = "Stock Out";
            this.stockOutToolStripMenuItem.Click += new System.EventHandler(this.stockOutToolStripMenuItem_Click);
            // 
            // searchItemToolStripMenuItem
            // 
            this.searchItemToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchItemToolStripMenuItem.Name = "searchItemToolStripMenuItem";
            this.searchItemToolStripMenuItem.Size = new System.Drawing.Size(128, 29);
            this.searchItemToolStripMenuItem.Text = "Search Item";
            this.searchItemToolStripMenuItem.Click += new System.EventHandler(this.searchItemToolStripMenuItem_Click);
            // 
            // searchByDateToolStripMenuItem
            // 
            this.searchByDateToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchByDateToolStripMenuItem.Name = "searchByDateToolStripMenuItem";
            this.searchByDateToolStripMenuItem.Size = new System.Drawing.Size(156, 29);
            this.searchByDateToolStripMenuItem.Text = "Search By Date";
            this.searchByDateToolStripMenuItem.Click += new System.EventHandler(this.searchByDateToolStripMenuItem_Click);
            // 
            // userModifyToolStripMenuItem
            // 
            this.userModifyToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userModifyToolStripMenuItem.Name = "userModifyToolStripMenuItem";
            this.userModifyToolStripMenuItem.Size = new System.Drawing.Size(133, 29);
            this.userModifyToolStripMenuItem.Text = "User Modify";
            this.userModifyToolStripMenuItem.Click += new System.EventHandler(this.userModifyToolStripMenuItem_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(1118, 600);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Home";
            this.Text = "Home";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Home_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem categoryMenuItem;
        private System.Windows.Forms.ToolStripMenuItem companyMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemSetupMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchByDateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem userModifyToolStripMenuItem;
    }
}