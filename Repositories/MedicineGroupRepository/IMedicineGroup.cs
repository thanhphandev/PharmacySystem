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
        IEnumerable<MedicineGroupModel> GetAllMedicineGroups();
        void AddMedicineGroup(MedicineGroupModel medicineGroup);
        void UpdateMedicineGroup(MedicineGroupModel medicineGroup);
        void DeleteMedicineGroup(string code);
    }
}
