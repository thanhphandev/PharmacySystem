namespace PharmacySystem.Views.SuppliersForm
{
    partial class SuppliersView
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
            this.SupplierDataGrid = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierPhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SupplierAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHeader
            // 
            this.txtHeader.Location = new System.Drawing.Point(42, 29);
            this.txtHeader.Size = new System.Drawing.Size(104, 20);
            this.txtHeader.Text = "Nhà cung cấp";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Items.AddRange(new object[] {
            "All",
            "Tên",
            "SDT",
            "Địa chỉ"});
            this.cbFilter.Size = new System.Drawing.Size(88, 25);
            // 
            // SupplierDataGrid
            // 
            this.SupplierDataGrid.AllowUserToAddRows = false;
            this.SupplierDataGrid.AllowUserToDeleteRows = false;
            this.SupplierDataGrid.AllowUserToOrderColumns = true;
            this.SupplierDataGrid.AllowUserToResizeColumns = false;
            this.SupplierDataGrid.AllowUserToResizeRows = false;
            this.SupplierDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SupplierDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SupplierDataGrid.BackgroundColor = System.Drawing.Color.MintCream;
            this.SupplierDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SupplierDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupplierDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.SupplierName,
            this.SupplierPhone,
            this.SupplierAddress,
            this.Edit,
            this.Delete});
            this.SupplierDataGrid.Location = new System.Drawing.Point(46, 141);
            this.SupplierDataGrid.Name = "SupplierDataGrid";
            this.SupplierDataGrid.ReadOnly = true;
            this.SupplierDataGrid.RowTemplate.Height = 30;
            this.SupplierDataGrid.Size = new System.Drawing.Size(798, 348);
            this.SupplierDataGrid.TabIndex = 8;
            this.SupplierDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SupplierDataGrid_CellClick);
            // 
            // Index
            // 
            this.Index.FillWeight = 18.61392F;
            this.Index.HeaderText = "#";
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            // 
            // SupplierName
            // 
            this.SupplierName.FillWeight = 55F;
            this.SupplierName.HeaderText = "Tên nhà cung cấp";
            this.SupplierName.Name = "SupplierName";
            this.SupplierName.ReadOnly = true;
            // 
            // SupplierPhone
            // 
            this.SupplierPhone.FillWeight = 55F;
            this.SupplierPhone.HeaderText = "Số điện thoại";
            this.SupplierPhone.Name = "SupplierPhone";
            this.SupplierPhone.ReadOnly = true;
            // 
            // SupplierAddress
            // 
            this.SupplierAddress.FillWeight = 120F;
            this.SupplierAddress.HeaderText = "Địa chỉ";
            this.SupplierAddress.Name = "SupplierAddress";
            this.SupplierAddress.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.FillWeight = 14.94309F;
            this.Edit.HeaderText = "";
            this.Edit.Image = global::PharmacySystem.Properties.Resources.pencil;
            this.Edit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Edit.MinimumWidth = 10;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.FillWeight = 14.78384F;
            this.Delete.HeaderText = "";
            this.Delete.Image = global::PharmacySystem.Properties.Resources.remove;
            this.Delete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Delete.MinimumWidth = 10;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            // 
            // SuppliersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 533);
            this.Controls.Add(this.SupplierDataGrid);
            this.Name = "SuppliersView";
            this.Text = "";
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.txtHeader, 0);
            this.Controls.SetChildIndex(this.btnRefresh, 0);
            this.Controls.SetChildIndex(this.cbFilter, 0);
            this.Controls.SetChildIndex(this.SupplierDataGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView SupplierDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierPhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn SupplierAddress;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}