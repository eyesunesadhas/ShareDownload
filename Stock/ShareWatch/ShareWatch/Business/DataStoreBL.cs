using ShareWatch.Common;
using ShareWatch.Common.DataStore;
using ShareWatch.DataModels.Common;
using ShareWatch.DataModels.CoreDataModel;

namespace ShareWatch.BusinessLogic
{
    public class DataStoreBL : BusinessBase
    {
        public DataStoreBL(BusinessBase businessBase)
               : base(businessBase)
        {

        }

        public OutRecordsListData<MessageData> GetMessages()
        {
            return MessageStore.Instance.GetStoreData();
        }

        public OutRecordsListData<RefmRecordData> GetRefmLookup()
        {
            return RefmStore.Instance.GetStoreData();
        }





    }
}