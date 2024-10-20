using PharmacySystem.Models;
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
        string TextSearch { get; set; }
        void DisplayMedicineGroups(List<MedicineGroupModel> medicineGroups);
        MedicineGroupModel GetSelectedMedicineGroup();

        event EventHandler AddData;
        event EventHandler RefreshData;
        
        
        event EventHandler UpdateData;
        event EventHandler DeleteData;
    }
}
