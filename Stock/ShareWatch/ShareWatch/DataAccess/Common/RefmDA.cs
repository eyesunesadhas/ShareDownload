using Microsoft.Practices.EnterpriseLibrary.Data;
using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataModels.Common;
using ShareWatch.DataModels.CoreDataModel;

namespace ShareWatch.DataAccess.Common
{
    public class RefmDA : DataAccessBase
    {
        public RefmDA(BusinessBase businessBase)
            : base(businessBase)
        {

        }

        /// <summary>
        /// Loads the REFM details from the REFM_Y1.
        /// </summary>
        /// <returns>Returns RefmRecordData List object which contains TableID,TableSubID,ValueCode and other related information</returns>
        public OutRecordsListData<RefmRecordData> GetAllRefmMaintenanceDetails()
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Inquiry);
            OutRecordsListData<RefmRecordData> output = new OutRecordsListData<RefmRecordData>();
            IRowMapper<RefmRecordData> rowMapper = MapBuilder<RefmRecordData>.MapNoProperties()
                .Map(outData => outData.TableID).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.TABLE_ID)))
                .Map(outData => outData.TableSubID).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.TABLE_SUB_ID)))
                .Map(outData => outData.Code).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.VALUE_CODE)))
                .Map(outData => outData.Description).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.DESCRIPTION_VALUE_TEXT)))
                .Map(outData => outData.DispOrder).ToColumn(DACursorConstants.DISP_ORDER_NUMB)
                .Build();

            daUtility.DataBase.ExecuteSprocAccessor<RefmRecordData>(DAProcedureConstants.REFM_SELECT_S1, rowMapper, output);
            return output;
        }
    }
}