using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Views.SuppliersForm
{
    public interface IAddSupplierView
    {
        string LabelHeader { get; set; }
        string SupplierName { get; set; }
        string SupplierPhone { get; set; }
        string SupplierAddress { get; set; }
        bool IsEditMode { get; set; }

        void CloseForm();
        event EventHandler AddSupplier;
        event EventHandler UpdateSupplier;
    }
}
