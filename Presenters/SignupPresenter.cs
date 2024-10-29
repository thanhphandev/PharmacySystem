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
        private readonly AuthService _authService;

        public SignupPresenter(ISignupView signupView, string connectionString)
        {
            
            _signupView = signupView;
            _connectionString = connectionString;
            _authService = new AuthService(_connectionString);

            _signupView.Signup += async(sender, args) => await OnSignup();
    
        }

        private async Task OnSignup()
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

            if (string.IsNullOrWhiteSpace(_signupView.Email) || !IsValidEmail(_signupView.Email))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ email hợp lệ!", "Thông báo");
                return;
            }

            if (_signupView.BOD > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không được vượt quá thời điểm hiện tại!", "Thông báo");
                return;
            }

            if (string.IsNullOrWhiteSpace(_signupView.Phone) || !IsValidPhoneNumber(_signupView.Phone))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại hợp lệ!", "Thông báo");
                return;
            }

            try
            {
               
                bool signupSuccessfull = await _authService.Signup(_signupView.Username,
                                                             _signupView.Password,
                                                             _signupView.FullName,
                                                             _signupView.Gender,
                                                             _signupView.Email,
                                                             _signupView.Phone,
                                                             _signupView.BOD,
                                                             _signupView.Address
                                                             );
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

        
    private bool IsValidEmail(string email)
        {
            try
            {
                var mail = new System.Net.Mail.MailAddress(email);
                return mail.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
           
            var cleaned = new string(phoneNumber.Where(char.IsDigit).ToArray());
            return cleaned.Length >= 10 && cleaned.Length <= 15;
        }

    }
}
