using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Models
{
    public class POSBillModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal ReceivedAmount { get; set; }
        public int EmployeeId { get; set; }
    }
}
