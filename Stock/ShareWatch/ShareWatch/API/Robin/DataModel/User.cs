using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobinHoodUI.Api.DataModel
{
    public class User
    {
        [JsonProperty("id")]
        public string ID { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("detail")]
        public string Error { get; set; }
    }
}
