using ShareWatch.Properties;

namespace ShareWatch.Common
{
    /// <summary>
    /// Stores the configuration for the application
    /// </summary>
    public sealed class ApplicationSettings
    {
        /// <summary>
        /// The m_instance
        /// </summary>
        private static ApplicationSettings m_instance = null;

        /// <summary>
        /// Prevents a default instance of the <see cref="ApplicationSettings" /> class from being created.
        /// </summary>
        private ApplicationSettings()
        {
            Initialize();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static ApplicationSettings Default
        {
            get
            {
                if (m_instance == null)
                {
                    if (m_instance == null)
                    {
                        m_instance = new ApplicationSettings();
                    }
                }
                return m_instance;
            }
        }


        public string ApplicationMode { get; set; } = string.Empty;
        public string DevelopmentUserID { get; set; } = string.Empty;

        /// <summary>
        /// Gets the OnlineDBConstr.
        /// </summary>
        /// <value>
        /// The OnlineDBConstr.
        /// </value>
        public string DBConnectionString
        {
            get;
            private set;
        } = string.Empty;

        /// <summary>
        /// Gets the application title.
        /// </summary>
        /// <value>
        /// The application title.
        /// </value>
        public string ApplicationTitle
        {
            get;
            private set;
        } = string.Empty;

        /// <summary>
        /// Gets a value indicating whether this instance is logging enabled for exceptions.
        /// </summary>
        public bool IsLoggingEnabledForExceptions
        {
            get;
            private set;
        } = true;

        /// <summary>
        /// Gets a value indicating whether this instance is logging enabled for user activity.
        /// </summary>
        public bool IsLoggingEnabledForUserActivity
        {
            get;
            private set;
        } = true;

        /// <summary>
        /// Gets a value indicating whether this instance is logging enabled for autentication.
        /// </summary>
        public bool IsLoggingEnabledForAuthentication
        {
            get;
            private set;
        } = true;

        /// <summary>
        /// Gets a value indicating whether this instance is logging enabled for sp.
        /// </summary>
        public bool IsLoggingEnabledForSP
        {
            get;
            private set;
        } = true;

        /// <summary>
        /// Gets the transaction retry count.
        /// </summary>
        public int TransactionRetryCount
        {
            get;
            private set;
        } = 0;

        /// <summary>
        /// Gets the transaction retry delay.
        /// </summary>
        public int TransactionRetryDelay
        {
            get;
            private set;
        } = 0;


        public bool IsLogOnFileSystem { get; internal set; } = true;
        public string LoggingFolder { get; internal set; } = @"C:\LogFiles";




        /// <summary>
        /// Initializes this instance.
        /// </summary>
        private void Initialize()
        {
            this.DBConnectionString = Settings.Default.CnStr;
            this.ApplicationTitle = Settings.Default.ApplicationName;
            this.IsLoggingEnabledForExceptions = Settings.Default.IsLoggingEnabledForExceptions;
            this.IsLoggingEnabledForUserActivity = Settings.Default.IsLoggingEnabledForUserActivity;
            this.IsLoggingEnabledForAuthentication = Settings.Default.IsLoggingEnabledForAuthentication;
            this.IsLoggingEnabledForSP = Settings.Default.IsLoggingEnabledForSP;
            this.TransactionRetryCount = Settings.Default.TransactionRetryCount;
            this.TransactionRetryDelay = Settings.Default.TransactionRetryDelay;
            this.ApplicationMode = Settings.Default.ApplicationMode;
            this.LoggingFolder = Settings.Default.LoggingFolder;
        }
    }
}