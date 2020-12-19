using System.Windows.Forms;

namespace ProDataGridViewColumns
{
    public class DataGridViewRatingColumn : DataGridViewImageColumn
    {
        public DataGridViewRatingColumn()
        {
            this.CellTemplate = new DataGridViewRatingCell();
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ValueType = typeof(int);
        }
    }


}
