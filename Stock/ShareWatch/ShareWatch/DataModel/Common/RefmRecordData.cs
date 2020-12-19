namespace ShareWatch.DataModels.Common
{
    /// <summary>
    /// Data class to hold the REFM related data
    /// </summary>
    public class RefmRecordData
    {

        /// <summary>
        /// This is a cross reference field for REFM that stores the actual description of the UDC code.
        /// </summary>
        public string TableID
        {
            get;
            set;
        } = string.Empty;

        /// <summary>
        /// This is a cross reference field for REFM that stores the actual description of the UDC code.
        /// </summary>
        public string TableSubID
        {
            get;
            set;
        } = string.Empty;

        /// <summary>
        /// Gets or sets the display order numb.
        /// </summary>
        public int DispOrder
        {
            get;
            set;
        } = 0;


        /// <summary>
        /// Identifies the value within the Reference Table.
        /// </summary>
        public string Code
        {
            get;
            set;
        } = string.Empty;


        /// <summary>
        /// Identifies the values description within the Reference Table.
        /// </summary>
        public string Description
        {
            get;
            set;
        } = string.Empty;


    }
}