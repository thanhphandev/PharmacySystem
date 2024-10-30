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
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddUnitType)).BeginInit();
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
            // MedicinesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 572);
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
            ((System.ComponentModel.ISupportInitialize)(this.btnAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddUnitType)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnAddUnitType;
        private System.Windows.Forms.Label label1;
    }
}