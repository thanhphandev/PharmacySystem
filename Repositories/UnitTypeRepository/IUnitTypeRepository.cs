using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Repositories.UnitTypeRepository
{
    internal interface IUnitTypeRepository
    {
        void AddUnitType(string unitType);
        void DeleteUnitType(string unitType);
        List<UnitTypeModel> GetAllUnitTypes();
    }
}
