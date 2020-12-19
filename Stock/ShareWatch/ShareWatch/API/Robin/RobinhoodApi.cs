using Newtonsoft.Json;
using RobinHoodUI.Api.DataModel;
using ShareWatch.API.Robin.DataModel;
using ShareWatch.Common;
using ShareWatch.DataModel.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RobinHoodUI.Api
{
    public class RobinhoodApi
    {
        //private static HttpClient _Client { get; set; }
        //private const string API_BASE_URL = "https://api.robinhood.com/";   // Api Base URL
        public string AuthToken { get; set; } = string.Empty;

     

        /// <summary>
        /// Login to Robinhood.
        /// </summary>
        /// <param name="username">Username.</param>
        /// <param name="password">Password.</param>
        public async  Task<OutData<string>> Login(string username, string password)
        {
            OutData<string> output = new OutData<string>();
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentNullException("username");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new ArgumentNullException("password");
            }
            FormUrlEncodedContent content = new FormUrlEncodedContent(
                new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password)
                });

            try
            {
                HttpClientHandler handler = new HttpClientHandler
                {
                    UseDefaultCredentials = true
                };
                HttpClient client = new HttpClient(handler);
                client.DefaultRequestHeaders.Accept.Clear();
                string url = $"{RobinApiEndpoint.Accounts}";
                Uri requestUri = new Uri(url);
                HttpResponseMessage response = await client.PostAsync(requestUri, content);

                if (!response.IsSuccessStatusCode)
                {
                    output.StatusList.Add(new Status("F", response.StatusCode.ToString(), 0));
                    Logger.Log($"Login - Failed call");
                    return output;
                }
                output.Data = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return output;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// Gets current user's profile.
        /// </summary>
        /// <returns>User</returns>
        //async public  Task<User> GetUser()
        //{
        //    if (String.IsNullOrEmpty(AuthToken))
        //    {
        //        throw new Exception("End-point requires user authentication.");
        //    }

        //    try
        //    {
        //        var resp = await _Client.GetAsync("user/");
        //        var user = JsonConvert.DeserializeObject(await resp.Content.ReadAsStringAsync(), typeof(User)) as User;

        //        if (String.IsNullOrEmpty(user.Error))
        //        {
        //            return user;
        //        }
        //        else
        //        {
        //            throw new Exception(user.Error);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        /// <summary>
        /// Gets list of user dividends.
        /// </summary>
        /// <returns>List of Dividends.</returns>
        //async public static Task<List<Dividend>> GetDividends()
        //{
        //    try
        //    {
        //        var resp = await _Client.GetAsync("dividends/");
        //        var collection = JsonConvert.DeserializeObject(await resp.Content.ReadAsStringAsync(), typeof(ObjectCollection<Dividend>)) as ObjectCollection<Dividend>;
        //        if (String.IsNullOrEmpty(collection.Error))
        //        {
        //            return collection.Results;
        //        }
        //        else
        //        {
        //            throw new Exception(collection.Error);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        /// <summary>
        /// Gets list of requested quotes.
        /// </summary>
        /// <param name="symbols">Symbols of entities to get quotes for</param>
        /// <returns>List of Quotes.</returns>
        //async public static Task<List<Quote>> GetQuotes(params string[] symbols)
        //{
        //    if (symbols.Length == 0)
        //    {
        //        throw new Exception("At least one symbol required.");
        //    }

        //    try
        //    {
        //        string queryParams = String.Join(",", symbols);
        //        var resp = await _Client.GetAsync("quotes/?symbols=" + queryParams);
        //        Debug.WriteLine(await resp.Content.ReadAsStringAsync());
        //        var collection = JsonConvert.DeserializeObject(await resp.Content.ReadAsStringAsync(), typeof(ObjectCollection<Quote>)) as ObjectCollection<Quote>;
        //        if (String.IsNullOrEmpty(collection.Error))
        //        {
        //            return collection.Results;
        //        }
        //        else
        //        {
        //            throw new Exception(collection.Error);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        /// <summary>
        /// Gets list of companies.
        /// </summary>
        /// <returns>Instruments List</returns>
        //async public static Task<List<Instrument>> GetInstruments()
        //{
        //    try
        //    {
        //        var resp = await _Client.GetAsync("instruments/");
        //        var collection = JsonConvert.DeserializeObject(await resp.Content.ReadAsStringAsync(), typeof(ObjectCollection<Instrument>)) as ObjectCollection<Instrument>;
        //        if (String.IsNullOrEmpty(collection.Error))
        //        {
        //            return collection.Results;
        //        }
        //        else
        //        {
        //            throw new Exception(collection.Error);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}
    }
}
