using System;

namespace ShareWatch.ExcelExport
{
    public class ExcelColumn
    {
        public string ColumnName { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string Alignment { get; set; } = "left";
        public Type DataType { get; set; } = Type.GetType("System.String");
        public float Width { get; set; } = 1;
        public bool IndicatorColumn { get; set; } = false;
        public string Formula { get; set; } = string.Empty;
    }
}
