using PharmacySystem.Presenters;
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
    public partial class MainView : Form, IMainView
    {
        public MainView(string connectionString)
        {
            InitializeComponent();
            new MainPresenter(this, connectionString);
            this.Load += new EventHandler(LoadUserData);

            btnLogout.Click += delegate
            {
                Logout?.Invoke(this, EventArgs.Empty);
            };
            btnDashboard.Click += delegate
            {
                ShowDashboard?.Invoke(this, EventArgs.Empty);
            };
        }

        public event EventHandler Logout;
        public event EventHandler ShowDashboard;

        private void LoadUserData(object sender, EventArgs e)
        {
            lbFullName.Text = "Xin chào, " + UserSession.FullName;

        }


        public void CloseForm()
        {
            this.Close();
        }
    }
}
