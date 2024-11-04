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
        event EventHandler Logout;
        event EventHandler ShowDashboard;
        void LoadUserData();
        void LoadMedicineData(List<MedicineInfoModel> medicineInfo);
        void LoadMedicineGroups(List<MedicineGroupModel> medicineGroups);
        List<(string MedicineCode, int Quantity)> GetCartItems();
        void CloseForm();
    }
}
