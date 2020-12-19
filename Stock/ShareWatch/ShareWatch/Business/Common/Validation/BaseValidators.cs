using ShareWatch.Common;
using ShareWatch.Common.DataStore;
using ShareWatch.Common.Utility;
using ShareWatch.Const;
using System;
using System.Text.RegularExpressions;

namespace ShareWatch.BusinessLogic.Common.Validation
{
    /// <summary>
    /// The Basic Validation and Simple validation are done
    /// </summary>
    public sealed partial class BaseValidators
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseValidators" /> class.
        /// </summary>
        private BaseValidators()
        {
        }

        #region Private Constants

        private const string CONFIRMED_BAD = "B";
        private const string SSN_TYPE_ITIN = "I";

        #endregion Private Constants

        #region Private Methods

        /// <summary>
        /// Determines whether [is regular expression matches] [the specified expression].
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <param name="value">The value to be validated.</param>
        /// <returns>
        ///   <c>true</c> if [is regular expression matches] [the specified expression]; otherwise, <c>false</c>.
        /// </returns>
        private static bool IsRegularExpressionMatches(string expression, string value)
        {
            Regex regularExpression = new Regex(expression);
            return (regularExpression.Match(value).Success);
        }

        #endregion Private Methods

        #region Amount Validations

        /// <summary>
        /// Checks if the given input value is Negative
        /// </summary>
        /// <param name="value">The input to check for Negative number</param>
        /// <returns>
        ///   <c>true</c> if [Is Amount Negative] ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAmountNegative(double value)
        {
            return (!IsEmpty(value) && value < Constants.INT_ZERO);
        }

        /// <summary>
        /// Checks if the given input value is Negative
        /// </summary>
        /// <param name="value">The input to check for Negative number</param>
        /// <returns>
        ///   <c>true</c> if [Is Amount Negative] ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAmountNegative(long value)
        {
            return (!IsEmpty(value) && value < Constants.INT_ZERO);
        }

        /// <summary>
        /// Checks if the given input is valid Amount. Checks for the given input to
        /// be valid numeric with "." and "-" (negative) symbol allowed
        /// </summary>
        /// <param name="amount">The input to check for valid Amount</param>
        /// <returns>
        ///   <c>true</c> if [Is Valid Amount ] ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidAmount(string amount)
        {
            // Return true if the amount is empty
            if (IsEmpty(amount))
            {
                return true;
            }
            return !IsRegularExpressionMatches("[^0-9.-]", amount);
        }

        /// <summary>
        /// Checks if the given input is valid Amount.
        /// </summary>
        /// <param name="amount">The input to check for valid Amount</param>
        /// <returns>
        ///   <c>true</c> if [Is Valid Amount ] ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidAmount(long amount)
        {
            return IsValidNumeric(amount);
        }

        /// <summary>
        /// Checks if the given input is valid Amount.
        /// </summary>
        /// <param name="amount">The input to check for valid Amount</param>
        /// <returns>
        ///   <c>true</c> if [Is Valid Amount ] ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidAmount(double amount)
        {
            return IsValidNumeric(amount);
        }

        /// <summary>
        /// Checks if the given input is valid Amount.
        /// </summary>
        /// <param name="amount">The input to check for valid Amount</param>
        /// <returns>
        /// 	<c>true</c> if [Is Valid Amount ] ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidAmount(decimal amount)
        {
            return IsValidNumeric(amount);
        }

        /// <summary>
        /// Checks if the given input value is Negative
        /// </summary>
        /// <param name="value">The input to check for Negative number</param>
        /// <returns>
        /// 	<c>true</c> if [Is Amount Negative] ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsAmountNegative(decimal value)
        {
            return (!IsEmpty(value) && value < Constants.INT_ZERO);
        }

        #endregion Amount Validations

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

        #region DateTime validations

