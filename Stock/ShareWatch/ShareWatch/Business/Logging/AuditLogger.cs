using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataAccess.Logging;
using ShareWatch.DataModels.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ShareWatch.BusinessLogic.Logging
{
    public class AuditLogger
    {
        private readonly BusinessBase businessBase = null;

        public AuditLogger(BusinessBase businessBase)
        {
            this.businessBase = businessBase;
        }

        private string sqlText = string.Empty;
        private string storedProcedureName = string.Empty;
        private static object _synRootObj = new object();
        private static readonly List<string> ignoreList = new List<string>()
        {
            DAProcedureConstants.ACLG_INSERT_S1,
            DAProcedureConstants.AULG_INSERT_S1,
            DAProcedureConstants.SPLG_INSERT_S1,
            DAProcedureConstants.ERLG_INSERT_S1,
            DAProcedureConstants.RSAC_CHECK_SECUIRTY
           // DAProcedureConstants.UTKT_VALIDATE_S1
        };
        private DateTime startTime = DateTime.Now;

        public void StartDBCall()
        {
            this.startTime = DateTime.Now;
        }

        public void SetStatement(string storedProcedureName, string sqlText)
        {
            this.storedProcedureName = storedProcedureName;
            this.sqlText = sqlText;
        }

        public void EndDBCall(string errorText = "")
        {
            if (!ApplicationSettings.Default.IsLoggingEnabledForSP)
            {
                return;
            }
            if (ignoreList.Contains(this.storedProcedureName))
            {
                return;
            }
            string client = businessBase?.ServerIP;
            if (UtilityHandler.IsEmpty(client))
            {
                client = Dns.GetHostName();
            }
            string workerID = businessBase?.SignedOnWorkerID;
            if (UtilityHandler.IsEmpty(workerID))
            {
                workerID = "ANOYMOUS";
            }
            string applicationName = ApplicationSettings.Default.ApplicationTitle;
            string uniqueID = businessBase?.UniqueID ?? "SERVERCALL";
            SpAccessAuditData activityLogSpDetailsInData = new SpAccessAuditData()
            {
                ApplicationName = applicationName,
                StartTimeDttm = startTime,
                EndTimeDttm = DateTime.Now,
                ErrorText = errorText,
                SqlText = sqlText,
                StoredProcedureName = storedProcedureName
            };

            Task.Factory.StartNew(() =>
            {
                lock (_synRootObj)
                {
                    ActivityLogDA activityLogDA = new ActivityLogDA(businessBase);
                    activityLogDA.AddSpAccessAuditData(activityLogSpDetailsInData);
                }
            });


        }



    }
}