using ShareWatch.DataModel.Common;

namespace ShareWatch.DataModels.CoreDataModel
{
    public class PageData : DataModelBase
    {
        public int PageNumb { get; set; } = 1;
        public int PageSizeNumb { get; set; } = 10;
    }
}