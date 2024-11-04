using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Views.UIComponents
{
    public interface IMedicineProduct
    {
        string MedicineCode { get; set; }
        string MedicineName { get; set; }
        decimal MedicinePrice { get; set; }
        string MedicineImage { get; set; }
        string UnitType { get; set; }
        int Quantity { get; set; }
        event EventHandler AddToCart;
    }
}
