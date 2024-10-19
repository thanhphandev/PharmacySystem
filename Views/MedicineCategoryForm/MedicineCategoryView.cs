﻿using PharmacySystem.Presenters;
using PharmacySystem.Views.DashboardForm.BaseForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Views.MedicineCategoryForm
{
    public partial class MedicineCategoryView : BaseManagementForm, IMedicineCategoryView
    {
        private readonly string _connectionString;
        public MedicineCategoryView(string connectionString)
        {
           
            InitializeComponent();
            _connectionString = connectionString;
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MedicineCategoryAddForm view = new MedicineCategoryAddForm(_connectionString);
            view.ShowDialog();
        }

        public void SetMedicineBindingSource(BindingSource medicineGroups)
        {
            MedicineGroupDataGrid.DataSource = medicineGroups;
        }
    }
}