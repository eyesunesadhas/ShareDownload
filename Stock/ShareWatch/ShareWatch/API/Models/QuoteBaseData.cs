namespace ShareWatch.API.Models
{
    public class QuoteBaseData
    {
        public string Symbol { get; set; } = string.Empty;
        public decimal Open { get; set; } = 0;
        public decimal High { get; set; } = 0;
        public decimal Low { get; set; } = 0;
        public decimal Current { get; set; } = 0;
        public decimal Close { get; set; } = 0;
        public long Volume { get; set; } = 0;
    }
}
