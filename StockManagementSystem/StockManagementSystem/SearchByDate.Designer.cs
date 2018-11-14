namespace StockManagementSystem
{
    partial class SearchByDate
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.fromDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.toDateTimePiker = new System.Windows.Forms.DateTimePicker();
            this.SearchButton = new System.Windows.Forms.Button();
            this.showGridView = new System.Windows.Forms.DataGridView();
            this.slDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sellQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.searchItemByDateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.PdfButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.showGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchItemByDateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(193, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(193, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "To Date";
            // 
            // fromDateTimePicker
            // 
            this.fromDateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fromDateTimePicker.Location = new System.Drawing.Point(313, 70);
            this.fromDateTimePicker.Name = "fromDateTimePicker";
            this.fromDateTimePicker.Size = new System.Drawing.Size(314, 26);
            this.fromDateTimePicker.TabIndex = 1;
            // 
            // toDateTimePiker
            // 
            this.toDateTimePiker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDateTimePiker.Location = new System.Drawing.Point(313, 104);
            this.toDateTimePiker.Name = "toDateTimePiker";
            this.toDateTimePiker.Size = new System.Drawing.Size(314, 26);
            this.toDateTimePiker.TabIndex = 1;
            // 
            // SearchButton
            // 
            this.SearchButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchButton.Location = new System.Drawing.Point(552, 152);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 33);
            this.SearchButton.TabIndex = 2;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // showGridView
            // 
            this.showGridView.AutoGenerateColumns = false;
            this.showGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.showGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.showGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.slDataGridViewTextBoxColumn,
            this.itemNameDataGridViewTextBoxColumn,
            this.sellQuantityDataGridViewTextBoxColumn});
            this.showGridView.DataSource = this.searchItemByDateBindingSource;
            this.showGridView.Location = new System.Drawing.Point(79, 241);
            this.showGridView.Name = "showGridView";
            this.showGridView.Size = new System.Drawing.Size(586, 192);
            this.showGridView.TabIndex = 3;
            // 
            // slDataGridViewTextBoxColumn
            // 
            this.slDataGridViewTextBoxColumn.DataPropertyName = "Sl";
            this.slDataGridViewTextBoxColumn.FillWeight = 30F;
            this.slDataGridViewTextBoxColumn.HeaderText = "Sl";
            this.slDataGridViewTextBoxColumn.Name = "slDataGridViewTextBoxColumn";
            // 
            // itemNameDataGridViewTextBoxColumn
            // 
            this.itemNameDataGridViewTextBoxColumn.DataPropertyName = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.HeaderText = "ItemName";
            this.itemNameDataGridViewTextBoxColumn.Name = "itemNameDataGridViewTextBoxColumn";
            // 
            // sellQuantityDataGridViewTextBoxColumn
            // 
            this.sellQuantityDataGridViewTextBoxColumn.DataPropertyName = "SellQuantity";
            this.sellQuantityDataGridViewTextBoxColumn.HeaderText = "SellQuantity";
            this.sellQuantityDataGridViewTextBoxColumn.Name = "sellQuantityDataGridViewTextBoxColumn";
            // 
            // searchItemByDateBindingSource
            // 
            this.searchItemByDateBindingSource.DataSource = typeof(StockManagementSystem.Model.SearchItemByDate);
            // 
            // PdfButton
            // 
            this.PdfButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PdfButton.Location = new System.Drawing.Point(552, 439);
            this.PdfButton.Name = "PdfButton";
            this.PdfButton.Size = new System.Drawing.Size(113, 33);
            this.PdfButton.TabIndex = 2;
            this.PdfButton.Text = "Create PDF";
            this.PdfButton.UseVisualStyleBackColor = true;
            this.PdfButton.Click += new System.EventHandler(this.PdfButton_Click);
            // 
            // SearchByDate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(749, 495);
            this.Controls.Add(this.showGridView);
            this.Controls.Add(this.PdfButton);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.toDateTimePiker);
            this.Controls.Add(this.fromDateTimePicker);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SearchByDate";
            this.Text = "SearchByDate";
            ((System.ComponentModel.ISupportInitialize)(this.showGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchItemByDateBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker fromDateTimePicker;
        private System.Windows.Forms.DateTimePicker toDateTimePiker;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.DataGridView showGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn slDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sellQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource searchItemByDateBindingSource;
        private System.Windows.Forms.Button PdfButton;
    }
}