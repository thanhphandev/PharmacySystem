using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace PharmacySystem.Models
{
    public class UserModel
    {
        private int userId;
        private string fullname;
        private string username;
        private string password;
        private string email;
        private string phone;
        private string address;
        private string gender;
        private DateTime bod;
        private string role;
        
        public int UserId { get => userId; set => userId = value; }
        public string FullName { get => fullname; set => fullname = value; }
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }
        public DateTime BoD { get => bod; set => bod = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Address { get => address; set => address = value; }
        public string Gender { get => gender; set => gender = value; }
        public string Role { get => role; set => role = value; }
       
    }

}
