using ShareWatch.BusinessLogic.Common.Validation;
using ShareWatch.Common;
using ShareWatch.DataModel.Share.Bank;

namespace ShareWatch.Business.Share
{
    public partial class BankBL : BusinessBase
    {

        /* Validation Code block */
        public bool IsValid(AccountMasterData input, ValidationStatus validationStatus)
        {


            return validationStatus.IsValid;
        }
    }
}
