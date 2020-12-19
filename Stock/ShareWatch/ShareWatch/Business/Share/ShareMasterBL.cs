using ShareWatch.BusinessLogic.Common;
using ShareWatch.Common;
using ShareWatch.Common.Utility;
using ShareWatch.DataAccess.Share;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModel.Share.Shrm;
using ShareWatch.DataModel.Share.Shrv;
using ShareWatch.DataModel.Share.Stdv;
using ShareWatch.DataModels.CoreDataModel;
using System.Transactions;

namespace ShareWatch.Business.Share
{
    public partial class ShareMasterBL : BusinessBase
    {
        public ShareMasterBL(BusinessBase businessBase)
               : base(businessBase)
        {

        }

        public StatusOut SaveShare(ShareData input)
        {
            StatusOut output = new StatusOut();
            if (!IsValidInput<ShareMasterData>(input.MarketValue, output, this.IsValid))
            {
                return output;
            }
            using (TransactionScope scope = TransactionScopeBase.GetInstance())
            {
                UtilityBL utilityBL = new UtilityBL(businessBase);
               
                ulong newTransactionEventSeqNumb = utilityBL.Generatevent("SaveShareMaster");
                input.MarketValue.NewTransactionEventSeqNumb = newTransactionEventSeqNumb;
                ShareMasterDA shareMasterDA = new ShareMasterDA(businessBase);
                ShareTradeValueDA shareTradeValueDA = new ShareTradeValueDA(businessBase);
                SaveShareMaster(input.MarketValue);
                ShareTradeValueData data = input.TraderValue;
                data.NewTransactionEventSeqNumb = newTransactionEventSeqNumb;
                if (data.BuyAtAmnt > 0
                   || data.SellAtAmnt > 0)
                {
                   int rowsAffected = shareTradeValueDA.SaveShareTradeValue(data);
                }
                scope.Complete();
            }
            return output;
        }

        public StatusOut SaveShareMaster(ShareMarketValueData input)
        {
            StatusOut output = new StatusOut();
            if (!IsValidInput<ShareMasterData>(input, output, this.IsValid))
            {
                return output;
            }

            if (input.Week52LowAmnt == 0 
                 || (input.LowAmnt > 0 && input.LowAmnt < input.Week52LowAmnt)
                 )
            {
                input.Week52LowAmnt = input.LowAmnt;
            }
            if (input.Week52HighAmnt == 0
                || input.HighAmnt > input.Week52HighAmnt )
            {
                input.Week52HighAmnt = input.HighAmnt;
            }
         
            using (TransactionScope scope = TransactionScopeBase.GetInstance())
            {
                //Skip  generating new events
                if (input.NewTransactionEventSeqNumb == 0)
                {
                    UtilityBL utilityBL = new UtilityBL(businessBase);
                    input.NewTransactionEventSeqNumb = utilityBL.Generatevent("SaveShareMaster");
                }
                ShareMasterDA shareMasterDA = new ShareMasterDA(businessBase);
                ShareMarketValueDA shareMarketValueDA = new ShareMarketValueDA(businessBase);
                int rowsAffected = shareMasterDA.SaveShareMaster(input);
                if(input.CurrentAmnt > 0)
                {
                    shareMarketValueDA.SaveShareMarketValue(input);
                }
                scope.Complete();
            }
            return output;
        }

        public StatusOut DeleteShareMaster(ShareMarketValueData input)
        {
            StatusOut output = new StatusOut();

            if (!IsValidKeyInput<ShareMasterData>(input, output, this.IsValid))
            {
                return output;
            }
            using (TransactionScope scope = TransactionScopeBase.GetInstance())
            {

                UtilityBL utilityBL = new UtilityBL(businessBase);
                input.NewTransactionEventSeqNumb = utilityBL.Generatevent("DeleteShareMaster");

                ShareMasterDA shareMasterDA = new ShareMasterDA(businessBase);
                int rowsAffected = shareMasterDA.DeleteShareMaster(input);

                scope.Complete();
            }
            return output;
        }

        public OutRecordsListData<ShareMasterData> GetSharesDetail(ShareKeyData input)
        {
            ShareMasterDA shareMasterDA = new ShareMasterDA(businessBase);
            return shareMasterDA.GetSharesDetail(input);

        }
    }
}
