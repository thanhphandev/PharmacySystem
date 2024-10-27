using PharmacySystem.Models;
using PharmacySystem.Repositories.MedicineGroupRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Services
{
    public class MedicineGroupService
    {
        private readonly string _connectionString;
        private readonly IMedicineGroupRepository _medicineGroup;

        public MedicineGroupService(string connectionString) 
        {
            _connectionString = connectionString;
            _medicineGroup = new MedicineGroupRepository(_connectionString);
        }

        public bool AddMedicineGroup(MedicineGroupModel medicineGroup)
        {
            
            var existGroup = CheckGroupExist(medicineGroup.GroupCode);
            if (existGroup != null)
            {
                return false;
            }

            _medicineGroup.AddMedicineGroup(medicineGroup);
            return true;
        }

        public bool UpdateMedicineGroup(string oldGroupCode, MedicineGroupModel updatedMedicineGroup)
        {
            
            _medicineGroup.UpdateMedicineGroup(oldGroupCode, updatedMedicineGroup);
            return true;
        }

        public List<MedicineGroupModel> GetAllMedicineGroups()
        {
            List<MedicineGroupModel>  medicineGroups = _medicineGroup.GetAllMedicineGroups();
            return medicineGroups;
        }

        public void DeleteMedicineGroup(string groupCode)
        {
            _medicineGroup.DeleteMedicineGroup(groupCode);
        }


        public MedicineGroupModel CheckGroupExist(string code)
        {
            var medicineGroup = _medicineGroup.GetMedicineGroupByCode(code);
            if (medicineGroup == null)
            {
                return null;
            }
            return medicineGroup;
        }

    }
}
