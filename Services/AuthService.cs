using Org.BouncyCastle.Crypto.Generators;
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

        public UserModel CheckAccountExist(string username)
        {
            var user = _userRepository.GetUserByUsername(username);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public bool Signup(string username, string password, string fullname, string birthYear)
        {
            var existingUser = CheckAccountExist(username);
            if (existingUser != null)
            {
                return false;
            }

            var user = new UserModel
            {
                Username = username,
                Password = HashPassword(password),
                FullName = fullname,
                Birth_year = Convert.ToInt32(birthYear)
            };

            _userRepository.AddUser(user);
            return true;
        }

        public bool Login(string username, string password)
        {
            var user  = CheckAccountExist(username);
            if (user == null)
            {
                return false;
            }

            bool isCorrectPassword = VerifyPassword(password, user.Password);
            if (isCorrectPassword) {
                UserSession.UserId = user.UserId;
                UserSession.Username = user.Username;
                UserSession.FullName = user.FullName;
                UserSession.BirthYear = user.Birth_year;
                UserSession.Role = user.Role;
                UserSession.LoginTime = DateTime.Now;

            }
            

            return isCorrectPassword;
        }


        private string HashPassword(string password)
        {
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            return hashedPassword;
        }

        public bool VerifyPassword(string enteredPassword, string storedHashedPassword)
        {

            bool isVerified = BCrypt.Net.BCrypt.Verify(enteredPassword, storedHashedPassword);
            return isVerified;
        }

    }
}
