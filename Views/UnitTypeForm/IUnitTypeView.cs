using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Views.UnitTypeForm
{
    public interface IUnitTypeView
    {
        string UnitName { get; set; }
        string SelectedUnitType { get; set; }
        event EventHandler AddUnitType;
        event EventHandler DeleteUnitType;
        void LoadData(List<UnitTypeModel> unitTypes);
    }
}
