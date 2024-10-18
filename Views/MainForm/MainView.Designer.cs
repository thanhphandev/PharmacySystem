namespace PharmacySystem.Views.MainForm
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
            this.lbUsername = new System.Windows.Forms.Label();
            this.lbLoginDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Location = new System.Drawing.Point(300, 40);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(87, 13);
            this.lbUsername.TabIndex = 0;
            this.lbUsername.Text = " Ten Dang Nhap";
            // 
            // lbLoginDate
            // 
            this.lbLoginDate.AutoSize = true;
            this.lbLoginDate.Location = new System.Drawing.Point(303, 57);
            this.lbLoginDate.Name = "lbLoginDate";
            this.lbLoginDate.Size = new System.Drawing.Size(88, 13);
            this.lbLoginDate.TabIndex = 1;
            this.lbLoginDate.Text = "Ngày Đăng nhập";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "label3";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbLoginDate);
            this.Controls.Add(this.lbUsername);
            this.Name = "MainView";
            this.ShowIcon = false;
            this.Text = "Hệ thống quản lý thuốc, dược phẩm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Label lbLoginDate;
        private System.Windows.Forms.Label label3;
    }
}