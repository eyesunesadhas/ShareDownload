using ShareMarketDownload.Const;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ShareMarketDownload.Business
{
    public sealed class UtilityHandler
    {
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

        #region Check Empty validation methods

        /// <summary>
        /// Checks if the given input is Empty
        /// </summary>
        /// <param name="value">The input value to be checked for Empty</param>
        /// <returns>
        ///   <c>true</c> if given value is null or empty ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(string value)
        {
            return UtilityHandler.IsEmpty(value);
        }

        /// <summary>
        /// Checks if the given input is Empty
        /// </summary>
        /// <param name="value">The input value to be checked for Empty</param>
        /// <returns>
        ///   <c>true</c> if given value is null or empty ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(int value)
        {
            return UtilityHandler.IsEmpty(value);
        }

        /// <summary>
        /// Checks if the given input is Empty
        /// </summary>
        /// <param name="value">The input value to be checked for Empty</param>
        /// <returns>
        ///   <c>true</c> if given value is null or empty ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(double value)
        {
            return UtilityHandler.IsEmpty(value);
        }

        /// <summary>
        /// Checks if the given input is Empty
        /// </summary>
        /// <param name="value">The input value to be checked for Empty</param>
        /// <returns>
        /// 	<c>true</c> if given value is null or empty ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(decimal value)
        {
            return UtilityHandler.IsEmpty(value);
        }

        /// <summary>
        /// Checks if the given input is Empty
        /// </summary>
        /// <param name="value">The input value to be checked for Empty</param>
        /// <returns>
        ///   <c>true</c> if given value is null or empty ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(long value)
        {
            return UtilityHandler.IsEmpty(value);
        }

        /// <summary>
        /// Checks if the given input is Empty
        /// </summary>
        /// <param name="value">The input value to be checked for Empty</param>
        /// <returns>
        ///   <c>true</c> if given value is null or empty ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(float value)
        {
            return UtilityHandler.IsEmpty(value);
        }

        /// <summary>
        /// Checks if the given input is Empty
        /// </summary>
        /// <param name="value">The input value to be checked for Empty</param>
        /// <returns>
        ///   <c>true</c> if given value is null or empty ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(ulong value)
        {
            return UtilityHandler.IsEmpty(value);
        }

        /// <summary>
        /// Checks if the given input is Empty
        /// </summary>
        /// <param name="value">The input value to be checked for Empty</param>
        /// <returns>
        ///   <c>true</c> if given value is null or empty ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(DateTime value)
        {
            return UtilityHandler.IsEmpty(value);
        }

        /// <summary>
        /// validates if the date time for null date
        /// </summary>
        /// <param name="dateTime">value to be validated</param>
        /// <returns>
        ///   <c>true</c> if given value is null or empty ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsEmpty(DateTime? dateTime)
        {
            // Return true if the dateTime is null
            if (dateTime == null)
            {
                return true;
            }

            // Return true if the dateTime is  default date
            if (dateTime == Constants.NULL_DATE)
            {
                return true;
            }
            return false;
        }

        #endregion Check Empty validation methods

    }
}
