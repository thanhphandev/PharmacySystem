using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Models
{
    public class MedicineInfoModel
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public int UnitTypeId { get; set; }
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string GroupCode { get; set; }
    }
}
