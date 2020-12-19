using ShareWatch.DataModel.Common;

namespace ShareWatch.DataModels.Logging
{
    /// <summary>
    /// The class used to insert data in Auth AUDIT in DB
    /// </summary>
    public class ActivityLoginData : DataModelBase
    {
        public string UserID { get; set; } = string.Empty;
        public string TicketID { get; set; } = string.Empty;
        public string AuthTypeCode { get; set; } = string.Empty;
        public int AttemptCnt { get; set; } = 0;
        public string ErrorCode { get; set; } = string.Empty;
        public string ErrorText { get; set; } = string.Empty;
    }

}