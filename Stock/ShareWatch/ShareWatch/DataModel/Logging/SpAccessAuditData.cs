using ShareWatch.DataModel.Common;
using System;

namespace ShareWatch.DataModels.Logging
{
    public class SpAccessAuditData : DataModelBase
    {
        public string ApplicationName { get; set; } = string.Empty;

        public string ApplicationID { get; set; } = string.Empty;
        public string StoredProcedureName { get; set; } = string.Empty;
        public DateTime StartTimeDttm { get; set; } = DateTime.Now;
        public DateTime EndTimeDttm { get; set; } = DateTime.Now;
        public string SqlText { get; set; } = string.Empty;
        public string ErrorText { get; set; } = string.Empty;

    }
}