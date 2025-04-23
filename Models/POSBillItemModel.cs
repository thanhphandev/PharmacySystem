using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Models
{
    public class POSBillItemModel
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public int MedicineBatchId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
