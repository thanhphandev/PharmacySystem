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
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MedicineGroupDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // txtHeader
            // 
            this.txtHeader.Size = new System.Drawing.Size(167, 20);
            this.txtHeader.Text = "Danh sách nhóm thuốc";
            // 
            // MedicineGroupDataGrid
            // 
            this.MedicineGroupDataGrid.AllowUserToAddRows = false;
            this.MedicineGroupDataGrid.AllowUserToDeleteRows = false;
            this.MedicineGroupDataGrid.AllowUserToOrderColumns = true;
            this.MedicineGroupDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MedicineGroupDataGrid.BackgroundColor = System.Drawing.Color.White;
            this.MedicineGroupDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MedicineGroupDataGrid.Location = new System.Drawing.Point(46, 149);
            this.MedicineGroupDataGrid.Name = "MedicineGroupDataGrid";
            this.MedicineGroupDataGrid.ReadOnly = true;
            this.MedicineGroupDataGrid.Size = new System.Drawing.Size(722, 326);
            this.MedicineGroupDataGrid.TabIndex = 5;
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
    }
}