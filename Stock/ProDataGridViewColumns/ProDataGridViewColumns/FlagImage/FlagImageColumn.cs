using System.Drawing;
using System.Windows.Forms;

namespace ProDataGridViewColumns
{
    public class FlagImageColumn : DataGridViewImageColumn
    {
        public FlagImageColumn()
        {
            this.CellTemplate = new FlagImageCell();
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ValueType = typeof(string);
        }

        public FlagImageColumn(string Header, string Mapping, int Width)
        {
            this.CellTemplate = new FlagImageCell();
            this.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.ValueType = typeof(string);
            this.HeaderText = Header;
            this.DataPropertyName = Mapping;
            this.Width = Width;
        }

        public void AddImage(string key, Image img)
        {
            FlagImageCell.AddImage(key, img);
        }


    }
}
