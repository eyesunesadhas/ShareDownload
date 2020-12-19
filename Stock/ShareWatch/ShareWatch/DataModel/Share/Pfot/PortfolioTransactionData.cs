using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWatch.DataModel.Share.Pfot
{
    public class PortfolioTransactionData
    {
      
        public DateTime TransActionDate { get; set; } = DateTime.MinValue;
        public string TradeCode { get; set; } = string.Empty;
        public string TradeName { get; set; } = string.Empty;
        public string TransActionCode { get; set; } = string.Empty;
        public string TractionActionText { get; set; } = string.Empty;
        public decimal SharesCount { get; set; } = 0;
        public decimal CostBasisAmnt { get; set; } = 0;
        public decimal TotalInvestAmnt
        {
            get
            {
                return SharesCount * CostBasisAmnt;
            }
        }
        public int AccountID { get; set; } = 0;
        public string BankName { get; set; } = string.Empty;
        public string BankAccountID { get; set; } = string.Empty;
        public string AccountTypeCode { get; set; } = string.Empty;
        public string AccountTypeText { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public decimal SharesInHandCount { get; set; } = 0;
        public decimal RunningInvestAmnt { get; set; } = 0;
        public decimal WorthAmnt { get; set; } = 0;
        public int TransID { get; set; } = 0;
    }
}
