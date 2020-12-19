using ShareWatch.Common;
using System;

namespace ShareWatch.BusinessLogic.Logging
{
    public partial class ApplicationLogger : BusinessBase
    {


        static ApplicationLogger m_instance = null;
        static BusinessBase sBusinessBase = BusinessBase.GetInstance();
        public ApplicationLogger(BusinessBase businessBase)
        : base(businessBase)
        {
        }

        public static ApplicationLogger Default
        {
            get
            {
                if (m_instance == null)
                {
                    if (m_instance == null)
                    {
                        m_instance = new ApplicationLogger(sBusinessBase);
                    }
                }
                return m_instance;
            }
        }


        /// <summary>
        /// The _syn root object
        /// </summary>
        private static object _synRootObj = new object();

        public void WriteInfoLog(string step, Exception ex)
        {

        }

        public void WriteInfoLog(string step, string message)
        {

        }
    }
}