using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Views.SuppliersForm
{
    public interface ISuppliersView
    {
        string TextSearch { get; set; }
        void DisplaySuppliers(List<SupplierModel> suppliers);
        SupplierModel GetSelectedSupplier();

        event EventHandler AddData;
        event EventHandler RefreshData;
        event EventHandler UpdateData;
        event EventHandler DeleteData;
    }
}
