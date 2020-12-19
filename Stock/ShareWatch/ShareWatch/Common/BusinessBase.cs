using System;
using System.Collections.Generic;
using System.Net;


namespace ShareWatch.Common
{
    /// <summary>
    /// Acts as a base class for all the BL classes, used to store the execution flow in a list &amp; log it.
    /// </summary>
    public partial class BusinessBase
    {
        /// <summary>
        /// The m_business base
        /// </summary>
        protected BusinessBase businessBase;

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessBase" /> class.
        /// </summary>
        private BusinessBase()
        {
            businessBase = this;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BusinessBase" /> class.
        /// </summary>
        /// <param name="businessBase">The business base object.</param>
        public BusinessBase(BusinessBase businessBase)
        {
            this.businessBase = businessBase;
        }

        public static BusinessBase GetInstance()
        {
            return new BusinessBase()
            {
                ServerIP = Dns.GetHostName()
            };
        }

        private readonly List<ProcessStep> processSteps = new List<ProcessStep>();

        public string ServerIP { get; set; } = string.Empty;
        public string ClientIP { get; set; } = string.Empty;
        public string UrlReferrer { get; set; } = string.Empty;
        public string PageLocation { get; set; } = string.Empty;
        public string SessionID { get; set; } = string.Empty;
        public string ServiceName { get; set; } = string.Empty;
        public string MethodName { get; set; } = string.Empty;

        public string ApplicationID { get; set; } = string.Empty;

        public string UserAgent { get; set; } = string.Empty;

        /// <summary>
        /// 	Bearer Token. A security token with the property that any party in possession of the token (a "bearer") 
        /// 	can use the token in any way that any other party in possession of it can.
        /// </summary>
        public string BearerToken { get; set; } = string.Empty;

        public string SignedOnWorkerID
        {
            get
            {
                string userID = Environment.UserName;
                // string userName = WindowsIdentity.GetCurrent().Name;
                return userID;
            }
        }


        private string m_uniqueID = string.Empty;

        public string UniqueID
        {
            get
            {
                if (string.IsNullOrEmpty(m_uniqueID))
                {
                    m_uniqueID = DateTime.Now.ToString("yyyyMMdd.HHmmss.FFFFFFF.")
                                      + (new Random().Next(100000000, 999999999));
                }
                return m_uniqueID;
            }
        }


        public void AddToProcessStep(object dataIn,
                                    Exception ex = null,
                                    bool isDbCall = false,
                                    string storedProcedure = "",
                                    string sqlText = "")
        {
            processSteps.Add(new ProcessStep(
                   dataIn,
                   ex,
                   isDbCall,
                  storedProcedure,
                  sqlText
                ));
        }

        public List<ProcessStep> GetProcessSteps()
        {
            return processSteps;
        }
    }
}