using ShareWatch.Const;
using ShareWatch.DataModel.Common;

namespace ShareWatch.DataModels.Common
{
    /// <summary>
    /// A record is inserted in the GLEV_Y1 Table and a sequence is used to generate a value  for the EventGlobalSeq_NUMB Column
    /// </summary>
    public class EventDataOutData : StatusOut
    {
        /// <summary>
        /// Gets or sets the description error text.
        /// </summary>
        public string DescriptionErrorText
        {
            get;
            set;
        } = string.Empty;

        /// <summary>
        /// Gets or sets the event global seq numb.
        /// </summary>
        public ulong EventGlobalSeqNumb
        {
            get;
            set;
        } = Constants.NULL_ULONG;

        /// <summary>
        /// Gets or sets the MSG code.
        /// </summary>
        public string MsgCode
        {
            get;
            set;
        } = string.Empty;


    }
}