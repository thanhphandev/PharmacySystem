using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Repositories.SupplierRepository
{
    public interface ISupplierRepository
    {
        void AddSupplier(SupplierModel supplier);
        void DeleteSupplier(int id);
        List<SupplierModel> GetAllSuppliers();
        void UpdateSupplier(int id, SupplierModel supplier);
    }
}
