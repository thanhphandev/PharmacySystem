using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Models
{
    public class MedicineQuantityModel
    {
        private int id;
        private int medicineId; // reference to MedicineModel.Id
        private int quantity;

        public int Id { get => id; set => id = value; }
        public int MedicineId { get => medicineId; set => medicineId = value; }
        public int Quantity { get => quantity; set => quantity = value; }
    }
}
