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
        public string CustomerPhone { get; set; }
        public decimal ReceivedAmount { get; set; }
        public decimal TotalAmount { get; set; }
        public int EmployeeId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
