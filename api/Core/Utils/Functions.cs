using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Core.Utils
{
    public class Functions
    {
        public static string ParseDate(DateTime? date)
        {
            return date != null ? date.Value.ToString(SystemParameters.DateFormat.YYYYMMDD, CultureInfo.InvariantCulture) : string.Empty;
        }

        public static DateTime ParseDate(string date)
        {
            var isValidDate = DateTime.TryParseExact(date, SystemParameters.DateFormat.YYYYMMDD, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime resultDate);
            return isValidDate ? resultDate : DateTime.MinValue;
        }

        public static string ErrorMessageTemplate(string code, string message)
        {
            return $"({code}) {message}";
        }
    }
}
