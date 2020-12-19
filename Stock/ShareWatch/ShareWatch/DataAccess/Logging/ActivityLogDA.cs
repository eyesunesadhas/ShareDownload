using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataAccess.Common;
using ShareWatch.DataModels.Logging;
using System.Data;
using System.Data.Common;

namespace ShareWatch.DataAccess.Logging
{
    public class ActivityLogDA : DataAccessBase
    {

        public ActivityLogDA(BusinessBase applicationBase)
           : base(applicationBase)
        {
        }

        public int AddUserAccessAuditData(UserAccessAuditData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Insert);
            int output = 0;
            using (DbCommand dbCommand = daUtility.DataBase.GetStoredProcCommand(DAProcedureConstants.ACLG_INSERT_S1))
            {
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_UNIQUE_ID, DbType.String, 35, businessBase.UniqueID);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_PAGELOCATION, DbType.String, 100, businessBase.PageLocation);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_SERVICE_NAME, DbType.String, 35, businessBase.ServiceName);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_METHOD_NAME, DbType.String, 100, businessBase.MethodName);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_APPLICATION_ID, DbType.String, 16, businessBase.ApplicationID);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_SERVERIP_TEXT, DbType.String, 35, businessBase.ServerIP);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_CLIENTIP_TEXT, DbType.String, 15, businessBase.ClientIP);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_AGENT_TEXT, DbType.String, 400, businessBase.UserAgent);
                daUtility.AddInput(dbCommand, DAParameterConstants.AN_HTTPSTATUS, DbType.Decimal, 3, input.HttpStatus);
                daUtility.AddInput(dbCommand, DAParameterConstants.AD_STARTTIME_DTTM, DbType.DateTime2, 0, input.StartTimeDttm);
                daUtility.AddInput(dbCommand, DAParameterConstants.AD_ENDTIME_DTTM, DbType.DateTime2, 0, input.EndTimeDttm);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_INPUT_JSON, DbType.String, 8000, input.InputJSON);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_STATUS_JSON, DbType.String, 8000, input.StatusJSON);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_SIGNED_ON_WORKER_ID, DbType.String, 36, businessBase.SignedOnWorkerID);
                int rowsAffected = daUtility.DataBase.ExecuteNonQuery(dbCommand, input);
            }
            return output;
        }

        public int AddSpAccessAuditData(SpAccessAuditData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Insert);
            int output = 0;
            using (DbCommand dbCommand = daUtility.DataBase.GetStoredProcCommand(DAProcedureConstants.SPLG_INSERT_S1))
            {
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_APPLICATION_NAME, DbType.String, 50, input.ApplicationName);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_UNIQUE_ID, DbType.String, 35, businessBase.UniqueID);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_APPLICATION_ID, DbType.String, 16, businessBase.ApplicationID);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_STOREDPROCEDURE_NAME, DbType.String, 400, input.StoredProcedureName);
                daUtility.AddInput(dbCommand, DAParameterConstants.AD_STARTTIME_DTTM, DbType.DateTime2, 0, input.StartTimeDttm);
                daUtility.AddInput(dbCommand, DAParameterConstants.AD_ENDTIME_DTTM, DbType.DateTime2, 0, input.EndTimeDttm);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_SQL_TEXT, DbType.String, -1, input.SqlText);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_ERROR_TEXT, DbType.String, 8000, input.ErrorText);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_SIGNED_ON_WORKER_ID, DbType.String, 36, businessBase.SignedOnWorkerID);
                int rowsAffected = daUtility.DataBase.ExecuteNonQuery(dbCommand, input);
            }
            return output;
        }

        public int AddLoginActivity(ActivityLoginData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Insert);
            int output = 0;
            using (DbCommand dbCommand = daUtility.DataBase.GetStoredProcCommand(DAProcedureConstants.AULG_INSERT_S1))
            {
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_UNIQUE_ID, DbType.String, 35, businessBase.UniqueID);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_USER_ID, DbType.String, 36, input.UserID);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_TICKET_ID, DbType.String, 1000, input.TicketID);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_AUTHTYPE_CODE, DbType.String, 10, input.AuthTypeCode);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_CLIENTIP_TEXT, DbType.String, 15, businessBase.ClientIP);
                daUtility.AddInput(dbCommand, DAParameterConstants.AI_ATTEMPT_CNT, DbType.Int64, 3, input.AttemptCnt);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_ERROR_CODE, DbType.String, 18, input.ErrorCode);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_ERROR_TEXT, DbType.String, 300, input.ErrorText);
                output = daUtility.DataBase.ExecuteNonQuery(dbCommand, input);
            }
            return output;
        }


        /// <summary>
        /// Adds the error details.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        public int AddErrorDetails(ErrorDetailsLogData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Insert);
            int output = 0;
            using (DbCommand dbCommand = daUtility.DataBase.GetStoredProcCommand(DAProcedureConstants.ERLG_INSERT_S1))
            {
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_UNIQUE_ID, DbType.String, 35, businessBase.UniqueID);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_TYPE_TEXT, DbType.String, 10, input.TypeText);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_APPLICATION_ID, DbType.String, 16, input.ApplicationID);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_SERVERIP_TEXT, DbType.String, 35, businessBase.ServerIP);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_CLIENTIP_TEXT, DbType.String, 15, businessBase.ClientIP);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_AGENT_TEXT, DbType.String, 400, input.AgentText);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_INPUT_JSON, DbType.String, 8000, input.InputJSON);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_STATUS_JSON, DbType.String, 8000, input.StatusJSON);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_SCRIPTERROR_TEXT, DbType.String, 8000, input.ScriptErrorText);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_STACKTRACE_TEXT, DbType.String, 8000, input.StackTraceText);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_BASEEXCEPTION_TEXT, DbType.String, 4000, input.BaseExceptionText);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_INNEREXCEPTION_TEXT, DbType.String, 4000, input.InnerExceptionText);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_INNEREXCEPTIONSTACK_TEXT, DbType.String, 8000, input.InnerExceptionStackText);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_SIGNED_ON_WORKER_ID, DbType.String, 36, businessBase.SignedOnWorkerID);
                int rowsAffected = daUtility.DataBase.ExecuteNonQuery(dbCommand, input);
            }
            return output;
        }
    }
}