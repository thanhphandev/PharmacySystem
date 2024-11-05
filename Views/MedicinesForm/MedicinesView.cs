using PharmacySystem.Models;
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
    public partial class MedicinesView : BaseManagementForm, IMedicineView
    {
        private readonly string _connectionString;
        public event EventHandler AddMedicineData;
        public event EventHandler AddUnitType;

        //public event EventHandler UpdateData;
        //public event EventHandler DeleteData;
        //public event EventHandler RefreshData;

        public MedicinesView(string connectionString)
        {
            InitializeComponent();
            _connectionString = connectionString;
            AssociateAndRaiseViewEvents();
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnAddUnitType.Click += delegate
            {
                AddUnitType?.Invoke(this, EventArgs.Empty);
            };
            btnAdd.Click += delegate
            {
                AddMedicineData?.Invoke(this, EventArgs.Empty);
            };
        }

        public string SearchText { get => txtSearch.Text; set => txtSearch.Text = value; }      

        public void DisplayMedicines(List<MedicineModel> medicines)
        {
           
        }

        public MedicineModel GetSelectedMedicine()
        {
            throw new NotImplementedException();
        }
    }
}
