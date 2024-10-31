namespace PharmacySystem.Views.MedicinesForm
{
    partial class MedicinesView
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
            this.btnAddUnitType = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SupplierDataGrid = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvGroup = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvUnitType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvImage = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvExpireDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvSupplier = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddUnitType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHeader
            // 
            this.txtHeader.Location = new System.Drawing.Point(42, 25);
            this.txtHeader.Size = new System.Drawing.Size(105, 20);
            this.txtHeader.Text = "Quản lý thuốc";
            // 
            // btnAdd
            // 
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(476, 94);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(759, 94);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(351, 94);
            // 
            // cbFilter
            // 
            this.cbFilter.Location = new System.Drawing.Point(382, 94);
            this.cbFilter.Size = new System.Drawing.Size(88, 25);
            // 
            // btnAddUnitType
            // 
            this.btnAddUnitType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddUnitType.Image = global::PharmacySystem.Properties.Resources.wallet;
            this.btnAddUnitType.Location = new System.Drawing.Point(127, 94);
            this.btnAddUnitType.Name = "btnAddUnitType";
            this.btnAddUnitType.Size = new System.Drawing.Size(25, 25);
            this.btnAddUnitType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnAddUnitType.TabIndex = 8;
            this.btnAddUnitType.TabStop = false;
            this.btnAddUnitType.Click += new System.EventHandler(this.btnAddUnitType_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.label1.Location = new System.Drawing.Point(103, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Thêm đơn vị";
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
            this.dgvCode,
            this.dgvName,
            this.dgvGroup,
            this.dgvUnitType,
            this.dgvPrice,
            this.dgvImage,
            this.dgvQuantity,
            this.dgvExpireDate,
            this.dgvSupplier,
            this.Edit,
            this.Delete});
            this.SupplierDataGrid.Location = new System.Drawing.Point(46, 139);
            this.SupplierDataGrid.Name = "SupplierDataGrid";
            this.SupplierDataGrid.ReadOnly = true;
            this.SupplierDataGrid.RowTemplate.Height = 30;
            this.SupplierDataGrid.Size = new System.Drawing.Size(1066, 420);
            this.SupplierDataGrid.TabIndex = 10;
            // 
            // Index
            // 
            this.Index.FillWeight = 26.23789F;
            this.Index.HeaderText = "#";
            this.Index.MinimumWidth = 8;
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            // 
            // dgvCode
            // 
            this.dgvCode.FillWeight = 25.90342F;
            this.dgvCode.HeaderText = "Mã";
            this.dgvCode.MinimumWidth = 7;
            this.dgvCode.Name = "dgvCode";
            this.dgvCode.ReadOnly = true;
            // 
            // dgvName
            // 
            this.dgvName.FillWeight = 82.55022F;
            this.dgvName.HeaderText = "Tên";
            this.dgvName.MinimumWidth = 21;
            this.dgvName.Name = "dgvName";
            this.dgvName.ReadOnly = true;
            // 
            // dgvGroup
            // 
            this.dgvGroup.FillWeight = 55.93804F;
            this.dgvGroup.HeaderText = "Nhóm";
            this.dgvGroup.Name = "dgvGroup";
            this.dgvGroup.ReadOnly = true;
            this.dgvGroup.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvGroup.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dgvUnitType
            // 
            this.dgvUnitType.FillWeight = 72.38578F;
            this.dgvUnitType.HeaderText = "Đơn vị";
            this.dgvUnitType.Name = "dgvUnitType";
            this.dgvUnitType.ReadOnly = true;
            // 
            // dgvPrice
            // 
            this.dgvPrice.FillWeight = 71.47218F;
            this.dgvPrice.HeaderText = "Giá";
            this.dgvPrice.Name = "dgvPrice";
            this.dgvPrice.ReadOnly = true;
            // 
            // dgvImage
            // 
            this.dgvImage.FillWeight = 68.8272F;
            this.dgvImage.HeaderText = "Hình ảnh";
            this.dgvImage.Name = "dgvImage";
            this.dgvImage.ReadOnly = true;
            // 
            // dgvQuantity
            // 
            this.dgvQuantity.FillWeight = 40.78058F;
            this.dgvQuantity.HeaderText = "SL";
            this.dgvQuantity.Name = "dgvQuantity";
            this.dgvQuantity.ReadOnly = true;
            // 
            // dgvExpireDate
            // 
            this.dgvExpireDate.FillWeight = 101.7922F;
            this.dgvExpireDate.HeaderText = "Hạn sử dụng";
            this.dgvExpireDate.Name = "dgvExpireDate";
            this.dgvExpireDate.ReadOnly = true;
            // 
            // dgvSupplier
            // 
            this.dgvSupplier.FillWeight = 63.62017F;
            this.dgvSupplier.HeaderText = "Nhà cung cấp";
            this.dgvSupplier.Name = "dgvSupplier";
            this.dgvSupplier.ReadOnly = true;
            this.dgvSupplier.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSupplier.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Edit
            // 
            this.Edit.FillWeight = 20.66496F;
            this.Edit.HeaderText = "";
            this.Edit.Image = global::PharmacySystem.Properties.Resources.pencil;
            this.Edit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.FillWeight = 20.32305F;
            this.Delete.HeaderText = "";
            this.Delete.Image = global::PharmacySystem.Properties.Resources.remove;
            this.Delete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            // 
            // MedicinesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 597);
            this.Controls.Add(this.SupplierDataGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnAddUnitType);
            this.Name = "MedicinesView";
            this.Text = "MedicinesView";
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.txtHeader, 0);
            this.Controls.SetChildIndex(this.btnRefresh, 0);
            this.Controls.SetChildIndex(this.cbFilter, 0);
            this.Controls.SetChildIndex(this.btnAddUnitType, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.SupplierDataGrid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddUnitType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnAddUnitType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView SupplierDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvName;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvGroup;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvUnitType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvExpireDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvSupplier;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}