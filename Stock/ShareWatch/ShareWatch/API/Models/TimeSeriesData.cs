using System;

namespace ShareWatch.API.Models
{
    public class TimeSeriesData : QuoteBaseData
    {
        public DateTime TradeDate { get; set; } = DateTime.MinValue;
    }
}
