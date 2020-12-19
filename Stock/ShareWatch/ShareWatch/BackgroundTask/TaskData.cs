using System.Collections.Generic;

namespace ShareWatch.BackgroundTask
{
    public class TaskData<T>
    {
        public List<T> Data { get; set; } = new List<T>();
        public int Processed { get; set; } = 0;
        public int Max
        {
            get
            {
                if (Data is null)
                {
                    return 0;
                }
                return Data.Count;
            }
        }
    }
}
