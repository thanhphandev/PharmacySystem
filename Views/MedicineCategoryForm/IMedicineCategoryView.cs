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
        void SetMedicineBindingSource(BindingSource medicineGroups);
    }
}
