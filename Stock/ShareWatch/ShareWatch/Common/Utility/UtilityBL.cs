using ShareWatch.BusinessLogic.Common;
using ShareWatch.Const;
using ShareWatch.DataAccess.Batch;
using ShareWatch.DataAccess.Logging;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModels.Common;
using ShareWatch.DataModels.Logging;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace ShareWatch.Common.Utility
{
    /// <summary>
    /// UtilityBL is used to define the commonly used methods in the application
    /// </summary>
    public partial class UtilityBL : BusinessBase
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="UtilityBL"/> class.
        /// </summary>
        /// <param name="businessBaseObject">The business base object.</param>
        public UtilityBL(BusinessBase businessBaseObject)
            : base(businessBaseObject)
        {
        }

        /// <summary>
        /// Gets the current date.
        /// </summary>
        public static DateTime CurrentDate
        {
            get
            {
                return DateTime.Now;
            }
        }


        public ulong Generatevent(string processID)
        {
            return GenerateCMEvent(processID);
        }



        /// <summary>
        /// Generates the CaseMangement event.
        /// </summary>
        /// <param name="processID">The process ID.</param>
        /// <param name="eventFunctionalSeqNumb">The event functional sequence number.</param>
        /// <param name="noteIndc">The note indicator.</param>
        /// <returns>The Generated CaseMangement event value</returns>
        public ulong GenerateCMEvent(string processID,
                                     FunctionalEvent eventFunctionalSeqNumb = FunctionalEvent.None,
                                     string noteIndc = Constants.STATUS_NO)
        {
            BatchCommonDA batchCommonDA = new BatchCommonDA(businessBase);
            EventDataInData eventDataInData = new EventDataInData()
            {
                WorkerUpdateID = businessBase.SignedOnWorkerID,
                ProcessID = processID,
                EffectiveEventDate = CurrentDate,
                EventFunctionalSeqNumb = (int)eventFunctionalSeqNumb,
            };

            EventDataOutData output = batchCommonDA.GenerateCMEvent(eventDataInData);

            return output.TransactionEventSeqNumb;
        }

        /// <summary>
        /// Gets the current date time.
        /// </summary>
        /// <returns></returns>
        public OutData<DateTime> GetCurrentDateTime()
        {
            return new OutData<DateTime>
            {
                Data = UtilityBL.CurrentDate
            };

        }




        /// <summary>
        /// Logs the authentication details.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public StatusOut LogAuthenticationDetails(ActivityLoginData input)
        {
            StatusOut output = new StatusOut();
            ActivityLogDA activityLogDA = new ActivityLogDA(businessBase);
            activityLogDA.AddLoginActivity(input);
            return output;
        }

        /// <summary>
        /// Logs the exception details.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public StatusOut LogExceptionDetails(ErrorDetailsLogData input)
        {
            StatusOut output = new StatusOut();
            using (TransactionScope scope = TransactionScopeBase.GetInstance())
            {
                ActivityLogDA activityLogDA = new ActivityLogDA(businessBase);
                activityLogDA.AddErrorDetails(input);
                scope.Complete();
            }

            try
            {
                Dictionary<string, object> message = new Dictionary<string, object>();
                message.Add("ERROR", input.ScriptErrorText);
                message.Add("STACK", input.StackTraceText);
                message.Add("BROWSER", businessBase.UserAgent);
                message.Add("CLIENT", businessBase.ClientIP);

                // DoLog.HandleScriptError(message);

            }
            catch (Exception)
            {

                //Since its Logging Exception no need to Handle
            }

            return output;
        }

        /// <summary>
        /// Logs the user activity details.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public StatusOut LogUserActivityDetails(UserAccessAuditData input)
        {
            ActivityLogDA activityLogDA = new ActivityLogDA(businessBase);
            activityLogDA.AddUserAccessAuditData(input);
            return new StatusOut();
        }




    }
}