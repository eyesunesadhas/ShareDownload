using System;

namespace ShareWatch.Const
{
    public partial class Constants
    {
        /* HTTP STATUS */
        public const int SERVICE_STATUS_SUCCESS = 200;
        public const int SERVICE_STATUS_UNAUTHORIZED = 401;
        public const int SERVICE_STATUS_FAIL = 500;


        #region Application Constants
        public const string ACCESS_DENIED = "Access Denied";
        public const string AUTHENTICATION_TOKEN = "AuthenticationToken";

        #endregion Application Constants

        public const string PROPERTY_INFO_APPLICATION_ID = "ApplicationID";

        public const string PROPERTY_INFO_USER_ID = "UserID";

        public const string CHAR_ZERO = "0";
        public const int INITIAL_RECORD_INDEX = 0;
        public const int INT_FIVE = 5;
        public const int INT_FOUR = 4;
        public const int INT_MINUS_ONE = -1;
        public const int INT_ONE = 1;
        public const int INT_SIX = 6;
        public const int INT_THREE = 3;
        public const int INT_TWO = 2;
        public const int INT_ZERO = 0;
        public const int INT_SEVEN = 7;
        public const int INT_EIGHT = 8;
        public const int INT_NINE = 9;
        public const int INT_TEN = 10;
        public const int MEMBER_MAX_LENGTH = 10;
        public const int NO_DATA_COUNT = 0;
        public const int NO_ROWS_AFFECTED = 0;
        public const string PROPERTY_INFO_MEMBER_ID_NO = "MemberIdno";
        public const string ZERO_SEVEN_CHARS = "0000000";
        public const string PRODUCTION = "production";

        #region Date Formats
        public const string DATE_FORMAT_FULL_DATETIME = "dd/MM/yyyy hh:mm tt";
        public const string DATE_FORMAT_MONTH3 = "dd-MMM-YYYY";
        public const string DATE_FORMAT_YEAR = "yyyy";
        public const string TIME_FORMAT_12 = "hh:mm tt";
        public const string TIME_FORMAT_24 = "HH:mm";
        public const string US_DATE_FORMAT = "MM/dd/yyyy";
        public const string US_DATETIME_AMPM = "MM/dd/yyyy hh:mm:ss tt";
        public const string YEAR_MONTH = "yyyyMM";
        #endregion Date Formats

        #region Default Values
        public const string CANADA_COUNTRY_CODE = "CA";
        public const double DEFAULT_AMOUNT_VALUE = 0.0;
        public const decimal DECIMAL_DEFAULT_AMOUNT_VALUE = 0.0m;
        public const string DEFAULT_COUNTRY_CODE = "US";
        public const string DEFAULT_COUNTY_CODE = "99";
        public const string DEFAULT_FIPS = "4500000";
        public const string DEFAULT_OFFICE_CODE = "00";
        public const string DEFAULT_STATE_CODE = "AR";
        public const string DEFAULT_STATE_FIPS_CODE = "45";
        public const int FOSTER_CARE_MEMBERIDNO = 999998;
        public const int OFFICE_IDNO_INITIAL_VALUE = -1;
        public const int UNIDETIFIED_FOSTER_CARE_MEMBERIDNO = 999995;

        /* since only direct value can be given as constant declared as static */
        public static DateTime END_VALIDITY_DATE = DateTime.Parse("12/31/9999");

        public static DateTime MAX_DATE = DateTime.MaxValue.Date;
        public static DateTime MIN_DATE = DateTime.MinValue;
        public static DateTime NULL_DATE = DateTime.Parse("03/03/0003");
        public static DateTime NULL_DATETIME = DateTime.Parse("03/03/0003 00:00:00");
        public static DateTime LOW_DATE = DateTime.Parse("01/01/1900");
        public const int MAX_INT = int.MaxValue;
        #endregion Default Values

