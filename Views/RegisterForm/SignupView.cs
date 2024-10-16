using PharmacySystem.Presenters;
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

namespace PharmacySystem.Views
{
    public partial class SignupView : Form, ISignupView
    {
        private string _connectionString;
        public SignupView(string connectionString)
        {
            InitializeComponent();
            new SignupPresenter(this, connectionString);

            _connectionString = connectionString;
            AsscociateAndRaiseViewEvents();
        }

        private void AsscociateAndRaiseViewEvents()
        {
            btnSignup.Click += delegate { Signup?.Invoke(this, EventArgs.Empty); };
            
        }

        public string FullName { get => txtFullName.Text; set => txtFullName.Text = value; }
        public string Username { get => txtUsername.Text; set => txtUsername.Text = value; }
        public string Password { get => txtPassword.Text; set => txtPassword.Text = value; }
        public string BirthYear { get => txtBirthYear.Text; set => txtBirthYear.Text = value; }

        public event EventHandler Signup;


        public void CloseForm()
        {
            this.Hide();
        }

        private void lkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LoginView loginView = new LoginView(_connectionString);
            loginView.Show();
            this.Hide();

        }

        private void chkDisplayPassword_CheckedChanged_1(object sender, EventArgs e)
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
    }
}
