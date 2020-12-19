using System;

namespace ShareWatch.API
{


    public class CompanyOverviewData
    {
        public string Symbol { get; set; } = string.Empty;
        public string AssetType { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Exchange { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Sector { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public long FullTimeEmployees { get; set; } = 0;
        public string FiscalYearEnd { get; set; } = string.Empty;
        public DateTime LatestQuarter { get; set; } = DateTime.MinValue;
        public long MarketCapitalization { get; set; } = 0L;
        public long EBITDA { get; set; } = 0L;
        public decimal PERatio { get; set; } = 0;
        public decimal PEGRatio { get; set; } = 0;
        public decimal BookValue { get; set; } = 0;
        public decimal DividendPerShare { get; set; } = 0;
        public decimal DividendYield { get; set; } = 0;
        public decimal EPS { get; set; } = 0;
        public decimal RevenuePerShareTTM { get; set; } = 0;
        public decimal ProfitMargin { get; set; } = 0;
        public decimal OperatingMarginTTM { get; set; } = 0;
        public decimal ReturnOnAssetsTTM { get; set; } = 0;
        public decimal ReturnOnEquityTTM { get; set; } = 0;
        public decimal RevenueTTM { get; set; } = 0;
        public decimal GrossProfitTTM { get; set; } = 0;
        public decimal DilutedEPSTTM { get; set; } = 0;
        public decimal QuarterlyEarningsGrowthYOY { get; set; } = 0;
        public decimal QuarterlyRevenueGrowthYOY { get; set; } = 0;
        public decimal AnalystTargetPrice { get; set; } = 0;
        public decimal TrailingPE { get; set; } = 0;
        public decimal ForwardPE { get; set; } = 0;
        public decimal PriceToSalesRatioTTM { get; set; } = 0;
        public decimal PriceToBookRatio { get; set; } = 0;
        public decimal EVToRevenue { get; set; } = 0;
        public decimal EVToEBITDA { get; set; } = 0;
        public decimal Beta { get; set; } = 0;
        public decimal Week52High { get; set; } = 0;
        public decimal Week52Low { get; set; } = 0;
        public decimal Day50MovingAverage { get; set; } = 0;
        public decimal Day200MovingAverage { get; set; } = 0;
        public long SharesOutstanding { get; set; } = 0L;
        public long SharesFloat { get; set; } = 0L;
        public long SharesShort { get; set; } = 0L;
        public long SharesShortPriorMonth { get; set; } = 0L;
        public decimal ShortRatio { get; set; } = 0;
        public decimal ShortPercentOutstanding { get; set; } = 0;
        public decimal ShortPercentFloat { get; set; } = 0;
        public decimal PercentInsiders { get; set; } = 0;
        public decimal PercentInstitutions { get; set; } = 0;
        public decimal ForwardAnnualDividendRate { get; set; } = 0;
        public decimal ForwardAnnualDividendYield { get; set; } = 0;
        public decimal PayoutRatio { get; set; } = 0;
        public DateTime DividendDate { get; set; } = DateTime.MinValue;
        public DateTime ExDividendDate { get; set; } = DateTime.MinValue;
        public string LastSplitFactor { get; set; } = string.Empty;
        public DateTime LastSplitDate { get; set; } = DateTime.MinValue;
    }


}
