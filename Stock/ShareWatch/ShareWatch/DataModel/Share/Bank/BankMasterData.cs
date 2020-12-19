using ShareWatch.Common;
using ShareWatch.Const;

namespace ShareWatch.DataModel.Share.Bank
{
    public class AccountMasterData : AccountKeyData
    {

        public string BankName { get; set; } = string.Empty;
        public string BankAccountID { get; set; } = string.Empty;
        public string AccountTypeCode { get; set; } = string.Empty;
        public string AccountTypeText { get; set; } = string.Empty;
      
        public string OwnerName { get; set; } = string.Empty;

        public string HideAccountIndc { get; set; } = Constants.NO_INDC;
        public string AccountName
        {
            get
            {
                string accountName = BankName.Trim();
                if (!UtilityHandler.IsEmpty(BankAccountID))
                {
                    accountName = $"{accountName} [{BankAccountID}-{AccountTypeCode}] ";
                }
                if (!UtilityHandler.IsEmpty(OwnerName))
                {
                    accountName = $"{accountName} {OwnerName}";
                }
                return accountName;
            }
        }
    }
}
