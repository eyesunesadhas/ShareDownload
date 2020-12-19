using Microsoft.Practices.EnterpriseLibrary.Data;
using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataModels.Common;
using ShareWatch.DataModels.CoreDataModel;

namespace ShareWatch.DataAccess.Common
{
    public class EmsgDA : DataAccessBase
    {
        public EmsgDA(BusinessBase businessBase)
            : base(businessBase)
        {
        }


        /// <summary>
        /// Gets the error message code.
        /// </summary>
        /// <returns>Returns GetMessagesRecordData object which contain ErrorCode and DescriptionErrorText</returns>
        public OutRecordsListData<MessageData> GetErrorMessageData()
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Inquiry);
            OutRecordsListData<MessageData> output = new OutRecordsListData<MessageData>();
            IRowMapper<MessageData> rowMapper = MapBuilder<MessageData>.MapNoProperties()
                .Map(outData => outData.ErrorCode).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.ERROR_CODE)))
                .Map(outData => outData.Description).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.DESCRIPTION_ERROR_TEXT)))
                .Build();

            daUtility.DataBase.ExecuteSprocAccessor<MessageData>(
                  DAProcedureConstants.EMSG_SELECT_S1,
                  rowMapper,
                  output);
            return output;
        }


    }
}