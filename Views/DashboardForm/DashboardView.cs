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

namespace PharmacySystem.Views.DashboardForm
{
    public partial class DashboardView : Form, IDashboard
    {
        public DashboardView(string connectionString)
        {
            InitializeComponent();
            new DashboardPresenter(this, connectionString);
            btnHome.Click += delegate { ShowMainView?.Invoke(this, EventArgs.Empty); };
            this.Load += new EventHandler(LoadUserData);
        }

        private void LoadUserData(object sender, EventArgs e)
        {
            lbuser.Text = $"Xin chào, {UserSession.FullName}\nBạn đang đăng nhập với vai trò là {UserSession.Role}";
        }

        public event EventHandler ShowMainView;

        public void CloseForm()
        {
            this.Hide();
        }
    }
}
