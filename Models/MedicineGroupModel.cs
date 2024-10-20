using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Models
{
    public class MedicineGroupModel
    {
        private string group_code;
        private string group_name;
        private string description;

       
        public string GroupCode { get => group_code; set => group_code = value; }
        
        public string GroupName { get => group_name; set => group_name = value; }
        
        public string Description { get => description; set => description = value; }
    }
}
