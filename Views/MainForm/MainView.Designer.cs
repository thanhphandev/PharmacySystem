﻿namespace PharmacySystem.Views.MainForm
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.panel1 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnDashboard = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbFullName = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbLogo = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCharge = new System.Windows.Forms.Button();
            this.txtTotal = new System.Windows.Forms.Label();
            this.txtTempTotal = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SupplierDataGrid = new System.Windows.Forms.DataGridView();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Delete = new System.Windows.Forms.DataGridViewImageColumn();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDashboard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.btnDashboard);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.lbFullName);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.lbLogo);
            this.panel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1255, 66);
            this.panel1.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(296, 21);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(74, 25);
            this.comboBox1.TabIndex = 7;
            // 
            // btnDashboard
            // 
            this.btnDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDashboard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDashboard.Image = global::PharmacySystem.Properties.Resources.dashboard;
            this.btnDashboard.Location = new System.Drawing.Point(1165, 17);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Size = new System.Drawing.Size(30, 30);
            this.btnDashboard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDashboard.TabIndex = 6;
            this.btnDashboard.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = global::PharmacySystem.Properties.Resources.search;
            this.pictureBox2.Location = new System.Drawing.Point(749, 18);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(28, 28);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 5;
            this.pictureBox2.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(376, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(367, 25);
            this.textBox1.TabIndex = 4;
            // 
            // lbFullName
            // 
            this.lbFullName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbFullName.AutoSize = true;
            this.lbFullName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFullName.Location = new System.Drawing.Point(994, 25);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(118, 17);
            this.lbFullName.TabIndex = 3;
            this.lbFullName.Text = "Xin chào, username";
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogout.Image = global::PharmacySystem.Properties.Resources.logout1;
            this.btnLogout.Location = new System.Drawing.Point(1213, 17);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(30, 30);
            this.btnLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLogout.TabIndex = 2;
            this.btnLogout.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(159, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(41, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // lbLogo
            // 
            this.lbLogo.AutoSize = true;
            this.lbLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbLogo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbLogo.Location = new System.Drawing.Point(8, 21);
            this.lbLogo.Name = "lbLogo";
            this.lbLogo.Size = new System.Drawing.Size(145, 21);
            this.lbLogo.TabIndex = 0;
            this.lbLogo.Text = "Pharmacy System";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.SupplierDataGrid);
            this.panel3.Controls.Add(this.flowLayoutPanel2);
            this.panel3.Controls.Add(this.flowLayoutPanel1);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.MinimumSize = new System.Drawing.Size(850, 500);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1255, 618);
            this.panel3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.btnCharge);
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Controls.Add(this.txtTempTotal);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(844, 437);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(411, 119);
            this.panel2.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.GhostWhite;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(57, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 30);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnCharge
            // 
            this.btnCharge.BackColor = System.Drawing.Color.Blue;
            this.btnCharge.FlatAppearance.BorderColor = System.Drawing.Color.Blue;
            this.btnCharge.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCharge.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCharge.ForeColor = System.Drawing.Color.White;
            this.btnCharge.Location = new System.Drawing.Point(200, 79);
            this.btnCharge.Name = "btnCharge";
            this.btnCharge.Size = new System.Drawing.Size(127, 30);
            this.btnCharge.TabIndex = 2;
            this.btnCharge.Text = "Thanh toán";
            this.btnCharge.UseVisualStyleBackColor = false;
            // 
            // txtTotal
            // 
            this.txtTotal.AutoSize = true;
            this.txtTotal.Location = new System.Drawing.Point(309, 59);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(68, 17);
            this.txtTotal.TabIndex = 1;
            this.txtTotal.Text = "XXX.000 đ";
            // 
            // txtTempTotal
            // 
            this.txtTempTotal.AutoSize = true;
            this.txtTempTotal.Location = new System.Drawing.Point(309, 29);
            this.txtTempTotal.Name = "txtTempTotal";
            this.txtTempTotal.Size = new System.Drawing.Size(68, 17);
            this.txtTempTotal.TabIndex = 1;
            this.txtTempTotal.Text = "XXX.000 đ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(14, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 19);
            this.label2.TabIndex = 0;
            this.label2.Text = "Tổng:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(14, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tạm tính:";
            // 
            // SupplierDataGrid
            // 
            this.SupplierDataGrid.AllowUserToAddRows = false;
            this.SupplierDataGrid.AllowUserToDeleteRows = false;
            this.SupplierDataGrid.AllowUserToOrderColumns = true;
            this.SupplierDataGrid.AllowUserToResizeColumns = false;
            this.SupplierDataGrid.AllowUserToResizeRows = false;
            this.SupplierDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SupplierDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.SupplierDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SupplierDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SupplierDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SupplierDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Index,
            this.code,
            this.dgvName,
            this.dgvQuantity,
            this.dgvPrice,
            this.dgvAmount,
            this.Delete});
            this.SupplierDataGrid.Location = new System.Drawing.Point(844, 72);
            this.SupplierDataGrid.Name = "SupplierDataGrid";
            this.SupplierDataGrid.ReadOnly = true;
            this.SupplierDataGrid.RowTemplate.Height = 30;
            this.SupplierDataGrid.Size = new System.Drawing.Size(411, 358);
            this.SupplierDataGrid.TabIndex = 9;
            // 
            // Index
            // 
            this.Index.FillWeight = 14.75847F;
            this.Index.HeaderText = "#";
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            // 
            // code
            // 
            this.code.FillWeight = 18.80264F;
            this.code.HeaderText = "id";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            // 
            // dgvName
            // 
            this.dgvName.FillWeight = 102.2159F;
            this.dgvName.HeaderText = "Tên";
            this.dgvName.Name = "dgvName";
            this.dgvName.ReadOnly = true;
            // 
            // dgvQuantity
            // 
            this.dgvQuantity.FillWeight = 21.10533F;
            this.dgvQuantity.HeaderText = "SL";
            this.dgvQuantity.Name = "dgvQuantity";
            this.dgvQuantity.ReadOnly = true;
            // 
            // dgvPrice
            // 
            this.dgvPrice.FillWeight = 57.25486F;
            this.dgvPrice.HeaderText = "Giá";
            this.dgvPrice.Name = "dgvPrice";
            this.dgvPrice.ReadOnly = true;
            // 
            // dgvAmount
            // 
            this.dgvAmount.FillWeight = 52.43291F;
            this.dgvAmount.HeaderText = "S.tiền";
            this.dgvAmount.Name = "dgvAmount";
            this.dgvAmount.ReadOnly = true;
            // 
            // Delete
            // 
            this.Delete.FillWeight = 18.36213F;
            this.Delete.HeaderText = "";
            this.Delete.Image = global::PharmacySystem.Properties.Resources.remove;
            this.Delete.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Delete.MinimumWidth = 10;
            this.Delete.Name = "Delete";
            this.Delete.ReadOnly = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 72);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(835, 484);
            this.flowLayoutPanel2.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(337, 253);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(8, 8);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 562);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1255, 56);
            this.panel4.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 4);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Thuế VAT";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1255, 618);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ thống quản lý thuốc, dược phẩm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnDashboard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SupplierDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbLogo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btnLogout;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbFullName;
        private System.Windows.Forms.PictureBox btnDashboard;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView SupplierDataGrid;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvAmount;
        private System.Windows.Forms.DataGridViewImageColumn Delete;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnCharge;
        private System.Windows.Forms.Label txtTotal;
        private System.Windows.Forms.Label txtTempTotal;
        private System.Windows.Forms.Label label3;
    }
}