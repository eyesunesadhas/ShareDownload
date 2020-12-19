using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataAccess.Common;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModels.Common;
using System;
using System.Data;
using System.Data.Common;

namespace ShareWatch.DataAccess.Batch
{
    /// <summary>
    /// Provides the ability to persist and later retrieve the application's data through a batch sp's
    /// </summary>
    public partial class BatchCommonDA : DataAccessBase
    {
        public BatchCommonDA(BusinessBase applicationBase) : base(applicationBase)
        {
        }

        /// <summary>
        /// Retrieves the current date time from Database
        /// </summary>
        /// <returns>Returns out data value contain ReturnValue</returns>
        public OutData<DateTime> GetDBDateTime()
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Inquiry);
            OutData<DateTime> output = new OutData<DateTime>();
            using (DbCommand dbCommand = daUtility.DataBase.GetStoredProcCommand(DAProcedureConstants.BATCH_COMMON_SCALAR_SF_SYS_DATE_TIME))
            {
                daUtility.AddReturn(dbCommand, DAParameterConstants.RETURN_VALUE, DbType.String, 4000, 0);

                daUtility.DataBase.ExecuteNonQuery(dbCommand, null);
                if (!UtilityHandler.IsDataFound(dbCommand.Parameters))
                {
                    DAUtility.SetNoMatchingRecords(output);
                    return output;
                }
                output.Data = UtilityHandler.ParseDateTime(dbCommand.Parameters[DAOutParameterConstants.RETURN_VALUE].Value.ToString());
            }
            return output;
        }

        /// <summary>
        /// Generates the CM event.
        /// </summary>
        /// <param name="input">Input values contains WorkerID,ProcessID,EffectiveEventDate,NoteIndc
        ///     and EventFunctionalSeqNumb</param>
        /// <returns>Returns EventDataOutData values</returns>
        public EventDataOutData GenerateCMEvent(EventDataInData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Insert);
            EventDataOutData output = new EventDataOutData();
            using (DbCommand dbCommand = daUtility.DataBase.GetStoredProcCommand(DAProcedureConstants.BATCH_COMMON_SP_GEN_SEQ_TXN_EVENT))
            {
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_SIGNED_ON_WORKER_ID, DbType.String, 36, businessBase.SignedOnWorkerID);
                daUtility.AddInput(dbCommand, DAParameterConstants.AC_PROCESS_ID, DbType.String, 50, input.ProcessID);
                daUtility.AddInput(dbCommand, DAParameterConstants.AD_EFFECTIVE_EVENT_DATE, DbType.DateTime2, 0, input.EffectiveEventDate);
                daUtility.AddInput(dbCommand, DAParameterConstants.AN_EVENT_FUNCTIONAL_SEQ_NUMB, DbType.Int64, 5, input.EventFunctionalSeqNumb);
                daUtility.AddOutput(dbCommand, DAOutParameterConstants.AN_TRANSACTION_EVENT_SEQ_NUMB, DbType.Int64, 19);
                daUtility.AddOutput(dbCommand, DAOutParameterConstants.AC_MSG_CODE, DbType.String, 1);
                daUtility.AddOutput(dbCommand, DAOutParameterConstants.AS_DESCRIPTION_ERROR_TEXT, DbType.String, 4000);
                int rowAffecred = daUtility.DataBase.ExecuteNonQuery(dbCommand, input);
                //checks if the output has some valid data
                if (!UtilityHandler.IsDataFound(dbCommand.Parameters))
                {
                    DAUtility.SetNoMatchingRecords(output);
                    return output;
                }
                output.TransactionEventSeqNumb = UtilityHandler.ParseULong(dbCommand.Parameters[DAOutParameterConstants.AN_TRANSACTION_EVENT_SEQ_NUMB].Value.ToString().Trim());
                output.MsgCode = dbCommand.Parameters[DAOutParameterConstants.AC_MSG_CODE].Value.ToString().Trim();
                output.DescriptionErrorText = dbCommand.Parameters[DAOutParameterConstants.AS_DESCRIPTION_ERROR_TEXT].Value.ToString().Trim();
            }
            return output;
        }


    }
}