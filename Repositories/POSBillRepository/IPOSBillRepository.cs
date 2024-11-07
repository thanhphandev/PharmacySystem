using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Repositories.POSBillRepository
{
    public interface IPOSBillRepository
    {
        void AddPosBill(decimal receiveAmount, int employeeId);
        List<POSBillReport> GetFinancialReport(DateTime fromDate, DateTime toDate);
    }
}
