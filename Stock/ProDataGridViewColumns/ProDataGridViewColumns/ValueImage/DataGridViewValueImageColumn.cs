using System.Windows.Forms;

namespace ProDataGridViewColumns
{
    public class DataGridViewValueImageColumn : DataGridViewImageColumn
    {
        public DataGridViewValueImageColumn()
        {
            this.CellTemplate = new DataGridViewValueImageCell();
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ValueType = typeof(string);
        }


    }
}
