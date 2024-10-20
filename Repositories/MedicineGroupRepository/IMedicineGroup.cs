using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Repositories.MedicineGroupRepository
{
    public interface IMedicineGroup
    {
        MedicineGroupModel GetMedicineGroupByCode(string code);
        List<MedicineGroupModel> GetAllMedicineGroups();
        void AddMedicineGroup(MedicineGroupModel medicineGroup);
        void UpdateMedicineGroup(string oldGroupCode, MedicineGroupModel updatedMedicineGroup);
        void DeleteMedicineGroup(string code);
    }
}
