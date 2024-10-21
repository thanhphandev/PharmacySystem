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
namespace PharmacySystem.Presenters
{
    public class SignupPresenter
    {
        private readonly string _connectionString;

        private readonly ISignupView _signupView;
        private readonly UserRepository _userRepository;
        private readonly AuthService _authService;

        public SignupPresenter(ISignupView signupView, string connectionString)
        {
            
            _signupView = signupView;
            _connectionString = connectionString;
            _authService = new AuthService(_connectionString);

            _signupView.Signup += OnSignup;
    
        }

        private void OnSignup(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(_signupView.Username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông báo");
                return;
            }

            if (string.IsNullOrWhiteSpace(_signupView.Password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo");
                return;
            }
            
            if (string.IsNullOrWhiteSpace(_signupView.FullName))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu!", "Thông báo");
                return;
            }

            if (_signupView.FullName.Length > 20)
            {
                MessageBox.Show("Vui lòng viết gọn họ và tên!", "Thông báo");
                return;
            }


            if (!IsStrongPassword(_signupView.Password))
            {
                MessageBox.Show("Mật khẩu phải từ 8 kí tự trở lên và chứa tối thiểu 1 kí tự số, kí tự đặc biệt, in hoa!", "Thông báo");
                return;
            }

            if (!int.TryParse(_signupView.BirthYear, out int birthYear) || birthYear < 1900 || birthYear > DateTime.Now.Year)
            {
                MessageBox.Show("Năm sinh không hợp lệ! Vui lòng nhập số hợp lệ.", "Thông báo");
                return;
            }


            try
            {
               
                bool signupSuccessfull = _authService.Signup(_signupView.Username,
                                                             _signupView.Password,
                                                             _signupView.FullName, 
                                                             _signupView.BirthYear);
                if (signupSuccessfull)
                {
                    var result = MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập", "Thông báo", MessageBoxButtons.OK);
                    if (result == DialogResult.OK)
                    {
                        LoginView loginView = new LoginView(_connectionString);
                        loginView.Show();
                        _signupView.CloseForm();
                    }

                }
                else
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo");
                }
            
            } catch(Exception ex)
            {
                MessageBox.Show($"Đăng ký thất bại! Vui lòng liên hệ nhà cung cấp\n {ex.Message}", "Cảnh báo");
            }
            
        }

        private bool IsStrongPassword(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }

            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));

            return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
        }

    }
}
