using System.Windows.Forms;

namespace ProDataGridViewColumns
{
    public class DataGridViewLabelColumn : DataGridViewTextBoxColumn
    {
        public string Format
        {
            set
            {
                if (value == "") return;
                if (this.CellTemplate != null)
                {
                    DataGridViewLabelCell cell = (DataGridViewLabelCell)this.CellTemplate;
                    cell.Format = value;
                    this.CellTemplate = cell;
                }

            }
        }
        public DataGridViewLabelColumn()
        {
            this.CellTemplate = new DataGridViewLabelCell();
            this.ValueType = typeof(string);
        }
    }

}
