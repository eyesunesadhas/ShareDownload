using ShareWatch.DataModel.Share.Shrm;
using System;

namespace ShareWatch.DataModel.Share.Shrv
{
    public class ShareMarketValueData : ShareMasterData
    {
        //public DateTime RefreshedTime { get; set; } = DateTime.MinValue;
        public DateTime TradeDate { get; set; } = DateTime.MinValue;
        public decimal OpenAmnt { get; set; } = 0;
        public decimal CloseAmnt { get; set; } = 0;
        public decimal LowAmnt { get; set; } = 0;
        public decimal HighAmnt { get; set; } = 0;
        public decimal CurrentAmnt { get; set; } = 0;
        public long VolumeCount { get; set; } = 0;
        public long AvgVolCount { get; set; } = 0;
        public decimal PreviousClose { get; set; } = 0;
        public decimal ChangeAmnt { get; set; } = 0;
        public decimal ChangePercent { get; set; } = 0;

        public string SellAtMarginMetIndc
        {
            get
            {
                return (CurrentAmnt >= SellAtAmnt) ? "Y" : "N";
            }
        }

        public string BuyAtMarginMetIndc
        {
            get
            {
                return (CurrentAmnt < BuyAtAmnt) ? "Y" : "N";
            }
        }
    }


}