        /// <summary>
        /// Checks if the From Date is the First day of the month. Returns true if
        /// input date matches the first day of the month, false if doesn't match.
        /// </summary>
        /// <param name="dateFirst">Date to be checked</param>
        /// <returns>
        ///   <c>true</c> if input date matches the first day of the month; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFirstDayOfTheMonth(DateTime dateFirst)
        {
            // Check for datFirst is not empty, if it is empty return false
            if (!IsEmpty(dateFirst))
            {
                // Return true if dateFirst is equal to one otherwise return false
                if (dateFirst.Day == Constants.INT_ONE)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checks if the given input is Current or Future Date
        /// </summary>
        /// <param name="date">The input to check for Current or Future Date.</param>
        /// <returns>
        ///   <c>true</c> if input date is Current or Future Date; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFutureCurrentDate(DateTime date)
        {
            // Return false if date is empty
            if (IsEmpty(date))
            {
                return false;
            }
            try
            {
                return (date.Date.CompareTo(UtilityBL.CurrentDate.Date) >= Constants.INT_ZERO);
            }
            catch (FormatException)
            {
                // The error is logged as information as it is handled in the class
                //DoLog.WriteInfoLog(null, exception.Message);
            }
            return false;
        }

        /// <summary>
        /// Checks if the given input is Future Date
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        ///   <c>true</c> if input date is Future Date; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFutureDate(DateTime date)
        {
            // Return false if date is empty
            if (IsEmpty(date))
            {
                return false;
            }
            try
            {
                return (date.Date.CompareTo(UtilityBL.CurrentDate.Date) > Constants.INT_ZERO);
            }
            catch (FormatException)
            {
                // DoLog.WriteInfoLog(null, exception.Message);
            }
            return false;
        }

        /// <summary>
        /// Checks if the To Date is the last day of the month. Returns true if input
        /// date matches the last day of the month, false if doesn't match.
        /// </summary>
        /// <param name="dateLast">Date to be checked</param>
        /// <returns>
        ///   <c>true</c> if input date matches the last day of the month; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsLastDayOfTheMonth(DateTime dateLast)
        {
            // Check for dateLast is not empty, if it is empty return false
            if (!IsEmpty(dateLast))
            {
                int daysInMonth = DateTime.DaysInMonth(dateLast.Year, dateLast.Month);

                // Return true if daysInMonth is Last Day of month otherwise return false
                if (daysInMonth == dateLast.Day)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Determines whether [is past current date] [the specified date].
        /// </summary>
        /// <param name="date">The input to check for Current or Past Date.</param>
        /// <returns>
        ///   <c>true</c> if [is past current date] [the specified date]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsPastCurrentDate(DateTime date)
        {
            // Return false if the date is empty
            if (IsEmpty(date))
            {
                return false;
            }
            try
            {
                return (date.Date.CompareTo(UtilityBL.CurrentDate.Date) <= Constants.INT_ZERO);
            }
            catch (FormatException)
            {
                // The error is logged as information as it is handled in the class
                //DoLog.WriteInfoLog(null, exception.Message);
            }
            return false;
        }

        /// <summary>
        /// Determines whether [is past date] [the specified date].
        /// </summary>
        /// <param name="date">The input to check for Past Date.</param>
        /// <returns>
        ///   <c>true</c> if [is past date] [the specified date]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsPastDate(DateTime date)
        {
            // Return false if the date is empty
            if (IsEmpty(date))
            {
                return false;
            }
            try
            {
                return (date.Date.CompareTo(UtilityBL.CurrentDate.Date) < Constants.INT_ZERO);
            }
            catch (FormatException)
            {
                // The error is logged as information as it is handled in the class
                // DoLog.WriteInfoLog(null, exception.Message);
            }
            return false;
        }

        /// <summary>
        /// Checks if the given input is Current Date (date == today)
        /// </summary>
        /// <param name="date">The input to check for Past Date.</param>
        /// <returns>
        ///   <c>true</c> if input date is Current date ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsToday(DateTime date)
        {
            // Return true if the date is empty
            if (IsEmpty(date))
            {
                return true;
            }
            try
            {
                return (date.Date.CompareTo(UtilityBL.CurrentDate.Date) == Constants.INT_ZERO);
            }
            catch (FormatException)
            {
                // The error is logged as information as it is handled in the class
                //DoLog.WriteInfoLog(null, exception.Message);
            }
            return false;
        }

        /// <summary>
        /// Checks if the given input valid Date
        /// </summary>
        /// <param name="value">The input to check for valid Date</param>
        /// <returns>
        ///   <c>true</c> if input date is valid date ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidDate(string value)
        {
            // Return true if the value is empty
            if (UtilityHandler.IsEmpty(value))
            {
                return true;
            }
            bool isValid = false;

            // Return false if the length of the input argument is not 10.
            if (value.Length != 10)
            {
                return isValid;
            }
            try
            {
                DateTime.ParseExact(value, Constants.US_DATE_FORMAT, null);
                isValid = true;
            }
            catch (FormatException)
            {
                // The error is logged as information as it is handled in the class
                // DoLog.WriteInfoLog(null, exception.Message);
            }
            return isValid;
        }

        /// <summary>
        /// Checks if the given input valid Date.
        /// </summary>
        /// <param name="value">The input to check for valid Date</param>
        /// <returns>
        ///   <c>true</c> if input date is valid date ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidDate(DateTime? value)
        {
            // Return true if the value is empty
            if (IsEmpty(value))
            {
                return true;
            }
            DateTime dateTime = UtilityBL.CurrentDate;
            try
            {
                dateTime = DateTime.ParseExact(Constants.INVALID_DATE, Constants.US_DATE_FORMAT, null);
                return (value.Value.CompareTo(dateTime) != Constants.INT_ZERO);
            }
            catch (FormatException)
            {
                // DoLog.WriteInfoLog(null, exception.Message);
            }
            return false;
        }

        /// <summary>
        /// Checks if the given input valid DateTime
        /// </summary>
        /// <param name="date">The date.</param>
        /// <returns>
        ///   <c>true</c> if input date is valid dateTime ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidDateTime(DateTime date)
        {
            // Return true if the date is empty
            if (IsEmpty(date))
            {
                return true;
            }
            DateTime dateTime = UtilityBL.CurrentDate;
            try
            {
                dateTime = DateTime.ParseExact(Constants.INVALID_DATE, Constants.US_DATE_FORMAT, null);
                return (date.CompareTo(dateTime) != Constants.INT_ZERO);
            }
            catch (FormatException)
            {
                //  The error is logged as information as it is handled in the class
                //  DoLog.WriteInfoLog(null, exception.Message);
            }
            return false;
        }

        #endregion DateTime validations

        #region Minimum Length Validations

        /// <summary>
        /// Checks if the Minimum length criteria is met.
        /// </summary>
        /// <param name="value">The value that needs to be checked for Minimum Length</param>
        /// <param name="length">The length to be met</param>
        /// <returns>
        ///   <c>true</c> if given value length is less than Minimum length; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMinLength(string value, int length)
        {
            return (!IsEmpty(value) && value.Length < length);
        }

        /// <summary>
        /// Checks if the Minimum length criteria is met.
        /// </summary>
        /// <param name="value">The value that needs to be checked for Minimum Length</param>
        /// <param name="length">The length to be met</param>
        /// <returns>
        ///   <c>true</c> if given value length is less than Minimum length; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMinLength(int value, int length)
        {
            return (!IsEmpty(value) && System.Convert.ToString(value).Length < length);
        }

        /// <summary>
        /// Checks if the Minimum length criteria is met.
        /// </summary>
        /// <param name="value">The value that needs to be checked for Minimum Length</param>
        /// <param name="length">The length to be met</param>
        /// <returns>
        ///   <c>true</c> if given value length is less than Minimum length; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMinLength(long value, int length)
        {
            return (!IsEmpty(value) && System.Convert.ToString(value).Length < length);
        }

        /// <summary>
        /// Validates for minimum length
        /// </summary>
        /// <param name="value">value which needs to be validated</param>
        /// <param name="length">length for which it needs to be validated</param>
        /// <returns>
        ///   <c>true</c> if given value length is less than Minimum length; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMinLength(float value, int length)
        {
            return (!IsEmpty(value) && value.ToString().Length < length);
        }

        /// <summary>
        /// Validates for minimum length
        /// </summary>
        /// <param name="value">value which needs to be validated</param>
        /// <param name="length">length for which it needs to be validated</param>
        /// <returns>
        ///   <c>true</c> if given value length is less than Minimum length; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMinLength(double value, int length)
        {
            return (!IsEmpty(value) && value.ToString().Length < length);
        }

        /// <summary>
        /// Checks if the Minimum length criteria is met.
        /// </summary>
        /// <param name="value">The value that needs to be checked for Minimum Length</param>
        /// <param name="length">The maximum length allowed for the value</param>
        /// <param name="scale">The precision after the decimal point.</param>
        /// <param name="minimumLength">The length to be met</param>
        /// <returns>
        ///   <c>true</c> if given value length is less than Minimum length; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMinLength(double value, int length, int scale, int minimumLength)
        {
            // Return false if value is empty or invalid numeric
            if (IsEmpty(value) || !IsValidNumeric(value))
            {
                return false;
            }
            string localScale = string.Empty;
            string formatValue = Constants.CHAR_ZERO;

            // Assign default value for localScale identifier
            for (int i = Constants.INT_ZERO; i < length; i++)
            {
                // Assign Zero for localScale if i is less than scale value  otherwise assign Hash value
                if (i < scale)
                {
                    localScale += Constants.CHAR_ZERO;
                }
                else
                {
                    localScale += Constants.SYMBOL_HASH;
                }
            }

            // Assign length if value's decimalPoint length not equal to -1
            if (scale > Constants.INT_ZERO && value.ToString().IndexOf(Constants.SYMBOL_DECIMAL_POINT, StringComparison.InvariantCultureIgnoreCase) != -1)
            {
                formatValue += (Constants.SYMBOL_DECIMAL_POINT + localScale);

                // Length increased to accommodate the Constants.DECIMAL_POINT
                length += Constants.SYMBOL_DECIMAL_POINT.Length;
            }

            // Assign length with negative sign if value is less than zero
            if (value < Constants.INT_ZERO)
            {
                // One character for the Constants.NEGATIVE_SIGN sign
                length += Constants.SYMBOL_NEGATIVE_SIGN.Length;
            }
            string stringValue = value.ToString(formatValue);
            return (stringValue.Length < minimumLength);
        }

        /// <summary>
        /// Checks if the Minimum length criteria is met.
        /// </summary>
        /// <param name="value">The value that needs to be checked for Minimum Length</param>
        /// <param name="length">The maximum length allowed for the value</param>
        /// <param name="scale">The precision after the decimal point.</param>
        /// <param name="minLength">The length to be met</param>
        /// <returns>
        ///   <c>true</c> if given value length is less than Minimum length; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsMinLength(float value, int length, int scale, int minLength)
        {
            // Return false if value is empty or invalid numeric
            if (IsEmpty(value) || !IsValidNumeric(value))
            {
                return false;
            }
            string localScale = string.Empty;
            string format = Constants.CHAR_ZERO;

            // Assign default value for localScale identifier
            for (int i = Constants.INT_ZERO; i < length; i++)
            {
                // Assign localScale with zero if i less than scale otherwise with Hash
                if (i < scale)
                {
                    localScale += Constants.CHAR_ZERO;
                }
                else
                {
                    localScale += Constants.SYMBOL_HASH;
                }
            }

            // Assign length if value's decimalPoint length not equal to -1
            if (scale > Constants.INT_ZERO && value.ToString().IndexOf(Constants.SYMBOL_DECIMAL_POINT, StringComparison.InvariantCultureIgnoreCase) != -1)
            {
                format += (Constants.SYMBOL_DECIMAL_POINT + localScale);
                // Len increased to accommodate the Constants.DECIMAL_POINT
                length += Constants.SYMBOL_DECIMAL_POINT.Length;
            }

            // Assign length with negative sign if value is less than zero
            if (value < Constants.INT_ZERO)
            {
                // One character for the Constants.NEGATIVE_SIGN sign
                length += Constants.SYMBOL_NEGATIVE_SIGN.Length;
            }
            string formattedValue = value.ToString(format);
            return (formattedValue.Length < minLength);
        }

        #endregion Minimum Length Validations

        #region Over Size Validations

        /// <summary>
        /// Check if the Maximum allowed length is exceeded
        /// </summary>
        /// <param name="value">The value that needs to be checked for Maximum Length</param>
        /// <param name="length">The length to be met</param>
        /// <returns>
        ///   <c>true</c> if given value length is less than Maximum length; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOverSize(string value, int length)
        {
            return (!IsEmpty(value) && value.Length > length);
        }

        /// <summary>
        /// validates if the input is oversize
        /// </summary>
        /// <param name="value">input to be validated</param>
        /// <param name="length">length against which to be validated</param>
        /// <returns>
        ///   <c>true</c> if given value length is less than Maximum length; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOverSize(int value, int length)
        {
            // Return false if Input value is empty or invalid numeric
            if (IsEmpty(value) || !IsValidNumeric(value))
            {
                return false;
            }
            return (value.ToString().Length > length);
        }

        /// <summary>
        /// validates if the input is oversize
        /// </summary>
        /// <param name="value">input to be validated</param>
        /// <param name="length">length against which to be validated</param>
        /// <returns>
        ///   <c>true</c> if given value length is less than Maximum length; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOverSize(long value, int length)
        {
            // Return false if Input value is empty or invalid numeric
            if (IsEmpty(value) || !IsValidNumeric(value))
            {
                return false;
            }
            return (value.ToString().Length > length);
        }

        /// <summary>
        /// validates if the input is oversize
        /// </summary>
        /// <param name="value">input to be validated</param>
        /// <param name="length">length against which to be validated</param>
        /// <returns>
        ///   <c>true</c> if given value length is less than Maximum length; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOverSize(double value, int length)
        {
            // Return false if Input value is empty or invalid numeric
            if (IsEmpty(value) || !IsValidNumeric(value))
            {
                return false;
            }
            string formattedValue = value.ToString("0.00");
            return (formattedValue.Length > length);
        }

        /// <summary>
        /// Check if the Maximum allowed length is exceeded
        /// </summary>
        /// <param name="value">The value that needs to be checked for Maximum Length</param>
        /// <param name="length">The length to be met</param>
        /// <param name="scale">The precision after the decimal point.</param>
        /// <returns>
        ///   <c>true</c> if given value length is less than Maximum length; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOverSize(double value, int length, int scale)
        {
            // Return false if Input value is empty or invalid numeric
            if (IsEmpty(value) || !IsValidNumeric(value))
            {
                return false;
            }
            int precision = length - scale;
            string localScale = string.Empty;
            string format = string.Empty;

            // Assign format identifier with zero
            for (int i = Constants.INT_ZERO; i < precision; i++)
            {
                format += Constants.CHAR_ZERO;
            }

            // Assign localScale identifier with zero
            for (int i = Constants.INT_ZERO; i < scale; i++)
            {
                localScale += Constants.CHAR_ZERO;
            }

            // Assign length with decimal value if scale less than zero
            if (scale > Constants.INT_ZERO)
            {
                format += (Constants.SYMBOL_DECIMAL_POINT + localScale + Constants.SYMBOL_HASH);

                // Len increased to accommodate the Constants.DECIMAL_POINT
                length += Constants.SYMBOL_DECIMAL_POINT.Length;
            }

            // Assign length with negative if value less than zero
            if (value < Constants.INT_ZERO)
            {
                // One character for the Constants.NEGATIVE_SIGN sign
                length += Constants.SYMBOL_NEGATIVE_SIGN.Length;
            }
            string formattedValue = value.ToString(format);
            return (formattedValue.Length != length);
        }

        /// <summary>
        /// Check if the Maximum allowed length is exceeded
        /// </summary>
        /// <param name="value">The value that needs to be checked for Maximum Length</param>
        /// <param name="length">The length to be met</param>
        /// <param name="scale">The precision after the decimal point.</param>
        /// <returns>
        ///   <c>true</c> if given value length is less than Maximum length; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOverSize(float value, int length, int scale)
        {
            // Assign format identifier with zero
            if (IsEmpty(value) || !IsValidNumeric(value))
            {
                return false;
            }
            int precision = length - scale;
            string localScale = string.Empty;
            string format = string.Empty;

            // Assign format identifier with zero
            for (int i = Constants.INT_ZERO; i < precision; i++)
            {
                format += Constants.CHAR_ZERO;
            }

            // Assign localScale identifier with zero
            for (int i = Constants.INT_ZERO; i < scale; i++)
            {
                localScale += Constants.CHAR_ZERO;
            }

            // Assign length with decimal value if scale less than zero
            if (scale > Constants.INT_ZERO)
            {
                format += (Constants.SYMBOL_DECIMAL_POINT + localScale + Constants.SYMBOL_HASH);

                // Len increased to accommodate the Constants.DECIMAL_POINT
                length += Constants.SYMBOL_DECIMAL_POINT.Length;
            }

            // Assign length with negative if value less than zero
            if (value < Constants.INT_ZERO)
            {
                // One character for the Constants.NEGATIVE_SIGN sign
                length += Constants.SYMBOL_NEGATIVE_SIGN.Length;
            }
            string formattedValue = value.ToString(format);
            return (formattedValue.Length != length);
        }

        /// <summary>
        /// validates if the input is oversize
        /// </summary>
        /// <param name="value">input to be validated</param>
        /// <param name="length">length against which to be validated</param>
        /// <returns>
        /// 	<c>true</c> if given value length is less than Maximum length; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOverSize(decimal value, int length)
        {
            // Return false if Input value is empty or invalid numeric
            if (IsEmpty(value) || !IsValidNumeric(value))
            {
                return false;
            }
            string formattedValue = value.ToString("0.00");
            return (formattedValue.Length > length);
        }

        /// <summary>
        /// validates if the input is oversize
        /// </summary>
        /// <param name="value">input to be validated</param>
        /// <param name="length">length against which to be validated</param>
        /// <returns>
        /// 	<c>true</c> if given value length is less than Maximum length; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOverSize(ulong value, int length)
        {
            // Return false if Input value is empty or invalid numeric
            if (IsEmpty(value) || !IsValidNumeric(Convert.ToDouble(value)))
            {
                return false;
            }
            return (value.ToString().Length > length);
        }

        /// <summary>
        /// Check if the Maximum allowed length is exceeded
        /// </summary>
        /// <param name="value">The value that needs to be checked for Maximum Length</param>
        /// <param name="length">The length to be met</param>
        /// <param name="scale">The precision after the decimal point.</param>
        /// <returns>
        /// 	<c>true</c> if given value length is less than Maximum length; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsOverSize(decimal value, int length, int scale)
        {
            // Return false if Input value is empty or invalid numeric
            if (IsEmpty(value) || !IsValidNumeric(value))
            {
                return false;
            }
            int precision = length - scale;
            string localScale = string.Empty;
            string format = string.Empty;

            // Assign format identifier with zero
            for (int i = Constants.INT_ZERO; i < precision; i++)
            {
                format += Constants.CHAR_ZERO;
            }

            // Assign localScale identifier with zero
            for (int i = Constants.INT_ZERO; i < scale; i++)
            {
                localScale += Constants.CHAR_ZERO;
            }

            // Assign length with decimal value if scale less than zero
            if (scale > Constants.INT_ZERO)
            {
                format += (Constants.SYMBOL_DECIMAL_POINT + localScale + Constants.SYMBOL_HASH);

                // Len increased to accommodate the Constants.DECIMAL_POINT
                length += Constants.SYMBOL_DECIMAL_POINT.Length;
            }

            // Assign length with negative if value less than zero
            if (value < Constants.INT_ZERO)
            {
                // One character for the Constants.NEGATIVE_SIGN sign
                length += Constants.SYMBOL_NEGATIVE_SIGN.Length;
            }
            string formattedValue = value.ToString(format);
            return (formattedValue.Length != length);
        }

        #endregion Over Size Validations

        #region String Value Allowed characters Validations

        /// <summary>
        /// Checks if the given input is valid Alphabet
        /// </summary>
        /// <param name="value">The input to check for valid Alphabet</param>
        /// <returns>
        ///   <c>true</c> if input value is valid Alphabet; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidAlpha(string value)
        {
            // Return true if value is empty
            if (IsEmpty(value))
            {
                return true;
            }
            return !IsRegularExpressionMatches("[^A-Za-z]", value);
        }

        /// <summary>
        /// Checks if the given input is valid Alphabet and Hyphen.
        /// </summary>
        /// <param name="value">The input to check for valid Alphabet and Hyphen</param>
        /// <returns>
        ///   <c>true</c> if input value is valid AlphabetHypen; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidAlphaHypen(string value)
        {
            // Return true if value is empty
            if (IsEmpty(value))
            {
                return true;
            }
            return !IsRegularExpressionMatches("[^A-Za-z-_]", value);
        }

        /// <summary>
        /// Checks if the given input is valid AlphaNumeric. This includes "_" and White space character also.
        /// </summary>
        /// <param name="value">The input to check for valid AlphaNumeric</param>
        /// <returns>
        ///   <c>true</c> if input value is valid AlphabetNumeric; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidAlphaNumeric(string value)
        {
            // Return true if value is empty
            if (IsEmpty(value))
            {
                return true;
            }
            return !IsRegularExpressionMatches("[^A-Za-z0-9_ ]", value);
        }

        /// <summary>
        /// Checks if the given input is valid AlphaNumeric and Hyphen. This includes "," character also.
        /// This method is implemented to validate alphanumeric with Comma for future use.
        /// </summary>
        /// <param name="value">The input to check for valid AlphaNumeric</param>
        /// <returns>
        ///   <c>true</c> if input value is valid AlphabetNumericComma; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidAlphaNumericComma(string value)
        {
            // Return true if value is empty
            if (IsEmpty(value))
            {
                return true;
            }
            return !IsRegularExpressionMatches("[^A-Za-z0-9,]", value);
        }

        /// <summary>
        /// Checks if the given input is valid AlphaNumeric and Hyphen. This includes "_", "-" and White space character also.
        /// </summary>
        /// <param name="value">The input to check for valid AlphaNumeric</param>
        /// <returns>
        ///   <c>true</c> if input value is valid AlphabetNumericHypen; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidAlphaNumericHypen(string value)
        {
            // Return true if value is empty
            if (IsEmpty(value))
            {
                return true;
            }
            return !IsRegularExpressionMatches("[^A-Za-z0-9_ -]", value);
        }

        /// <summary>
        /// Checks if the given input is valid Alphabet and Space.
        /// </summary>
        /// <param name="value">The input to check for valid Alphabet and Space</param>
        /// <returns>
        ///   <c>true</c> if input value is valid AlphabetSpace; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidAlphaSpace(string value)
        {
            // Return true if value is empty
            if (IsEmpty(value))
            {
                return true;
            }
            return !IsRegularExpressionMatches("[^A-Za-z ]", value);
        }

        /// <summary>
        /// Checks if the given input is valid Number and Hyphen. This include "." decimal point
        /// </summary>
        /// <param name="value">The input to check for valid Number and Hyphen</param>
        /// <returns>
        ///   <c>true</c> if input value is valid NumericHypen; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidNumericHypen(string value)
        {
            // Return true if value is empty
            if (IsEmpty(value))
            {
                return true;
            }
            return !IsRegularExpressionMatches("[^0-9'.-]", value);
        }

        /// <summary>
        /// Determines whether [is non zero alpha numeric] [the specified value].
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static bool IsNonZeroAlphaNumeric(string value)
        {
            // Return true if value is empty
            if (IsEmpty(value))
            {
                return true;
            }
            int number;

            bool result = Int32.TryParse(value, out number);
            return !(result && number == Constants.INT_ZERO);
        }

        #endregion String Value Allowed characters Validations

        #region Numeric Value Validations

        /// <summary>
        /// Checks if the given input is valid number
        /// </summary>
        /// <param name="value">The input to check for valid number</param>
        /// <returns>
        ///   <c>true</c> if input value is valid Numeric; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidNumeric(string value)
        {
            // Return true if value is empty
            if (IsEmpty(value))
            {
                return true;
            }
            return !IsRegularExpressionMatches("[^0-9]", value);
        }

        /// <summary>
        /// Checks if the given input is valid number.
        /// </summary>
        /// <param name="value">The input to check for valid number</param>
        /// <returns>
        ///   <c>true</c> if input value is valid Numeric; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidNumeric(int value)
        {
            return (value != Constants.INVALID_INT);
        }


        public static bool IsValidNumeric(long value)
        {
            return (value != Constants.INVALID_LONG);
        }
        public static bool IsValidNumeric(ulong value)
        {
            return (value != Constants.INVALID_ULONG);
        }

        public static bool IsValidNumeric(double value)
        {
            return (value.ToString("E12") != Constants.INVALID_DOUBLE.ToString("E12"));
        }

        /// <summary>
        /// Checks if the given input is valid number
        /// </summary>
        /// <param name="value">The input to check for valid number</param>
        /// <returns>
        /// 	<c>true</c> if input value is valid Numeric; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidNumeric(decimal value)
        {
            return (value.ToString("E12") != Constants.INVALID_DECIMAL.ToString("E12"));
        }

        /// <summary>
        /// Checks if the given input is valid number
        /// </summary>
        /// <param name="value">The input to check for valid number</param>
        /// <returns>
        ///   <c>true</c> if input value is valid Numeric; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidNumeric(float value)
        {
            return (value != Constants.INVALID_FLOAT);
        }

        #endregion Numeric Value Validations

        #region Other Special Field Validations

        /// <summary>
        /// Checks if the given input is valid Future Year by checking  if the input is future Year
        /// </summary>
        /// <param name="year">The input value that needs to be checked for Future Year. The input is of format yyyy</param>
        /// <returns>
        ///   <c>true</c> if input value is valid futureYear otherwise, <c>false</c>.
        /// </returns>
        public static bool IsFutureYear(string year)
        {
            // Return true if monthYear is empty
            if (IsEmpty(year))
            {
                return true;
            }
            int yearValue = int.Parse(year);
            DateTime todayDate = UtilityHandler.SystemCurrentDateTime;
            string currentYear = todayDate.ToString(Constants.DATE_FORMAT_YEAR);
            int todayValue = int.Parse(currentYear);
            return (yearValue > todayValue);
        }

        /// <summary>
        /// Checks if the given input is valid Description format. The formats allowed are "MM YY".
        /// </summary>
        /// <param name="accountingPeriod">The input to check for valid Description format</param>
        /// <returns>
        ///   <c>true</c> if input value is valid Accounting Period; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidAccountingPeriod(string accountingPeriod)
        {
            // Return true if accountingPeriod is empty
            if (IsEmpty(accountingPeriod))
            {
                return true;
            }
            return IsRegularExpressionMatches("(0[1-9]|1[0-2]) \\d{2}$", accountingPeriod);
        }

        /// <summary>
        /// Checks if the given input is valid Address format. The formats allowed are A-Za-z0-9'#.- and White space
        /// </summary>
        /// <param name="address">The input to check for valid Address format</param>
        /// <returns>
        ///   <c>true</c> if input value is valid Address format ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidAddress(string address)
        {
            // Return true if address is empty
            if (IsEmpty(address))
            {
                return true;
            }
            return !IsRegularExpressionMatches("[^A-Za-z0-9/!\"$&()+:'#. ,-;\\{=?\\\\@^|_]", address);
        }

        /// <summary>
        /// Checks if the given input is valid Case Id by checking the size described
        /// for the Case ID and checking if the input has valid alphabet at the
        /// beginning and end and remaining as valid Number
        /// </summary>
        /// <param name="caseIdno">The input value that needs to be checked for Valid Case Id</param>
        /// <returns>
        ///   <c>true</c> if input value is valid CaseIdno; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidCaseIdno(int caseIdno)
        {
            // Return true if caseIdno is empty
            if (IsEmpty(caseIdno))
            {
                return true;
            }

            // Check for valid caseIdno
            if (IsValidNumeric(caseIdno))
            {
                // Return true if caseIdno greater than equal to one and also less than equal to ''999999'
                if (caseIdno >= Constants.INT_ONE && caseIdno <= 9999999)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the given input is valid Check Number format. The Check Number format is A-Za-z0-9'. and White space
        /// </summary>
        /// <param name="checkNumber">The input to check for valid Check Number format</param>
        /// <returns>
        ///   <c>true</c> if input value is valid checkNumber; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidCheckNumber(string checkNumber)
        {
            // Return true if checkNumber is empty
            if (IsEmpty(checkNumber))
            {
                return true;
            }
            return !IsRegularExpressionMatches("[^A-Za-z0-9'. ]", checkNumber);
        }

        /// <summary>
        /// Checks if the given input is valid City format. The City format is
        /// A-Za-z0-9'. Hyphen and White space
        /// </summary>
        /// <param name="amount">The input to check for valid City format</param>
        /// <returns>
        ///   <c>true</c> if input value is valid City format ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidCity(string amount)
        {
            // Return true if amount is empty
            if (IsEmpty(amount))
            {
                return true;
            }
            return !IsRegularExpressionMatches("[^A-Za-z -.'&*?,{(/)_;\\\\]", amount);
        }

        /// <summary>
        /// Checks if the given input is valid Description format. The formats
        /// allowed are A-Za-z0-9!\"#$%&amp;'()*+,-./:;{}[]&lt;&gt;=?@^~`_\r\n and White space.
        /// </summary>
        /// <param name="description">The input to check for valid Description format</param>
        /// <returns>
        ///   <c>true</c> if input value is valid description format; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidDescription(string description)
        {
            // Return true if description is empty
            if (IsEmpty(description))
            {
                return true;
            }
            return !IsRegularExpressionMatches("^[a-zA-Z0-9\t\n ~`!@#$%^&*()-_=+{[}];:,<.>\\/?\"']", description);
        }

        /// <summary>
        /// Checks if the given input is valid DocketID. This includes AlphaNumeric .
        /// The Docket ID should have first 2 characters and remaining Numbers.
        /// </summary>
        /// <param name="docketID">The input to check for valid DocketID</param>
        /// <returns>
        ///   <c>true</c> if input value is valid DocketID; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidDocketID(string docketID)
        {
            // Return true if DocketID is empty
            if (IsEmpty(docketID))
            {
                return true;
            }

            // Require a minimum 3 characters, with the first 3 characters being only alpha and numeric
            // Allow spaces ONLY after the first three alpha numeric characters
            // Allow ONLY hyphens as special characters and ONLY after the first three alpha numeric characters
            return IsRegularExpressionMatches("^[a-zA-Z0-9]{3}[a-zA-Z0-9 -]{0,14}$", docketID);
        }

        /// <summary>
        /// Checks if the given input is valid Email format.
        /// </summary>
        /// <param name="value">The input to check for valid Email format</param>
        /// <returns>
        ///   <c>true</c> if input value is valid Email; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidEMail(string value)
        {
            // Return true if value is empty
            if (IsEmpty(value))
            {
                return true;
            }
            if (value.IndexOf(" ") != -1)
            {
                return false;
            }

            return IsRegularExpressionMatches("[^\\.]\\S+@\\S+\\.\\S+", value);
        }

        public static bool IsStrongPassword(string value)
        {
            // Return true if value is empty
            if (IsEmpty(value))
            {
                return true;
            }
            if (value.IndexOf(" ") != -1)
            {
                return false;
            }

            return IsRegularExpressionMatches("^(?=(.*\\d))(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z\\d]).{8,}$", value);
        }

        /// <summary>
        /// Checks if the given input is valid Employer Id by checking the size
        /// described for the Employer ID and checking if the input is valid Alphabet/Number
        /// </summary>
        /// <param name="employerIdno">The input value that needs to be checked for Valid Employer Id</param>
        /// <returns>
        ///   <c>true</c> if input value is valid EmployerIdno; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidEmployerIdno(int employerIdno)
        {
            // Return true if employerIdno is empty
            if (IsEmpty(employerIdno))
            {
                return true;
            }

            // Check for valid employerIdno
            if (IsValidNumeric(employerIdno))
            {
                // Return true if employerIdno greater than equal to one and also less than equal to ''999999999'
                if (employerIdno >= Constants.INT_ONE && employerIdno <= 999999999)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the given input is valid FipsIdno code.
        /// </summary>
        /// <param name="validFips">The string to be checked for valid FipsIdno code</param>
        /// <returns>
        ///   <c>true</c> if input value is valid Fips; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidFips(string validFips)
        {
            // Return true if fips is empty
            if (IsEmpty(validFips))
            {
                return true;
            }

            // Return false if fips length not equal to seven
            if (validFips.Length != 7)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if the given input is valid Future Month by checking the size as 6
        /// and checking if the input is future Year and Month
        /// </summary>
        /// <param name="month">The input value that needs to be checked for Future Year and
        /// Month. The input is of format yyyyMM</param>
        /// <returns>
        ///   <c>true</c> if input value is valid futureMonthSupport; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidFutureMonthSupport(int month)
        {
            // Return true if month is empty
            if (IsEmpty(month))
            {
                return true;
            }
            string formattedMonth = month.ToString("######");
            return IsValidFutureMonthSupport(formattedMonth);
        }

        /// <summary>
        /// Checks if the given input is valid Future Month by checking the size as 6 and checking if the input is future Year and Month
        /// </summary>
        /// <param name="month">The input value that needs to be checked for Future Year and Month. The input is of format yyyyMM</param>
        /// <returns>
        ///   <c>true</c> if input value is valid futureMonthSupport; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidFutureMonthSupport(string month)
        {
            // Return true if month is empty
            if (IsEmpty(month))
            {
                return true;
            }

            // Return false if month length not equal to 6
            if (month.Length != 6)
            {
                return false;
            }
            int monthValue = int.Parse(month);
            DateTime todayDate = UtilityBL.CurrentDate;
            string curDate = todayDate.ToString(Constants.YEAR_MONTH);
            int todayValue = int.Parse(curDate);
            return (monthValue > todayValue);
        }

        /// <summary>
        /// Checks if the given input is valid Future Month by checking the size as 6 and checking if the input is future Month and Year
        /// </summary>
        /// <param name="month">The input value that needs to be checked for Future Month and Year. The input is of format MMyyyy</param>
        /// <returns>
        ///   <c>true</c> if input value is valid futureMonthYearSupport; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidFutureMonthYearSupport(int month)
        {
            // Return true if month is empty
            if (IsEmpty(month))
            {
                return true;
            }
            string formattedMonth = month.ToString("######");
            return IsValidFutureMonthYearSupport(formattedMonth);
        }

        /// <summary>
        /// Checks if the given input is valid Future Month by checking the size as 6 and checking if the input is future Month and Year
        /// </summary>
        /// <param name="monthYear">The input value that needs to be checked for Future Month and Year. The input is of format MMyyyy</param>
        /// <returns>
        ///   <c>true</c> if input value is valid futureMonthYearSupport; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidFutureMonthYearSupport(string monthYear)
        {
            // Return true if monthYear is empty
            if (IsEmpty(monthYear))
            {
                return true;
            }
            int length = monthYear.Length;

            // Assign monthYear if length equal to five
            if (length == 5)
            {
                monthYear = Constants.CHAR_ZERO + monthYear;
            }

            // Return false if length not equal to 6
            if (length != 6)
            {
                return false;
            }
            string monthValue = monthYear.Substring(0, 2);
            string yearValue = monthYear.Substring(2, 4);
            monthYear = yearValue + monthValue;
            int mnthYear = int.Parse(monthYear);
            DateTime todayDate = UtilityHandler.SystemCurrentDateTime;
            string currentDate = todayDate.ToString(Constants.YEAR_MONTH);
            int todayValue = int.Parse(currentDate);
            return (mnthYear > todayValue);
        }

        /// <summary>
        /// To check if the input is valid 'ITIN' and valid MemSsn. Checks if the given input is valid ITIN/MemSsn format.
        /// The MemSsn should be of 9 digits and certain MemSsn are reserved which can not be as input
        /// </summary>
        /// <param name="itinSsn">The input to check for valid MemSsn format</param>
        /// <param name="ssnType">The MemSsn Type to identify if it is 'ITIN' or MemSsn</param>
        /// <param name="ssnStatus">The status of MemSsn for the Member</param>
        /// <returns></returns>
        /// <c>true</c> if input value is valid memberSSN format; otherwise, <c>false</c>.
        public static bool IsValidItinSsn(int itinSsn, string ssnType, string ssnStatus)
        {
            // Return true if itinSsn is empty or zero
            if (IsEmpty(itinSsn) || itinSsn.Equals(Constants.INT_ZERO))
            {
                return true;
            }

            // Return true if itinSsn is valid numeric
            if (CONFIRMED_BAD.Equals(ssnStatus))
            {
                return IsValidNumeric(itinSsn);
            }
            else if (SSN_TYPE_ITIN.Equals(ssnType))
            {
                // Return true if itinSsn is valid numeric

                string itinSsnString = itinSsn.ToString();
                return (IsValidNumeric(itinSsn) && itinSsnString[0] == '9' && (itinSsnString[3] == '7' || (itinSsnString[3] == '8' && itinSsnString[4] <= '8')
                    || (itinSsnString[3] == '9' && itinSsnString[4] != '3')));
            }
            else
            {
                return IsValidSsn(itinSsn);
            }
        }

        /// <summary>
        /// Checks if the given input is valid IV-A Case Id by checking the size
        /// described for the IV-D Case ID and checking if the input has first valid
        /// character (C or S) and remaining valid Number with last two digits between 01 and 21.
        /// Application should allow workers to use any available IV-A
        /// case number regardless of whether
        /// Application has the grant information for the IV-A case number.
        /// </summary>
        /// <param name="ivaCaseIdno">The input value that needs to be checked for Valid IV-D CaseId</param>
        /// <returns>
        ///   <c>true</c> if input value is valid IvaCase; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidIvaCase(string ivaCaseIdno)
        {
            // Return true if ivaCaseIdno is empty
            if (IsEmpty(ivaCaseIdno))
            {
                return true;
            }

            // Return false if ivaCaseIdno length not equal to Ten
            if (ivaCaseIdno.Length != 10)
            {
                return false;
            }
            bool isValid = IsValidNumeric(ivaCaseIdno);
            return isValid;
        }

        /// <summary>
        /// Determines whether [is valid IVA case id] [the specified case idno].
        /// </summary>
        /// <param name="caseIdno">The case idno.</param>
        /// <returns>
        ///   <c>true</c> if [is valid IVA case id] [the specified case idno]; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidIvaCaseIdno(long caseIdno)
        {
            // Return true if caseIdno is empty
            if (IsEmpty(caseIdno))
            {
                return true;
            }

            // Check for valid numeric
            if (IsValidNumeric(caseIdno))
            {
                // Return true if caseIdno is greater than equal to one and also less than equal to '999999999'
                if (caseIdno >= Constants.INT_ONE && caseIdno <= 9999999999)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the given input is valid IV-A Member Id. Checks for the input
        /// by checking the size described for the IV-A Member ID and checking if the
        /// input is valid Number
        /// </summary>
        /// <param name="memberIdno">The input need to validated for IV-A Member Id</param>
        /// <returns>
        ///   <c>true</c> if input value is valid memberIdno; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidIvaMemberIdno(long memberIdno)
        {
            // Return true if memberIdno is empty
            if (IsEmpty(memberIdno))
            {
                return true;
            }

            // Check for valid numeric
            if (IsValidNumeric(memberIdno))
            {
                // Return true if memberIdno is greater than equal to one and also less than equal to '999999999'
                if (memberIdno >= Constants.INT_ONE && memberIdno <= 9999999999)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the given input is valid Member Id by checking the size
        /// described for the Member ID and checking if the input is valid Number
        /// </summary>
        /// <param name="memberIdno">The input value that needs to be checked for Valid Member Id</param>
        /// <returns>
        ///   <c>true</c> if input value is valid memberIdno; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidMemberIdno(long memberIdno)
        {
            // Return true if memberIdno is empty
            if (IsEmpty(memberIdno))
            {
                return true;
            }

            // Check for valid numeric
            if (IsValidNumeric(memberIdno))
            {
                // Return true if memberIdno is greater than equal to one and also less than equal to '999999999'
                if (memberIdno >= 1 && memberIdno <= 9999999999)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the given input is valid Month support by checking the size as 6 and checking if the input has valid month and valid year
        /// </summary>
        /// <param name="month">The input value that needs to be checked for Valid Year and Month. The input is of format yyyyMM</param>
        /// <returns>
        ///   <c>true</c> if input value is valid MonthSupport ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidMonthSupport(int month)
        {
            // Return true if month is empty
            if (IsEmpty(month))
            {
                return true;
            }

            // Month and Year part are split and validated
            if (System.Convert.ToString(month).Length != 6)
            {
                return false;
            }
            int monthValue = month % 100;

            // Return false if month not ranges between 1 and 12
            if (!(monthValue >= Constants.INT_ONE && monthValue <= 12))
            {
                return false;
            }
            int yearValue = month / 100;

            // Return false if invalid year
            if (yearValue < Constants.INT_ONE || yearValue > 9999)
            {
                return false;
            }

            // Return false if month or year equal to 2
            if (monthValue == Constants.INT_TWO && yearValue == Constants.INT_TWO)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if the given input is valid Month support by checking the size as 6 and checking if the input has valid month and valid year
        /// </summary>
        /// <param name="month">The input value that needs to be checked for Valid Year and Month. The input is of format yyyyMM</param>
        /// <returns>
        ///   <c>true</c> if input value is valid MonthSupport ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidMonthSupport(string month)
        {
            // Return true if month is empty
            if (IsEmpty(month))
            {
                return true;
            }
            return IsValidMonthSupport(UtilityHandler.ParseInt(month));
        }

        /// <summary>
        /// Checks if the given input is valid Month support by checking the size as 6 and checking if the input has valid month and valid year
        /// </summary>
        /// <param name="month">The input value that needs to be checked for Valid Month and Year. The input is of format MMyyyy</param>
        /// <returns>
        ///   <c>true</c> if input value is valid MonthYearSupport ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidMonthYearSupport(int month)
        {
            // Return true if month is empty
            if (IsEmpty(month))
            {
                return true;
            }

            // Month and Year part are split and validated Month and year length is 6 or 5
            if (System.Convert.ToString(month).Length != 6 && System.Convert.ToString(month).Length != 5)
            {
                return false;
            }
            int monthValue = month / 10000;

            // Return false if invalid monthValue
            if (!(monthValue >= Constants.INT_ONE && monthValue <= 12))
            {
                return false;
            }
            int yearValue = month % 10000;

            // Return false if invalid yearValue
            if (yearValue < Constants.INT_ONE || yearValue > 9999)
            {
                return false;
            }

            // Return false if monthValue or yearValue equal to 2
            if (monthValue == Constants.INT_TWO && yearValue == Constants.INT_TWO)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if the given input is valid Month support by checking the size as 6 and checking if the input has valid month and valid year
        /// </summary>
        /// <param name="month">The input value that needs to be checked for Valid Month and Year. The input is of format MMyyyy</param>
        /// <returns>
        ///   <c>true</c> if input value is valid MonthYearSupport ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidMonthYearSupport(string month)
        {
            // Return true if month is empty
            if (IsEmpty(month))
            {
                return true;
            }
            return IsValidMonthYearSupport(UtilityHandler.ParseInt(month));
        }

        /// <summary>
        /// Checks if the given input is valid Name format. The formats allowed are A-Za-z'- and White space
        /// </summary>
        /// <param name="value">The input to check for valid Name format</param>
        /// <returns>
        ///   <c>true</c> if input value is valid Name format; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidName(string value)
        {
            // Return true if value is empty
            if (IsEmpty(value))
            {
                return true;
            }

            // Return false if first character of the given value is not a letter
            if (!System.Char.IsLetter(value[Constants.INT_ZERO]))
            {
                return false;
            }
            return !IsRegularExpressionMatches("[^A-Za-z' -.]", value);
        }

        /// <summary>
        /// Checks if the given input is valid OTHP Id by checking the size described
        /// for the OTHP ID and checking if the input is valid Number
        /// </summary>
        /// <param name="OthpIdno">The input value that needs to be checked for Valid OTHP Id</param>
        /// <returns>
        ///   <c>true</c> if input value is valid OthpIdno ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidOthpIdno(int OthpIdno)
        {
            // Return true if OthpIdno is empty
            if (IsEmpty(OthpIdno))
            {
                return true;
            }

            // Check for valid numeric
            if (IsValidNumeric(OthpIdno))
            {
                // Return true if OthpIdno is greater than equal to one and also less than equal to '999999999'
                if (OthpIdno >= Constants.INT_ONE && OthpIdno <= 999999999)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the given input is valid Name format. The formats allowed are (A-Za-z0-9&amp;,_'.#-) and White space.
        /// </summary>
        /// <param name="othpName">The input to check for valid OTHP Name format</param>
        /// <returns>
        ///   <c>true</c> if input value is valid OthpName ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidOthpName(string othpName)
        {
            // Return true if othpName is empty
            if (IsEmpty(othpName))
            {
                return true;
            }
            return !IsRegularExpressionMatches("[^A-Za-z0-9!\"#$%&'()*+,./:;\\{\\}\\[\\]<>=?\\\\@^~`|_\r\n -]", othpName);
        }

        /// <summary>
        /// Checks if the given input is valid Payor Id by checking if the input is
        /// valid Number and is of length 8
        /// </summary>
        /// <param name="payorIdno">The input value that needs to be checked for Valid Payor Id</param>
        /// <returns>
        ///   <c>true</c> if input value is valid payorIdno ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidPayorIdno(long payorIdno)
        {
            // Return true if payorIdno is empty
            if (IsEmpty(payorIdno))
            {
                return true;
            }

            // Check for valid numeric
            if (IsValidNumeric(payorIdno))
            {
                // Return true if payorIdno is greater than equal to one and also less than equal to '999999999'
                if (payorIdno >= Constants.INT_ONE && payorIdno <= 9999999999)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the given input is valid Phone number format. Phone number will accept numeric ,
        /// alpha X only,parenthesis and hypen.If the phone number is less than 10 digit or greater than 15 digit it returns false.
        /// </summary>
        /// <param name="phone">The input to check for valid Phone number format</param>
        /// <returns>
        ///   <c>true</c> if input value is valid PhoneNumber ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidPhoneNumber(ulong phone)
        {
            // Return true if phone is empty
            if (IsEmpty(phone))
            {
                return true;
            }

            // Return false if invalid value
            if (!IsValidNumeric(phone))
            {
                return false;
            }
            int length = phone.ToString().Length;

            // Return false if length less than ten or greater than fifteen
            if (length < 10 || length > 15)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if the given input is valid Receipt Number. The Receipt Number format is MM/DD/YYYY-ABC-9999-999-999
        /// </summary>
        /// <param name="receiptNumber">The input to check for valid Receipt Number</param>
        /// <returns>
        ///   <c>true</c> if input value is valid Receipt Number ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidReceiptNumber(string receiptNumber)
        {
            // Return true if receiptNumber is empty
            if (IsEmpty(receiptNumber))
            {
                return true;
            }

            // MM/DD/YYYY-ABC-9999-999-999
            bool isValidReceipt = IsRegularExpressionMatches("^\\d{2}/\\d{2}/\\d{4}\\-[A-Z]{3}\\-\\d{4}\\-\\d{3}(-\\d{3}|)$", receiptNumber);

            // Check for valid Receipt
            if (isValidReceipt)
            {
                isValidReceipt = IsValidDate(receiptNumber.Substring(0, Constants.US_DATE_FORMAT.Length));
            }
            return isValidReceipt;
        }

        /// <summary>
        /// Checks if the given input is Recipient Id by checking if the input is valid Alphabet or Number
        /// </summary>
        /// <param name="recipientIdno">The input value that needs to be checked for Valid RecipientId</param>
        /// <returns>
        ///   <c>true</c> if input value is valid recipientIdno ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidRecipientIdno(long recipientIdno)
        {
            // Return true if recipientIdno is empty
            if (IsEmpty(recipientIdno))
            {
                return true;
            }

            // Check for valid numeric
            if (IsValidNumeric(recipientIdno))
            {
                // Return true if recipientIdno is greater than equal to one and also less than equal to '999999999'
                if (recipientIdno >= Constants.INT_ONE && recipientIdno <= 9999999999)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Checks if the given input is valid MemSsn format. The MemSsn should be of 9
        /// digits and certain MemSsn are reserved which can not be as input
        /// </summary>
        /// <param name="value">The input to check for valid MemSsn format</param>
        /// <returns>
        ///   <c>true</c> if input value is valid SSN ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidSsn(int value)
        {
            // Return true if value is empty
            if (IsEmpty(value))
            {
                return true;
            }

            // Check for valid numeric
            if (!IsValidNumeric(value))
            {
                return false;
            }
            string ssnString = value.ToString();
            ssnString = UtilityHandler.FormatDefaultNumericToString(ssnString, 9, true);

            //SSN should not be 123456789, 111111111 , 333333333, 999999999
            if (ssnString == "123456789"
                    || ssnString == "111111111" || ssnString == "333333333"
                    || ssnString == "999999999")
            {
                return false;
            }

            String ssnArea = ssnString.Substring(0, 3);

            //SSN first part should not be 000 or 666, should not start with 9
            if (ssnArea == "000" || ssnArea == "666" || ssnArea.ToCharArray()[0] == '9')
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Checks if the given input is valid State in US.
        /// </summary>
        /// <param name="stateCode">The input to check for valid US State</param>
        /// <returns>
        ///   <c>true</c> if input value is valid USState ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidUSState(string stateCode)
        {
            // Return true if stateCode is empty
            if (IsEmpty(stateCode))
            {
                return true;
            }

            // Return false if length not equal to 2
            if (stateCode.Length != 2)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// New Validation for Worker ID. Checks if the given input is valid Worker ID.
        /// </summary>
        /// <param name="workerID">The input to check for valid Worker ID format</param>
        /// <returns>
        ///   <c>true</c> if input value is valid WorkerID ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidWorkerID(string workerID)
        {
            // Return true if workerID is empty
            if (IsEmpty(workerID))
            {
                return true;
            }
            return !IsRegularExpressionMatches("^[a-zA-Z0-9~`!|@#$%^&*()-_=+{[}];:,<.>\\/?\"']", workerID);
        }

        /// <summary>
        /// Checks if the given input is a valid year
        /// </summary>
        /// <param name="year">The input need to be validated for year</param>
        /// <returns>
        ///   <c>true</c> if input value is valid year ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidYear(string year)
        {
            // Return true if year is empty
            if (IsEmpty(year))
            {
                return true;
            }

            // Return false if year length not equal to four or invalid numeric
            if (year.Length != 4 || !IsValidNumeric(year))
            {
                return false;
            }
            int fieldValue = int.Parse(year);

            // Return false if year is less then 1000.
            if (fieldValue < 1000)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Checks if the given input is valid Zip format. The Zip format is
        /// A-Za-z0-9 and the Hyphen character and White space. The Zip code should be minimum length of 5.
        /// </summary>
        /// <param name="zipCode">The input to check for valid Zip format</param>
        /// <param name="country">The country.</param>
        /// <returns>
        ///   <c>true</c> if input value is valid Zip format ; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidZip(string zipCode, string country = "")
        {
            // Return true if zipCode is empty
            if (IsEmpty(zipCode))
            {
                return true;
            }
            int length = zipCode.Length;

            // Return false if length less than 5 or greater than 15
            if (country == Constants.DEFAULT_COUNTRY_CODE && (length < 5 || length > 15))
            {
                return false;
            }
            return !IsRegularExpressionMatches("[^A-Za-z0-9 -]", zipCode);
        }

        #endregion Other Special Field Validations



        /// <summary>
        /// Checks if the give code is existing in Lookup table based on the table
        /// and subTable
        /// </summary>
        /// <param name="screenId">The screen id.</param>
        /// <param name="commonName">Name of the common.</param>
        /// <param name="code">The code that will be checked in the table and subTable</param>
        /// <param name="dependentValue">The dependent value.</param>
        /// <returns>
        ///   <c>true</c> if the code exists in the given table and subTable; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsValidLookUp(string screenId, string commonName, string code, string dependentValue)
        {
            // Return true if code is empty
            if (IsEmpty(code))
            {
                return true;
            }
            return RefmStore.Instance.IsRefmCodeExists(screenId, commonName, code, dependentValue);
        }
    }
}