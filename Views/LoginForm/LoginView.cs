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
using PharmacySystem.Presenters;

namespace PharmacySystem.Views
{
    
    public partial class LoginView : Form, ILoginView
    {
        
        public event EventHandler Login;
        public event EventHandler NavigateToSignupPage;

        public LoginView(string connectionString)
        {
            InitializeComponent();
            new LoginPresenter(this, connectionString);
            AssociateAndRaiseViewEvents();
            
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnLogin.Click += delegate { Login?.Invoke(this, EventArgs.Empty); };
            lkRegister.Click += delegate { NavigateToSignupPage?.Invoke(this, EventArgs.Empty); };
            txtPassword.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    Login?.Invoke(this, EventArgs.Empty);
                    e.SuppressKeyPress = true;
                }
            };
        }

        public string Username { get => txtUsername.Text; set => txtUsername.Text = value; }
        public string Password { get => txtPassword.Text; set => txtPassword.Text = value; }

        public void CloseForm()
        {
            this.Hide();
        }

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


        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
