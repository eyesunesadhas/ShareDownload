using Microsoft.Practices.EnterpriseLibrary.Data;
using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataAccess.Common;
using ShareWatch.DataAccess.Share.Shrm.Mapper;
using ShareWatch.DataModel.Share.Shrm;
using ShareWatch.DataModel.Share.Shrv;
using ShareWatch.DataModels.CoreDataModel;
using System;
using System.Data;
using System.Data.Common;

namespace ShareWatch.DataAccess.Share
{
    public class ShareMasterDA : DataAccessBase
    {
        public ShareMasterDA(BusinessBase businessBase)
            : base(businessBase)
        {
        }

        public int SaveShareMaster(ShareMasterData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Update);
            using DbCommand dbCommand = daUtility.DataBase.GetStoredProcCommand(DAProcedureConstants.SHRM_SAVE_S1);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_TRADE_CODE, DbType.String, 15, input.TradeCode);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_TRADE_NAME, DbType.String, 255, input.TradeName);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_REGION_NAME, DbType.String, 50, input.RegionName);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_COUNTRY_CODE, DbType.String, 50, input.CountryCode);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_TYPE_CODE, DbType.String, 25, input.TypeCode);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_EXCHANGE_CODE, DbType.String, 25, input.ExchangeCode);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_SECTOR_NAME, DbType.String, 100, input.SectorName);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_CURRENCY_CODE, DbType.String, 25, input.CurrencyCode);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_INDUSTRY_NAME, DbType.String, 100, input.IndustryName);
            daUtility.AddInput(dbCommand, DAParameterConstants.AI_FTEMPLOYEES_CNT, DbType.Int64, 19, input.FTEmployeesCount);
            daUtility.AddInput(dbCommand, DAParameterConstants.AD_LATESTQUARTER_DATE, DbType.DateTime2, 7, input.LatestQuarterDate);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_MARKETGAP_NUMB, DbType.Int64, 19, input.MarketGapNumb);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_PERATIO_NUMB, DbType.Decimal, 10, 5, input.PERatioNumb);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_BOOKVALUE_NUMB, DbType.Decimal, 10, 5, input.BookValueNumb);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_DIVIDENDPERSHARE_AMNT, DbType.Decimal, 19, 2, input.DividendPerShareAmnt);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_DIVIDENDYIELD_NUMB, DbType.Decimal, 10, 5, input.DividendYieldNumb);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_EPS_NUMB, DbType.Decimal, 10, 5, input.EpsNumb);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_WEEK52HIGH_AMNT, DbType.Decimal, 19, input.Week52HighAmnt);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_WEEK52LOW_AMNT, DbType.Decimal, 19, input.Week52LowAmnt);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_DAY50MOVAVG_AMNT, DbType.Decimal, 12, 4, input.Day50MovAvgAmnt);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_DAY200MOVAVG_AMNT, DbType.Decimal, 12, 4, input.Day200MovAvgAmnt);
            daUtility.AddInput(dbCommand, DAParameterConstants.AD_DIVIDEND_DATE, DbType.DateTime2, 7, input.DividendDate);
            daUtility.AddInput(dbCommand, DAParameterConstants.AD_EXDIVIDEND_DATE, DbType.DateTime2, 7, input.ExDividendDate);
            daUtility.AddInput(dbCommand, DAParameterConstants.AC_BUY_RECO_INDC, DbType.String, 1, input.BuyRecommendationIndc);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_BUY_RECO_BY_NAME, DbType.String, 50, input.BuyRecommendationByName);
            daUtility.AddInput(dbCommand, DAParameterConstants.AD_BUY_RECO_DATE, DbType.DateTime2, 7, input.BuyRecommendationDate);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_TRANSACTIONEVENTSEQ_NUMB, DbType.Decimal, 19, input.TransactionEventSeqNumb);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_NEWTRANSACTIONEVENTSEQ_NUMB, DbType.Decimal, 19, input.NewTransactionEventSeqNumb);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_SIGNEDONWORKER_ID, DbType.String, 36, businessBase.SignedOnWorkerID);
            return daUtility.DataBase.ExecuteNonQuery(dbCommand, input);
        }


        public int DeleteShareMaster(ShareMarketValueData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Delete);
            int output = 0;
            using (DbCommand dbCommand = daUtility.DataBase.GetStoredProcCommand(DAProcedureConstants.SHRM_DELETE_S1))
            {
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_TRADE_CODE, DbType.String, 15, input.TradeCode);
                daUtility.AddInput(dbCommand, DAParameterConstants.AN_TRANSACTIONEVENTSEQ_NUMB, DbType.Decimal, 19, input.TransactionEventSeqNumb);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_SIGNEDONWORKER_ID, DbType.String, 36, businessBase.SignedOnWorkerID);
                int rowsAffected = daUtility.DataBase.ExecuteNonQuery(dbCommand, input);
            }
            return output;
        }

        public OutRecordsListData<ShareMasterData> GetSharesDetail(ShareKeyData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Inquiry);
            OutRecordsListData<ShareMasterData> output = new OutRecordsListData<ShareMasterData>();
            IRowMapper<ShareMasterData> rowMapper = MapBuilder<ShareMasterData>.MapNoProperties()
             .Map(outData => outData.TradeCode).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.TRADE_CODE)))
             .Map(outData => outData.TradeName).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.TRADE_NAME)))
            .Build();
            daUtility.DataBase.ExecuteSprocAccessor<ShareMasterData>(
                DAProcedureConstants.SHRM_SELECT_S2,
                new ShareKeyDataMapper(),
                  rowMapper,
                  output,
                  new Object[] { daUtility, input });
            return output;
        }


    }
}
