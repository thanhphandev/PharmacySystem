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
        void DisplayEmployeeRoleChart(List<RoleCountModel> roleCounts);
    }
}
