﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using PharmacySystem.Views;
using PharmacySystem.Views.LoginForm;
using PharmacySystem.Presenters;
using PharmacySystem.Views.RegisterForm;
using System.IO;
using PharmacySystem.Common;

namespace PharmacySystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            string connectionString = ConfigurationManager.ConnectionStrings["PharmacyDb"].ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Connection string not found");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            ILoginView loginView = new LoginView(connectionString);
            Application.Run((Form) loginView);
        }
    }
}

