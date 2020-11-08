using ShareWatch.DataModel.Common;
using System.Collections.Generic;

namespace ShareWatch.DataModels.CoreDataModel
{
    /// <summary>
    /// To get the list of data for the input provided
    /// Type parameters:
    ///   T:
    ///     The type of elements in the out class.
    /// </summary>
    public class OutRecordsListData<T> : StatusOut
    {
        /// <summary>
        /// The List of Record object. Each record for one row returned from database
        /// Type parameters:
        ///   T:
        ///     The type of elements in the list.
        /// </summary>
        public List<T> Data { get; set; } = new List<T>();

        /// <summary>
        /// Initializes a new instance of the <see cref="OutRecordsListData&lt;T&gt;"/> class.
        /// </summary>
        public OutRecordsListData()
        {
        }
    }
}