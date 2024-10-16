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
namespace PharmacySystem.Presenters
{
    public class SignupPresenter
    {
        private readonly string _connectionString;

        private ISignupView _signupView;
        private UserRepository _userRepository;
        private AuthService _authService;

        public SignupPresenter(ISignupView signupView, string connectionString)
        {
            
            _signupView = signupView;
            _connectionString = connectionString;
            _signupView.Signup += OnSignup;

            _userRepository = new UserRepository(_connectionString);
            _authService = new AuthService(_userRepository);
            
        }

        private void OnSignup(object sender, EventArgs e)
        {
            bool signupSuccessfull = _authService.Signup(_signupView.Username, _signupView.Password, _signupView.FullName);
            if (signupSuccessfull)
            {
                MessageBox.Show("Đăng ký thành công!", "Thông báo");

            }
            else
            {
                MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo");
            }
        }
    }
}
