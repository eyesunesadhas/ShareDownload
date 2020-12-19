
using ShareWatch.Const;
using System;

namespace ShareWatch.DataModel.Share.Shrm
{
    public class ShareMasterData : ShareKeyData
    {
        public string TradeName { get; set; } = string.Empty;
        public string RegionName { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public string TypeCode { get; set; } = string.Empty;
        public string ExchangeCode { get; set; } = string.Empty;
        public string SectorName { get; set; } = string.Empty;
        public string CurrencyCode { get; set; } = string.Empty;
        public string IndustryName { get; set; } = string.Empty;
        public long FTEmployeesCount { get; set; } = 0;
        public DateTime LatestQuarterDate { get; set; } = DateTime.MinValue;
        public long MarketGapNumb { get; set; } = 0;
        public decimal PERatioNumb { get; set; } = 0;
        public decimal BookValueNumb { get; set; } = 0;
        public decimal DividendPerShareAmnt { get; set; } = 0;
        public decimal DividendYieldNumb { get; set; } = 0;
        public decimal EpsNumb { get; set; } = 0;
        public decimal BuyAtAmnt { get; set; } = 0;
        public decimal SellAtAmnt { get; set; } = 0;
        public decimal SoldAtAmnt { get; set; } = 0;
        public DateTime SoldOnDate { get; set; } = DateTime.MinValue;
        public decimal Week52HighAmnt { get; set; } = 0;
        public decimal Week52LowAmnt { get; set; } = 0;
        public decimal Day50MovAvgAmnt { get; set; } = 0;
        public decimal Day200MovAvgAmnt { get; set; } = 0;
        public DateTime DividendDate { get; set; } = DateTime.MinValue;
        public DateTime ExDividendDate { get; set; } = DateTime.MinValue;
        public DateTime UpdateDttm { get; set; } = DateTime.MinValue;
        public string BuyRecommendationIndc { get; set; } = Constants.NO_INDC;
        public string BuyRecommendationByName { get; set; } = string.Empty;
        public DateTime BuyRecommendationDate { get; set; } = DateTime.MinValue;

        public string WishToHaveIndc { get; set; } = string.Empty;
    }


}
