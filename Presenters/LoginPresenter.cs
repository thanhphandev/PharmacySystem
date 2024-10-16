using PharmacySystem.Models;
using PharmacySystem.Repositories.UserRepository;
using PharmacySystem.Services;
using PharmacySystem.Views;
using PharmacySystem.Views.LoginForm;
using PharmacySystem.Views.RegisterForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Presenters
{
    public class LoginPresenter
    {
        private readonly string connectionString;
        private ILoginView _loginView;
        private AuthService _authService;
        private UserRepository _userRepository;
       
       
        public LoginPresenter(ILoginView loginView, string connectionString)
        {
           
            _loginView = loginView;
            this.connectionString = connectionString;

            _loginView.Login += OnLogin;

            _userRepository = new UserRepository(connectionString);
            _authService = new AuthService(_userRepository);

            
        }

        private void OnLogin(object sender, EventArgs e)
        {
            MainView view = new MainView();
            try
            {
                bool loginSucessfull = _authService.Login(_loginView.Username, _loginView.Password);
                
                if (loginSucessfull)
                {

                    MessageBox.Show("Đăng nhập thành công!", "Thông báo");
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Cảnh báo");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đăng nhập thất bại! Lỗi: {ex.Message}");
            }
        }
    }
}
