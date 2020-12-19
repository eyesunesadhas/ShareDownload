using System.Drawing;
using System.Windows.Forms;

namespace ProDataGridViewColumns
{
    public class TextAndImageColumn : DataGridViewTextBoxColumn
    {
        private Image imageValue;
        private Size imageSize;

        public TextAndImageColumn()
        {
            this.CellTemplate = new TextAndImageCell();
        }

        public override object Clone()
        {
            TextAndImageColumn c = base.Clone() as TextAndImageColumn;
            c.imageValue = this.imageValue;
            c.imageSize = this.imageSize;
            return c;
        }

        public Image Image
        {
            get { return this.imageValue; }
            set
            {
                if (this.Image != value)
                {
                    this.imageValue = value;
                    this.imageSize = value.Size;

                    if (this.InheritedStyle != null)
                    {
                        Padding inheritedPadding = this.InheritedStyle.Padding;
                        this.DefaultCellStyle.Padding = new Padding(imageSize.Width,
                                             inheritedPadding.Top, inheritedPadding.Right,
                                             inheritedPadding.Bottom);
                    }
                }
            }
        }

        private TextAndImageCell TextAndImageCellTemplate
        {
            get { return this.CellTemplate as TextAndImageCell; }
        }

        internal Size ImageSize
        {
            get { return imageSize; }
        }
    }

}
