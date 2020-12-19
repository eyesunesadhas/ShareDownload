using ShareWatch.BusinessLogic.Common;
using ShareWatch.Common;
using ShareWatch.DataAccess.Share;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModel.Share.Stdv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace ShareWatch.Business.Share
{
    public partial class ShareTradeValueBL : BusinessBase
    {
        public ShareTradeValueBL(BusinessBase businessBase)
               : base(businessBase)
        {

        }
        public StatusOut SaveShareTradeValue(ShareTradeValueData input)
        {
            StatusOut output = new StatusOut();

            if (!IsValidInput<ShareTradeValueData>(input, output, this.IsValid))
            {
                return output;
            }
            using (TransactionScope scope = TransactionScopeBase.GetInstance())
            {
                ShareTradeValueDA shareTradeValueDA = new ShareTradeValueDA(businessBase);
                int rowAffected = shareTradeValueDA.SaveShareTradeValue(input);
                scope.Complete();
            }
            return output;
        }
        public OutData<ShareTradeValueData> GetShareTradeValue(ShareTradeValueData input)
        {
            OutData<ShareTradeValueData> output = new OutData<ShareTradeValueData>();

            if (!IsValidInput<ShareTradeValueData>(input, output, this.IsValid))
            {
                return output;
            }
            ShareTradeValueDA shareTradeValueDA = new ShareTradeValueDA(businessBase);
            return shareTradeValueDA.GetShareTradeValue(input);
        }


    }
}