        #region Exception Constants
        public const string DATABASE_ENGINE_DEADLOCK_VICTIM = "deadlock victim";
        public const string EXCEPTION_FM_EVENT_CANNOT_BE_NONE = "FunctionalEvent cannot be None for FinancialMangement";
        public const string EXCEPTION_LOOKUP_NOT_FOUND = "Lookup type not found";
        public const string EXCEPTION_CONNECT_ERROR = "unable to connect to the remote server";
        public const string EXCEPTION_ABORTED_CONNECT_ERROR = "connection was aborted";
        public const string EXCEPTION_REQUEST_CHANNEL_ERROR = "the request channel timed out ";
        public const string EXCEPTION_CLOSED_CONNECT_ERROR = "connection was closed";
        public const string EXCEPTION_REMOTE_CERTIFICATE_ERROR = "not establish trust relationship";

        #endregion Exception Constants

        #region Invalid Value Constants
        public const string INVALID_DATE = "02/02/0002";
        public const decimal INVALID_DECIMAL = decimal.MinValue / 2;
        public const double INVALID_DOUBLE = double.MinValue / 2;
        public const float INVALID_FLOAT = float.MinValue / 2;
        public const int INVALID_INT = int.MinValue / 2;
        public const long INVALID_LONG = long.MinValue / 2;
        public const ulong INVALID_ULONG = ulong.MaxValue;
        #endregion Invalid Value Constants

        #region Logger Constants
        public const string LOGGER_DATE_PART_A = "A";
        public const string LOGGER_DATE_PART_B = "B";
        public const string LOGGER_DATE_PART_C = "C";
        public const string LOGGER_DATE_PART_D = "D";
        public const string LOGGER_FILE_DATE = "yyyyMMdd";
        public const string LOGGER_FILE_EXTENSION = ".csv";
        public const string LOGGER_FILE_LOG = "LOG_";
        public const string LOGGER_LABEL_APPLICATION = "Application";
        public const string LOGGER_LABEL_BUSINESS_OBJECT = "Business Object";
        public const string LOGGER_LABEL_CONNECTION = "Connection";
        public const string LOGGER_LABEL_DB = "DB";
        public const string LOGGER_LABEL_WEB_ERROR = "WebError";
        public const string LOGGER_LABEL_INPUT = "Input";
        public const string LOGGER_LABEL_MESSAGE = "Message";
        public const string LOGGER_LABEL_METHOD = "Method";
        public const string LOGGER_LABEL_OUTPUT = "Output";
        public const string LOGGER_LABEL_ROUTINE = "Routine";
        public const string LOGGER_LABEL_STACK_TRACE = "Stack Trace";
        public const string LOGGER_LABEL_INNER_EXCEPTION = "Inner Exception";
        public const string LOGGER_LABEL_INNER_EXCEPTION_STACK = "Inner Exception Stack";
        public const string LOGGER_LABEL_MORE_DETAILS = "More Details";
        public const string LOGGER_LABEL_MACHINE = "Machine";
        public const string LOGGER_LABEL_USER_HOST = "UserHost Address";
        public const string LOGGER_LABEL_USER_OFFICE = "User/Office";
        public const string LOGGER_LABEL_STORED_PROCEDURE = "Stored Procedure";
        public const string LOGGER_LABEL_TIME = "Time";
        public const string LOGGER_LABEL_WORKER_ID = "WorkerID";
        public const string LOGGER_LABEL_UNIQUE_ID = "UniqueID";
        public const string LOGGER_NAME_EXCEPTION = "Exception";
        public const string LOGGER_NAME_FIS = "FIS";
        public const string LOGGER_NAME_FLOW = "Flow";
        public const string LOGGER_NAME_INFO = "Info";
        public const string LOGGER_RETURN_VALUE = "Return Value";
        public const string LOGGER_NAME_REPORTS = "Reports";
        public const string LOGGER_NAME_AUTHENTICATION = "Authentication";
        public const string LOGGER_NAME_SP = "SP";

        /// <summary>
        /// LOGGER_SENDER_ADDRESS
        /// </summary>
        public const string LOGGER_SENDER_ADDRESS = "Sender Address";
        /// <summary>
        /// LOGGER_RECIPIENT_ADDRESS
        /// </summary>
        public const string LOGGER_RECIPIENT_ADDRESS = "Recipient Address";
        /// <summary>
        /// LOGGER_LABEL_SUBJECT
        /// </summary>
        public const string LOGGER_LABEL_SUBJECT = "Subject";
        /// <summary>
        /// LOGGER_LABEL_ERROR
        /// </summary>
        public const string LOGGER_LABEL_ERROR = "Error";
        /// <summary>
        /// LOGGER_INNER_EXCEPTION
        /// </summary>
        public const string LOGGER_INNER_EXCEPTION = "InnerException";
        /// <summary>
        /// LOGGER_NAME_MAIL_EXCEPTION
        /// </summary>
        public const string LOGGER_NAME_MAIL_EXCEPTION = "MailException";
        #endregion Logger Constants

