using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Views.LoginForm
{
    public interface ILoginView
    {
        string Username { get; set; }
        string Password { get; set; }

        event EventHandler Login;
        event EventHandler NavigateToSignupPage;

        void CloseForm();  
    }
}
