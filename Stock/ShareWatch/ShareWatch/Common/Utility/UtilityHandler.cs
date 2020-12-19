
using Newtonsoft.Json;
using ShareWatch.API;
using ShareWatch.API.Models;
using ShareWatch.Const;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModel.Share.Shrv;
using ShareWatch.DataModels.Logging;
using ShareWatch.ExcelExport;
using ShareWatch.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Reflection;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace ShareWatch.Common
{
    public partial class UtilityHandler
    {
        /// <summary>
        /// Declaration to represent the minimum System.TimeSpan value.
        /// </summary>
        private static TimeSpan m_differenceInTimeSpan = TimeSpan.MinValue;

        /// <summary>
        /// Creates a new instance of UtilHandler
        /// </summary>
        public UtilityHandler()
        {
        }

        public static List<string> GetUserRoles(ClaimsIdentity claimsIdentity)
        {
            List<string> roles = new List<string>();
            foreach (Claim claim in claimsIdentity.Claims)
            {
                if (claim.Type == ClaimTypes.Role)
                {
                    roles.Add(claim.Value);
                }
            }
            return roles;
        }

        public static bool IsOneInList(List<string> roles, List<string> userRoles)
        {
            foreach (string servieRole in roles)
            {
                foreach (string userRole in userRoles)
                {
                    if (string.Compare(servieRole, userRole, true) == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static string Serialize(object input)
        {
            string jsonString = string.Empty;
            if (input != null)
            {
                jsonString = JsonConvert.SerializeObject(input);
            }
            return jsonString;
        }

        public static string GetCrypt(string text)
        {
            SHA512 alg = SHA512.Create();
            byte[] result = alg.ComputeHash(Encoding.UTF8.GetBytes(text));
            return Convert.ToBase64String(result);
        }



        /// <summary>
        /// Gets or sets the system current date time.
        /// System date will be set only once, condition IsEmpty checked to avoid repeated setting.
        /// </summary>
        /// <value>
        /// The system current date time.
        /// </value>
        public static DateTime SystemCurrentDateTime
        {
            get
            {
                return DateTime.Now;
            }
            set
            {
                // Check if the m_differenceInTimeSpan value is equal to Time span's minimum value
                if (m_differenceInTimeSpan == TimeSpan.MinValue)
                {
                    //Calculating the difference between the DB time & App Server time
                    m_differenceInTimeSpan = value - DateTime.Now;
                }
            }
        }



        public static string GetExceptionMessage(Exception ex)
        {
            if (ex != null)
            {
                if (ex.InnerException != null && ex.InnerException.Message != null)
                {
                    return ex.InnerException.Message;
                }
                else
                {
                    return ex.Message;
                }
            }
            return string.Empty;
        }

        /// <summary>
        /// Gets the unique identifier.
        /// </summary>
        public static string UniqueID
        {
            get
            {
                DateTime dateNow = DateTime.Now;
                string msPart = "0000000" + dateNow.ToString("FFFFFFF");
                msPart = msPart.Substring(msPart.Length - 7);
                return dateNow.ToString("yyyyMMdd.HHmmss.") + msPart + "." + (new Random().Next(100000000, 999999999));
            }
        }

        /// <summary>
        /// Gets the date time by adding the days
        /// </summary>
        /// <param name="dateValue">dateValue is passed as parameter</param>
        /// <param name="days">days passed as parameter</param>
        /// <returns>Added Date Time</returns>
        public static DateTime AddDays(DateTime dateValue, int days) => dateValue.AddDays(days);

        /// <summary>
        /// Gets the date time by adding the days
        /// </summary>
        /// <param name="dateValue">dateValue is passed as parameter</param>
        /// <param name="months">months passed as parameter</param>
        /// <returns>Added Date Time</returns>
        public static DateTime AddMonths(DateTime dateValue, int months) => dateValue.AddMonths(months);

        /// <summary>
        /// Gets the date time by adding the years
        /// </summary>
        /// <param name="dateValue">dateValue is passed as parameter</param>
        /// <param name="years">year passed as parameter</param>
        /// <returns>Added Date Time</returns>
        public static DateTime AddYears(DateTime dateValue, int years) => dateValue.AddYears(years);

        /// <summary>
        /// Converts the object as XML.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="removeExtras">if set to <c>true</c> [remove extras].</param>
        /// <returns></returns>
        public static string ConvertObjectAsXml(object data, bool removeExtras = false)
        {
            string strXml = SerializeObject(data);
            if (removeExtras)
            {
                strXml = strXml.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>", string.Empty);
                strXml = strXml.Replace(" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"", string.Empty);
                strXml = strXml.Replace(" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"", string.Empty);
                strXml = strXml.Replace("0003-03-03T00:00:00", string.Empty);
                strXml = strXml.Replace("0001-01-01T00:00:00", string.Empty);
                strXml = strXml.Replace("9999-12-31T00:00:00", string.Empty);
                strXml = strXml.Replace("-4.4942328371557893E+307", string.Empty);
                strXml = strXml.Replace("-9223372036854775808", string.Empty);
                strXml = strXml.Replace("-2147483648", string.Empty);
                strXml = strXml.Replace("-3.40282347E+38", string.Empty);
            }
            return strXml;
        }

        /// <summary>
        /// Copies the data between objects.
        /// </summary>
        /// <typeparam name="Tin">The type of the in.</typeparam>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination.</param>
        /// <param name="matchExact">if set to <c>true</c> [match exact].</param>
        /// <returns></returns>
        public static Tout CopyDataBetweenObjects<Tin, Tout>(Tin source, Tout destination, bool matchExact = false)
            where Tin : class
            where Tout : class
        {
            PropertyInfo[] sourcePropertyInfo = (from prop in source.GetType().GetProperties()
                                                 orderby prop.Name
                                                 select prop).ToArray();

            PropertyInfo[] destinationPropertyInfo = (from prop in destination.GetType().GetProperties()
                                                      orderby prop.Name
                                                      select prop).ToArray();

            foreach (PropertyInfo inClass in sourcePropertyInfo)
            {
                foreach (PropertyInfo outClass in destinationPropertyInfo)
                {
                    if (!matchExact && outClass.Name.Contains(inClass.Name) && outClass.CanWrite)
                    {
                        outClass.SetValue(destination, inClass.GetValue(source, null), null);
                    }
                    else if (matchExact && outClass.Name.Equals(inClass.Name) && outClass.CanWrite)
                    {
                        outClass.SetValue(destination, inClass.GetValue(source, null), null);
                    }
                }
            }

            return destination;
        }

        public static void UpdateCurrentQuote(ShareMarketValueData data, OutData<GlobalQuoteData> input)
        {
            if (!IsValidStatus(input))
            {
                return;
            }
            GlobalQuoteData market = input.Data;
            if (IsEmpty(market.Symbol))
            {
                return;
            }
            data.OpenAmnt = market.Open;
            data.HighAmnt = market.High;
            data.LowAmnt = market.Low;
            data.CurrentAmnt = market.Current;
            data.VolumeCount = market.Volume;
            data.TradeDate  = market.LatestTrading;
            data.PreviousClose = market.PreviousClose;
            data.ChangeAmnt = market.Change;
            data.ChangePercent = market.ChangePercent;
        }



        /// <summary>
        /// Copies the data between objects.
        /// </summary>
        /// <typeparam name="Tin">The type of the in.</typeparam>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="destination">The destination</param>
        /// <param name="mapping">Dictionaly contains property mapping (Source property name, destination property name)</param>
        /// <param name="matchExact">if set to <c>true</c> [match exact].</param>
        /// <returns></returns>
        public static Tout CopyDataBetweenObjects<Tin, Tout>(Tin source, Tout destination, Dictionary<string, string> mapping, bool matchExact = false)
            where Tin : class
            where Tout : class
        {

            PropertyInfo[] sourcePropertyInfo = (from prop in source.GetType().GetProperties()
                                                 orderby prop.Name
                                                 select prop).ToArray();

            PropertyInfo[] destinationPropertyInfo = (from prop in destination.GetType().GetProperties()
                                                      orderby prop.Name
                                                      select prop).ToArray();

            Dictionary<PropertyInfo, PropertyInfo> dictionaryPropertyInfo =
            (from destinationInfo in destinationPropertyInfo
             join sourceInfo in sourcePropertyInfo
             on destinationInfo.CanWrite equals true
             where ((!matchExact && destinationInfo.Name.Contains(sourceInfo.Name))
                                                                                 || (matchExact && destinationInfo.Name.Equals(sourceInfo.Name)))
             select new
             {
                 destinationInfo,
                 sourceInfo
             })
            .ToDictionary(element => element.destinationInfo, element => element.sourceInfo);

            foreach (PropertyInfo keyPropertyInfo in dictionaryPropertyInfo.Keys)
            {
                keyPropertyInfo.SetValue(destination, dictionaryPropertyInfo[keyPropertyInfo].GetValue(source, null), null);
            }

            // Check whether any custom mappings exist or not.
            if (mapping != null)
            {
                foreach (string key in mapping.Keys)
                {
                    PropertyInfo sourceInfo = sourcePropertyInfo.Where(info => info.Name == key).First();
                    PropertyInfo destInfo = destinationPropertyInfo.Where(info => info.Name == mapping[key]).First();
                    destInfo.SetValue(destination, sourceInfo.GetValue(source, null), null);
                }
            }
            return destination;
        }



        /// <summary>
        /// Copies the status from one output object to another.
        /// </summary>
        /// <param name="destinationOutput">The base output.</param>
        /// <param name="srcOutput">The data access output.</param>
        public static void CopyStatus(StatusOut destinationOutput, StatusOut srcOutput) => destinationOutput.StatusList = srcOutput.StatusList;

        /// <summary>
        /// Calculates the difference in days between two dates.
        /// </summary>
        /// <param name="firstDate">The first date.</param>
        /// <param name="secondDate">The second date.</param>
        /// <returns>Days between two dates</returns>
        public static int DateDifferenceInDays(DateTime firstDate, DateTime secondDate)
        {
            // Difference in days, hours, and minutes.
            TimeSpan timeSpan = secondDate - firstDate;
            // Difference in days.
            return timeSpan.Days;
        }

        /// <summary>
        /// Dates the difference in years.
        /// </summary>
        /// <param name="firstDate">The first date.</param>
        /// <param name="secondDate">The second date.</param>
        /// <returns>Years between two dates</returns>
        public static int DateDifferenceInYears(DateTime firstDate, DateTime secondDate)
        {
            // Difference in days, hours, and minutes.
            int totalDays = DateDifferenceInDays(firstDate, secondDate);
            // Difference in days.
            return (int)(totalDays / 365.25);
        }

        /// <summary>
        /// Decrypts the given input string
        /// </summary>
        /// <param name="value">The string value to be decrypted</param>
        /// <returns></returns>
        public static string DecryptString(string value)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            return encoder.GetString(System.Convert.FromBase64String(value));
        }

        /// <summary>
        /// Converts a JSON-formatted string to an object of the specified type.
        /// </summary>
        /// <param name="jsonString">The JSON string.</param>
        /// <param name="deserializeType">Type of the de-serialize.</param>
        /// <returns></returns>
        public static object DeSerializeFromJson(string jsonString, object deserializeType)
        {
            object jsonObj = JsonConvert.DeserializeObject(jsonString);
            return jsonObj;
        }

        /// <summary>
        /// Deserialize from json.
        /// </summary>
        /// <param name="jsonString">The json string.</param>
        /// <returns>Dictionary&lt;string, object&gt;</returns>
        public static Dictionary<string, object> DeSerializeFromJson(string jsonString) => DeSerializeFromJson<Dictionary<string, object>>(jsonString);

        /// <summary>
        /// Des the serialize from json.
        /// </summary>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <param name="jsonString">The json string.</param>
        /// <returns></returns>
        public static Tout DeSerializeFromJson<Tout>(string jsonString) where Tout : class
        {
            Tout output = JsonConvert.DeserializeObject<Tout>(jsonString);
            return output;
        }

        /// <summary>
        /// Differences as time timeSpan.
        /// </summary>
        /// <param name="dt2">The DT2.</param>
        /// <param name="dt1">The DT1.</param>
        /// <returns></returns>
        public static string DifferenceAsTimeSpan(DateTime dt2, DateTime dt1)
        {
            string retVal = "";
            TimeSpan timeSpan = (dt2 - dt1);
            retVal = timeSpan.Days + "D " + timeSpan.Hours + ":" + timeSpan.Minutes + ":" + timeSpan.Seconds + "." + timeSpan.Milliseconds;
            return retVal;
        }

        /// <summary>
        /// Encrypts the given input string
        /// </summary>
        /// <param name="value">The string value to be encrypted</param>
        /// <returns></returns>
        public static string EncryptString(string value)
        {
            UTF8Encoding encoder = new UTF8Encoding();
            return System.Convert.ToBase64String(encoder.GetBytes(value));
        }



        /// <summary>
        /// parses the stringValue to Int32
        /// </summary>
        /// <param name="stringValue">stringValue passed as parameter</param>
        /// <returns>returns returnValue</returns>
        public static int ExactParseInt32(string stringValue)
        {
            int returnValue = Constants.NULL_INT;
            if (!int.TryParse(stringValue, out returnValue))
            {
                returnValue = Constants.NULL_INT;
            }
            return returnValue;
        }

        /// <summary>
        /// returns the value
        /// </summary>
        /// <param name="value">value passed as parameter</param>
        /// <returns>returns the value</returns>
        public static int Floor(double value) => (int)value;

        /// <summary>
        /// Formats the default numeric to string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <param name="isToFormatForZeroValue">if set to <c>true</c> [is to format for zero value].</param>
        /// <returns>Formatted numeric to string with prefix by zero</returns>
        public static string FormatDefaultNumericToString(long value, int length, bool isToFormatForZeroValue = false) => FormatDefaultNumericToString(value.ToString(), length, isToFormatForZeroValue);

        /// <summary>
        /// Formats the default numeric to string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <param name="isToFormatForZeroValue">if set to <c>true</c> [is to format for zero value].</param>
        /// <returns>Formatted numeric to string with prefix by zero</returns>
        public static string FormatDefaultNumericToString(int value, int length, bool isToFormatForZeroValue = false) => FormatDefaultNumericToString(value.ToString(), length, isToFormatForZeroValue);

        /// <summary>
		/// Formats the default numeric to string.
		/// </summary>
		/// <param name="value">The value.</param>
		/// <param name="length">The length.</param>
		/// <param name="isToFormatForZeroValue">if set to <c>true</c> [is to format for zero value].</param>
		/// <returns>Formatted numeric to string with prefix by zero</returns>
		public static string FormatDefaultNumericToString(decimal value, int length, bool isToFormatForZeroValue = false) => FormatDefaultNumericToString(value.ToString(), length, isToFormatForZeroValue);


        /// <summary>
        /// Formats the default numeric to string.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="length">The length.</param>
        /// <param name="isToFormatForZeroValue">if set to <c>true</c> [is to format for zero value].</param>
        /// <returns>Formatted string with prefix by zero</returns>
        public static string FormatDefaultNumericToString(string value, int length, bool isToFormatForZeroValue = false)
        {
            string returnValue = string.Empty;
            value = RemoveSpacesFromChar(value);

            if (value == Constants.CHAR_ZERO && !isToFormatForZeroValue)
            {
                return returnValue;
            }
            int appendLength = length - value.Length;

            if (appendLength == Constants.INT_ZERO)
            {
                return value;
            }
            returnValue = value.PadLeft(length, '0');
            return returnValue;
        }

        /// <summary>
        /// Gets the FirstDay of the date passed
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>FirstDay of the date passed</returns>
        public static DateTime GetFirstDateOfMonth(DateTime date) => new DateTime(date.Year, date.Month, 1);

        /// <summary>
        /// Gets the first day of week.
        /// </summary>
        /// <param name="dateValue">The date value.</param>
        /// <returns>first day of week</returns>
        public static DateTime GetFirstDateOfWeek(DateTime dateValue)
        {
            int diffValue = DayOfWeek.Monday - dateValue.DayOfWeek;
            DateTime monday = dateValue.AddDays(diffValue);
            return monday;
        }

        /// <summary>
        /// Gets the Last day of the date passed
        /// </summary>
        /// <param name="date">date passed as parameter</param>
        /// <returns>returns Last day of the date passed </returns>
        public static DateTime GetLastDateOfMonth(DateTime date) => new DateTime(date.Year, date.Month, DateTime.DaysInMonth(date.Year, date.Month));

        /// <summary>
        /// Gets the last day of week.
        /// </summary>
        /// <param name="dateValue">The date value.</param>
        /// <returns>last day of week</returns>
        public static DateTime GetLastDateOfWeek(DateTime dateValue)
        {
            int diffValue = DayOfWeek.Saturday - dateValue.DayOfWeek;
            DateTime lastDayOfWeek = dateValue.AddDays(diffValue);
            return lastDayOfWeek;
        }

        /// <summary>
        /// Returns the serializer settings. Common DateTime formatting with Custom formatter.
        /// </summary>
        /// <returns>JsonSerializerSettings</returns>
        public static JsonSerializerSettings GetSerializerSettings()
        {
            JsonSerializerSettings jSettings = new Newtonsoft.Json.JsonSerializerSettings()
            {
                Formatting = Newtonsoft.Json.Formatting.Indented,
                DateTimeZoneHandling = DateTimeZoneHandling.Utc
            };


            return jSettings;
        }

        /// <summary>
        /// If the Generic type base class is Status out then creates the instance of generic type
        /// else creates the instance of status out.
        /// </summary>
        /// <typeparam name="Tout">The type of the out.</typeparam>
        /// <returns>
        /// StatusOut instance
        /// </returns>
        public static StatusOut GetStatusOutInstance<Tout>() where Tout : StatusOut
        {
            StatusOut statusOut = null;
            if (IsStatusOutType(typeof(Tout)))
            {
                statusOut = (StatusOut)Activator.CreateInstance(typeof(Tout));
            }
            else
            {
                statusOut = new StatusOut();
            }
            return statusOut;
        }

        /// <summary>
        /// gets the unique id
        /// </summary>
        /// <returns>returns the unique id</returns>
        public static string GetUniqueID() => System.Guid.NewGuid().ToString();

        /// <summary>
        /// Determines whether data available in the specified db parameters.
        /// </summary>
        /// <param name="dbParams">The db parameters.</param>
        /// <returns>
        /// 	<c>true</c> if data available; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsDataFound(DbParameterCollection dbParams)
        {
            bool isDataFound = false;
            foreach (DbParameter dbParam in dbParams)
            {
                if (dbParam.Direction != ParameterDirection.Input && !IsEmpty(dbParam.Value.ToString()))
                {
                    isDataFound = true;
                    break;
                }
            }
            return isDataFound;
        }

        /// <summary>
        /// Determines whether the specified input value is null or empty.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified input value is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(string value) => (string.IsNullOrWhiteSpace(value));

        /// <summary>
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified input value is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(int value) => (value == Constants.NULL_INT);

        /// <summary>
        /// Determines whether the specified input value is minimum float value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified input value is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(ulong value) => (value == Constants.NULL_ULONG);

        /// <summary>
        /// Determines whether the specified input value is minimum float value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified input value is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(float value) => (value == Constants.NULL_FLOAT || value == Constants.NULL_INT);

        /// <summary>
        /// Determines whether the specified input value is minimum long value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified input value is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(long value) => (value == Constants.NULL_LONG || value == Constants.NULL_FLOAT || value == Constants.NULL_INT);

        /// <summary>
        /// Determines whether the specified input value is not minimum decimal value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified input value is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(decimal value) => (value.ToString("E12") == Constants.NULL_DECIMAL.ToString("E12") || value == Constants.NULL_LONG || value == Constants.NULL_INT);

        /// <summary>
        /// Determines whether the specified input value is minimum Double value .
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified input value is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(double value) => (value.ToString("E12") == Constants.NULL_DOUBLE.ToString("E12") || value == Constants.NULL_LONG || value == Constants.NULL_FLOAT || value == Constants.NULL_INT);

        /// <summary>
        /// Determines whether the specified string array value is empty.
        /// </summary>
        /// <param name="stringArrayValue">The string array value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified string array value is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(string[] stringArrayValue) => (stringArrayValue == null || stringArrayValue.Length == Constants.INT_ZERO);

        /// <summary>
        /// Determines whether the specified date array value is empty.
        /// </summary>
        /// <param name="dateArrayValue">The date array value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified date array value is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(DateTime[] dateArrayValue) => (dateArrayValue == null || dateArrayValue.Length == Constants.INT_ZERO);

        /// <summary>
        /// Determines whether the specified input value is minimum Date value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        ///   <c>true</c> if the specified input value is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(DateTime value) => (value == Constants.NULL_DATE);

        /// <summary>
        /// Determines whether the specified int array value is empty.
        /// </summary>
        /// <param name="arrayValue">The array value.</param>
        /// <returns>
        ///   <c>true</c> if the specified int array value is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(int[] arrayValue) => (arrayValue == null || arrayValue.Length == Constants.INT_ZERO);

        /// <summary>
        /// Determines whether the specified int array value is empty.
        /// </summary>
        /// <param name="arrayValue">The array value.</param>
        /// <returns>
        ///   <c>true</c> if the specified int array value is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(double[] arrayValue) => (arrayValue == null || arrayValue.Length == Constants.INT_ZERO);

        /// <summary>
        /// Determines whether the specified array value is empty.
        /// </summary>
        /// <param name="arrayValue">The array value.</param>
        /// <returns>
        /// 	<c>true</c> if the specified array value is empty; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(long[] arrayValue) => (arrayValue == null || arrayValue.Length == Constants.INT_ZERO);

        /// <summary>
        /// Determines whether [is valid status] [the specified base out].
        /// </summary>
        /// <param name="baseOut">The base out.</param>
        /// <returns>
        /// 	<c>true</c> if [is valid status] [the specified base out]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidStatus(StatusOut baseOut)
        {
            if (baseOut == null)
            {
                return false;
            }
            return IsValidStatus(baseOut.StatusList);
        }

        /// <summary>
        /// Determines whether [is valid status] [the specified status list].
        /// </summary>
        /// <param name="statusList">The status list.</param>
        /// <returns>
        /// 	<c>true</c> if [is valid status] [the specified status list]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidStatus(List<Status> statusList)
        {
            int countOfInvalidStatus = statusList.Count
                (status =>
                   !IsEmpty(status.Code)
                   && status.Code != Constants.STATUS_SUCCESS
                );
            return countOfInvalidStatus == Constants.INT_ZERO;
        }

        /// <summary>
        /// Determines whether [is valid status] [the specified status].
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns>
        /// 	<c>true</c> if [is valid status] [the specified status]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidStatus(Status status) => (IsEmpty(status.Code) || status.Code == Constants.STATUS_SUCCESS);

        /// <summary>
        /// Determines whether [is status failure] [the specified base out].
        /// </summary>
        /// <param name="baseOut">The base out.</param>
        /// <returns></returns>
        public static bool IsStatusFailure(StatusOut baseOut)
        {
            if (baseOut == null)
            {
                return false;
            }
            return IsStatusFailure(baseOut.StatusList);
        }

        /// <summary>
        /// Determines whether [is status failure] [the specified status list].
        /// </summary>
        /// <param name="statusList">The status list.</param>
        /// <returns></returns>
        public static bool IsStatusFailure(List<Status> statusList)
        {
            int countOfInvalidStatus = statusList.Count(status => !IsEmpty(status.Code) && status.Code == Constants.STATUS_FAILURE);
            return countOfInvalidStatus != Constants.INT_ZERO;
        }

        /// <summary>
        /// Determines whether [is status failure] [the specified status].
        /// </summary>
        /// <param name="status">The status.</param>
        /// <returns></returns>
        public static bool IsStatusFailure(Status status) => (IsEmpty(status.Code) || status.Code == Constants.STATUS_FAILURE);

        /// <summary>
        /// gets the length of the sourceString
        /// </summary>
        /// <param name="sourceString">sourceString is passed as parameter</param>
        /// <returns>returns the length of the sourceString</returns>
        public static int Length(string sourceString) => IsEmpty(sourceString) ? Constants.INT_ZERO : sourceString.Length;

        /// <summary>
        /// parses the stringValue to DateTime
        /// </summary>
        /// <param name="stringValue">stringValue passed as parameter</param>
        /// <returns>
        /// returns type of DateTime
        /// </returns>
        public static DateTime ParseDateTime(string stringValue) => ParseDateTime(stringValue, null);

        /// <summary>
        /// parses the stringValue to DateTime
        /// </summary>
        /// <param name="stringValue">stringValue passed as parameter</param>
        /// <returns>returns dateValue</returns>
        public static DateTime ParseDateTime(string stringValue, string format)
        {
            DateTime dateValue = Constants.NULL_DATE;
            bool isSuccess = true;
            if (format != null)
            {
                isSuccess = DateTime.TryParseExact(stringValue, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateValue);
            }
            else
            {
                isSuccess = DateTime.TryParse(stringValue, out dateValue);
            }
            if (!isSuccess)
            {
                dateValue = Constants.NULL_DATE;
            }
            return dateValue;
        }

        /// <summary>
        /// parses the stringValue to Double
        /// </summary>
        /// <param name="stringValue">stringValue passed as parameter</param>
        /// <returns>returns Double Value</returns>
        public static double ParseDouble(string stringValue)
        {
            double returnValue = Constants.NULL_DOUBLE;
            if (!double.TryParse(stringValue, out returnValue))
            {
                returnValue = Constants.NULL_DOUBLE;
            }
            return returnValue;
        }

        /// <summary>
        /// Parses the double zero.
        /// </summary>
        /// <param name="stringValue">The string value.</param>
        /// <returns>Double</returns>
        public static double? ParseDoubleZero(string stringValue)
        {
            double returnValue = Constants.INT_ZERO;
            double.TryParse(stringValue, out returnValue);
            return returnValue;
        }

        /// <summary>
        /// parses the stringValue to Decimal
        /// </summary>
        /// <param name="stringValue">stringValue passed as parameter</param>
        /// <returns>returns Decimal Value</returns>
        public static decimal ParseDecimal(string stringValue)
        {
            decimal returnValue = Constants.NULL_DECIMAL;
            if (!decimal.TryParse(stringValue, out returnValue))
            {
                returnValue = Constants.NULL_DECIMAL;
            }
            return returnValue;
        }

        /// <summary>
        /// Parses the Decimal zero.
        /// </summary>
        /// <param name="stringValue">The string value.</param>
        /// <returns>Decimal</returns>
        public static decimal? ParseDecimalZero(string stringValue)
        {
            decimal returnValue = Constants.INT_ZERO;
            decimal.TryParse(stringValue, out returnValue);
            return returnValue;
        }

        /// <summary>
		/// Parse the given string value to int
		/// </summary>
		/// <param name="stringParseToInteger">The string parse to integer.</param>
		/// <returns>
		/// The int value that is parsed from str. If invalid string value is passed the value 0 will be returned.
		/// </returns>
		public static int ParseInt(string stringParseToInteger)
        {
            int returnValue = Constants.NULL_INT;
            if (!int.TryParse(stringParseToInteger, out returnValue))
            {
                returnValue = Constants.NULL_INT;
            }
            return returnValue;
        }

        /// <summary>
        /// parses the stringValue to Int32
        /// </summary>
        /// <param name="stringValue">stringValue passed as parameter</param>
        /// <returns>returns returnValue</returns>
        public static int ParseInt32(string stringValue)
        {
            int returnValue = Constants.NULL_INT;
            if (!Int32.TryParse(stringValue, out returnValue))
            {
                returnValue = Constants.NULL_INT;
            }
            return returnValue;
        }

        /// <summary>
        /// Parses the int32 zero.
        /// </summary>
        /// <param name="stringValue">The string value.</param>
        /// <returns></returns>
        public static int? ParseInt32Zero(string stringValue)
        {
            int returnValue = Constants.INT_ZERO;
            Int32.TryParse(stringValue, out returnValue);
            return returnValue;
        }

        /// <summary>
        /// Parses the int zero.
        /// </summary>
        /// <param name="stringParseToInteger">The string parse to integer.</param>
        /// <returns></returns>
        public static int? ParseIntZero(string stringParseToInteger)
        {
            int returnValue = Constants.INT_ZERO;
            int.TryParse(stringParseToInteger, out returnValue);
            return returnValue;
        }

        /// <summary>
        /// parses the stringValue to Int32
        /// </summary>
        /// <param name="strValue">The string value.</param>
        /// <returns>
        /// returns lonValue
        /// </returns>
        public static long ParseLong(string strValue)
        {
            long longValue = Constants.NULL_LONG;
            if (!long.TryParse(strValue, out longValue))
            {
                longValue = Constants.NULL_LONG;
            }
            return longValue;
        }

        /// <summary>
        /// Parses the long zero.
        /// </summary>
        /// <param name="strValue">The STR value.</param>
        /// <returns></returns>
        public static long? ParseLongZero(string strValue)
        {
            long longValue = Constants.INT_ZERO;
            long.TryParse(strValue, out longValue);
            return longValue;
        }

        /// <summary>
        /// Parses the time from the given Date string.
        /// </summary>
        /// <param name="dateTimeValue">The string format of date time value.</param>
        /// <returns>The Time Value</returns>
        public static string ParseTime(string dateTimeValue)
        {
            string timeValue = ParseDateTime(dateTimeValue).ToShortTimeString();

            if (timeValue.Equals(Constants.NULL_TIME))
            {
                timeValue = string.Empty;
            }
            return timeValue;
        }

        /// <summary>
        /// Parses the time from the given Date.
        /// </summary>
        /// <param name="dateTimeValue">The date time value.</param>
        /// <returns>The Time Value</returns>
        public static string ParseTime(DateTime dateTimeValue)
        {
            string timeValue = string.Empty;

            if (!IsEmpty(dateTimeValue))
            {
                timeValue = dateTimeValue.ToShortTimeString();

                if (timeValue.Equals(Constants.NULL_TIME))
                {
                    timeValue = string.Empty;
                }
            }
            return ParseTime(dateTimeValue.ToString());
        }

        /// <summary>
        /// parses the stringValue to Int32
        /// </summary>
        /// <param name="strValue">The string value.</param>
        /// <returns>
        /// returns lonValue
        /// </returns>
        public static ulong ParseULong(string strValue)
        {
            ulong ulongValue = Constants.NULL_ULONG;
            if (!ulong.TryParse(strValue, out ulongValue))
            {
                ulongValue = Constants.NULL_ULONG;
            }
            return ulongValue;
        }



        /// <summary>
        /// Removes null string & trims the char.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>empty if null; removes null string & trims the char</returns>
        public static string RemoveSpacesFromChar(string value) => (value == null ? string.Empty : (value.ToString().Trim().TrimEnd('\0').Trim()));

        /// <summary>
        /// replaces the old value with new value
        /// </summary>
        /// <param name="sourceValue">sourceValue is passed as parameter</param>
        /// <param name="oldValue">old value is passed as parameter</param>
        /// <param name="newValue">newValue is passed as parameter</param>
        /// <returns>returns the sourceValue</returns>
        public static string Replace(string sourceValue, string oldValue, string newValue)
        {
            if (sourceValue == null || oldValue == null || newValue == null)
            {
                return sourceValue;
            }
            return sourceValue.Replace(oldValue, newValue);
        }

        /// <summary>
        /// Reverses the string
        /// </summary>
        /// <param name="source">source is the given string</param>
        /// <returns>returns the reversed string</returns>
        public static string ReverseString(string source)
        {
            string returnValue = string.Empty;
            List<char> result = source.ToList();
            result.Reverse();
            returnValue = new string(result.ToArray());
            return returnValue;
        }

        /// <summary>
        /// Rounds off the double value
        /// </summary>
        /// <param name="dblValue">dblValue passed as parameter</param>
        /// <param name="digit">digit passed as parameter</param>
        /// <returns>returns the rounded value</returns>
        public static double Round(double dblValue, int digit)
        {
            return Math.Round(dblValue, digit);
        }

        /// <summary>
        /// Rounds off the double value with no digit. Here MidpointRounding.AwayFromZero is used to avoid the issue Math.Round(1.5) = 2, Math.Round(2.5) = 2
        /// </summary>
        /// <param name="dblValue">dblValue passed as parameter</param>
        /// <returns>returns the rounded value</returns>
        public static double Round(double dblValue)
        {
            return Math.Round(dblValue, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        /// Rounds off the decimal value
        /// </summary>
        /// <param name="dclValue">dclValue passed as parameter</param>
        /// <param name="digit">digit passed as parameter</param>
        /// <returns>returns the rounded value</returns>
        public static decimal Round(decimal dclValue, int digit)
        {
            return Math.Round(dclValue, digit);
        }

        /// <summary>
        /// Rounds off the decimal value with no digit. Here MidpointRounding.AwayFromZero is used to avoid the issue Math.Round(1.5) = 2, Math.Round(2.5) = 2
        /// </summary>
        /// <param name="dclValue">dclValue passed as parameter</param>
        /// <returns>returns the rounded value</returns>
        public static decimal Round(decimal dclValue)
        {
            return Math.Round(dclValue, MidpointRounding.AwayFromZero);
        }

        /// <summary>
		/// Serializes the object.
		/// </summary>
		/// <param name="obj">The obj.</param>
		/// <returns></returns>
		public static string SerializeObject(object obj)
        {
            string serializedXml = string.Empty;
            if (obj != null)
            {
                MemoryStream memoryStream = new MemoryStream();
                XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
                XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8);
                xmlSerializer.Serialize(xmlTextWriter, obj);
                memoryStream = (MemoryStream)xmlTextWriter.BaseStream;
                serializedXml = UTF8ByteArrayToString(memoryStream.ToArray());
                serializedXml = serializedXml.Trim();
                serializedXml = serializedXml.Substring(1);

                if (serializedXml.Substring(0, 1) != "<")
                {
                    serializedXml = "<" + serializedXml;
                }
            }
            return serializedXml;
        }

        /// <summary>
        /// Serializes the object to json type string.
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <returns></returns>
        public static string SerializeObjectToJsonTypeString(object objectToSerialize)
        {
            string jsonString = string.Empty;
            if (objectToSerialize != null)
            {
                string className = objectToSerialize.GetType().Name;
                if (className.Equals("string", StringComparison.InvariantCultureIgnoreCase))
                {
                    jsonString = objectToSerialize.ToString();
                }
                else
                {
                    jsonString = className + " " + SerializeToJsonString(objectToSerialize);
                }
            }
            return jsonString;
        }

        /// <summary>
        /// Serializes the object to json string.
        /// </summary>
        /// <param name="objectToSerialize">The object to serialize.</param>
        /// <returns></returns>
        public static string SerializeToJsonString(object objectToSerialize)
        {
            string jsonString = string.Empty;
            if (objectToSerialize != null)
            {
                jsonString = JsonConvert.SerializeObject(objectToSerialize);
            }
            return jsonString;
        }

        /// <summary>
        /// if first value is empty returns secondValue else firstValue
        /// </summary>
        /// <param name="firstValue">firstValue is passed as parameter</param>
        /// <param name="secondValue">secondValue is passed as parameter</param>
        /// <returns>returns first value if it is not empty or returns second value</returns>
        public static string SubstituteNull(string firstValue, string secondValue = " ")
        {
            return (IsEmpty(firstValue) ? secondValue : firstValue);
        }

        /// <summary>
        /// if first value is empty returns secondValue else firstValue
        /// </summary>
        /// <param name="firstValue">firstValue is passed as parameter</param>
        /// <param name="secondValue">secondValue is passed as parameter</param>
        /// <returns>returns first value if it is not empty or returns second value</returns>
        public static int SubstituteNull(int firstValue, int secondValue = 0)
        {
            return (IsEmpty(firstValue) ? secondValue : firstValue);
        }

        /// <summary>
        /// if first value is empty returns secondValue else firstValue
        /// </summary>
        /// <param name="firstValue">firstValue is passed as parameter</param>
        /// <param name="secondValue">secondValue is passed as parameter</param>
        /// <returns>returns first value if it is not empty or returns second value</returns>
        public static double SubstituteNull(double firstValue, double secondValue = 0)
        {
            return (IsEmpty(firstValue) ? secondValue : firstValue);
        }

        /// <summary>
        /// if first value is empty returns secondValue else firstValue
        /// </summary>
        /// <param name="firstValue">firstValue is passed as parameter</param>
        /// <param name="secondValue">secondValue is passed as parameter</param>
        /// <returns>returns first value if it is not empty or returns second value</returns>
        public static long SubstituteNull(long firstValue, long secondValue = 0)
        {
            return (IsEmpty(firstValue) ? secondValue : firstValue);
        }

        /// <summary>
        /// Substitutes the null.
        /// </summary>
        /// <param name="firstValue">The first value.</param>
        /// <param name="secondValue">The second value.</param>
        /// <returns></returns>
        public static ulong SubstituteNull(ulong firstValue, ulong secondValue = 0)
        {
            return (IsEmpty(firstValue) ? secondValue : firstValue);
        }

        /// <summary>
        /// if first value is empty returns secondValue else firstValue
        /// </summary>
        /// <param name="firstValue">firstValue is passed as parameter</param>
        /// <param name="secondValue">secondValue is passed as parameter</param>
        /// <returns>returns first value if it is not empty or returns second value</returns>
        public static DateTime SubstituteNull(DateTime firstValue, DateTime secondValue)
        {
            return (IsEmpty(firstValue) ? secondValue : firstValue);
        }

        /// <summary>
        /// parses the dateTime
        /// </summary>
        /// <param name="dateTime">dateTime is passed as parameter</param>
        /// <param name="stringDate">stringDate is passed as parameter</param>
        /// <returns>returns dateTime on parsing</returns>
        public static DateTime SubstituteNull(DateTime dateTime, string stringDate)
        {
            if (IsEmpty(dateTime))
            {
                DateTime.TryParse(stringDate, out dateTime);
            }
            return dateTime;
        }

        /// <summary>
        /// parses the decimal
        /// </summary>
        /// <param name="dateTime">firstValue is passed as parameter</param>
        /// <param name="stringDate">secondValue is passed as parameter</param>
        /// <returns>returns first value if it is not empty or returns second value</returns>
        public static Decimal SubstituteNull(Decimal firstValue, Decimal secondValue = 0)
        {
            return (IsEmpty(firstValue) ? secondValue : firstValue);
        }

        /// <summary>
        /// if first value is empty returns secondValue else firstValue
        /// </summary>
        /// <param name="firstValue">The first value.</param>
        /// <param name="secondValue">The second value.</param>
        /// <returns></returns>
        public static float SubstituteNull(float firstValue, float secondValue = 0)
        {
            return (IsEmpty(firstValue) ? secondValue : firstValue);
        }

        /// <summary>
		/// gets the substring of the sourceString
		/// </summary>
		/// <param name="sourceString">sourceString is passed as parameter </param>
		/// <param name="startIndex">startIndex is the starting Index of the string</param>
		/// <returns>returns the substring of the source string</returns>
		public static string Substr(string sourceString, int startIndex)
        {
            if (IsEmpty(sourceString))
            {
                return sourceString;
            }
            if (startIndex > Constants.INT_ZERO)
            {
                startIndex--;
            }
            if (startIndex < Constants.INT_ZERO || sourceString.Length < startIndex)
            {
                return string.Empty;
            }
            return sourceString.Substring(startIndex);
        }

        /// <summary>
        /// gets the substring of the sourceString
        /// </summary>
        /// <param name="sourceString">sourceString is passed as parameter</param>
        /// <param name="startIndex">startIndex is passed as parameter</param>
        /// <param name="length">length is the length of the string</param>
        /// <returns>returns the substring of the string</returns>
        public static string Substr(string sourceString, int startIndex, int length)
        {
            if (IsEmpty(sourceString))
            {
                return sourceString;
            }
            if (startIndex > Constants.INT_ZERO)
            {
                startIndex--;
            }
            if (startIndex < Constants.INT_ZERO || sourceString.Length < (startIndex + length))
            {
                return string.Empty;
            }
            return sourceString.Substring(startIndex, length);
        }

        /// <summary>
        /// Calculates the difference in Times.
        /// </summary>
        /// <param name="firstTime">The first time.</param>
        /// <param name="secondTime">The second time.</param>
        /// <returns>Minutes between two date time values</returns>
        public static double TimeDifference(DateTime firstTime, DateTime secondTime)
        {
            // Difference in minutes.
            TimeSpan timeSpan = secondTime - firstTime;
            // Difference in minutes.
            return timeSpan.TotalMinutes;
        }

        /// <summary>
        /// Formats the string to Int32 if not empty or assigns minimum value
        /// </summary>
        /// <param name="stringValue">stringValue is passed as parameter</param>
        /// <returns>returns stringValue</returns>
        public static int ToNumberFormat(string stringValue)
        {
            if (IsEmpty(stringValue))
            {
                return Constants.NULL_INT;
            }
            return ExactParseInt32(stringValue);
        }

        /// <summary>
        /// Converts the dateTime to string format on checking the format
        /// </summary>
        /// <param name="dateTime">dateTime is passed as a parameter</param>
        /// <param name="format">format is passed as parameter</param>
        /// <returns>returns dateTime in string format</returns>
        public static string ToStringFormat(DateTime dateTime, string format)
        {
            if (format == "d" || format == "D")
            {
                return (((int)dateTime.DayOfWeek) + 1).ToString();
            }
            return dateTime.ToString(format);
        }

        /// <summary>
        /// trims the sourceString
        /// </summary>
        /// <param name="sourceString">sourceString is passed as parameter</param>
        /// <returns>
        /// returns sourceString after trimming is it not null
        /// </returns>
        public static string Trim(string sourceString)
        {
            return IsEmpty(sourceString) ? string.Empty : sourceString.Trim();
        }

        /// <summary>
        /// Updates the out data status.
        /// </summary>
        /// <param name="output">The output.</param>
        /// <param name="transactionCheckTypes">The transaction check types.</param>
        /// <param name="relatedField">The related field.</param>
        public static void UpdateStatus(StatusOut output, TransactionCheckType transactionCheckTypes, string relatedField = "")
        {
            string errorCode = Constants.STATUS_FAILURE;
            switch (transactionCheckTypes)
            {
                case TransactionCheckType.ConcurrencyFailed:
                    errorCode = ErrorConstants.E0153;
                    break;

                case TransactionCheckType.ConcurrencyFailedOnDelete:
                    errorCode = ErrorConstants.E0154;
                    break;

                case TransactionCheckType.DuplicateRecord:
                    errorCode = ErrorConstants.E0145;
                    break;

                case TransactionCheckType.NoMatchingRecords:
                    errorCode = ErrorConstants.E0012;
                    break;

                case TransactionCheckType.InsertFailed:
                    errorCode = ErrorConstants.E0113;
                    break;

                case TransactionCheckType.UpdateFailed:
                    errorCode = ErrorConstants.E0001;
                    break;

                case TransactionCheckType.DeleteFailed:
                    errorCode = ErrorConstants.E0115;
                    break;
            }
            UpdateStatus(output, errorCode, relatedField);
        }


        /// <summary>
        /// Refreshes the status.
        /// </summary>
        /// <param name="output">The output.</param>
        /// <param name="code">The code.</param>
        /// <param name="relatedField">The related field.</param>
        public static void RefreshStatus(StatusOut output, string code, string relatedField = "")
        {
            output.StatusList.Clear();
            UpdateStatus(output, code, relatedField);
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="output">The output.</param>
        /// <param name="code">The code.</param>
        /// <param name="relatedField">The related field.</param>
        public static void UpdateStatus(StatusOut output, string code, string relatedField = "")
        {
            output.StatusList.Add(new Status(code, relatedField));
        }

        /// <summary>
        /// Updates the status.
        /// </summary>
        /// <param name="output">The output.</param>
        /// <param name="code">The code.</param>
        /// <param name="description">The description.</param>
        /// <param name="relatedField">The related field.</param>
        /// <param name="row">The row.</param>
        public static void UpdateStatus(StatusOut output, string code, string description, string relatedField, int row)
        {
            output.StatusList.Add(new Status(code, description, relatedField, row));
        }

        /// <summary>
        /// Gets the uppercase of the stringValue
        /// </summary>
        /// <param name="stringValue">stringValue is passed as parameter</param>
        /// <returns>returns uppercase of the stringValue</returns>
        public static string Upper(string stringValue)
        {
            return IsEmpty(stringValue) ? string.Empty : stringValue.ToUpper();
        }

        /// <summary>
        /// UTs the f8 byte array to string.
        /// </summary>
        /// <param name="characters">The characters.</param>
        /// <returns></returns>
        public static string UTF8ByteArrayToString(Byte[] characters)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            return encoding.GetString(characters);
        }


        public static ErrorDetailsLogData UpdateStatus(
            Exception exception,
            object input,
            StatusOut output,
            string detailLogData = ""
            )
        {

            string errorCode = string.Empty;
            string expMessage = exception.Message.ToLower();
            if (exception is SqlException)
            {
                if (expMessage.Contains(Constants.DATABASE_ENGINE_DEADLOCK_VICTIM))
                {
                    errorCode = ErrorConstants.E1193;
                }
            }
            else if (expMessage.Contains(Constants.EXCEPTION_CONNECT_ERROR))
            {
                errorCode = ErrorConstants.E2113;
            }
            else if (expMessage.Contains(Constants.EXCEPTION_ABORTED_CONNECT_ERROR)
                || expMessage.Contains(Constants.EXCEPTION_REQUEST_CHANNEL_ERROR)
                || expMessage.Contains(Constants.EXCEPTION_CLOSED_CONNECT_ERROR)
                || expMessage.Contains(Constants.EXCEPTION_REMOTE_CERTIFICATE_ERROR))
            {
                errorCode = ErrorConstants.I0108;
            }
            string exceptionMessage = exception.Message;
            List<string> messageList = new List<string>
            {
                exceptionMessage
            };
            if (exception.InnerException != null)
            {
                messageList.Add(exception.InnerException.Message);
            }
            string baseexceptionMessage = exception.GetBaseException().Message;

            if (!baseexceptionMessage.Equals(exceptionMessage))
            {
                messageList.Add($"(BaseException: {baseexceptionMessage} )");
            }
            messageList.Add(exception.StackTrace);

            string message = "Application Exception : " + string.Join(Environment.NewLine, messageList);

            if (output != null)
            {
                if (string.IsNullOrEmpty(errorCode))
                {
                    output.StatusList.Add(new Status(Constants.STATUS_FAILURE, message, Constants.INT_ZERO));
                }
                else
                {
                    output.StatusList.Add(new Status(errorCode));
                }
            }
            StackTrace stackTrace = new StackTrace();
            int counter = 1;
            string frameName = stackTrace.GetFrame(counter).GetMethod().Name;
            while (frameName.Equals("InvokeBusinessMethod", StringComparison.InvariantCultureIgnoreCase) || frameName.Equals("WriteToLogAndUpdateStatus", StringComparison.InvariantCultureIgnoreCase))
            {
                counter++;
                if (stackTrace.GetFrames().Length >= counter)
                {
                    frameName = stackTrace.GetFrame(counter).GetMethod().Name;
                }
            }
            if (input is IList)
            {
                IList inputList = (IList)input;
                if (inputList.Count > 0)
                {
                    DataModelBase dataModelBase = (DataModelBase)inputList[0];
                }
            }
            else if (input != null)
            {
                DataModelBase dataModelBase = (DataModelBase)input;
            }

            ErrorDetailsLogData logErrorDetailsInData = new ErrorDetailsLogData()
            {
                TypeText = exception.ToString(),
                BusinessObject = frameName,
                InputJSON = UtilityHandler.SerializeObjectToJsonTypeString(input),
                StatusJSON = (output != null) ? UtilityHandler.SerializeObjectToJsonTypeString(output.StatusList) : string.Empty,
                ScriptErrorText = exception.Message,
                StackTraceText = ((UtilityHandler.IsEmpty(exception.StackTrace)) ? exception.Message : exception.StackTrace),
                BaseExceptionText = exception.GetBaseException().Message,
                InnerExceptionText = (exception.InnerException != null) ? exception.InnerException.Message : Constants.SYMBOL_HYPEN_WITH_SPACE,
                InnerExceptionStackText = ((exception.InnerException != null) ? ((UtilityHandler.IsEmpty(exception.InnerException.StackTrace)) ? exception.InnerException.Message : exception.InnerException.StackTrace) : Constants.SYMBOL_HYPEN_WITH_SPACE)
            };

            return logErrorDetailsInData;
        }

        /// <summary>
        /// Updates the status on finally.
        /// </summary>
        /// <param name="output">The output.</param>
        /// <param name="executionTrackerList">The execution tracker list.</param>
        public static void UpdateStatus(StatusOut output, List<ProcessStep> executionTrackerList)
        {
            //If output is not null, check for valid status.
            if (output != null)
            {
                //If no status is set, set success message
                if (output.StatusList.Count == Constants.INT_ZERO)
                {
                    output.StatusList.Add(new Status(Constants.STATUS_SUCCESS));
                }
                else
                {
                    //Identify if the word deadlock victim is found in the description, as from batch this will be sent as description
                    List<Status> deadLockStatusList = (from status in output.StatusList
                                                       where !IsEmpty(status.Code)
                                                           && status.Code == Constants.STATUS_FAILURE
                                                           && status.Description.ToLower().Contains(Constants.DATABASE_ENGINE_DEADLOCK_VICTIM)
                                                       select status).ToList();

                    //Change the error code & description for deadlock victim status
                    deadLockStatusList.ForEach(status =>
                    {
                        int particularRowNo = output.StatusList.IndexOf(status);
                        Status deadLockStatus = new Status(ErrorConstants.E1193);
                        output.StatusList[particularRowNo] = deadLockStatus;
                    });
                }
            }
        }

        /// <summary>
        /// Determines whether object's base class is StatusOut.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        ///   <c>true</c> if [is status out type] [the specified object type]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsStatusOutType(Type objectType)
        {
            if (objectType == typeof(StatusOut))
            {
                return true;
            }
            if (objectType == typeof(object))
            {
                return false;
            }
            return IsStatusOutType(objectType.BaseType);
        }


        public static string DoXmlToHtmlTransfrom(string xml, string xslPath)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load(xslPath);
            StringBuilder sb = new StringBuilder();
            using (TextReader reader = new StringReader(xml))
            {
                XmlReader xmlReader = XmlReader.Create(reader);
                XPathDocument xPathDocument = new XPathDocument(xmlReader);
                using (StringWriter writer = new StringWriter(sb))
                {
                    xslt.Transform(xPathDocument, null, writer);
                }
            }
            return sb.ToString().Replace("~~~", "<br/>");
        }

        public static bool SendEmail(string from,
          string to,
          string cc,
          string bcc,
          string subject,
          string body,
          List<string> files = null)
        {
            try
            {
                if (from == string.Empty)
                {
                    throw new ApplicationException("Required From Mail ID");
                }
                if (to == string.Empty)
                {
                    throw new ApplicationException("Required To Mail ID");
                }
                string smtpServerName = Settings.Default.SmtpMailServer;
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient(smtpServerName);
                mail.From = new MailAddress(from);
                List<MailAddress> mads = GetMailAddress(to);
                foreach (MailAddress a in mads)
                {
                    mail.To.Add(a);
                }
                mads = GetMailAddress(cc);
                foreach (MailAddress a in mads)
                {
                    mail.CC.Add(a);
                }
                mads = GetMailAddress(bcc);
                foreach (MailAddress a in mads)
                {
                    mail.Bcc.Add(a);
                }
                mail.Subject = subject;
                mail.Body = body;
                //Attach the file 
                if (files != null)
                {
                    foreach (string attachmentFileName in files)
                    {
                        if (File.Exists(attachmentFileName))
                        {
                            mail.Attachments.Add(new Attachment(attachmentFileName));
                        }
                    }
                }
                mail.IsBodyHtml = true;
                smtpServer.Port = 25;
                smtpServer.EnableSsl = false;
                smtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                Logger.LogError("SendMail", ex.Message);
                return false;
            }
        }

        private static List<MailAddress> GetMailAddress(string ma)
        {
            List<MailAddress> output = new List<MailAddress>();
            if (ma == string.Empty)
            {
                return output;
            }
            string[] sa = ma.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in sa)
            {
                output.Add(new MailAddress(s));
            }
            return output;
        }

        public static string HtmlEncode(string s)
        {
            string t = s.Replace("&", "&amp;").Replace(">", "&gt;").Replace("<", "&lt;");
            return t.Replace("\r\n", "~~~").Replace("\n", "~~~").Replace("\r", "~~~");
        }

        public static void Export2Csv(string fileName, DataSet ds)
        {
            if (ds == null || ds.Tables.Count == 0 || ds.Tables[0].Rows.Count == 0)
            {
                throw new ApplicationException("No Data found");
            }
            DataTable dt = ds.Tables[0];
            using (StreamWriter file = new System.IO.StreamWriter(fileName))
            {
                List<string> cells = new List<string>();
                foreach (DataColumn dc in dt.Columns)
                {
                    cells.Add(dc.ColumnName);
                }
                string line = string.Join(",", cells.ToArray());
                file.WriteLine(line);
                foreach (DataRow row in dt.Rows)
                {
                    cells = new List<string>();
                    foreach (DataColumn dc in dt.Columns)
                    {
                        cells.Add(row[dc.ColumnName].ToString());
                    }
                    line = string.Join(",", cells.ToArray());
                    file.WriteLine(line);
                }
                file.Close();
            }
        }


        public static HttpClient GetHttpClient()
        {
            HttpClientHandler handler = new HttpClientHandler
            {
                UseDefaultCredentials = true
            };
            HttpClient client = new HttpClient(handler);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static DateTime GetBindableDate(DateTime input)
        {
            DateTime disDate = DateTime.Parse("1/1/1900");
            if (input.Date <= disDate.Date
               || input.Date == Constants.MAX_DATE)
            {
                return disDate;
            }
            return input;
        }

        public static DateTime GetDataBaseDate(DateTime input)
        {
            DateTime disDate = DateTime.Parse("1/1/1900");
            return (input <= disDate) ? DateTime.MinValue : input;
        }

        public static string GetDisplayDate(DateTime input)
        {
            DateTime disDate = DateTime.Parse("1/1/1900");
            if (input.Date <= disDate.Date
               || input.Date == Constants.MAX_DATE)
            {
                return string.Empty;
            }
            return input.ToString("MM/dd/yyyy");
        }

        public static bool GetBooleanValue(string input)
        {
            return (input.ToUpper().Trim()) switch
            {
                Constants.YES_INDC => true,
                _ => false,
            };
        }

        public static string GetIndcValue(bool input)
        {
            if (input)
            {
                return Constants.YES_INDC;
            }
            else
            {
                return Constants.NO_INDC;
            }
        }
        public static bool UpdateShareValueData(ShareMarketValueData input,
                                 OutData<TimeSeriesIntradayData> timeSeries)
        {
            if (!UtilityHandler.IsValidStatus(timeSeries))
            {
                return false;
            }
            TimeSeriesIntradayData series = timeSeries.Data;
            if (series.Data.Count > 0)
            {
                TimeSeriesData data = series.Data[0];
                input.HighAmnt = data.High;
                input.LowAmnt = data.Low;
                input.OpenAmnt = data.Open;
                input.CloseAmnt = data.Close;
                input.VolumeCount = data.Volume;
                input.CurrentAmnt = data.High;
                input.TradeDate = data.TradeDate;
                return true;
            }
            return false;
        }

        public static bool UpdateCompanyData(ShareMarketValueData input,
                                            OutData<CompanyOverviewData> company)
        {
            if (!UtilityHandler.IsValidStatus(company))
            {
                return false;
            }
            CompanyOverviewData data = company.Data;
            input.TradeName = data.Name;
            input.RegionName = data.Country;
            input.CurrencyCode = data.Currency;
            input.TypeCode = data.AssetType;
            input.CountryCode = data.Country;
            input.ExchangeCode = data.Exchange;
            input.SectorName = data.Sector;
            input.IndustryName = data.Industry;
            input.FTEmployeesCount = data.FullTimeEmployees;
            input.LatestQuarterDate = data.LatestQuarter;
            input.MarketGapNumb = data.MarketCapitalization;
            input.PERatioNumb = data.PEGRatio;
            input.BookValueNumb = data.BookValue;
            input.DividendPerShareAmnt = data.DividendPerShare;
            input.DividendYieldNumb = data.DividendYield;
            input.EpsNumb = data.EPS;
            input.Week52HighAmnt = data.Week52High;
            input.Week52LowAmnt = data.Week52Low;
            input.Day50MovAvgAmnt = data.Day50MovingAverage;
            input.Day200MovAvgAmnt = data.Day200MovingAverage;
            input.DividendDate = data.DividendDate;
            input.ExDividendDate = data.ExDividendDate;
            return true;
        }

        public static DataTable ToDataTable<T>(List<T> data,
                                            List<ExcelColumn> columns = null,
                                            string tableName = "")
        {
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable(tableName);
            if (columns != null)
            {
                foreach (ExcelColumn col in columns)
                {
                    dt.Columns.Add(col.ColumnName, col.DataType);
                }
            }
            else
            {
                foreach (PropertyDescriptor prop in props)
                {
                    dt.Columns.Add(prop.Name, prop.PropertyType); //
                }
            }
            foreach (T rec in data)
            {
                DataRow row = dt.NewRow();
                dt.Rows.Add(row);
                foreach (PropertyDescriptor prop in props)
                {
                    string value = string.Empty;

                    if (prop.GetValue(rec) is System.DateTime)
                    {
                        DateTime date = (DateTime)prop.GetValue(rec);
                        if (date == DateTime.MinValue)
                        {
                            continue;
                        }
                        value = date.ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        object o = prop.GetValue(rec);
                        if (o != null)
                        {
                            value = o.ToString();
                        }
                    }

                    if (dt.Columns.Contains(prop.Name))
                    {
                        ExcelColumn col = GetExcelColumn(columns, prop.Name);
                        if (col.IndicatorColumn)
                        {
                            value = (value == Constants.YES_INDC) ? "Yes" : string.Empty;
                        }
                        row[prop.Name] = value;
                    }
                }

            }

            //Change the display Name 
            foreach (ExcelColumn col in columns)
            {
                if (UtilityHandler.IsEmpty(col.DisplayName))
                {
                    continue;
                }
                if (col.ColumnName != col.DisplayName
                    && dt.Columns.Contains(col.ColumnName))
                {
                    dt.Columns[col.ColumnName].ColumnName = col.DisplayName;
                }
            }
            dt.AcceptChanges();
            return dt;
        }

        private static ExcelColumn GetExcelColumn(List<ExcelColumn> columns, string name)
        {
            foreach (ExcelColumn col in columns)
            {
                if (string.Compare(col.ColumnName, name, true) == 0)
                {
                    return col;
                }
            }
            return null;
        }

        public static DataTable CleanData(DataTable dt)
        {

            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    string value = row[dc.ColumnName].ToString();
                    if (dc.ColumnName.EndsWith("Date"))
                    {
                        DateTime dateValue = DateTime.MinValue;
                        DateTime.TryParse(value, out dateValue);
                        if (dateValue == DateTime.MinValue)
                        {
                            row[dc.ColumnName] = string.Empty;
                        }
                    }
                }
            }
            return dt;
        }

        public static List<string> GetSplitCsvLine(string line)
        {
            List<string> output = new List<string>();
            line = $"{line}  ";
            int startPos = 0;
            bool inQuote = false;
            for (int i = 0; i < line.Length; i++)
            {
                string ch = line.Substring(i, 1);
                switch (ch)
                {
                    case "\"":
                        inQuote = !inQuote;
                        break;
                    case ",":
                        if (!inQuote)
                        {
                            string token = line[startPos..i].Trim().Replace("\"", string.Empty);
                            output.Add(token);
                            startPos = i + 1;
                        }
                        break;
                }
            }
            if (startPos < line.Length - 1)
            {
                output.Add(line[startPos..].Trim().Replace("\"", string.Empty));
            }
            return output;
        }

    }



}