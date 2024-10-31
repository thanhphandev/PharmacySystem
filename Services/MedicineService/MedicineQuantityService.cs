using PharmacySystem.Repositories.MedicineQuantityRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Services.MedicineService
{
    class MedicineQuantityService
    {
        private readonly IMedicineQuantityRepository _medicineQuantityRepository;
        public MedicineQuantityService(string connectionString)
        {
            _medicineQuantityRepository = new MedicineQuantityRepository(connectionString);
        }

        public void AddMedicineQuantity(int medicineId, int quantity)
        {
            try
            {
                _medicineQuantityRepository.AddMedicineQuantity(medicineId, quantity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateMedicineQuantity(int medicineId, int quantity)
        {
            try
            {
                _medicineQuantityRepository.UpdateMedicineQuantity(medicineId, quantity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
