using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PharmacySystem.Services;
using PharmacySystem.Views;
using PharmacySystem.Views.LoginForm;
using PharmacySystem.Views.RegisterForm;
using PharmacySystem.Repositories.UserRepository;
using PharmacySystem.Models;
using PharmacySystem.Common;
namespace PharmacySystem.Presenters
{
    public class SignupPresenter
    {
        private readonly string _connectionString;

        private readonly ISignupView _signupView;
        private readonly AuthService _authService;

        public SignupPresenter(ISignupView signupView, string connectionString)
        {
            
            _signupView = signupView;
            _connectionString = connectionString;
            _authService = new AuthService(_connectionString);

            _signupView.Signup += async(sender, args) => await OnSignup();
            _signupView.NavigateToLoginPage += (sender, args) => OnNavigateToLoginPage();

        }

        private void OnNavigateToLoginPage()
        {
            LoginView loginView = new LoginView(_connectionString);
            loginView.Show();
            _signupView.CloseForm();
        }

        private async Task OnSignup()
        {

            var validationMessage = ValidateSignupInputs();
            if (validationMessage != null)
            {
                MessageBox.Show(validationMessage, "Thông báo");
                return;
            }

            try
            {
                bool signupSuccessful = await _authService.Signup(
                    _signupView.Username,
                    _signupView.Password,
                    _signupView.FullName,
                    _signupView.Gender,
                    _signupView.Email,
                    _signupView.Phone,
                    _signupView.BOD,
                    _signupView.Address
                );

                if (signupSuccessful)
                {
                    var result = MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập", "Thông báo", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        var loginView = new LoginView(_connectionString);
                        loginView.Show();
                        _signupView.CloseForm();
                    }
                }
                else
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đăng ký thất bại! Vui lòng liên hệ nhà cung cấp\n {ex.Message}", "Cảnh báo");
            }
        }

        private string ValidateSignupInputs()
        {
            
            if (string.IsNullOrWhiteSpace(_signupView.Username))
            {
                return "Vui lòng nhập tên đăng nhập!";
            }

            if (string.IsNullOrWhiteSpace(_signupView.Password))
            {
                return "Vui lòng nhập mật khẩu!";
            }

            if (!Validator.IsStrongPassword(_signupView.Password))
            {
                return "Mật khẩu phải từ 8 kí tự trở lên và chứa tối thiểu 1 kí tự số, kí tự đặc biệt, in hoa!";
            }

            if (string.IsNullOrWhiteSpace(_signupView.FullName))
            {
                return "Vui lòng nhập họ và tên!";
            }

            if (_signupView.FullName.Length > 20)
            {
                return "Vui lòng viết gọn họ và tên!";
            }

            if (string.IsNullOrWhiteSpace(_signupView.Email) || !Validator.IsValidEmail(_signupView.Email))
            {
                return "Vui lòng nhập địa chỉ email hợp lệ!";
            }

            if (_signupView.BOD > DateTime.Now)
            {
                return "Ngày sinh không được vượt quá thời điểm hiện tại!";
            }

            if (string.IsNullOrWhiteSpace(_signupView.Phone) || !Validator.IsValidPhoneNumber(_signupView.Phone))
            {
                return "Vui lòng nhập số điện thoại hợp lệ!";
            }

            return null;
        }

    }
}
