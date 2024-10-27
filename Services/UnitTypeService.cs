using PharmacySystem.Models;
using PharmacySystem.Repositories.UnitTypeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Services
{
   
    public class UnitTypeService
    {
        private readonly IUnitTypeRepository _unitTypeRepository;
        public UnitTypeService(string connectionString)
        {
            _unitTypeRepository = new UnitTypeRepository(connectionString);
        }

        public bool AddUnitType(string unitType)
        {
            _unitTypeRepository.AddUnitType(unitType);
            return true;
        }

        public bool DeleteUnitType(string unitType)
        {
            _unitTypeRepository.DeleteUnitType(unitType);
            return true;
        }

        public List<UnitTypeModel> GetAllUnitTypes()
        {
            var unitTypes = _unitTypeRepository.GetAllUnitTypes();
            return unitTypes;
        }
    }
}
