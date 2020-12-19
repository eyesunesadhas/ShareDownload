using ShareWatch.Const;
using System;

namespace ShareWatch.DataModel.Share.Pfol
{
    public class PortfolioData : PortfolioKeyData
    {
        public string TransActionCode { get; set; } = string.Empty;
        public DateTime TransActionDate { get; set; } = DateTime.MinValue;
        public DateTime SettlementDate { get; set; } = DateTime.MinValue;
        
        public decimal SharesCount { get; set; } = 0;
        public decimal CostBasisAmnt { get; set; } = 0;
        public decimal TotalInvestAmnt
        {
            get
            {
                return SharesCount * CostBasisAmnt;
            }
        }
        public decimal CurrentAmnt { get; set; } = 0;

        public decimal CostBenefitAmnt
        {
            get
            {
                return CurrentAmnt - CostBasisAmnt;
            }
        }
        public decimal BenefitAmnt
        {
            get
            {
                return CurrentAmnt - CostBasisAmnt;
            }
        }

        public decimal ProfitAmnt
        {
            get
            {
                return CurrentAmnt >= CostBasisAmnt ? CurrentAmnt - CostBasisAmnt : 0;
            }
        }
        public decimal LossAmnt {
            get
            {
                return CurrentAmnt < CostBasisAmnt ? CurrentAmnt - CostBasisAmnt : 0;
            }
        }
        
        public decimal TotalCurrentAmnt
        {
            get
            {
                return CurrentAmnt * SharesCount;
            }
        }
        public decimal TotalBenefitAmnt
        {
            get
            {
                return (CurrentAmnt * SharesCount) - (SharesCount * CostBasisAmnt);
            }
        }

        public decimal BenefitPercentage
        {
            get
            {
                decimal vested = SharesCount * CostBasisAmnt;
                decimal benfit = (CurrentAmnt * SharesCount) - (SharesCount * CostBasisAmnt);
                if (vested == 0) { return 0; }
                return (benfit / vested) * 100;
            }
        }

        public decimal SoldAtAmnt { get; set; } = 0;
        public DateTime SoldOnDate { get; set; } = DateTime.MinValue;
        public decimal BuyAtAmnt { get; set; } = 0;
        public decimal SellAtAmnt { get; set; } = 0;
        public decimal ProfitMargin
        {
            get
            {
                decimal benfit = (SellAtAmnt - BuyAtAmnt);
                if (BuyAtAmnt == 0) { return 0; }
                return (benfit / BuyAtAmnt) * 100;
            }
        }

        public string SellAtMarginMetIndc
        {
            get
            {
                return (CurrentAmnt >= SellAtAmnt)? "Y" : "N";
            }
        }

        public string BuyAtMarginMetIndc
        {
            get
            {
                return (CurrentAmnt < BuyAtAmnt) ? "Y" : "N";
            }
        }
        public decimal Week52HighAmnt { get; set; } = 0;
        public decimal Week52LowAmnt { get; set; } = 0;
        public decimal DividendYieldNumb { get; set; } = 0;
        public decimal DividendPerShareAmnt { get; set; } = 0;
        public DateTime DividendDate { get; set; } = DateTime.MinValue;
        public decimal PERatioNumb { get; set; } = 0;
        public string BuyRecommendationIndc { get; set; } = Constants.NO_INDC;
        public string BuyRecommendationByName { get; set; } = string.Empty;
        public DateTime BuyRecommendationDate { get; set; } = DateTime.MinValue;

    }

}
