using System.Data;

namespace ShareWatch.DataAccess.Common
{
    /// <summary>
    ///DataRecordRetrieve
    /// </summary>
    public class DataRecordRetrieve
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataRecordRetrieve" /> class.
        /// </summary>
        /// <param name="dataRecord">The data record.</param>
        /// <param name="columnName">Name of the column.</param>
        public DataRecordRetrieve(IDataRecord dataRecord, string columnName)
        {
            this.DataRecord = dataRecord;
            this.ColumnName = columnName;
        }

        /// <summary>
        /// Gets or sets the name of the column.
        /// </summary>
        public string ColumnName
        {
            get;
            set;
        } = string.Empty;

        /// <summary>
        /// Gets or sets the data record.
        /// </summary>
        public IDataRecord DataRecord
        {
            get;
            set;
        } = null;
    }
}