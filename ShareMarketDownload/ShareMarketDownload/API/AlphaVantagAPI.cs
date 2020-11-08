
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShareMarketDownload.Business;
using ShareMarketDownload.Common;
using ShareMarketDownload.Properties;
using ShareWatch.API.Models;
using ShareWatch.DataModel.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace ShareWatch.API
{
    public class AlphaVantagAPI
    {

        // https://github.com/LutsenkoKirill/AlphaVantage.Net/tree/v2
        // https://www.alphavantage.co/documentation/#intraday



        public async Task<OutData<CompanyOverviewData>> GetCompanyOverview(string shareCode)
        {
            //https://www.alphavantage.co/query?function=OVERVIEW&symbol=IBM&apikey=demo
            CompanyOverviewData data = new CompanyOverviewData()
            {
                Symbol = shareCode
            };
            OutData<CompanyOverviewData> output = new OutData<CompanyOverviewData>()
            {
                Data = data
            };
            try
            {
                string query = $"/query?function=OVERVIEW&symbol={shareCode}";
                string url = $"{Settings.Default.StockApi}{query}&apikey={Settings.Default.ApiKey}";
                using HttpClient client = UtilityHandler.GetHttpClient();
                Uri requestUri = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(requestUri).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    output.StatusList.Add(new Status("F", response.StatusCode.ToString(), 0));
                    Logger.Log($"CompanyOverviewData -{shareCode} - Failed call");
                    return output;
                }
                string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                Dictionary<string, string> dicData = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                data.Symbol = GetTagValue(dicData, AlphaVantagTagConstants.TAG_SYMBOL);
                data.AssetType = GetTagValue(dicData, AlphaVantagTagConstants.TAG_ASSET_TYPE);
                data.Name = GetTagValue(dicData, AlphaVantagTagConstants.TAG_NAME);
                data.Description = GetTagValue(dicData, AlphaVantagTagConstants.TAG_DESCRIPTION);
                data.Exchange = GetTagValue(dicData, AlphaVantagTagConstants.TAG_EXCHANGE);
                data.Currency = GetTagValue(dicData, AlphaVantagTagConstants.TAG_CURRENCY);
                data.Country = GetTagValue(dicData, AlphaVantagTagConstants.TAG_COUNTRY);
                data.Sector = GetTagValue(dicData, AlphaVantagTagConstants.TAG_SECTOR);
                data.Industry = GetTagValue(dicData, AlphaVantagTagConstants.TAG_INDUSTRY);
                data.Address = GetTagValue(dicData, AlphaVantagTagConstants.TAG_ADDRESS);
                data.FullTimeEmployees = GetTagValueLong(dicData, AlphaVantagTagConstants.TAG_FULLTIME_EMPLOYEES);
                data.FiscalYearEnd = GetTagValue(dicData, AlphaVantagTagConstants.TAG_FISCAL_YEAR_END);
                data.LatestQuarter = GetTagValueDateTime(dicData, AlphaVantagTagConstants.TAG_LATEST_QUARTER);
                data.MarketCapitalization = GetTagValueLong(dicData, AlphaVantagTagConstants.TAG_MARKET_CAPITALIZATION);
                data.EBITDA = GetTagValueLong(dicData, AlphaVantagTagConstants.TAG_EBITDA);
                data.PERatio = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_PERATIO);
                data.PEGRatio = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_PEGRATIO);
                data.BookValue = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_BOOKVALUE);
                data.DividendPerShare = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_DIVIDEND_PER_SHARE);
                data.DividendYield = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_DIVIDEND_YIELD);
                data.EPS = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_EPS);
                data.RevenuePerShareTTM = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_REVENUE_PER_SHARE_TTM);
                data.ProfitMargin = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_PROFIT_MARGIN);
                data.OperatingMarginTTM = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_OPERATING_MARGIN_TTM);
                data.ReturnOnAssetsTTM = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_RETURN_ON_ASSETS_TTM);
                data.ReturnOnEquityTTM = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_RETURN_ON_EQUITY_TTM);
                data.RevenueTTM = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_REVENUE_TTM);
                data.GrossProfitTTM = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_GROSS_PROFIT_TTM);
                data.DilutedEPSTTM = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_DILUTED_EPS_TTM);
                data.QuarterlyEarningsGrowthYOY = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_QUARTERLY_EARNINGS_GROWTH_YOY);
                data.QuarterlyRevenueGrowthYOY = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_QUARTERLY_REVENUE_GROWTH_YOY);
                data.AnalystTargetPrice = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_ANALYST_TARGET_PRICE);
                data.TrailingPE = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_TRAILING_PE);
                data.ForwardPE = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_FORWARD_PE);
                data.PriceToSalesRatioTTM = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_PRICE_TO_SALES_RATIO_TTM);
                data.PriceToBookRatio = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_PRICE_TO_BOOK_RATIO);
                data.EVToRevenue = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_EV_TO_REVENUE);
                data.EVToEBITDA = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_EV_TO_EBITDA);
                data.Beta = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_BETA);
                data.Week52High = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_52_WEEK_HIGH);
                data.Week52Low = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_52_WEEK_LOW);
                data.Day50MovingAverage = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_50_DAY_MOVING_AVERAGE);
                data.Day200MovingAverage = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_200_DAY_MOVING_AVERAGE);
                data.SharesOutstanding = GetTagValueLong(dicData, AlphaVantagTagConstants.TAG_SHARES_OUTSTANDING);
                data.SharesFloat = GetTagValueLong(dicData, AlphaVantagTagConstants.TAG_SHARES_FLOAT);
                data.SharesShort = GetTagValueLong(dicData, AlphaVantagTagConstants.TAG_SHARES_SHORT);
                data.SharesShortPriorMonth = GetTagValueLong(dicData, AlphaVantagTagConstants.TAG_SHARES_SHORT_PRIOR_MONTH);
                data.ShortRatio = GetTagValueLong(dicData, AlphaVantagTagConstants.TAG_SHORT_RATIO);
                data.ShortPercentOutstanding = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_SHORT_PERCENT_OUTSTANDING);
                data.ShortPercentFloat = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_SHORT_PERCENT_FLOAT);
                data.PercentInsiders = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_PERCENT_INSIDERS);
                data.PercentInstitutions = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_PERCENT_INSTITUTIONS);
                data.ForwardAnnualDividendRate = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_FORWARD_ANNUAL_DIVIDEND_RATE);
                data.ForwardAnnualDividendYield = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_FORWARD_ANNUAL_DIVIDEND_YIELD);
                data.PayoutRatio = GetTagValueDecimal(dicData, AlphaVantagTagConstants.TAG_PAYOUT_RATIO);
                data.DividendDate = GetTagValueDateTime(dicData, AlphaVantagTagConstants.TAG_DIVIDEND_DATE);
                data.ExDividendDate = GetTagValueDateTime(dicData, AlphaVantagTagConstants.TAG_EX_DIVIDEND_DATE);
                data.LastSplitFactor = GetTagValue(dicData, AlphaVantagTagConstants.TAG_LAST_SPLIT_FACTOR);
                data.LastSplitDate = GetTagValueDateTime(dicData, AlphaVantagTagConstants.TAG_LAST_SPLIT_DATE);
                if (UtilityHandler.IsEmpty(data.Name))
                {
                    output.StatusList.Add(new Status("F", "Not Parsed data data well", 0));
                    Logger.Log($"CompanyOverviewData - {shareCode} JSon Pasing Issue");
                    Logger.Log(json);
                    return output;
                }
                return output;

            }
            catch (Exception ex)
            {
                string mess = $"GetCompanyOverview - Share :{shareCode} {ex.Message}";
                output.StatusList.Add(new Status("F", mess, 0));
                Logger.LogError($"GetCompanyOverview - Share :{shareCode}", $"{ex.Message} - {ex.StackTrace}");
                return output;
            }
        }

      

        public async Task<OutData<GlobalQuoteData>> GetCurrentQuote(string shareCode)
        {
            //https://www.alphavantage.co/query?function=GLOBAL_QUOTE&symbol=IBM&apikey=demo
            OutData<GlobalQuoteData> output = new OutData<GlobalQuoteData>();
            try
            {
                string query = $"/query?function=GLOBAL_QUOTE&symbol={shareCode}";
                string url = $"{Settings.Default.StockApi}{query}&apikey={Settings.Default.ApiKey}";
                using HttpClient client = UtilityHandler.GetHttpClient();
                Uri requestUri = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(requestUri).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    output.StatusList.Add(new Status("F", response.StatusCode.ToString(), 0));
                    Logger.Log($"GetCurrentQuote -{shareCode} - Failed call");
                    return output;
                }
                string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                LogJsonValue(shareCode, json);
                Dictionary<string, object> jo = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                foreach (string key in jo.Keys)
                {
                    JToken value = (JObject)jo[key];
                    if (key.StartsWith(AlphaVantagTagConstants.TAG_GLOBAL_QUOTE))
                    {
                        output.Data = ParseGlobalQuote(value);
                    }
                }
                if (UtilityHandler.IsEmpty(output.Data.Symbol))
                {
                    output.StatusList.Add(new Status("F", "Not Parsed data data well", 0));
                    Logger.Log($"GetCurrentQuote - {shareCode} JSon Pasing Issue");
                    Logger.Log(json);
                    return output;
                }
                return output;

            }
            catch (Exception ex)
            {
                string mess = $"GetCompanyOverview - Share :{shareCode} {ex.Message}";
                output.StatusList.Add(new Status("F", mess, 0));
                Logger.LogError($"GetCompanyOverview - Share :{shareCode}", $"{ex.Message} - {ex.StackTrace}");
                return output;
            }

        }


        public async Task<OutData<string>> GetShareIntradayCsv(string shareCode)
        {
            OutData<string> output = new OutData<string>();
            try
            {
                string query = $"/query?function=TIME_SERIES_DAILY_ADJUSTED&symbol={shareCode}&datatype=csv";
                string url = $"{Settings.Default.StockApi}{query}&apikey={Settings.Default.ApiKey}";
                HttpClientHandler handler = new HttpClientHandler
                {
                    UseDefaultCredentials = true
                };
                HttpClient client = new HttpClient(handler);
                client.DefaultRequestHeaders.Accept.Clear();
                Uri requestUri = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(requestUri).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    output.StatusList.Add(new Status("F", response.StatusCode.ToString(), 0));
                    Logger.Log($"GetShareIntraday -{shareCode} - Failed call");
                    return output;
                }
                output.Data  = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                string mess = $"GetShareIntradayCsv - Share :{shareCode} {ex.Message}";
                output.StatusList.Add(new Status("F", mess, 0));
                Logger.LogError($"GetShareIntradayCsv - Share :{shareCode}", $"{ex.Message} - {ex.StackTrace}");
                return output;
            }
            return output;

        }


        public async Task<OutData<TimeSeriesIntradayData>> GetShareIntraday(string shareCode,
                                                                            string interval = "15min",
                                                                            string outputSize = "compact",
                                                                            bool isAdjusted = true)
        {
            TimeSeriesIntradayData data = new TimeSeriesIntradayData();
            OutData<TimeSeriesIntradayData> output = new OutData<TimeSeriesIntradayData>()
            {
                Data = data
            };

            try
            {
                string query = $"/query?function=TIME_SERIES_INTRADAY&symbol={shareCode}&interval={interval}&outputsize={outputSize}";
                string url = $"{Settings.Default.StockApi}{query}&apikey={Settings.Default.ApiKey}";
                using HttpClient client = UtilityHandler.GetHttpClient();
                Uri requestUri = new Uri(url);
                HttpResponseMessage response = await client.GetAsync(requestUri).ConfigureAwait(false);
                if (!response.IsSuccessStatusCode)
                {
                    output.StatusList.Add(new Status("F", response.StatusCode.ToString(), 0));
                    Logger.Log($"GetShareIntraday -{shareCode} - Failed call");
                    return output;
                }
                string json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                LogJsonValue(shareCode, json);
                Dictionary<string, object> jo = JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
                foreach (string key in jo.Keys)
                {
                    JToken value = (JObject)jo[key];
                    if (key == AlphaVantagTagConstants.TAG_META_DATA)
                    {
                        data.MetaData = ParseMetaData(value);
                        continue;
                    }
                    if (key.StartsWith(AlphaVantagTagConstants.TAG_TIME_SERIES))
                    {
                        data.Data = ParseTimeSeries(value);
                    }
                }


                return output;

            }
            catch (Exception ex)
            {
                string mess = $"GetShareIntraday - Share :{shareCode} {ex.Message}";
                output.StatusList.Add(new Status("F", mess, 0));
                Logger.LogError($"GetShareIntraday - Share :{shareCode}", $"{ex.Message} - {ex.StackTrace}");
                return output;
            }
        }

        private void LogJsonValue(string shareCode, string json)
        {
            string fileName = $@"{Settings.Default.LoggingFolder}\{shareCode}.json";
            File.WriteAllText(fileName, json);
        }


        private GlobalQuoteData ParseGlobalQuote(JToken input)
        {
            GlobalQuoteData output = new GlobalQuoteData();
            foreach (JProperty prop in input.Children<JProperty>())
            {
                string key = prop.Name;
                string value = prop.Value.ToString();
                switch (key)
                {
                    case AlphaVantagTagConstants.TAG_01_SYMBOL:// "01. symbol";
                        output.Symbol = value;
                        break;
                    case AlphaVantagTagConstants.TAG_02_OPEN://"02. open";
                        output.Open = GetDecimalValue(value);
                        break;
                    case AlphaVantagTagConstants.TAG_03_HIGH://"03. high";
                        output.High = GetDecimalValue(value);
                        break;
                    case AlphaVantagTagConstants.TAG_04_LOW://"04. low";
                        output.Low = GetDecimalValue(value);
                        break;
                    case AlphaVantagTagConstants.TAG_05_PRICE://"05. price";
                        output.Current = GetDecimalValue(value);
                        break;
                    case AlphaVantagTagConstants.TAG_06_VOLUME://"06. volume";
                        output.Volume = GetLongValue(value);
                        break;
                    case AlphaVantagTagConstants.TAG_07_LATEST_TRADING_DAY:// "07. latest trading day";
                        output.LatestTrading = GetDateTimeValue(value);
                        break;
                    case AlphaVantagTagConstants.TAG_08_PREVIOUS_CLOSE://"08. previous close";
                        output.PreviousClose = GetDecimalValue(value);
                        break;
                    case AlphaVantagTagConstants.TAG_09_CHANGE://"09. change";
                        output.Change = GetDecimalValue(value);
                        break;
                    case AlphaVantagTagConstants.TAG_10_CHANGE_PERCENT://"10. change percent";
                        output.ChangePercent = GetDecimalValue(value);
                        break;
                }
            }

            return output;
        }


        private TimeSeriesMetaData ParseMetaData(JToken input)
        {
            // DateTime lastRefreshed = DateTime.MinValue;
            TimeSeriesMetaData output = new TimeSeriesMetaData();
            foreach (JProperty prop in input.Children<JProperty>())
            {
                string key = prop.Name;
                string value = prop.Value.ToString();
                switch (key)
                {
                    case AlphaVantagTagConstants.TAG_1_INFORMATION:
                        output.Information = value;
                        break;
                    case AlphaVantagTagConstants.TAG_2_SYMBOL:
                        output.Symbol = value;
                        break;
                    case AlphaVantagTagConstants.TAG_4_INTERVAL:
                        output.Interval = value;
                        break;
                    case AlphaVantagTagConstants.TAG_5_OUTPUT_SIZE:
                        output.OutputSize = value;
                        break;
                    case AlphaVantagTagConstants.TAG_6_TIME_ZONE:
                        output.TimeZone = value;
                        break;
                    case AlphaVantagTagConstants.TAG_3_LAST_REFRESHED:
                        output.LastRefreshed = GetDateTimeValue(value);
                        break;
                }
            }
            return output;
        }




        private List<TimeSeriesData> ParseTimeSeries(JToken input)
        {
            List<TimeSeriesData> output = new List<TimeSeriesData>();
            foreach (JProperty prop in input.Children<JProperty>())
            {
                string key = prop.Name;
                JToken value = (JToken)prop.Value;
                output.Add(GetTimeSeriesData(key, value));
            }
            return output;
        }

        private TimeSeriesData GetTimeSeriesData(string timeData, JToken input)
        {
            DateTime.TryParse(timeData, out DateTime marketTime);
            TimeSeriesData output = new TimeSeriesData()
            {
                MarketTime = marketTime
            };
            foreach (JProperty prop in input.Children<JProperty>())
            {
                string key = prop.Name;
                string value = prop.Value.ToString();
                switch (key)
                {
                    case AlphaVantagTagConstants.TAG_1_OPEN:
                        output.Open = GetDecimalValue(value);
                        break;
                    case AlphaVantagTagConstants.TAG_2_HIGH:
                        output.High = GetDecimalValue(value);
                        break;
                    case AlphaVantagTagConstants.TAG_3_LOW:
                        output.Low = GetDecimalValue(value);
                        break;
                    case AlphaVantagTagConstants.TAG_4_CLOSE:
                        output.Close = GetDecimalValue(value);
                        break;
                    case AlphaVantagTagConstants.TAG_5_VOLUME:
                        output.Volume = GetLongValue(value);
                        break;
                }
            }
            return output;
        }

        private string GetTagValue(Dictionary<string, string> input, string tag)
        {
            string output = string.Empty;
            if (UtilityHandler.IsEmpty(tag) || !input.ContainsKey(tag))
            {
                return output;
            }
            return input[tag];

        }


        private long GetTagValueLong(Dictionary<string, string> input, string tag)
        {
            long output = 0;
            string s = GetTagValue(input, tag);
            if (UtilityHandler.IsEmpty(s))
            {
                return output;
            }
            long.TryParse(s, out output);
            return output;
        }

        private DateTime GetTagValueDateTime(Dictionary<string, string> input, string tag)
        {
            DateTime output = DateTime.MinValue;
            string s = GetTagValue(input, tag);
            if (UtilityHandler.IsEmpty(s))
            {
                return output;
            }
            DateTime.TryParse(s, out output);
            return output;
        }

        private decimal GetTagValueDecimal(Dictionary<string, string> input, string tag)
        {
            decimal output = 0;
            string s = GetTagValue(input, tag);
            if (UtilityHandler.IsEmpty(s))
            {
                return output;
            }
            decimal.TryParse(s, out output);
            return output;
        }

        private DateTime GetDateTimeValue(string value)
        {
            DateTime.TryParse(value, out DateTime output);
            return output;
        }

        private long GetLongValue(string value)
        {
            long.TryParse(value, out long output);
            return output;
        }

        private decimal GetDecimalValue(string value)
        {
            decimal.TryParse(value, out decimal output);
            return output;
        }


    }
}
