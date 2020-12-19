using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareMarketDownload.API.Robinhood.Models
{
    public class LoginData
    {
        public string username { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public string grant_type { get; set; } = "password";
        public string client_id { get; set; } = string.Empty;
        public string device_token { get; set; } = string.Empty;
        public string mfa_code { get; set; } = null;

    }
}
