using PharmacySystem.Models;
using PharmacySystem.Repositories.MedicineInfoRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Services.MedicineService
{
    public class MedicineInfoService
    {
        private IMedicineInfoRepository _medicineRepository;
        public MedicineInfoService(string connectionString)
        {
            _medicineRepository = new MedicineInfoRepository(connectionString);
        }
        public bool AddMedicineInfo(MedicineInfoModel medicineInfo)
        {
            try
            {
                _medicineRepository.AddMedicineInfo(medicineInfo);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool DeleteMedicineInfo(int medicineId)
        {
            try
            {
                _medicineRepository.DeleteMedicineInfo(medicineId);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateMedicineInfo(string medicineCode, MedicineInfoModel medicineInfo)
        {
            try
            {
                _medicineRepository.UpdateMedicineInfo(medicineCode, medicineInfo);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public MedicineInfoModel GetMedicineInfoByMedicineCode(string medicineCode)
        {
            try
            {
                var medicine = _medicineRepository.GetMedicineInfoByMedicineCode(medicineCode);
                return medicine;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MedicineInfoModel> GetAllMedicineInfo()
        {
            try
            {
                var medicines = _medicineRepository.GetAllMedicineInfo();
                return medicines;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
