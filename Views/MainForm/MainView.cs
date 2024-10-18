using PharmacySystem.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Views.MainForm
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
            this.Load += new EventHandler(LoadUserData);
        }

        private void LoadUserData(object sender, EventArgs e)
        {
            lbUsername.Text = UserSession.Username;
            lbLoginDate.Text = UserSession.LoginTime.ToShortDateString();

        }
    }
}
