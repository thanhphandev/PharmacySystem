namespace PharmacySystem.Views.MedicineCategoryForm
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
            this.dgvIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvEdit = new System.Windows.Forms.DataGridViewImageColumn();
            this.dgvDelete = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MedicineGroupDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHeader
            // 
            this.txtHeader.Size = new System.Drawing.Size(167, 20);
            this.txtHeader.Text = "Danh sách nhóm thuốc";
            // 
            // btnAdd
            // 
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // MedicineGroupDataGrid
            // 
            this.MedicineGroupDataGrid.AllowUserToAddRows = false;
            this.MedicineGroupDataGrid.AllowUserToDeleteRows = false;
            this.MedicineGroupDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MedicineGroupDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.MedicineGroupDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MedicineGroupDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvIndex,
            this.dgvCode,
            this.dgvName,
            this.dgvEdit,
            this.dgvDelete});
            this.MedicineGroupDataGrid.Location = new System.Drawing.Point(46, 149);
            this.MedicineGroupDataGrid.Name = "MedicineGroupDataGrid";
            this.MedicineGroupDataGrid.ReadOnly = true;
            this.MedicineGroupDataGrid.Size = new System.Drawing.Size(722, 326);
            this.MedicineGroupDataGrid.TabIndex = 5;
            // 
            // dgvIndex
            // 
            this.dgvIndex.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvIndex.FillWeight = 70F;
            this.dgvIndex.HeaderText = "#";
            this.dgvIndex.MinimumWidth = 70;
            this.dgvIndex.Name = "dgvIndex";
            this.dgvIndex.ReadOnly = true;
            this.dgvIndex.Width = 70;
            // 
            // dgvCode
            // 
            this.dgvCode.HeaderText = "Code";
            this.dgvCode.Name = "dgvCode";
            this.dgvCode.ReadOnly = true;
            // 
            // dgvName
            // 
            this.dgvName.HeaderText = "Tên nhóm thuốc";
            this.dgvName.Name = "dgvName";
            this.dgvName.ReadOnly = true;
            // 
            // dgvEdit
            // 
            this.dgvEdit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvEdit.FillWeight = 50F;
            this.dgvEdit.HeaderText = "";
            this.dgvEdit.Image = global::PharmacySystem.Properties.Resources.pencil;
            this.dgvEdit.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dgvEdit.MinimumWidth = 50;
            this.dgvEdit.Name = "dgvEdit";
            this.dgvEdit.ReadOnly = true;
            this.dgvEdit.Width = 50;
            // 
            // dgvDelete
            // 
            this.dgvDelete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dgvDelete.FillWeight = 50F;
            this.dgvDelete.HeaderText = "";
            this.dgvDelete.Image = global::PharmacySystem.Properties.Resources.delete;
            this.dgvDelete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dgvDelete.MinimumWidth = 50;
            this.dgvDelete.Name = "dgvDelete";
            this.dgvDelete.ReadOnly = true;
            this.dgvDelete.Width = 50;
            // 
            // MedicineCategoryView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(820, 500);
            this.Controls.Add(this.MedicineGroupDataGrid);
            this.Name = "MedicineCategoryView";
            this.Text = "";
            this.Controls.SetChildIndex(this.btnAdd, 0);
            this.Controls.SetChildIndex(this.MedicineGroupDataGrid, 0);
            this.Controls.SetChildIndex(this.txtHeader, 0);
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MedicineGroupDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView MedicineGroupDataGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvName;
        private System.Windows.Forms.DataGridViewImageColumn dgvEdit;
        private System.Windows.Forms.DataGridViewImageColumn dgvDelete;
    }
}