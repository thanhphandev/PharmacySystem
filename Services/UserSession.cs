using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Services
{
    public static class UserSession
    {
        public static int UserId { get; set;  }
        public static string Username { get; set;  }
        public static string FullName { get; set; }
        public static int BirthYear { get; set;  }
        public static string Role { get; set;  }
        public static DateTime LoginTime { get; set; }
    }
}
