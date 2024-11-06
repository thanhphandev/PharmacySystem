namespace PharmacySystem.Views.UIComponents
{
    partial class MedicineProduct
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbName = new System.Windows.Forms.Label();
            this.lbPrice = new System.Windows.Forms.Label();
            this.btnChoose = new System.Windows.Forms.Button();
            this.pbMedicineImage = new System.Windows.Forms.PictureBox();
            this.lbQuantity = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbMedicineImage)).BeginInit();
            this.SuspendLayout();
            // 
            // lbName
            // 
            this.lbName.AutoEllipsis = true;
            this.lbName.AutoSize = true;
            this.lbName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.lbName.Location = new System.Drawing.Point(4, 129);
            this.lbName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(101, 20);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Paracetamon";
            // 
            // lbPrice
            // 
            this.lbPrice.AutoSize = true;
            this.lbPrice.Location = new System.Drawing.Point(5, 149);
            this.lbPrice.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbPrice.Name = "lbPrice";
            this.lbPrice.Size = new System.Drawing.Size(92, 17);
            this.lbPrice.TabIndex = 2;
            this.lbPrice.Text = "50.000 đ /Hộp";
            // 
            // btnChoose
            // 
            this.btnChoose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(81)))), ((int)(((byte)(162)))));
            this.btnChoose.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(81)))), ((int)(((byte)(162)))));
            this.btnChoose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChoose.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChoose.ForeColor = System.Drawing.Color.White;
            this.btnChoose.Location = new System.Drawing.Point(19, 170);
            this.btnChoose.Margin = new System.Windows.Forms.Padding(4);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(120, 30);
            this.btnChoose.TabIndex = 3;
            this.btnChoose.Text = "Chọn sản phẩm";
            this.btnChoose.UseVisualStyleBackColor = false;
            // 
            // pbMedicineImage
            // 
            this.pbMedicineImage.Image = global::PharmacySystem.Properties.Resources.Panadol_Extra_Advance_Box_32s380x463;
            this.pbMedicineImage.Location = new System.Drawing.Point(4, 4);
            this.pbMedicineImage.Margin = new System.Windows.Forms.Padding(4);
            this.pbMedicineImage.Name = "pbMedicineImage";
            this.pbMedicineImage.Size = new System.Drawing.Size(150, 120);
            this.pbMedicineImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbMedicineImage.TabIndex = 0;
            this.pbMedicineImage.TabStop = false;
            // 
            // lbQuantity
            // 
            this.lbQuantity.AutoSize = true;
            this.lbQuantity.Location = new System.Drawing.Point(124, 149);
            this.lbQuantity.Name = "lbQuantity";
            this.lbQuantity.Size = new System.Drawing.Size(15, 17);
            this.lbQuantity.TabIndex = 4;
            this.lbQuantity.Text = "1";
            // 
            // MedicineProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lbQuantity);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.lbPrice);
            this.Controls.Add(this.lbName);
            this.Controls.Add(this.pbMedicineImage);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MedicineProduct";
            this.Size = new System.Drawing.Size(158, 212);
            ((System.ComponentModel.ISupportInitialize)(this.pbMedicineImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbMedicineImage;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbPrice;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.Label lbQuantity;
    }
}
