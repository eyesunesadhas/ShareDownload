using Microsoft.Practices.EnterpriseLibrary.Data;
using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataAccess.Common;
using ShareWatch.DataAccess.Share.Shrm.Mapper;
using ShareWatch.DataModel.Share.Shrm;
using ShareWatch.DataModel.Share.Shrv;
using ShareWatch.DataModels.CoreDataModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace ShareWatch.DataAccess.Share
{

    public class ShareMarketValueDA : DataAccessBase
    {
        public ShareMarketValueDA(BusinessBase businessBase)
            : base(businessBase)
        {
        }

        public int SaveShareMarketValueTrend(List<ShareMarketValueData> input)
        {
            int rowAffected = 0;
            string logonUser = businessBase.SignedOnWorkerID;
            string ins = "INSERT INTO ShareMarketValueHist_T1(Trade_CODE,Trade_DATE,Open_AMNT,Close_AMNT,Low_AMNT,High_AMNT,Current_AMNT,Volume_CNT,AvgVol_CNT,WorkerUpdate_ID)";
            if(input.Count == 0)
            { 
                return rowAffected;
            }
            SaveShareMarketValue(input[0]);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ins);
            sb.AppendLine(" VALUES");
            List<string> valList = new List<string>();
            string tradeCode = string.Empty;
            foreach(ShareMarketValueData data in input)
            {
                tradeCode = data.TradeCode;
                string insSql = $"('{data.TradeCode}','{data.TradeDate:MM/dd/yyyy}', {data.OpenAmnt} , {data.CloseAmnt}, {data.LowAmnt} , {data.HighAmnt} , {data.CurrentAmnt}, {data.VolumeCount}, {data.AvgVolCount},'{logonUser}')";
                valList.Add(insSql);
            }
            sb.AppendLine(string.Join(",\n", valList));
            string sql = sb.ToString();
            using (SqlConnection Cn = new SqlConnection(ApplicationSettings.Default.DBConnectionString ))
            {
                try
                {
                    Cn.Open();
                    using SqlCommand cmd = new SqlCommand
                    {
                        Connection = Cn,
                        CommandType = CommandType.Text
                    };
                    cmd.CommandText = $"DELETE FROM ShareMarketValueHist_T1 WHERE Trade_CODE = '{tradeCode}';" ;
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = sql;
                    rowAffected= cmd.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    if (Cn.State == ConnectionState.Open)
                    {
                        Cn.Close();
                    }
                }
            }
            return rowAffected;
        }
        public int SaveShareMarketValue(ShareMarketValueData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Update);
            using DbCommand dbCommand = daUtility.DataBase.GetStoredProcCommand(DAProcedureConstants.SHRV_SAVE_S1);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_TRADE_CODE, DbType.String, 15, input.TradeCode);
            daUtility.AddInput(dbCommand, DAParameterConstants.AD_TRADE_DATE, DbType.DateTime2, 0, input.TradeDate);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_OPEN_AMNT, DbType.Decimal, 19, 4, input.OpenAmnt);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_CLOSE_AMNT, DbType.Decimal, 19, 4, input.CloseAmnt);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_LOW_AMNT, DbType.Decimal, 19, 4, input.LowAmnt);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_HIGH_AMNT, DbType.Decimal, 19, 4, input.HighAmnt);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_CURRENT_AMNT, DbType.Decimal, 19, 4, input.CurrentAmnt);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_VOLUME_CNT, DbType.Int64, 19, input.VolumeCount);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_AVGVOL_CNT, DbType.Int64, 19, input.AvgVolCount);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_TRANSACTIONEVENTSEQ_NUMB, DbType.Decimal, 19, input.TransactionEventSeqNumb);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_NEWTRANSACTIONEVENTSEQ_NUMB, DbType.Decimal, 19, input.NewTransactionEventSeqNumb);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_SIGNEDONWORKER_ID, DbType.String, 36, businessBase.SignedOnWorkerID);
            return daUtility.DataBase.ExecuteNonQuery(dbCommand, input);

        }



        public int DeleteShareMarketValue(ShareKeyData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Delete);
            using DbCommand dbCommand = daUtility.DataBase.GetStoredProcCommand(DAProcedureConstants.SHRV_DELETE_S1);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_TRADE_CODE, DbType.String, 15, input.TradeCode);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_TRANSACTIONEVENTSEQ_NUMB, DbType.Decimal, 19, input.TransactionEventSeqNumb);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_SIGNEDONWORKER_ID, DbType.String, 36, businessBase.SignedOnWorkerID);
            return daUtility.DataBase.ExecuteNonQuery(dbCommand, input);

        }



        public OutRecordsListData<ShareMarketValueData> GetShareValue(ShareKeyData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Inquiry);
            OutRecordsListData<ShareMarketValueData> output = new OutRecordsListData<ShareMarketValueData>();
            IRowMapper<ShareMarketValueData> rowMapper = MapBuilder<ShareMarketValueData>.MapNoProperties()
            .Map(outData => outData.TradeCode).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.TRADE_CODE)))
            .Map(outData => outData.TradeName).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.TRADE_NAME)))
            .Map(outData => outData.RegionName).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.REGION_NAME)))
            .Map(outData => outData.CountryCode).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.COUNTRY_CODE)))
            .Map(outData => outData.ExchangeCode).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.EXCHANGE_CODE)))
            .Map(outData => outData.SectorName).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.SECTOR_NAME)))
            .Map(outData => outData.TypeCode).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.TYPE_CODE)))
            .Map(outData => outData.CurrencyCode).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.CURRENCY_CODE)))
            .Map(outData => outData.IndustryName).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.INDUSTRY_NAME)))
            .Map(outData => outData.FTEmployeesCount).ToColumn(DACursorConstants.FT_EMPLOYEES_CNT)
            .Map(outData => outData.LatestQuarterDate).ToColumn(DACursorConstants.LATEST_QUARTER_DATE)
            .Map(outData => outData.MarketGapNumb).ToColumn(DACursorConstants.MARKET_GAP_NUMB)
            .Map(outData => outData.PERatioNumb).ToColumn(DACursorConstants.PE_RATIO_NUMB)
            .Map(outData => outData.BookValueNumb).ToColumn(DACursorConstants.BOOK_VALUE_NUMB)
            .Map(outData => outData.DividendPerShareAmnt).ToColumn(DACursorConstants.DIVIDEND_PER_SHARE_AMNT)
            .Map(outData => outData.DividendYieldNumb).ToColumn(DACursorConstants.DIVIDEND_YIELD_NUMB)
            .Map(outData => outData.BuyAtAmnt).ToColumn(DACursorConstants.BUY_AT_AMNT)
            .Map(outData => outData.SellAtAmnt).ToColumn(DACursorConstants.SELL_AT_AMNT)
            .Map(outData => outData.SoldAtAmnt).ToColumn(DACursorConstants.SOLD_AT_AMNT)
            .Map(outData => outData.SoldOnDate).ToColumn(DACursorConstants.SOLD_ON_DATE)
            .Map(outData => outData.Week52HighAmnt).ToColumn(DACursorConstants.WEEK_52_HIGH_AMNT)
            .Map(outData => outData.Week52LowAmnt).ToColumn(DACursorConstants.WEEK_52_LOW_AMNT)
            .Map(outData => outData.Day50MovAvgAmnt).ToColumn(DACursorConstants.DAY_50_MOV_AVG_AMNT)
            .Map(outData => outData.Day200MovAvgAmnt).ToColumn(DACursorConstants.DAY_200_MOV_AVG_AMNT)
            .Map(outData => outData.DividendDate).ToColumn(DACursorConstants.DIVIDEND_DATE)
            .Map(outData => outData.ExDividendDate).ToColumn(DACursorConstants.EX_DIVIDEND_DATE)
            .Map(outData => outData.OpenAmnt).ToColumn(DACursorConstants.OPEN_AMNT)
            .Map(outData => outData.LowAmnt).ToColumn(DACursorConstants.LOW_AMNT)
            .Map(outData => outData.HighAmnt).ToColumn(DACursorConstants.HIGH_AMNT)
            .Map(outData => outData.CurrentAmnt).ToColumn(DACursorConstants.CURRENT_AMNT)
            .Map(outData => outData.VolumeCount).ToColumn(DACursorConstants.VOLUME_CNT)
            .Map(outData => outData.AvgVolCount).ToColumn(DACursorConstants.AVGVOL_CNT)
            .Map(outData => outData.HaveShareIndc).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.HAVE_SHARE_INDC)))
            .Map(outData => outData.BuyRecommendationIndc).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.BUY_RECO_INDC)))
            .Map(outData => outData.BuyRecommendationByName).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.BUY_RECO_BY_NAME)))
            .Map(outData => outData.BuyRecommendationDate).ToColumn(DACursorConstants.BUY_RECO_DATE)
            .Map(outData => outData.TradeDate).ToColumn(DACursorConstants.TRADE_DATE)
            .Build();
            daUtility.DataBase.ExecuteSprocAccessor<ShareMarketValueData>(
                 DAProcedureConstants.SHRV_SELECT_S2,
                 new ShareKeyDataMapper(),
                 rowMapper,
                 output,
                 new Object[] { daUtility, input });
            return output;
        }


    }
}
