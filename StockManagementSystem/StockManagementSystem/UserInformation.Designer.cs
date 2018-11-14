namespace StockManagementSystem
{
    partial class UserInformation
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
            this.userInformationGridView = new System.Windows.Forms.DataGridView();
            this.Sno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.userInformationGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // userInformationGridView
            // 
            this.userInformationGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.userInformationGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.userInformationGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sno});
            this.userInformationGridView.Enabled = false;
            this.userInformationGridView.Location = new System.Drawing.Point(12, 70);
            this.userInformationGridView.Name = "userInformationGridView";
            this.userInformationGridView.Size = new System.Drawing.Size(607, 263);
            this.userInformationGridView.TabIndex = 0;
            this.userInformationGridView.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.userInformationGridView_RowPostPaint);
            // 
            // Sno
            // 
            this.Sno.HeaderText = "Sno";
            this.Sno.Name = "Sno";
            // 
            // UserInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(644, 356);
            this.Controls.Add(this.userInformationGridView);
            this.Name = "UserInformation";
            this.Text = "UserInformation";
            ((System.ComponentModel.ISupportInitialize)(this.userInformationGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView userInformationGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sno;
    }
}