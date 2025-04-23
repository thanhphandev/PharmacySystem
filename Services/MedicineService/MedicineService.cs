using PharmacySystem.Models;
using PharmacySystem.Repositories.MedicineRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Services.MedicineService
{
    public class MedicineService
    {
        private readonly IMedicineBatchRepository _medicineRepository;

        public MedicineService(string connectionString)
        {
            _medicineRepository = new MedicineBatchRepository(connectionString);
        }

        public int AddMedicine(MedicineBatch medicine)
        {
            try
            {
                int medicineId = _medicineRepository.AddMedicineBatch(medicine);
                return medicineId;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteMedicine(int id)
        {
            try
            {
                _medicineRepository.DeleteMedicineBatch(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MedicineProductModel> GetAllMedicineProduct()
        {
            try
            {
                return _medicineRepository.GetAllMedicineProduct();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MedicineProductModel> GetMedicineProductsByGroupCode(string groupCode)
        {
            try
            {
                return _medicineRepository.GetMedicineProductsByGroupCode(groupCode);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<MedicineProductModel> GetMedicineProductsByNameAndGroup(string searchText, string groupCode)
        {
            try
            {
                var medicineProducts = _medicineRepository.GetMedicineProductsByNameAndGroup(searchText, groupCode);
                return medicineProducts;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        // unused
        public void AddMedicineQuantity(int medicineId, int quantity)
        {
            try
            {
                _medicineRepository.AddMedicineQuantity(medicineId, quantity);
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
                _medicineRepository.UpdateMedicineQuantity(medicineId, quantity);
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
                int currentQuantity = _medicineRepository.GetCurrentQuantity(medicineId);
                if (soldQuantity > currentQuantity)
                    throw new InvalidOperationException("Insufficient quantity in stock.");

                _medicineRepository.UpdateMedicineQuantity(medicineId, currentQuantity - soldQuantity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
