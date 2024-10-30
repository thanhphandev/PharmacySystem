using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Views.MedicineCategoryForm
{
    public interface IMedicineGroupAddForm
    {
        string LabelHeader { get; set; }
        string OldGroupCode { get; set; }
        string GroupCode { get; set; }
        string GroupName { get; set; }
        bool IsEditMode { get; set; }
        string Content { get; set; }

        void CloseForm();
        event EventHandler AddMedicineGroup;
        event EventHandler UpdateMedicineGroup;
       
    }
}
