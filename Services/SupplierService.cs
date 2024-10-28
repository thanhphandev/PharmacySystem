using PharmacySystem.Models;
using PharmacySystem.Repositories.SupplierRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Services
{
    public class SupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        public SupplierService(string connectionString)
        {
            _supplierRepository = new SupplierRepository(connectionString);
        }

        public bool AddSupplier(SupplierModel supplier)
        {
            try
            {
                _supplierRepository.AddSupplier(supplier);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        public bool DeleteSupplier(int id)
        {
            try
            {
                _supplierRepository.DeleteSupplier(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool UpdateSupplier(int id, SupplierModel supplier)
        {
            try
            {
                _supplierRepository.UpdateSupplier(id, supplier);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<SupplierModel> GetAllSuppliers()
        {
            try
            {
                var suppliers = _supplierRepository.GetAllSuppliers();
                return suppliers;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
