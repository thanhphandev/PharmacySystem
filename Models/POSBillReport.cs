using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Models
{
    public class POSBillReport
    {
        private DateTime date;
        private decimal totalRevenue;
        private int totalBills;
        private decimal averageReceiveAmount;

        public DateTime Date { get => date; set => date = value; }
        public decimal TotalRevenue { get => totalRevenue; set => totalRevenue = value; }
        public int TotalBills { get => totalBills; set => totalBills = value; }
        public decimal AverageReceiveAmount { get => averageReceiveAmount; set => averageReceiveAmount = value; }
    }
}
