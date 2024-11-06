using PharmacySystem.Repositories.MedicineQuantityRepository;
using PharmacySystem.Repositories.MedicineRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmacySystem.Services.MedicineService
{
    class MedicineQuantityService
    {
        private readonly IMedicineQuantityRepository _medicineQuantityRepository;

        private readonly IMedicineRepository _medicineRepository;
        public MedicineQuantityService(string connectionString)
        {
            _medicineQuantityRepository = new MedicineQuantityRepository(connectionString);
            _medicineRepository = new MedicineRepository(connectionString);
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

        public void UpdateQuantityByNearestExpiry(string medicineCode, int soldQuantity)
        {
            if (soldQuantity <= 0)
                throw new ArgumentException("Sold quantity must be a positive integer.", nameof(soldQuantity));

            try
            {
                int medicineId = _medicineRepository.GetMedicineIdByEarliestExpiry(medicineCode);
                int currentQuantity = _medicineQuantityRepository.GetCurrentQuantity(medicineId);
                if (soldQuantity > currentQuantity)
                    throw new InvalidOperationException("Insufficient quantity in stock.");

                _medicineQuantityRepository.UpdateMedicineQuantity(medicineId, currentQuantity - soldQuantity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
