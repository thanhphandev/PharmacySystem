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
            //UserModel user = new UserModel
            //{
            //    Username = _signupView.Username,
            //    Password = _signupView.Password,
            //    FullName = _signupView.FullName,
            //    Birth_year = Convert.ToInt32(_signupView.BirthYear)
            //};

            try
            {
                //new Common.ModelDataValidation().Validate(user);
                bool signupSuccessfull = _authService.Signup(_signupView.Username,
                                                         _signupView.Password,
                                                         _signupView.FullName,
                                                         _signupView.BirthYear);
                if (signupSuccessfull)
                {
                    MessageBox.Show("Đăng ký thành công!", "Thông báo");

                }
                else
                {
                    MessageBox.Show("Tên đăng nhập đã tồn tại!", "Thông báo");
                }
            } catch(Exception ex)
            {
                MessageBox.Show($"Đăng ký thất bại do {ex.Message}");
            }
            
        }
    }
}
