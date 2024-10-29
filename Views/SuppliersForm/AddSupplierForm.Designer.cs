namespace PharmacySystem.Views.SuppliersForm
{
    partial class AddSupplierForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.Phone = new System.Windows.Forms.Label();
            this.txtSupplierPhone = new System.Windows.Forms.TextBox();
            this.txtSupplierAddress = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbHeader
            // 
            this.lbHeader.Size = new System.Drawing.Size(143, 20);
            this.lbHeader.Text = "Thêm nhà cung cấp";
            // 
            // btnClose
            // 
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tên nhà cung cấp";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(33, 120);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Size = new System.Drawing.Size(198, 25);
            this.txtSupplierName.TabIndex = 2;
            // 
            // Phone
            // 
            this.Phone.AutoSize = true;
            this.Phone.Location = new System.Drawing.Point(30, 159);
            this.Phone.Name = "Phone";
            this.Phone.Size = new System.Drawing.Size(85, 17);
            this.Phone.TabIndex = 1;
            this.Phone.Text = "Số điện thoại";
            // 
            // txtSupplierPhone
            // 
            this.txtSupplierPhone.Location = new System.Drawing.Point(33, 179);
            this.txtSupplierPhone.Name = "txtSupplierPhone";
            this.txtSupplierPhone.Size = new System.Drawing.Size(198, 25);
            this.txtSupplierPhone.TabIndex = 2;
            // 
            // txtSupplierAddress
            // 
            this.txtSupplierAddress.Location = new System.Drawing.Point(33, 227);
            this.txtSupplierAddress.Name = "txtSupplierAddress";
            this.txtSupplierAddress.Size = new System.Drawing.Size(374, 52);
            this.txtSupplierAddress.TabIndex = 3;
            this.txtSupplierAddress.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Địa chỉ";
            // 
            // AddSupplierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 361);
            this.Controls.Add(this.txtSupplierAddress);
            this.Controls.Add(this.txtSupplierPhone);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Phone);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AddSupplierForm";
            this.Text = "AddSupplierForm";
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.Phone, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtSupplierName, 0);
            this.Controls.SetChildIndex(this.txtSupplierPhone, 0);
            this.Controls.SetChildIndex(this.txtSupplierAddress, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.Label Phone;
        private System.Windows.Forms.TextBox txtSupplierPhone;
        private System.Windows.Forms.RichTextBox txtSupplierAddress;
        private System.Windows.Forms.Label label2;
    }
}