using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataAccess.Common;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModel.Share.Shrm;
using ShareWatch.DataModel.Share.Stdv;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWatch.DataAccess.Share
{
    public class ShareTradeValueDA : DataAccessBase
    {
        public ShareTradeValueDA(BusinessBase businessBase)
            : base(businessBase)
        {
        }

        public int SaveShareTradeValue(ShareTradeValueData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Update);
            int output = 0;
            using (DbCommand dbCommand = daUtility.DataBase.GetStoredProcCommand(DAProcedureConstants.STDV_SAVE_S1))
            {
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_TRADE_CODE, DbType.String, 15, input.TradeCode);
                daUtility.AddInput(dbCommand, DAParameterConstants.AN_BUYAT_AMNT, DbType.Decimal, 19,4, input.BuyAtAmnt);
                daUtility.AddInput(dbCommand, DAParameterConstants.AN_SELLAT_AMNT, DbType.Decimal, 19,4, input.SellAtAmnt);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_SIGNEDONWORKER_ID, DbType.String, 36, businessBase.SignedOnWorkerID);
                int rowsAffected = daUtility.DataBase.ExecuteNonQuery(dbCommand, input);
            }
            return output;
        }


        public OutData<ShareTradeValueData> GetShareTradeValue(ShareKeyData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Inquiry);
            ShareTradeValueData data = new ShareTradeValueData();
            OutData<ShareTradeValueData> output = new OutData<ShareTradeValueData>()
            {
                Data = data
            };
            using (DbCommand dbCommand = daUtility.DataBase.GetStoredProcCommand(DAProcedureConstants.STDV_SELECT_S1))
            {
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_TRADE_CODE, DbType.String, 15, input.TradeCode);
                daUtility.AddOutput(dbCommand, DAOutParameterConstants.AS_TRADE_NAME, DbType.String, 255);
                daUtility.AddOutput(dbCommand, DAOutParameterConstants.AN_CURRENT_AMNT, DbType.Decimal, 19,4);
                daUtility.AddOutput(dbCommand, DAOutParameterConstants.AN_WEEK52HIGH_AMNT, DbType.Decimal, 19,4);
                daUtility.AddOutput(dbCommand, DAOutParameterConstants.AN_WEEK8HIGH_AMNT, DbType.Decimal, 19,4);
                daUtility.AddOutput(dbCommand, DAOutParameterConstants.AN_WEEK8LOW_AMNT, DbType.Decimal, 19,4);
                daUtility.AddOutput(dbCommand, DAOutParameterConstants.AN_SOLDAT_AMNT, DbType.Decimal, 19,4);
                daUtility.AddOutput(dbCommand, DAOutParameterConstants.AD_SOLDON_DATE, DbType.DateTime2, 0);
                daUtility.AddOutput(dbCommand, DAOutParameterConstants.AN_BUYAT_AMNT, DbType.Decimal, 19,4);
                daUtility.AddOutput(dbCommand, DAOutParameterConstants.AN_SELLAT_AMNT, DbType.Decimal, 19,4);
                daUtility.DataBase.ExecuteNonQuery(dbCommand, input);
                // If there is no data
                if (!UtilityHandler.IsDataFound(dbCommand.Parameters))
                {
                    DAUtility.SetNoMatchingRecords(output);
                    return output;
                }
                data.TradeCode = input.TradeCode;
                data.TradeName = dbCommand.Parameters[DAOutParameterConstants.AS_TRADE_NAME].Value.ToString().Trim();
                data.CurrentAmnt = UtilityHandler.ParseDecimal(dbCommand.Parameters[DAOutParameterConstants.AN_CURRENT_AMNT].Value.ToString().Trim());
                data.Week52HighAmnt = UtilityHandler.ParseDecimal(dbCommand.Parameters[DAOutParameterConstants.AN_WEEK52HIGH_AMNT].Value.ToString().Trim());
                data.Week8HighAmnt = UtilityHandler.ParseDecimal(dbCommand.Parameters[DAOutParameterConstants.AN_WEEK8HIGH_AMNT].Value.ToString().Trim());
                data.Week8LowAmnt = UtilityHandler.ParseDecimal(dbCommand.Parameters[DAOutParameterConstants.AN_WEEK8LOW_AMNT].Value.ToString().Trim());
                data.SoldAtAmnt = UtilityHandler.ParseDecimal(dbCommand.Parameters[DAOutParameterConstants.AN_SOLDAT_AMNT].Value.ToString().Trim());
                data.SoldOnDate = UtilityHandler.ParseDateTime(dbCommand.Parameters[DAOutParameterConstants.AD_SOLDON_DATE].Value.ToString());
                data.BuyAtAmnt = UtilityHandler.ParseDecimal(dbCommand.Parameters[DAOutParameterConstants.AN_BUYAT_AMNT].Value.ToString().Trim());
                data.SellAtAmnt = UtilityHandler.ParseDecimal(dbCommand.Parameters[DAOutParameterConstants.AN_SELLAT_AMNT].Value.ToString().Trim());
            }
            return output;
        }

       
    }
}
