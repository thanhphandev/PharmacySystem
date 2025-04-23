using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Repositories.MedicineRepository
{
    public interface IMedicineBatchRepository
    {
        int AddMedicineBatch(MedicineBatch medicine);
        void DeleteMedicineBatch(int id);
        int GetMedicineIdByEarliestExpiry(string medicineCode);
        List<MedicineProductModel> GetAllMedicineProduct(); //fix
        List<MedicineProductModel> GetMedicineProductsByGroupCode(string groupCode); //fix
        List<MedicineProductModel> GetMedicineProductsByNameAndGroup(string searchText, string groupCode); //fix
        void AddMedicineQuantity(int medicineId, int quantity);
        void UpdateMedicineQuantity(int medicineId, int quantity);
        int GetCurrentQuantity(int medicineId);

    }
}
