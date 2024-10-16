using PharmacySystem.Models;
using PharmacySystem.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool Signup(string username, string password, string fullname)
        {
            var existingUser = _userRepository.GetUserByUsername(username);
            if (existingUser != null)
            {
                return false;
            }

            var user = new UserModel();
            user.Username = username;
            user.Password = HashPassword(password);
            user.FullName = fullname;
            _userRepository.AddUser(user);
            return true;
        }

        public bool Login(string username, string password)
        {
            var user = _userRepository.GetUserByUsername(username);
            // Kiểm tra xem user có tồn tại không
            if (user == null)
            {
                return false;
            }
            bool isCorrectPassword =  VerifyPassword(password, user.Password);

            return isCorrectPassword;
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {
            
            string hashedEnteredPassword = HashPassword(enteredPassword);
            return hashedEnteredPassword == storedHashedPassword;
        }

    }
}
