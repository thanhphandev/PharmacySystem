using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Views.MainForm
{
    public interface IMainView
    {
        decimal TotalAmount { get; set; }
        decimal GrandTotal { get; set; }
        string TextSearch { get; set; }
        string MedicineGroup { get; set; }

        event EventHandler Logout;
        event EventHandler ShowDashboard;
        event EventHandler SearchMedicinesByNameAndGroup;
        event EventHandler PurchaseMedicine;

        void LoadUserData();
        void ClearCartItems();
        void LoadMedicineData(List<MedicineProductModel> medicineInfo);
        void LoadMedicineGroups(List<MedicineGroupModel> medicineGroups);
        List<MedicineProductModel> GetCartItems();
        void CloseForm();
    }
}
