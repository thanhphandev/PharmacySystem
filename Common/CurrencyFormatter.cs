using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmacySystem.Common
{
    public class CurrencyFormatter
    {
        public static string FormatVND(decimal amount)
        {
            return amount.ToString("C0", CultureInfo.GetCultureInfo("vi-VN"));
        }
    }
}
