using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Models
{
    public class MedicineModel
    {
        private int id;
        private DateTime expireDate;
        private string medicineCode;  // reference to MedicineInfoModel.MedicineCode
        private int supplierId; // reference to SupplierModel.SupplierId

        public int Id { get => id; set => id = value; }
        public DateTime ExpireDate { get => expireDate; set => expireDate = value; }
        public string MedicineCode { get => medicineCode; set => medicineCode = value; }
        public int SupplierId { get => supplierId; set => supplierId = value; }
    }
}
