using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Repositories.MedicineInfoRepository
{
    public interface IMedicineInfoRepository
    {
        void AddMedicineInfo(MedicineInfoModel medicineInfo);
        void DeleteMedicineInfo(int medicineId);
        void UpdateMedicineInfo(string medicineCode, MedicineInfoModel medicineInfo);
        List<MedicineInfoModel> GetMedicinesByGroupCode(string groupCode);
        List<MedicineInfoModel> GetAllMedicineInfo();
        List<string> GetAllMedicineName();
        MedicineInfoModel GetMedicineInfoByMedicineName(string medicineName);
    }
}
