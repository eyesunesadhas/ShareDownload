using System.Collections.Generic;

namespace ShareWatch.DataModel.Common
{
    public class StatusOut : DataModelBase
    {
        /// <summary>
        /// Gets or sets the status list.
        /// </summary>
        public List<Status> StatusList
        {
            get;
            set;
        } = new List<Status>();

        /// <summary>
        /// Gets or sets the unique identifier.
        /// </summary>

        public string UniqueID
        {
            get;
            set;
        } = string.Empty;
    }
}
