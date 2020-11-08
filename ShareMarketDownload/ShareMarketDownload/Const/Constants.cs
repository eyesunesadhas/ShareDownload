using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareMarketDownload.Const
{
    public partial class Constants
    {
        /* HTTP STATUS */
        public const int SERVICE_STATUS_SUCCESS = 200;
        public const int SERVICE_STATUS_UNAUTHORIZED = 401;
        public const int SERVICE_STATUS_FAIL = 500;

        public const string NO_INDC = "N";
        public const string YES_INDC = "Y";

        #region Null Value Constants
        public const int NULL_COUNTY_VALUE = 0;
        public const decimal NULL_DECIMAL = decimal.MinValue / 4;
        public const double NULL_DOUBLE = double.MinValue / 4;
        public const float NULL_FLOAT = float.MinValue;
        public const int NULL_INT = int.MinValue;
        public const long NULL_LONG = long.MinValue;
        public const string NULL_TIME = "12:00 AM";
        public const ulong NULL_ULONG = ulong.MinValue;
        public static DateTime NULL_DATE = DateTime.Parse("03/03/0003");
        public static DateTime MIN_DATE = DateTime.MinValue;
        public static DateTime MAX_DATE = DateTime.MaxValue.Date;
        #endregion Null Value Constants
    }
}
