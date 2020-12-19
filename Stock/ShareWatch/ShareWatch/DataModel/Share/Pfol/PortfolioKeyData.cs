using ShareWatch.Common;
using ShareWatch.DataModel.Share.Bank;

namespace ShareWatch.DataModel.Share.Pfol
{
    public class PortfolioKeyData : AccountMasterData
    {
        public int TransID { get; set; } = 0;
        public string TradeCode { get; set; } = string.Empty;
        public string TradeName { get; set; } = string.Empty;
        public string ShareName
        {
            get
            {
                string value = $"{TradeName.Trim()}";
                if (!UtilityHandler.IsEmpty(TradeCode))
                {
                    value = $"{value} [{TradeCode}]";
                }
                return value;
            }
        }
    }
}
