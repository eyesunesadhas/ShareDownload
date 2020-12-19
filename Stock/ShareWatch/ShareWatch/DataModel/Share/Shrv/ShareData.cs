using ShareWatch.DataModel.Share.Shrm;
using ShareWatch.DataModel.Share.Stdv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWatch.DataModel.Share.Shrv
{
    public class ShareData: ShareKeyData
    {
        public ShareMarketValueData MarketValue { get; set; } = new ShareMarketValueData();
        public ShareTradeValueData TraderValue { get; set; } = new ShareTradeValueData();
    }
}
