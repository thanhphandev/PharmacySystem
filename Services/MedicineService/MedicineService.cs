﻿using PharmacySystem.Models;
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
        private readonly IMedicineRepository _medicineRepository;

        public MedicineService(string connectionString)
        {
            _medicineRepository = new MedicineRepository(connectionString);
        }

        public int AddMedicine(MedicineModel medicine)
        {
            try
            {
                int medicineId = _medicineRepository.AddMedicine(medicine);
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
                _medicineRepository.DeleteMedicine(id);
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
    }
}
