using PharmacySystem.Repositories.UserRepository;
using PharmacySystem.Services;
using PharmacySystem.Views;
using PharmacySystem.Views.DashboardForm;
using PharmacySystem.Views.LoginForm;
using PharmacySystem.Views.MainForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Presenters
{
    public class MainPresenter
    {
        private readonly IMainView _mainView;
        private readonly AuthService _authService;
        private readonly string _connectionString;

        public MainPresenter(IMainView mainView, string connectionString)
        {
            _mainView = mainView;
            _connectionString = connectionString;
            _authService = new AuthService(_connectionString);

            _mainView.Logout += OnLogout;
            _mainView.ShowDashboard += OnShowDashboard;
        }

        private void OnShowDashboard(object sender, EventArgs e)
        {
            DashboardView dashboardView = new DashboardView(_connectionString);
            dashboardView.Show();
            _mainView.CloseForm();
        }

        private void OnLogout(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Bạn có muốn đăng xuất không?!", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }
            LoginView loginView = new LoginView(_connectionString);
            loginView.Show();
            _authService.Logout();
            _mainView.CloseForm();
        }
    }
}
