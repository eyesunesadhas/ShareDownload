using System;
using System.Data;

namespace ShareWatch.DataModel.Common
{
    public class JobBase
    {
        public DataRow Data { get; set; } = null;
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; } = DateTime.Now;
        public TimeSpan TimeTaken
        {
            get
            {
                if (EndTime < StartTime) return DateTime.Now - StartTime;
                return EndTime - StartTime;
            }

        }
        public string StatusCode { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public string StackMessgae { get; set; } = string.Empty;

        public virtual void DoJob()
        {
        }
    }
}
