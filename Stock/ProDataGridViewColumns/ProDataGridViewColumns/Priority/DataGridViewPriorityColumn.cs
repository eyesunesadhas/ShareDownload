using System.Windows.Forms;


namespace ProDataGridViewColumns
{
    public class DataGridViewPriorityColumn : DataGridViewImageColumn
    {
        public DataGridViewPriorityColumn()
        {
            this.CellTemplate = new DataGridViewPriorityCell();
        }
    }
}
