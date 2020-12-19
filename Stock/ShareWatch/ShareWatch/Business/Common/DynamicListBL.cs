using ShareWatch.Common;
using ShareWatch.DataAccess.Common;
using ShareWatch.DataModels.Common;
using ShareWatch.DataModels.CoreDataModel;

namespace ShareWatch.BusinessLogic.Common
{
    public class DynamicListBL : BusinessBase
    {
        public DynamicListBL(BusinessBase businessBaseObject)
          : base(businessBaseObject)
        {
        }


        /// <summary>
        /// Gets the list of messages – This function is used to Get the list of messages.
        /// </summary>
        /// <returns>Returns GetMessagesRecordData contains ErrorCode and DescriptionErrorText.</returns>
        public OutRecordsListData<MessageData> GetMessages()
        {
            EmsgDA emsgDA = new EmsgDA(businessBase);
            return emsgDA.GetErrorMessageData();
        }

        public OutRecordsListData<RefmRecordData> LoadRefm()
        {
            RefmDA refmDA = new RefmDA(businessBase);
            return refmDA.GetAllRefmMaintenanceDetails();
        }
    }
}