using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Views.RegisterForm
{
    public interface ISignupView { 
    
        string FullName { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Gender { get; set; }
        string Email { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        DateTime BOD { get; set; }
        
        event EventHandler Signup;
        void CloseForm();
    }
}
