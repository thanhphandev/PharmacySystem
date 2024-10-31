using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Models
{
    public class MedicineInfoModel
    {
        private string medicineCode;
        private string medicineName;
        private int unitType;
        private decimal medicinePrice;
        private string medicineImage;
        private string medicineContent;
        private string medicineElement;
        private string groupCode;

        public string MedicineCode { get => medicineCode; set => medicineCode = value; }
        public string MedicineName { get => medicineName; set => medicineName = value; }
        public int UnitType { get => unitType; set => unitType = value; }
        public decimal MedicinePrice { get => medicinePrice; set => medicinePrice = value; }
        public string MedicineImage { get => medicineImage; set => medicineImage = value; }
        public string MedicineContent { get => medicineContent; set => medicineContent = value; }
        public string MedicineElement { get => medicineElement; set => medicineElement = value; }
        public string GroupCode { get => groupCode; set => groupCode = value; }
    }
}
