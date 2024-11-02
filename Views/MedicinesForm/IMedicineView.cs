using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Views.MedicinesForm
{
    public interface IMedicineView
    {
        string SearchText { get; set; }
        void DisplayMedicines(List<MedicineModel> medicines);
        MedicineModel GetSelectedMedicine();

        event EventHandler AddData;
        event EventHandler UpdateData;
        event EventHandler DeleteData;
        event EventHandler RefreshData;
    }
}
