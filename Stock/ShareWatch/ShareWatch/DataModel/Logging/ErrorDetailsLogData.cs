using ShareWatch.DataModel.Common;

namespace ShareWatch.DataModels.Logging
{
    /// <summary>
    /// In data used to store the error log details in DB
    /// </summary>
    public class ErrorDetailsLogData : DataModelBase
    {
        public string TypeText { get; set; } = string.Empty;
        public string ApplicationID { get; set; } = string.Empty;
        public string AgentText { get; set; } = string.Empty;
        public string InputJSON { get; set; } = string.Empty;
        public string StatusJSON { get; set; } = string.Empty;
        public string ScriptErrorText { get; set; } = string.Empty;
        public string StackTraceText { get; set; } = string.Empty;
        public string BaseExceptionText { get; set; } = string.Empty;
        public string InnerExceptionText { get; set; } = string.Empty;
        public string InnerExceptionStackText { get; set; } = string.Empty;
        public string BusinessObject { get; set; } = string.Empty;
    }
}