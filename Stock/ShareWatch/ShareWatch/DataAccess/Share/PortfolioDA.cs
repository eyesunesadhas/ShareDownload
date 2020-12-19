using Microsoft.Practices.EnterpriseLibrary.Data;
using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataAccess.Common;
using ShareWatch.DataAccess.Share.Mapper;
using ShareWatch.DataModel.Share.Pfol;
using ShareWatch.DataModels.CoreDataModel;
using System;
using System.Data;
using System.Data.Common;

namespace ShareWatch.DataAccess.Share
{


    public class PortfolioDA : DataAccessBase
    {
        public PortfolioDA(BusinessBase businessBase)
            : base(businessBase)
        {
        }
        public int SavePortfolio(PortfolioData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Update);
            using DbCommand dbCommand = daUtility.DataBase.GetStoredProcCommand(DAProcedureConstants.PFOT_SAVE_S1);
            daUtility.AddInput(dbCommand, DAParameterConstants.AI_TRANS_ID, DbType.Int64, 10, input.TransID);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_TRADE_CODE, DbType.String, 15, input.TradeCode);
            daUtility.AddInput(dbCommand, DAParameterConstants.AI_ACCOUNT_ID, DbType.Int64, 10, input.AccountID);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_SHARES_CNT, DbType.Decimal, 11, input.SharesCount);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_TRANS_ACTION_CODE, DbType.String, 10, input.TransActionCode);
            daUtility.AddInput(dbCommand, DAParameterConstants.AD_TRANS_ACTION_DATE, DbType.DateTime2, 0, input.TransActionDate);
            daUtility.AddInput(dbCommand, DAParameterConstants.AD_SETTLEMENT_DATE, DbType.DateTime2, 0, input.SettlementDate);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_COSTBASIS_AMNT, DbType.Decimal, 19, input.CostBasisAmnt);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_TRANSACTIONEVENTSEQ_NUMB, DbType.Decimal, 19, input.TransactionEventSeqNumb);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_NEWTRANSACTIONEVENTSEQ_NUMB, DbType.Decimal, 19, input.NewTransactionEventSeqNumb);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_SIGNEDONWORKER_ID, DbType.String, 36, businessBase.SignedOnWorkerID);
            daUtility.AddOutput(dbCommand, DAOutParameterConstants.AI_OUTTRANS_ID, DbType.Int64, 10);
            int rowsAffected = daUtility.DataBase.ExecuteNonQuery(dbCommand, input);
            return UtilityHandler.ParseInt32(dbCommand.Parameters[DAOutParameterConstants.AI_OUTTRANS_ID].Value.ToString());
        }

        public int SavePortfolioCostBasis(PortfolioData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Update);
            int output = 0;
            using (DbCommand dbCommand = daUtility.DataBase.GetStoredProcCommand(DAProcedureConstants.PFOL_SAVE_COST_BASIS_S2))
            {
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_TRADE_CODE, DbType.String, 15, input.TradeCode);
                daUtility.AddInput(dbCommand, DAParameterConstants.AI_ACCOUNT_ID, DbType.Int64, 10, input.AccountID);
                daUtility.AddInput(dbCommand, DAParameterConstants.AN_COSTBASIS_AMNT, DbType.Decimal, 19, input.CostBasisAmnt);
                daUtility.AddInput(dbCommand, DAParameterConstants.AN_TRANSACTIONEVENTSEQ_NUMB, DbType.Decimal, 19, input.TransactionEventSeqNumb);
                daUtility.AddInput(dbCommand, DAParameterConstants.AN_NEWTRANSACTIONEVENTSEQ_NUMB, DbType.Decimal, 19, input.NewTransactionEventSeqNumb);
                daUtility.AddInput(dbCommand, DAParameterConstants.AS_SIGNEDONWORKER_ID, DbType.String, 36, businessBase.SignedOnWorkerID);
                output = daUtility.DataBase.ExecuteNonQuery(dbCommand, input);
            }
            return output;
        }

        public OutRecordsListData<PortfolioData> GetPortfolioData(PortfolioData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Inquiry);
            OutRecordsListData<PortfolioData> output = new OutRecordsListData<PortfolioData>();
            IRowMapper<PortfolioData> rowMapper = MapBuilder<PortfolioData>.MapNoProperties()
            .Map(outData => outData.TradeCode).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.TRADE_CODE)))
            .Map(outData => outData.TradeName).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.TRADE_NAME)))
            .Map(outData => outData.AccountID).ToColumn(DACursorConstants.ACCOUNT_ID)
            .Map(outData => outData.BankName).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.BANK_NAME)))
            .Map(outData => outData.BankAccountID).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.BANKACCOUNT_ID)))
            .Map(outData => outData.AccountTypeCode).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.ACCOUNTTYPE_CODE)))
            .Map(outData => outData.AccountTypeText).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.ACCOUNTTYPE_TEXT)))
            .Map(outData => outData.OwnerName).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.OWNER_NAME)))
            .Map(outData => outData.HideAccountIndc).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.HIDE_ACCOUNT_INDC)))
            .Map(outData => outData.SharesCount).ToColumn(DACursorConstants.SHARES_CNT)
            .Map(outData => outData.CostBasisAmnt).ToColumn(DACursorConstants.COSTBASIS_AMNT)
            .Map(outData => outData.CurrentAmnt).ToColumn(DACursorConstants.CURRENT_AMNT)
            .Map(outData => outData.BuyAtAmnt).ToColumn(DACursorConstants.BUY_AT_AMNT)
            .Map(outData => outData.SellAtAmnt).ToColumn(DACursorConstants.SELL_AT_AMNT)
            .Map(outData => outData.SoldAtAmnt).ToColumn(DACursorConstants.SOLD_AT_AMNT)
            .Map(outData => outData.SoldOnDate).ToColumn(DACursorConstants.SOLD_ON_DATE)
            .Map(outData => outData.Week52HighAmnt).ToColumn(DACursorConstants.WEEK_52_HIGH_AMNT)
            .Map(outData => outData.Week52LowAmnt).ToColumn(DACursorConstants.WEEK_52_LOW_AMNT)
            .Map(outData => outData.DividendYieldNumb).ToColumn(DACursorConstants.DIVIDEND_YIELD_NUMB)
            .Map(outData => outData.DividendPerShareAmnt).ToColumn(DACursorConstants.DIVIDEND_PER_SHARE_AMNT)
            .Map(outData => outData.DividendDate).ToColumn(DACursorConstants.DIVIDEND_DATE)
            .Map(outData => outData.PERatioNumb).ToColumn(DACursorConstants.PERATIO_NUMB)
            .Map(outData => outData.TransID).ToColumn(DACursorConstants.TRANS_ID)
            .Map(outData => outData.TransActionCode).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.TRANSACTION_CODE)))
            .Map(outData => outData.TransActionDate).ToColumn(DACursorConstants.TRANS_ACTION_DATE)
            .Map(outData => outData.BuyRecommendationIndc).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.BUY_RECO_INDC)))
            .Map(outData => outData.BuyRecommendationByName).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.BUY_RECO_BY_NAME)))
            .Map(outData => outData.BuyRecommendationDate).ToColumn(DACursorConstants.BUY_RECO_DATE)
            .Build();
            daUtility.DataBase.ExecuteSprocAccessor<PortfolioData>(
                DAProcedureConstants.PFOL_SELECT_S2,
                new PortfolioDataMapper(),
                rowMapper,
                output,
                new Object[] { daUtility, input });
            return output;
        }
    }
}
