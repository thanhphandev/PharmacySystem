using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Views.DashboardForm
{
    public interface IHomeView
    {
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }
        void DisplayEmployeeRoleChart(List<RoleCountModel> roleCounts);
        void DisplayFinancialReport(List<POSBillReport> financialReport);
    }
}
