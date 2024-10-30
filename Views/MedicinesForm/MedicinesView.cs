using PharmacySystem.Views.DashboardForm.BaseForm;
using PharmacySystem.Views.UnitTypeForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Views.MedicinesForm
{
    public partial class MedicinesView : BaseManagementForm
    {
        private readonly string _connectionString;
        public MedicinesView(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
        }

        private void btnAddUnitType_Click(object sender, EventArgs e)
        {
            UnitTypeView view = new UnitTypeView(_connectionString);
            view.ShowDialog();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddMedicineForm view = new AddMedicineForm();
            view.ShowDialog();
        }
    }
}
