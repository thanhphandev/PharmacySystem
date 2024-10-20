﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Views.LoginForm
{
    public interface ILoginView
    {
        string Username { get; set; }
        string Password { get; set; }

        event EventHandler Login;
        void CloseForm();
    }
}
