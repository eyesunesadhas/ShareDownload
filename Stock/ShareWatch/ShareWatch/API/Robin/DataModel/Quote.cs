using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobinHoodUI.Api.DataModel
{
    public class Quote
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("ask_price")]
        public decimal AskPrice { get; set; }
        [JsonProperty("ask_size")]
        public uint AskSize { get; set; }
        [JsonProperty("bid_price")]
        public decimal BidPrice { get; set; }
        [JsonProperty("bid_size")]
        public uint BidSize { get; set; }
        [JsonProperty("last_trade_price")]
        public decimal LastTradePrice { get; set; }
        [JsonProperty("previous_close")]
        public decimal PreviousClosePrice { get; set; }
        [JsonProperty("adjusted_previous_close")]
        public decimal AdjustedClosePrice { get; set; }
        [JsonProperty("previous_close_date")]
        public DateTime PreviousCloseDate { get; set; }
        [JsonProperty("trading_halted")]
        public bool Halted { get; set; }
        [JsonProperty("updated_at")]
        public DateTime Updated_At { get; set; }

    }

}
