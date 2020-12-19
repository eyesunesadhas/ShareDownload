using ShareWatch.Const;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

namespace ShareWatch.Common
{
    public class ProcessStep
    {
        public string MethodName { get; set; } = string.Empty;
        public object InData { set; get; }
        public object OutData { set; get; }
        public bool IsDbCall { set; get; } = false;
        public string StoredProcedure { set; get; } = string.Empty;
        public string SqlText { set; get; } = string.Empty;
        public DateTime StartTime { set; get; }
        public DateTime EndTime { set; get; }
        public string ExceptionMessage { set; get; } = string.Empty;
        private Dictionary<string, string> OtherDetails { set; get; }

        public ProcessStep(
            object inData,
            Exception ex = null,
            bool isDbCall = false,
            string storedProcedure = "",
            string sqlText = ""
            )
        {
            this.InData = inData;
            this.StartTime = DateTime.Now;
            this.EndTime = Constants.NULL_DATE;
            if (ex != null)
            {
                this.ExceptionMessage = UtilityHandler.GetExceptionMessage(ex);
            }
            this.OtherDetails = new Dictionary<string, string>();
            this.IsDbCall = isDbCall;
            this.StoredProcedure = storedProcedure;
            this.SqlText = sqlText;
            StackTrace stackTrace = new StackTrace();
            StackFrame sf = stackTrace.GetFrame(3);
            string methodName = sf.GetMethod().Name;
            if (methodName == "ExecuteSprocAccessor"
                || methodName == "ExecuteNonQuery")
            {
                sf = stackTrace.GetFrame(4);
            }
            this.MethodName = GetMethodWithClassName(sf);
        }



        private string GetMethodWithClassName(StackFrame sf)
        {
            string methodName = string.Empty;
            if (sf != null)
            {
                MethodBase methodBase = sf.GetMethod();
                if (methodBase != null && methodBase.ReflectedType != null)
                {
                    methodName = methodBase.ReflectedType.FullName + "." + methodBase.Name;
                }
            }
            return methodName;
        }

        /// <summary>
        /// Gets the information.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        public string GetInfo(string key)
        {
            string info = string.Empty;
            if (OtherDetails.ContainsKey(key))
            {
                info = OtherDetails[key];
            }
            return info;

        }


        public void SetInfo(string key, string value)
        {
            if (!OtherDetails.ContainsKey(key))
            {
                OtherDetails.Add(key, value);
            }

        }
    }
}