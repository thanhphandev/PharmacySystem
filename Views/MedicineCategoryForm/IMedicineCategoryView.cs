﻿using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Views.MedicineCategoryForm
{
    public interface IMedicineCategoryView
    {
        void DisplayMedicineGroups(List<MedicineGroupModel> medicineGroups);
        void UpdateIndexColumn();
        MedicineGroupModel GetSelectedMedicineGroup();

        event EventHandler AddData;
        
        event EventHandler UpdateData;
        event EventHandler DeleteData;
    }
}
