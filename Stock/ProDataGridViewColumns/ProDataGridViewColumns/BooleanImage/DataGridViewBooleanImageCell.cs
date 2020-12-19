using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProDataGridViewColumns
{

    public class DataGridViewBooleanImageCell : DataGridViewImageCell
    {
        static Image TrueImg, FalseImg, BlankImg;
        const int IMAGEWIDTH = 16;

        public DataGridViewBooleanImageCell() : base()
        {
            this.ValueType = typeof(string);
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value is DBNull || value == null) return BlankImg;
            string val = value as string;
            val = val.Trim().ToUpper();
            if (val == "") return BlankImg;
            switch (val[0])
            {
                case 'T':
                case 'Y':
                    return TrueImg;
                case 'F':
                case 'N':
                    return FalseImg;
                default:
                    return BlankImg;
            }
        }

        public override object DefaultNewRowValue
        {
            get { return ""; }
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            Image cellImage = (Image)formattedValue;
            base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, cellImage, errorText, cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.SelectionBackground));
        }

        // Update cell's value when the user clicks on a star
        protected override void OnContentClick(DataGridViewCellEventArgs e)
        {
            base.OnContentClick(e);
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

        #region Pre load Images
        static DataGridViewBooleanImageCell()
        {
            string folder = Application.StartupPath + "\\Images\\";
            string TrueImgFile = folder + "True.gif";
            if (!File.Exists(TrueImgFile))
            {
                throw new ApplicationException("Image file Missing on " + TrueImgFile);
            }
            TrueImg = Image.FromFile(TrueImgFile);

            string FalseImgFile = folder + "False.gif";
            if (!File.Exists(FalseImgFile))
            {
                throw new ApplicationException("Image file Missing on " + FalseImgFile);
            }
            FalseImg = Image.FromFile(FalseImgFile);

            string BlankImgFile = folder + "Blank.gif";
            if (!File.Exists(BlankImgFile))
            {
                throw new ApplicationException("Image file Missing on " + BlankImgFile);
            }
            BlankImg = Image.FromFile(BlankImgFile);
        }
        #endregion

        #endregion

    }
}
