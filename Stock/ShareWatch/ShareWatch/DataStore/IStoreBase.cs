using System;

namespace ShareWatch.Common.DataStore
{
    internal interface IStoreBase
    {
        /// <summary>
        /// Logs the exception.
        /// </summary>
        /// <param name="businessBase">The business base.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="storeName">Name of the store.</param>
        void LogException(BusinessBase businessBase, Exception exception, String storeName);

        /// <summary>
        /// Writes to log and update status.
        /// </summary>
        /// <param name="businessObject">The business object.</param>
        void WriteToLogAndUpdateStatus(BusinessBase businessObject);
    }
}