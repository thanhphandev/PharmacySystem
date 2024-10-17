namespace PharmacySystem.Views
{
    partial class LoginView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginView));
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.chkDisplayPassword = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lkRegister = new System.Windows.Forms.LinkLabel();
            this.lbUsername = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.label2.Location = new System.Drawing.Point(53, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(261, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hệ thống quản lý nhà thuốc";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(373, 461);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Emoji", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.label1.Location = new System.Drawing.Point(434, 153);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(264, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Chào mừng bạn! Xin mời đăng nhập";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(447, 269);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(219, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(444, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mật khẩu";
            this.label4.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(447, 222);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(219, 20);
            this.txtUsername.TabIndex = 3;
            // 
            // chkDisplayPassword
            // 
            this.chkDisplayPassword.AutoSize = true;
            this.chkDisplayPassword.Location = new System.Drawing.Point(447, 295);
            this.chkDisplayPassword.Name = "chkDisplayPassword";
            this.chkDisplayPassword.Size = new System.Drawing.Size(109, 17);
            this.chkDisplayPassword.TabIndex = 5;
            this.chkDisplayPassword.Text = "Hiển thị mật khẩu";
            this.chkDisplayPassword.UseVisualStyleBackColor = true;
            this.chkDisplayPassword.CheckedChanged += new System.EventHandler(this.chkDisplayPassword_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(444, 348);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Bạn chưa có tài khoản?";
            // 
            // lkRegister
            // 
            this.lkRegister.AutoSize = true;
            this.lkRegister.Location = new System.Drawing.Point(562, 348);
            this.lkRegister.Name = "lkRegister";
            this.lkRegister.Size = new System.Drawing.Size(73, 13);
            this.lkRegister.TabIndex = 7;
            this.lkRegister.TabStop = true;
            this.lkRegister.Text = "Đăng ký ngay";
            this.lkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkRegister_LinkClicked);
            // 
            // lbUsername
            // 
            this.lbUsername.AutoSize = true;
            this.lbUsername.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUsername.Location = new System.Drawing.Point(444, 202);
            this.lbUsername.Name = "lbUsername";
            this.lbUsername.Size = new System.Drawing.Size(67, 17);
            this.lbUsername.TabIndex = 8;
            this.lbUsername.Text = "Username";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(447, 319);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 9;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // LoginView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(252)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lbUsername);
            this.Controls.Add(this.lkRegister);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.chkDisplayPassword);
            this.Controls.Add(this.txtUsername);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.Name = "LoginView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng nhập tài khoản";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.CheckBox chkDisplayPassword;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel lkRegister;
        private System.Windows.Forms.Label lbUsername;
        private System.Windows.Forms.Button btnLogin;
    }
}