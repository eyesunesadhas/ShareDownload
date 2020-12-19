using ShareWatch.DataModel.Common;
using System;

namespace ShareWatch.DataModels.Logging
{
    public class UserAccessAuditData : DataModelBase
    {
        public string UniqueID { get; set; } = string.Empty;
        public string ApplicationID { get; set; } = string.Empty;
        public int HttpStatus { get; set; } = 0;
        public DateTime StartTimeDttm { get; set; } = DateTime.Now;
        public DateTime EndTimeDttm { get; set; } = DateTime.Now;
        public string InputJSON { get; set; } = string.Empty;
        public string StatusJSON { get; set; } = string.Empty;

    }

}