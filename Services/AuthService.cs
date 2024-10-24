using Org.BouncyCastle.Crypto.Generators;
using PharmacySystem.Models;
using PharmacySystem.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Services
{
    public class AuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(string connectionString)
        {
            _userRepository = new UserRepository(connectionString);

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

        public bool Signup(string username, string password, string fullname, string gender, string email, string phone, DateTime BoD, string address)
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
                Gender = gender,
                Email = email,
                Address = address,
                Phone = phone,
                BoD = BoD,
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
            if(!isCorrectPassword)
            {
                return false;
            }
            UserSession.UserId = user.UserId;
            UserSession.Username = user.Username;
            UserSession.FullName = user.FullName;
            UserSession.Gender = user.Gender;
            UserSession.Email = user.Email;
            UserSession.Phone = user.Phone;
            UserSession.Address = user.Address;
            UserSession.BOD = user.BoD;
            UserSession.Role = user.Role;
            UserSession.LoginTime = DateTime.Now;

            return true;
        }

        public void Logout()
        {
            UserSession.UserId = 0;
            UserSession.Username = string.Empty;
            UserSession.FullName = string.Empty;
            UserSession.Gender = string.Empty;
            UserSession.Email = string.Empty;
            UserSession.Phone = string.Empty;
            UserSession.Address = string.Empty;
            UserSession.BOD = DateTime.MinValue;
            UserSession.Role = string.Empty;
            UserSession.LoginTime = DateTime.MinValue;
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
