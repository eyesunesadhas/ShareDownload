using System.Windows.Forms;

namespace ProDataGridViewColumns
{
    public class DataGridViewBooleanImageColumn : DataGridViewImageColumn
    {
        public DataGridViewBooleanImageColumn()
        {
            this.CellTemplate = new DataGridViewBooleanImageCell();
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ValueType = typeof(string);
        }
    }
}
