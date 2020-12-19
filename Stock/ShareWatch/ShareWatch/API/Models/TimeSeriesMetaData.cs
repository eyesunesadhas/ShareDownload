using System;

namespace ShareWatch.API.Models
{
    public class TimeSeriesMetaData
    {
        public string Information { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public DateTime LastRefreshed { get; set; } = DateTime.MinValue;
        public string Interval { get; set; } = string.Empty;
        public string OutputSize { get; set; } = string.Empty;
        public string TimeZone { get; set; } = string.Empty;
    }
}
