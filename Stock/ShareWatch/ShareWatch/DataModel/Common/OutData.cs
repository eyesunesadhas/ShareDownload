namespace ShareWatch.DataModel.Common
{
    public class OutData<T> : StatusOut
    {
        /// <summary>
        /// Gets or sets the return value.
        /// </summary>
        public T Data
        {
            get;
            set;
        }
    }
}