        #region Max Length constants

        public const int AMNT_MAX_LENGTH = 10;
        public const int AMNT_SCALE_LENGTH = 2;


        #endregion Max Length constants

        #region Null Value Constants
        public const int NULL_COUNTY_VALUE = 0;
        public const decimal NULL_DECIMAL = decimal.MinValue / 4;
        public const double NULL_DOUBLE = double.MinValue / 4;
        public const float NULL_FLOAT = float.MinValue;
        public const int NULL_INT = int.MinValue;
        public const long NULL_LONG = long.MinValue;
        public const string NULL_TIME = "12:00 AM";
        public const ulong NULL_ULONG = ulong.MinValue;
        #endregion Null Value Constants

        #region RegEx
        public const string REGEX_DOCKET_ID = "(JR#\\d{1,14}|MC#\\d{1,14}|\\d{4}-[A-Z]{2}-\\d{2}-(\\d{5}|\\d{5}[A-Z0-9]{1}))$";
        #endregion RegEx

        #region Status
        public const string STATUS_FAILURE = "F";
        public const string STATUS_NO = "N";
        public const string STATUS_SUCCESS = "S";
        public const string STATUS_YES = "Y";
        #endregion Status

        #region Symbols/Charachters constants
        public const string AMPERSAND_ENCODE = "&amp;";
        public const string GREATER_THAN_ENCODE = "&gt;";
        public const string LESS_THAN_ENCODE = "&lt;";
        public const string SPACE_ENCODE = "&nbsp;";
        public const string SYMBOL_AMPERSAND = "&";
        public const string SYMBOL_BACK_SLASH = "/";
        public const string SYMBOL_COMMA = ",";
        public const string SYMBOL_DECIMAL_POINT = ".";
        public const string SYMBOL_DOT = ".";
        public const string SYMBOL_DOUBLE_QUOTES = "\"";
        public const string SYMBOL_EMPTY = "";
        public const string SYMBOL_FORWARD_SLASH = "\\";
        public const string SYMBOL_GREATER_THAN = ">";
        public const string SYMBOL_HASH = "#";
        public const string SYMBOL_HYPEN = "-";
        public const string SYMBOL_HYPEN_WITH_SPACE = " - ";
        public const string SYMBOL_LESS_THAN = "<";
        public const string SYMBOL_NEGATIVE_SIGN = "-";
        public const string SYMBOL_NEW_LINE_BREAK = "\r\n";
        public const string SYMBOL_NEW_LINE_SYMBOL = "\n";
        public const string SYMBOL_PERCENTAGE = "%";
        public const string SYMBOL_SEMI_COLON = ";";
        public const string SYMBOL_SINGLE_QUOTE = "'";
        public const string SYMBOL_SPACE = " ";
        public const string SYMBOL_UNDERSCORE = "_";
        public const string SYMBOL_QUESTION_MARK = "?";
        public const char SYMBOL_ASTERISK = '*';
        public const string SYMBOL_CONCAT = "concat(";
        public const string SYMBOL_COMMA_SPACE = ", ";
        public const string SYMBOL_SPACE_COMMA = " ,";
        public const string SYMBOL_REMOVE_DOUBLE_SPACE = " {2,}";
        #endregion Symbols/Charachters constants

        public const string SYMBOL_BREAK = "<br/>";
        public const string LOGGER_LABEL_SCRIPT_ERROR = "ScriptError";
        public const string LOGGER_NAME_TXT = "TXT";

        public const string CONTENT_TYPE_TEXT = "text/plain";
        public const string CONTENT_TYPE_JSON = "application/json";


        public const string X_FORWARDED_FOR = "X-Forwarded-For";

        public const string USER_AGENT = "User-Agent";

        public const string NO_INDC = "N";
        public const string YES_INDC = "Y";
    }
}
