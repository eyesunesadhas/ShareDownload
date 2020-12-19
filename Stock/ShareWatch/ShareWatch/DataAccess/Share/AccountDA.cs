using Microsoft.Practices.EnterpriseLibrary.Data;
using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataAccess.Common;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModel.Share.Bank;
using ShareWatch.DataModels.CoreDataModel;
using System.Data;
using System.Data.Common;

namespace ShareWatch.DataAccess.Share
{
    public class AccountDA : DataAccessBase
    {
        public AccountDA(BusinessBase businessBase)
            : base(businessBase)
        {
        }

        public int SaveBankMaster(AccountMasterData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Update);
            using DbCommand dbCommand = daUtility.DataBase.GetStoredProcCommand(DAProcedureConstants.BANK_SAVE_S1);
            daUtility.AddInput(dbCommand, DAParameterConstants.AI_ACCOUNT_ID, DbType.Int64, 10, input.AccountID);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_BANK_NAME, DbType.String, 255, input.BankName);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_BANKACCOUNT_ID, DbType.String, 20, input.BankAccountID);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_ACCOUNTTYPE_CODE, DbType.String, 10, input.AccountTypeCode);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_OWNER_NAME, DbType.String, 255, input.OwnerName);
            daUtility.AddInput(dbCommand, DAParameterConstants.AC_HIDE_ACCOUNT_INDC, DbType.String, 1, input.HideAccountIndc);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_TRANSACTIONEVENTSEQ_NUMB, DbType.Decimal, 19, input.TransactionEventSeqNumb);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_NEWTRANSACTIONEVENTSEQ_NUMB, DbType.Decimal, 19, input.NewTransactionEventSeqNumb);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_SIGNEDONWORKER_ID, DbType.String, 36, businessBase.SignedOnWorkerID);
            daUtility.AddOutput(dbCommand, DAOutParameterConstants.AI_ACCOUNT_ID_OUT, DbType.Int64, 10);
            int rowsAffected = daUtility.DataBase.ExecuteNonQuery(dbCommand, input);
            return UtilityHandler.ParseInt32(dbCommand.Parameters[DAOutParameterConstants.AI_ACCOUNT_ID_OUT].Value.ToString());
        }




        public int DeleteBankMaster(AccountMasterData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Update);
            using DbCommand dbCommand = daUtility.DataBase.GetStoredProcCommand(DAProcedureConstants.BANK_DELETE_S1);
            daUtility.AddInput(dbCommand, DAParameterConstants.AI_ACCOUNT_ID, DbType.Int64, 10, input.AccountID);
            daUtility.AddInput(dbCommand, DAParameterConstants.AN_TRANSACTION_EVENT_SEQ_NUMB, DbType.Decimal, 19, input.TransactionEventSeqNumb);
            daUtility.AddInput(dbCommand, DAParameterConstants.AS_SIGNEDONWORKER_ID, DbType.String, 36, businessBase.SignedOnWorkerID);
            return daUtility.DataBase.ExecuteNonQuery(dbCommand, input);
        }

        public OutData<AccountMasterData> GetBankMasterData(AccountKeyData input)
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Inquiry);
            AccountMasterData data = new AccountMasterData();
            OutData<AccountMasterData> output = new OutData<AccountMasterData>()
            {
                Data = data
            };
            using (DbCommand dbCommand = daUtility.DataBase.GetStoredProcCommand(DAProcedureConstants.BANK_SELECT_S1))
            {
                daUtility.AddInput(dbCommand, DAParameterConstants.AI_ACCOUNT_ID, DbType.Int64, 10, input.AccountID);
                daUtility.AddOutput(dbCommand, DAOutParameterConstants.AS_BANK_NAME, DbType.String, 255);
                daUtility.AddOutput(dbCommand, DAOutParameterConstants.AS_BANKACCOUNT_ID, DbType.String, 20);
                daUtility.AddOutput(dbCommand, DAOutParameterConstants.AS_ACCOUNTTYPE_CODE, DbType.String, 10);
                daUtility.AddOutput(dbCommand, DAOutParameterConstants.AS_OWNER_NAME, DbType.String, 255);
                daUtility.AddOutput(dbCommand, DAOutParameterConstants.AC_HIDE_ACCOUNT_INDC, DbType.String, 1);
                daUtility.AddOutput(dbCommand, DAOutParameterConstants.AN_TRANSACTIONEVENTSEQ_NUMB, DbType.Int64, 19);

                daUtility.DataBase.ExecuteNonQuery(dbCommand, input);
                // If there is no data
                if (!UtilityHandler.IsDataFound(dbCommand.Parameters))
                {
                    DAUtility.SetNoMatchingRecords(output);
                    return output;
                }
                data.BankName = dbCommand.Parameters[DAOutParameterConstants.AS_BANK_NAME].Value.ToString().Trim();
                data.BankAccountID = dbCommand.Parameters[DAOutParameterConstants.AS_BANKACCOUNT_ID].Value.ToString().Trim();
                data.AccountTypeCode = dbCommand.Parameters[DAOutParameterConstants.AS_ACCOUNTTYPE_CODE].Value.ToString().Trim();
                data.OwnerName = dbCommand.Parameters[DAOutParameterConstants.AS_OWNER_NAME].Value.ToString().Trim();
                data.HideAccountIndc = dbCommand.Parameters[DAOutParameterConstants.AC_HIDE_ACCOUNT_INDC].Value.ToString().Trim();
                data.TransactionEventSeqNumb = UtilityHandler.ParseULong(dbCommand.Parameters[DAOutParameterConstants.AN_TRANSACTIONEVENTSEQ_NUMB].Value.ToString().Trim());
            }
            return output;
        }

        public OutRecordsListData<AccountMasterData> GetBanks()
        {
            DAUtility daUtility = new DAUtility(businessBase, TransactionType.Inquiry);
            OutRecordsListData<AccountMasterData> output = new OutRecordsListData<AccountMasterData>();
            IRowMapper<AccountMasterData> rowMapper = MapBuilder<AccountMasterData>.MapNoProperties()
            .Map(outData => outData.AccountID).ToColumn(DACursorConstants.ACCOUNT_ID)
            .Map(outData => outData.BankName).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.BANK_NAME)))
            .Map(outData => outData.BankAccountID).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.BANKACCOUNT_ID)))
            .Map(outData => outData.AccountTypeCode).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.ACCOUNTTYPE_CODE)))
            .Map(outData => outData.AccountTypeText).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.ACCOUNTTYPE_TEXT)))
            .Map(outData => outData.OwnerName).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.OWNER_NAME)))
            .Map(outData => outData.HideAccountIndc).WithFunc(record => DAUtility.GetString(new DataRecordRetrieve(record, DACursorConstants.HIDE_ACCOUNT_INDC)))
            .Map(outData => outData.TransactionEventSeqNumb).ToColumn(DACursorConstants.TRANSACTION_EVENT_SEQ_NUMB)
            .Build();
            daUtility.DataBase.ExecuteSprocAccessor<AccountMasterData>(
                 DAProcedureConstants.BANK_SELECT_S2,
                 rowMapper,
                 output);
            return output;
        }


    }
}
