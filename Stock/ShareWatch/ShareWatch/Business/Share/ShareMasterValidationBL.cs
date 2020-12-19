using ShareWatch.BusinessLogic.Common.Validation;
using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataModel.Share.Shrm;
using ShareWatch.DataModel.Share.Shrv;
using System;

namespace ShareWatch.Business.Share
{
    public partial class ShareMasterBL : BusinessBase
    {

        /* Validation Code block */
        public bool IsValid(ShareMasterData input, ValidationStatus validationStatus)
        {
            validationStatus.ValidateFieldIfEmpty(input.TradeCode, ErrorConstants.ERROR_ENTER_REQUIRED_FIELDS, DMFieldConstants.TRADE_CODE);
            validationStatus.ValidateFieldAlphaNumeric(input.TradeCode, ErrorConstants.ERROR_INVALID_VALUE, DMFieldConstants.TRADE_CODE);
            return validationStatus.IsValid;
        }


        /* Validation Code block */
        public bool IsValid(ShareKeyData input, ValidationStatus validationStatus)
        {
            validationStatus.ValidateFieldIfEmpty(input.TradeCode, ErrorConstants.ERROR_ENTER_REQUIRED_FIELDS, DMFieldConstants.TRADE_CODE);
            validationStatus.ValidateFieldAlphaNumeric(input.TradeCode, ErrorConstants.ERROR_INVALID_VALUE, DMFieldConstants.TRADE_CODE);
            return validationStatus.IsValid;
        }

        /* Validation Code block */
        public bool IsValid(ShareMarketValueData input, ValidationStatus validationStatus)
        {

            return validationStatus.IsValid;
        }

       
    }
}
