using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Views.MedicinesForm
{
    public interface IAddMedicineForm
    {
        bool IsEditMode { get; set; }
        string LabelHeader { get; set; }

        string MedicineCode { get; set; }
        string MedicineName { get; set; }
        int UnitType { get; set; }
        decimal MedicinePrice { get; set; }
        string MedicineImage { get; set; }
        string MedicineContent { get; set; }
        string MedicineElement { get; set; }
        string GroupCode { get; set; }

        DateTime ExpireDate { get; set; }
        
        int SupplierId { get; set; }
        
        int Quantity { get; set; }

        
        void SetAutoCompleteNameData(List<string> medicineName);
        void LoadMedicineGroups(List<MedicineGroupModel> medicineGroups);
        void LoadUnitTypes(List<UnitTypeModel> unitTypes);
        void LoadSuppliers(List<SupplierModel> suppliers);
        void CloseForm();
        event EventHandler LeaveTextBoxName;
        event EventHandler AddMedicine;
        event EventHandler UpdateMedicine;
    }
}
