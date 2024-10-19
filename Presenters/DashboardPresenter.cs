﻿using PharmacySystem.Views.DashboardForm;
using PharmacySystem.Views.MainForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Presenters
{
    public class DashboardPresenter
    {
        private readonly IDashboard _dashboardView;
        private readonly string _connectionString;

        public DashboardPresenter(IDashboard dashboardView, string connectionString)
        {
            _dashboardView = dashboardView;
            _connectionString = connectionString;
            _dashboardView.ShowMainView += OnShowMainView;
        }

        private void OnShowMainView(object sender, EventArgs e)
        {
            MainView mainView = new MainView(_connectionString);
            mainView.Show();
            _dashboardView.CloseForm();
        }

        
    }
}