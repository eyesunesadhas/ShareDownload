using System.Windows.Forms;

namespace ProDataGridViewColumns
{
    public class DataGridViewAttachmentColumn : DataGridViewImageColumn
    {
        public DataGridViewAttachmentColumn()
        {
            this.CellTemplate = new DataGridViewAttachmentCell();
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ValueType = typeof(string);
        }
    }
}
