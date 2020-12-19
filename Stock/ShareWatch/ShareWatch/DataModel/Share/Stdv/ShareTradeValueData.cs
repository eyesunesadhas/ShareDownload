using ShareWatch.DataModel.Share.Shrm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWatch.DataModel.Share.Stdv
{
    public class ShareTradeValueData: ShareKeyData
    {
        public string TradeName { get; set; } = string.Empty;
        public decimal CurrentAmnt { get; set; } = 0;
        public decimal Week52HighAmnt { get; set; } = 0;
        public decimal Week8HighAmnt { get; set; } = 0;
        public decimal Week8LowAmnt { get; set; } = 0;
        public decimal SoldAtAmnt { get; set; } = 0;
        public DateTime SoldOnDate { get; set; } = DateTime.MinValue;
        public decimal BuyAtAmnt { get; set; } = 0;
        public decimal SellAtAmnt { get; set; } = 0;
    }
}
