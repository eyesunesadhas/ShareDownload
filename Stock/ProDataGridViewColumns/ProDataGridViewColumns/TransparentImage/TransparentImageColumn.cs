using System.Drawing;
using System.Windows.Forms;

namespace ProDataGridViewColumns
{
    public class TransparentImageColumn : DataGridViewImageColumn
    {
        public TransparentImageColumn()
        {
            this.CellTemplate = new TransparentImageCell();
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ValueType = typeof(string);
        }

        public TransparentImageColumn(string Header, string Mapping, int Width)
        {
            this.CellTemplate = new TransparentImageCell();
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ValueType = typeof(string);
            this.HeaderText = Header;
            this.DataPropertyName = Mapping;
            this.Width = Width;
        }

        public void AddImage(string key, Image img)
        {
            TransparentImageCell.AddImage(key, img);
        }

    }
}
