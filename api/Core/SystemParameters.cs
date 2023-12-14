using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class SystemParameters
    {
        public struct DateFormat
        {
            public const string YYYYMMDD = "yyyy-MM-dd";
            public const string YYYYMMDDHHMMSS = "yyyy-MM-dd HH:mm:ss";
        }

        public struct ConnectionString
        {
            public const string TourBookingContext = "TourBookingContext";
        }
    }
}
