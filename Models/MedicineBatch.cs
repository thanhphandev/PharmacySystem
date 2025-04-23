using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Models
{
    public class MedicineBatch
    {
            public int ID { get; set; }
            public string MedicineCode { get; set; }
            public int SupplierID { get; set; }
            public DateTime ExpireDate { get; set; }
            public int Quantity { get; set; }
    }
}
