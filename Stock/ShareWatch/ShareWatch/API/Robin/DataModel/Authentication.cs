using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RobinHoodUI.Api.DataModel
{
    public class Authentication
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        [JsonProperty("non_field_errors")]
        public string[] Errors { get; set; }
    }

}
