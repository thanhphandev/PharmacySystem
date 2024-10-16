using PharmacySystem.Views.LoginForm;
using PharmacySystem.Views.RegisterForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using PharmacySystem.Presenters;

namespace PharmacySystem.Views
{
    public partial class LoginView : KryptonForm, ILoginView
    {
        private string message;
        public LoginView()
        {
            InitializeComponent();
            AsscociateAndRaiseViewEvents();
            
        }

        private void AsscociateAndRaiseViewEvents()
        {
            btnLogin.Click += delegate { Login?.Invoke(this, EventArgs.Empty); };
            

        }

        public string Username { get => txtUsername.Text; set => txtUsername.Text = value; }
        public string Password { get => txtPassword.Text; set => txtPassword.Text = value; }
        public string Message { get => message; set => message = value; }

        private void chkDisplayPassword_CheckedChanged(object sender, EventArgs e)
        {

            if (chkDisplayPassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        public void CloseForm()
        {
            this.Hide();
        }


        public event EventHandler Login;
        private void lkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignupView signupView = new SignupView();
            signupView.Show();
            this.Hide();
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        
    }
}
