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
        private int birth_year;
        private string role;

        [DisplayName("ID")]
        public int UserId { get => userId; set => userId = value; }

        [DisplayName("Họ và tên")]
        public string FullName { get => fullname; set => fullname = value; }

        [DisplayName("Tên đăng nhập")]
        public string Username { get => username; set => username = value; }
        [DisplayName("Mật khẩu")]
        public string Password { get => password; set => password = value; }

        [DisplayName("Năm sinh")]
        public int Birth_year { get => birth_year; set => birth_year = value; }
        [DisplayName("Vai trò")]
        public string Role { get => role; set => role = value; }
    }

}
