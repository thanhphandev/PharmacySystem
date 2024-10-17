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
        private string fullname;
        private string username;
        private string password;
        private int birth_year;
        private string role;

        [DisplayName("Họ và tên")]
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Họ và tên phải từ 5 đến 50 ký tự")]
        public string FullName { get => fullname; set => fullname = value; }

        [Required(ErrorMessage = "Username không được bỏ trống!")]
        public string Username { get => username; set => username = value; }
        [Required(ErrorMessage = "Mật khẩu không được bỏ trống")]
        public string Password { get => password; set => password = value; }

        [Required(ErrorMessage = "Năm sinh không được bỏ trống")]
        [Range(1900, 2100, ErrorMessage = "Năm sinh không hợp lệ")]
        public int Birth_year { get => birth_year; set => birth_year = value; }
        
        public string Role { get => role; set => role = value; }
    }

}
