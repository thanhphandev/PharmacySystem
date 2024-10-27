using PharmacySystem.Presenters;
using PharmacySystem.Repositories.MedicineGroupRepository;
using PharmacySystem.Services;
using PharmacySystem.Views.MainForm;
using PharmacySystem.Views.MedicineCategoryForm;
using PharmacySystem.Views.MedicinesForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Views.DashboardForm
{
    public partial class DashboardView : Form, IDashboard
    {
        private readonly string _connectionString;
        public event EventHandler ShowMainView;

        public DashboardView(string connectionString)
        {
            InitializeComponent();
            new DashboardPresenter(this, connectionString);
            _connectionString = connectionString;
            LoadUserData();
            DisplayFunctionBaseRole();
           
        }


        private void DisplayFunctionBaseRole()
        {
           
            List<Control> allControls = new List<Control>
            {
                btnDashboard,
                btnCategory,
                btnMedicine,
                btnEmployees,
                btnProvider,
                btnReport
            };

            flowLayoutPanel.Controls.Clear();
            foreach (var control in allControls)
            {
                if (UserSession.Role == "seller")
                {
                   
                    if (control == btnDashboard)
                    {
                        flowLayoutPanel.Controls.Add(control);
                    }
                    if (control == btnReport)
                    {
                        flowLayoutPanel.Controls.Add(control);
                    }
                }
                else
                {
                    flowLayoutPanel.Controls.Add(control);
                }
            }
        }



        private void LoadUserData()
        {
            lbuser.Text = $"Xin chào, {UserSession.FullName}\nBạn đang đăng nhập với vai trò là {UserSession.Role}";
            HomeUI homeUI = new HomeUI();
            AddControls(homeUI);
        }

        public void CloseForm()
        {
            this.Hide();
        }

        public void AddControls(Form form)
        {
            ControlsPanel.Controls.Clear();
            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            ControlsPanel.Controls.Add(form);
            form.Show();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
            MainView mainView = new MainView(_connectionString);
            mainView.Show();
            CloseForm();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            HomeUI homeUI = new HomeUI();
            AddControls(homeUI);
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            MedicineCategoryView view = new MedicineCategoryView(_connectionString);
            AddControls(view);
        }

        private void btnMedicine_Click(object sender, EventArgs e)
        {
            MedicinesView view = new MedicinesView(_connectionString);
            AddControls(view);
        }
    }
}
