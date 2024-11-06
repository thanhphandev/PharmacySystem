using PharmacySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Repositories.MedicineQuantityRepository
{
    public interface IMedicineQuantityRepository
    {
        void AddMedicineQuantity(int medicineId, int quantity);
        void UpdateMedicineQuantity(int medicineId, int quantity);
        int GetCurrentQuantity(int medicineId);
    }
}
