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

        event EventHandler Logout;
        event EventHandler ShowDashboard;
        void LoadUserData();
        void LoadMedicineData(List<MedicineProductModel> medicineInfo);
        void LoadMedicineGroups(List<MedicineGroupModel> medicineGroups);
        List<MedicineProductModel> GetCartItems();
        void CloseForm();
    }
}
