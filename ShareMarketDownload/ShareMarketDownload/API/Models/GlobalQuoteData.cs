using System;

namespace ShareWatch.API.Models
{
    public class GlobalQuoteData : QuoteBaseData
    {
        public DateTime LatestTrading { get; set; } = DateTime.MinValue;
        public decimal PreviousClose { get; set; } = 0;
        public decimal Change { get; set; } = 0;
        public decimal ChangePercent { get; set; } = 0;
    }
}
