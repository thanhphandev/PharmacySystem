using PharmacySystem.Models;
using PharmacySystem.Services;
using PharmacySystem.Views;
using PharmacySystem.Views.LoginForm;
using PharmacySystem.Views.MainForm;
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
       
        private readonly ILoginView _loginView;
        private readonly AuthService _authService;
        private readonly string _connectionString;
       
       
        public LoginPresenter(ILoginView loginView, string connectionString)
        {
           
            _loginView = loginView;
            _connectionString = connectionString;
            _authService = new AuthService(_connectionString);

            _loginView.Login += async (sender, args) => await OnLogin();


        }

        private async Task OnLogin()
        {
            if (string.IsNullOrWhiteSpace(_loginView.Username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo");
                return;
            }

            if (string.IsNullOrWhiteSpace(_loginView.Password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo");
                return;
            }


            try
            {
                var accountExist = await _authService.CheckAccountExist(_loginView.Username);
                if(accountExist == null)
                {
                    MessageBox.Show("Tài khoản không tồn tại! vui lòng đăng ký", "Thông báo");
                    return;
                }
                
                bool loginSucessfull = await _authService.Login(_loginView.Username, _loginView.Password);
                
                if (loginSucessfull)
                {

                    var result = MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK);
                    if(result == DialogResult.OK)
                    {
                        MainView mainView = new MainView(_connectionString);
                        mainView.Show();
                        _loginView.CloseForm();
                    }
                }
                else
                {
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Cảnh báo");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đăng nhập thất bại! vui lòng liên hệ nhà cung cấp.\nLỗi: {ex.Message}", "Cảnh báo");
            }
        }
    }
}
