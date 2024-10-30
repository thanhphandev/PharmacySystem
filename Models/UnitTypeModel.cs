using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Models
{
    public class UnitTypeModel
    {
        private int id;
        private string name;
        public int Id { get => id; set => id = value; }
        public string UnitType { get => name; set => name = value; }
    }
}
