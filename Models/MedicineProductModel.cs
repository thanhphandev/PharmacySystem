using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Models
{
    public class MedicineProductModel
    {
        private string medicineCode;
        private string medicineName;
        private string medicineUnit;
        private decimal price;
        private int quantity;
        private string imageUrl;

        public string MedicineCode { get => medicineCode; set => medicineCode = value; }
        public string MedicineName { get => medicineName; set => medicineName = value; }
        public decimal Price { get => price; set => price = value; }
        public string MedicineUnit { get => medicineUnit; set => medicineUnit = value; }
        public int Quantity { get => quantity; set => quantity = value; }
        public string ImageUrl { get => imageUrl; set => imageUrl = value; }
    }
}
