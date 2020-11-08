using System;

namespace ShareWatch.API.Models
{
    public class TimeSeriesData : QuoteBaseData
    {
        public DateTime MarketTime { get; set; } = DateTime.MinValue;
    }
}
