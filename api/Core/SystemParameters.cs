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
            public const string DDMMYYYY = "dd-MM-yyyy";
            public const string DDMMYYYYHHMMSS = "dd-MM-yyyy HH:mm:ss";
        }

        public struct ConnectionString
        {
            public const string TourBookingContext = "TourBookingContext";
        }
    }
}
