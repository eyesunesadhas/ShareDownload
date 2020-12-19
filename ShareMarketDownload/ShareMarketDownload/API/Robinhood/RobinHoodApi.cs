using Newtonsoft.Json;
using ShareMarketDownload.API.Robinhood.Models;
using ShareMarketDownload.Common;
using ShareWatch.DataModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShareMarketDownload.API.Robinhood
{
    public class RobinHoodApi
    {
        public async Task<OutData<string>> Login(LoginData input)
        {
            OutData<string> output = new OutData<string>();
            try
            {

                string url = $"{RobinApiEndpoint.Accounts}";
                HttpClientHandler handler = new HttpClientHandler
                {
                    UseDefaultCredentials = true
                };
                HttpClient client = new HttpClient(handler);
                client.DefaultRequestHeaders.Accept.Clear();
                Uri requestUri = new Uri(url);
                StringContent content = new StringContent(JsonConvert.SerializeObject(input));

                HttpResponseMessage response = await client.PostAsync(requestUri, content);
                if (!response.IsSuccessStatusCode)
                {
                    output.StatusList.Add(new Status("F", response.StatusCode.ToString(), 0));
                    Logger.Log($"Login - Failed call");
                    return output;
                }
                output.Data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                string mess = $"Login {ex.Message}";
                output.StatusList.Add(new Status("F", mess, 0));
                Logger.LogError($"Login ", $"{ex.Message} - {ex.StackTrace}");
                return output;
            }
            return output;
        }
          
        
    }
}
