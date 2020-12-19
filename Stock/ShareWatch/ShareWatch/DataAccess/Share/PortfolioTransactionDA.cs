using Microsoft.Practices.EnterpriseLibrary.Data;
using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataAccess.Common;
using ShareWatch.DataAccess.Share.Mapper;
using ShareWatch.DataModel.Share.Pfol;
using ShareWatch.DataModel.Share.Pfot;
using ShareWatch.DataModels.CoreDataModel;
using System;

namespace ShareWatch.DataAccess.Share
{


    public class PortfolioTransactionDA : DataAccessBase
    {
        public PortfolioTransactionDA(BusinessBase businessBase)
            : base(businessBase)
        {
        }

        public OutRecordsListData<PortfolioData> GetPortfolioSummary()
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
                DAProcedureConstants.PFOL_SELECT_SUMM_S3,
                rowMapper,
                output
               );
           // Generate Summery
            if (output.Data.Count > 0)
            {
                decimal totalInvestAmnt = 0;
                decimal totalCurrentAmnt = 0;
                decimal totalBenefitAmnt = 0;
                foreach (PortfolioData data in output.Data)
                {
                    totalInvestAmnt += data.TotalInvestAmnt;
                    totalCurrentAmnt += data.TotalCurrentAmnt;
                    totalBenefitAmnt += data.TotalBenefitAmnt;
                }
                output.Data.Add(new PortfolioData()
                        {
                            TradeCode = "",
                            TradeName = "Summary",
                            SharesCount = 1,
                            CostBasisAmnt = totalInvestAmnt,
                            CurrentAmnt = totalCurrentAmnt
                        }
                );
            }
            return output;
        }



        public OutRecordsListData<PortfolioData> GetPortfolio(PortfolioData input)
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
            .Map(outData => outData.SharesCount).ToColumn(DACursorConstants.SHARES_CNT)
            .Map(outData => outData.CostBasisAmnt).ToColumn(DACursorConstants.COSTBASIS_AMNT)
            .Map(outData => outData.CurrentAmnt).ToColumn(DACursorConstants.CURRENT_AMNT)
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
                DAProcedureConstants.PFOT_SELECT_S2,
                new PortfolioDataMapper(),
                rowMapper,
                output,
                new Object[] { daUtility, input });
            return output;
        }

        public OutRecordsListData<PortfolioTransactionData> GetPortfolioTransaction(PortfolioData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Inquiry);
            OutRecordsListData<PortfolioTransactionData> output = new OutRecordsListData<PortfolioTransactionData>();
            IRowMapper<PortfolioTransactionData> rowMapper = MapBuilder<PortfolioTransactionData>.MapNoProperties()
            .Map(outData => outData.TransActionDate).ToColumn(DACursorConstants.TRANS_ACTION_DATE)
            .Map(outData => outData.TradeCode).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.TRADE_CODE)))
            .Map(outData => outData.TradeName).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.TRADE_NAME)))
            .Map(outData => outData.TransActionCode).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.TRANSACTION_CODE)))
            .Map(outData => outData.SharesCount).ToColumn(DACursorConstants.SHARES_CNT)
            .Map(outData => outData.CostBasisAmnt).ToColumn(DACursorConstants.COSTBASIS_AMNT)
            .Map(outData => outData.SharesInHandCount).ToColumn(DACursorConstants.SHARES_IN_HAND_CNT)
            .Map(outData => outData.RunningInvestAmnt).ToColumn(DACursorConstants.RUNNING_INVEST_AMNT)
            .Map(outData => outData.WorthAmnt).ToColumn(DACursorConstants.WORTH_AMNT)
            .Map(outData => outData.AccountID).ToColumn(DACursorConstants.ACCOUNT_ID)
            .Map(outData => outData.BankName).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.BANK_NAME)))
            .Map(outData => outData.BankAccountID).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.BANKACCOUNT_ID)))
            .Map(outData => outData.AccountTypeCode).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.ACCOUNTTYPE_CODE)))
            .Map(outData => outData.AccountTypeText).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.ACCOUNTTYPE_TEXT)))
            .Map(outData => outData.OwnerName).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.OWNER_NAME)))
            .Map(outData => outData.TransID).ToColumn(DACursorConstants.TRANS_ID)
            .Build();
            daUtility.DataBase.ExecuteSprocAccessor<PortfolioTransactionData>(
                DAProcedureConstants.PFOT_SELECT_TRAN_S1,
                new PortfolioDataMapper(),
                rowMapper,
                output,
                new Object[] { daUtility, input });
            return output;
        }


    }
}
