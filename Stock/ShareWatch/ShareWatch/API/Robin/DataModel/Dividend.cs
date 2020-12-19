using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobinHoodUI.Api.DataModel
{
    public class Dividend
    {
        [JsonProperty("account")]
        public string Account { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("instrument")]
        public string Instrument { get; set; }
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
        [JsonProperty("rate")]
        public decimal Rate { get; set; }
        [JsonProperty("withholding")]
        public decimal Withholding { get; set; }
        [JsonProperty("record_date")]
        public DateTime RecordDate { get; set; }
        [JsonProperty("payable_date")]
        public DateTime PayableDate { get; set; }
        [JsonProperty("paid_at")]
        public DateTime PaidAt { get; set; }
    }
}
