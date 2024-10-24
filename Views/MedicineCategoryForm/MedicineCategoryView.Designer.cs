﻿namespace PharmacySystem.Views.MedicineCategoryForm
{
    partial class MedicineCategoryView
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
            this.MedicineGroupDataGrid = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewImageColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MedicineGroupDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHeader
            // 
            this.txtHeader.Size = new System.Drawing.Size(167, 20);
            this.txtHeader.Text = "Danh sách nhóm thuốc";
            // 
            // cbFilter
            // 
            this.cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFilter.Items.AddRange(new object[] {
            "Mã nhóm",
            "Tên Nhóm"});
            this.cbFilter.Size = new System.Drawing.Size(88, 25);
            // 
            // MedicineGroupDataGrid
            // 
            this.MedicineGroupDataGrid.AllowUserToAddRows = false;
            this.MedicineGroupDataGrid.AllowUserToDeleteRows = false;
            this.MedicineGroupDataGrid.AllowUserToOrderColumns = true;
            this.MedicineGroupDataGrid.AllowUserToResizeColumns = false;
            this.MedicineGroupDataGrid.AllowUserToResizeRows = false;
            this.MedicineGroupDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MedicineGroupDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MedicineGroupDataGrid.BackgroundColor = System.Drawing.Color.MintCream;
            this.MedicineGroupDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MedicineGroupDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MedicineGroupDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.GroupCode,
            this.GroupName,
            this.Description,
            this.Edit,
            this.Delete});
            this.MedicineGroupDataGrid.Location = new System.Drawing.Point(46, 149);
            this.MedicineGroupDataGrid.Name = "MedicineGroupDataGrid";
            this.MedicineGroupDataGrid.ReadOnly = true;
            this.MedicineGroupDataGrid.RowTemplate.Height = 30;
            this.MedicineGroupDataGrid.Size = new System.Drawing.Size(727, 295);
            this.MedicineGroupDataGrid.TabIndex = 5;
            this.MedicineGroupDataGrid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MedicineGroupDataGrid_CellClick);
            // 
            // Index
            // 
            this.Index.FillWeight = 18.61392F;
            this.Index.HeaderText = "#";
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            // 
            // GroupCode
            // 
            this.GroupCode.FillWeight = 30.13676F;
            this.GroupCode.HeaderText = "Mã nhóm";
            this.GroupCode.MinimumWidth = 20;
            this.GroupCode.Name = "GroupCode";
            this.GroupCode.ReadOnly = true;
            // 
            // GroupName
            // 
            this.GroupName.FillWeight = 79.20662F;
            this.GroupName.HeaderText = "Tên nhóm";
            this.GroupName.MinimumWidth = 30;
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.FillWeight = 133.5575F;
            this.Description.HeaderText = "Mô tả";
            this.Description.MinimumWidth = 60;
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
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
            // MedicineCategoryView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(820, 500);
            this.Controls.Add(this.MedicineGroupDataGrid);
            this.Name = "MedicineCategoryView";
            this.Text = "";
            this.Controls.SetChildIndex(this.cbFilter, 0);
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.btnSearch, 0);
            this.Controls.SetChildIndex(this.btnRefresh, 0);
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.MedicineGroupDataGrid, 0);
            this.Controls.SetChildIndex(this.txtHeader, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MedicineGroupDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MedicineGroupDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewImageColumn Edit;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
    }
}