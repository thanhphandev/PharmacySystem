using PharmacySystem.Presenters;
using PharmacySystem.Services;
using PharmacySystem.Views.MedicineCategoryForm;
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
            btnMain.Click += delegate { ShowMainView?.Invoke(this, EventArgs.Empty); };
            this.Load += new EventHandler(LoadUserData);
        }

        private void LoadUserData(object sender, EventArgs e)
        {
            lbuser.Text = $"Xin chào, {UserSession.FullName}\nBạn đang đăng nhập với vai trò là {UserSession.Role}";
            HomeUI homeUI = new HomeUI();
            AddControls(homeUI);
        }

        public void CloseForm()
        {
            this.Hide();
        }

        public void AddControls(Form form)
        {
            ControlsPanel.Controls.Clear();
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            ControlsPanel.Controls.Add(form);
            form.Show();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            HomeUI homeUI = new HomeUI();
            AddControls(homeUI);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            MedicineCategoryView view = new MedicineCategoryView();
            AddControls(view);
        }


        public event EventHandler ShowMainView;

        
    }
}
