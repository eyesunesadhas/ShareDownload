using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobinHoodUI.Api.DataModel
{
    public class ObjectCollection<T>
    {
        [JsonProperty("results")]
        public List<T> Results { get; set; }
        [JsonProperty("detail")]
        public string Error { get; set; }
    }
}
