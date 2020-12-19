using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobinHoodUI.Api.DataModel
{
    public class Instrument
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("symbol")]
        public string Symbol { get; set; }
        [JsonProperty("bloomberg_unique")]
        public string BloombergUuid { get; set; }
        [JsonProperty("tradeable")]
        public bool Tradeable { get; set; }
    }
}
