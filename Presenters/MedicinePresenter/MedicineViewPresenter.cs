using PharmacySystem.Views.MedicinesForm;
using PharmacySystem.Views.UnitTypeForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Presenters.MedicinePresenter
{
    public class MedicineViewPresenter
    {
        private readonly IMedicineView _medicineView;
        private readonly string _connectionString;
        public MedicineViewPresenter(IMedicineView medicineView, string connectionString)
        {
            _medicineView = medicineView;
            _connectionString = connectionString;
            _medicineView.AddMedicineData += OnAddMedicineData;
            _medicineView.AddUnitType += OnAddUnitType;
        }

        private void OnAddUnitType(object sender, EventArgs e)
        {
            UnitTypeView view = new UnitTypeView(_connectionString);
            view.ShowDialog();
        }

        private void OnAddMedicineData(object sender, EventArgs e)
        {
            AddMedicineForm view = new AddMedicineForm(_connectionString);
            view.ShowDialog();
        }
    }
}
