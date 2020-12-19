using ShareWatch.BusinessLogic.Common;
using ShareWatch.Common;
using ShareWatch.Common.Utility;
using ShareWatch.DataAccess.Share;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModel.Share.Shrm;
using ShareWatch.DataModel.Share.Shrv;
using ShareWatch.DataModels.CoreDataModel;
using System.Collections.Generic;
using System.Transactions;

namespace ShareWatch.Business.Share
{
    public class ShareMarketValueBL : BusinessBase
    {
        public ShareMarketValueBL(BusinessBase businessBase)
               : base(businessBase)
        {

        }
        public StatusOut SaveShareMarketValueTrend(List<ShareMarketValueData> input)
        {
            StatusOut output = new StatusOut();
            ShareMarketValueDA shareMarketValueDA = new ShareMarketValueDA(businessBase);
            _ = shareMarketValueDA.SaveShareMarketValueTrend(input);
            return output;
        }
        public StatusOut SaveShareMarketValue(ShareMarketValueData input)
        {
            StatusOut output = new StatusOut();

            if (!IsValidInput<ShareMarketValueData>(input, output, this.IsValid))
            {
                return output;
            }
            using (TransactionScope scope = TransactionScopeBase.GetInstance())
            {

                UtilityBL utilityBL = new UtilityBL(businessBase);
                input.NewTransactionEventSeqNumb = utilityBL.Generatevent("SaveShareMarket");
                ShareMarketValueDA shareMarketValueDA = new ShareMarketValueDA(businessBase);
                int rowsAffected = shareMarketValueDA.SaveShareMarketValue(input);
                scope.Complete();
            }
            return output;
        }

        public StatusOut DeleteShareMarketValue(ShareKeyData input)
        {
            StatusOut output = new StatusOut();

            if (!IsValidInput<ShareKeyData>(input, output, this.IsValid))
            {
                return output;
            }
            using (TransactionScope scope = TransactionScopeBase.GetInstance())
            {
                ShareMarketValueDA shareMarketValueDA = new ShareMarketValueDA(businessBase);
                int rowsAffected = shareMarketValueDA.DeleteShareMarketValue(input);
                scope.Complete();
            }
            return output;
        }

        public OutRecordsListData<ShareMarketValueData> GetShareValue(ShareKeyData input)
        {
            ShareMarketValueDA shareMarketValueDA = new ShareMarketValueDA(businessBase);
            return shareMarketValueDA.GetShareValue(input);

        }

    }
}
