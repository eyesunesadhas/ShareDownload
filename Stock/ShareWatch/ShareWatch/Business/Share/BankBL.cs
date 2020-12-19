using ShareWatch.BusinessLogic.Common;
using ShareWatch.Common;
using ShareWatch.Common.Utility;
using ShareWatch.DataAccess.Share;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModel.Share.Bank;
using ShareWatch.DataModels.CoreDataModel;
using System.Transactions;

namespace ShareWatch.Business.Share
{
    public partial class BankBL : BusinessBase
    {
        public BankBL(BusinessBase businessBase)
               : base(businessBase)
        {

        }

        public OutData<int> SaveBankMaster(AccountMasterData input)
        {
            OutData<int> output = new OutData<int>();

            if (!IsValidInput<AccountMasterData>(input, output, this.IsValid))
            {
                return output;
            }
            using (TransactionScope scope = TransactionScopeBase.GetInstance())
            {

                UtilityBL utilityBL = new UtilityBL(businessBase);
                input.NewTransactionEventSeqNumb = utilityBL.Generatevent("Save Account");
                AccountDA bankDA = new AccountDA(businessBase);
                output.Data = bankDA.SaveBankMaster(input);
                scope.Complete();
            }
            return output;
        }

        public StatusOut DeleteBankMaster(AccountMasterData input)
        {
            StatusOut output = new StatusOut();

            if (!IsValidInput<AccountMasterData>(input, output, this.IsValid))
            {
                return output;
            }
            using (TransactionScope scope = TransactionScopeBase.GetInstance())
            {

                UtilityBL utilityBL = new UtilityBL(businessBase);
                input.NewTransactionEventSeqNumb = utilityBL.Generatevent("Delete Account");

                AccountDA bankDA = new AccountDA(businessBase);
                int rowsAffected = bankDA.DeleteBankMaster(input);

                scope.Complete();
            }
            return output;
        }

        public OutData<AccountMasterData> GetBankMasterData(AccountKeyData input)
        {
            OutData<AccountMasterData> output = new OutData<AccountMasterData>();

            if (!IsValidKeyInput<AccountKeyData>(input, output, this.IsValid))
            {
                return output;
            }
            AccountDA bankDA = new AccountDA(businessBase);
            return bankDA.GetBankMasterData(input);

        }

        public OutRecordsListData<AccountMasterData> GetBanks()
        {
            AccountDA bankDA = new AccountDA(businessBase);
            return bankDA.GetBanks();
        }

        public OutRecordsListData<AccountMasterData> GetBanksList()
        {
            OutRecordsListData<AccountMasterData> output = new OutRecordsListData<AccountMasterData>();
            output.Data.Add(new AccountMasterData()
            {
                AccountID = 0,
                BankName = "All Account"
            });
            AccountDA bankDA = new AccountDA(businessBase);
            OutRecordsListData<AccountMasterData> dbData = bankDA.GetBanks();
            output.Data.AddRange(dbData.Data);
            return output;
        }

    }
}
