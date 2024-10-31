using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Models
{
    public class RoleCountModel
    {
        private string role;
        private int count;

        public string Role { get => role; set => role = value; }
        public int Count { get => count; set => count = value; }
    }
}
