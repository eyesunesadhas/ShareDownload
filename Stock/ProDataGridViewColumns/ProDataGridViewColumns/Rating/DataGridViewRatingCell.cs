using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProDataGridViewColumns
{
    public class DataGridViewRatingCell : DataGridViewImageCell
    {
        public DataGridViewRatingCell()
            : base()
        {
            // Value type is an integer.
            // Formatted value type is an image since we derive from the ImageCell
            this.ValueType = typeof(int);
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            // Convert integer to star images
            return starImages[(int)value];
        }

        public override object DefaultNewRowValue
        {
            // default new row to 3 stars
            get { return 3; }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            Image cellImage = (Image)formattedValue;

            int starNumber = GetStarFromMouse(cellBounds, this.DataGridView.PointToClient(Control.MousePosition));

            if (starNumber != -1)
                cellImage = starHotImages[starNumber];

            // surpress painting of selection
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, cellImage, errorText, cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.SelectionBackground));
        }

        // Update cell's value when the user clicks on a star
        protected override void OnContentClick(DataGridViewCellEventArgs e)
        {
            try
            {
                base.OnContentClick(e);
                int starNumber = GetStarFromMouse(this.DataGridView.GetCellDisplayRectangle(this.DataGridView.CurrentCellAddress.X, this.DataGridView.CurrentCellAddress.Y, false), this.DataGridView.PointToClient(Control.MousePosition));

                if (starNumber != -1)
                {
                    this.Value = starNumber;
                }
            }
            catch (Exception ex)
            {
                _ = ex.Message;
            }
        }

        #region Invalidate cells when mouse moves or leaves the cell
        protected override void OnMouseLeave(int rowIndex)
        {
            base.OnMouseLeave(rowIndex);
            this.DataGridView.InvalidateCell(this);
        }
        protected override void OnMouseMove(DataGridViewCellMouseEventArgs e)
        {
            base.OnMouseMove(e);
            this.DataGridView.InvalidateCell(this);
        }
        #endregion

        #region Private Implementation
        static Image[] starImages;
        static Image[] starHotImages;
        const int IMAGEWIDTH = 58;

        private int GetStarFromMouse(Rectangle cellBounds, Point mouseLocation)
        {
            if (cellBounds.Contains(mouseLocation))
            {

                int mouseXRelativeToCell = (mouseLocation.X - cellBounds.X);
                int imageXArea = (cellBounds.Width / 2) - (IMAGEWIDTH / 2);
                if (((mouseXRelativeToCell + 4) < imageXArea) || (mouseXRelativeToCell >= (imageXArea + IMAGEWIDTH)))
                    return -1;
                else
                {
                    int oo = (int)Math.Round((((float)(mouseXRelativeToCell - imageXArea + 5) / (float)IMAGEWIDTH) * 5f), MidpointRounding.AwayFromZero);
                    if (oo > 5 || oo < 0) System.Diagnostics.Debugger.Break();
                    return oo;
                }
            }
            else
            {
                return -1;
            }
        }
        // setup star images
        #region Load star images
        static DataGridViewRatingCell()
        {
            starImages = new Image[6];
            starHotImages = new Image[6];
            starImages[0] = ProDataGridViewColumns.Properties.Resources.star0;
            starImages[1] = ProDataGridViewColumns.Properties.Resources.star1;
            starImages[2] = ProDataGridViewColumns.Properties.Resources.star2;
            starImages[3] = ProDataGridViewColumns.Properties.Resources.star3;
            starImages[4] = ProDataGridViewColumns.Properties.Resources.star4;
            starImages[5] = ProDataGridViewColumns.Properties.Resources.star5;

            starHotImages[0] = ProDataGridViewColumns.Properties.Resources.starhot0;
            starHotImages[1] = ProDataGridViewColumns.Properties.Resources.starhot1;
            starHotImages[2] = ProDataGridViewColumns.Properties.Resources.starhot2;
            starHotImages[3] = ProDataGridViewColumns.Properties.Resources.starhot3;
            starHotImages[4] = ProDataGridViewColumns.Properties.Resources.starhot4;
            starHotImages[5] = ProDataGridViewColumns.Properties.Resources.starhot5;

            /*
            string folder = Application.StartupPath + "\\Images\\"; 
            // load normal stars
            for (int i = 0; i <= 5; i++)
            {
                string fileName = folder + "star" + i + ".png";
                if (!File.Exists(fileName))
                {
                    throw new ApplicationException("Star Rating control file Missing on " + fileName);  
                }
                Image img = Image.FromFile(fileName);
                starImages[i] = img;
            }

            // load hot normal stars
            for (int i = 0; i <= 5; i++)
            {
                string fileName = folder + "starhot" + i + ".png";
                if (!File.Exists(fileName))
                {
                    throw new ApplicationException("Star Rating control file Missing on " + fileName);
                }
                Image img = Image.FromFile(fileName);
                starHotImages[i] = img;
            } */
        }
        #endregion

        #endregion

    }
}
