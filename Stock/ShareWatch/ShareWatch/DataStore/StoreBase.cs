using ShareWatch.Common.Utility;
using ShareWatch.DataModels.Logging;
using System;
using System.Threading.Tasks;

namespace ShareWatch.Common.DataStore
{
    /// <summary>
    /// StoreBase
    /// </summary>
    public class StoreBase : IStoreBase
    {
        protected BusinessBase businessBase = BusinessBase.GetInstance();
        /// <summary>
        /// The _syn root object
        /// </summary>
        private static object m_synRootObj = new object();

        protected Exception m_exceptionData = null;

        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="businessBase">The business base.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="storeName">Name of the store.</param>
        public void LogException(BusinessBase businessBase, Exception exception, string storeName)
        {

            m_exceptionData = exception;

            //businessBase.GetExecutionList().Add(new ExecutionTracker(businessBase.UniqueID, null, exception.Message));

            ErrorDetailsLogData logErrorDetailsInData = UtilityHandler.UpdateStatus(exception, null, null, storeName);

            Task.Factory.StartNew(() =>
            {
                lock (m_synRootObj)
                {
                    UtilityBL utilityBL = new UtilityBL(businessBase);
                    utilityBL.LogExceptionDetails(logErrorDetailsInData);
                }
            });
        }

        /// <summary>
        /// Writes to log and update status.
        /// </summary>
        /// <param name="businessObject">The business object.</param>
        public void WriteToLogAndUpdateStatus(BusinessBase businessObject)
        {
            // UtilityHandler.WriteToLogAndUpdateStatus(null, businessObject.GetExecutionList());
        }
    }
}