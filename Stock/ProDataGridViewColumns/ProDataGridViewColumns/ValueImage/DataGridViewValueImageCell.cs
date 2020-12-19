using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace ProDataGridViewColumns
{

    public class DataGridViewValueImageCell : DataGridViewImageCell
    {
        private static Hashtable mImages = new Hashtable();

        public DataGridViewValueImageCell()
            : base()
        {
            this.ValueType = typeof(string);
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value is DBNull || value == null)
            {
                return GetCellImage("Blank");
            }
            string val = "";
            if (value is bool)
            {
                bool b = (bool)value;
                val = (b) ? "true" : "false";
            }
            else
            {
                val = value.ToString().Trim();
            }
            if (val == "")
            {
                return GetCellImage("Blank");
            }
            return GetCellImage(val);
        }

        public override object DefaultNewRowValue
        {
            get { return ""; }
        }

        /* protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
         {
             Image cellImage = (Image)formattedValue;
             base.Paint(graphics, clipBounds, cellBounds, rowIndex, elementState, value, cellImage, errorText, cellStyle, advancedBorderStyle, (paintParts & ~DataGridViewPaintParts.SelectionBackground));
         } */

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

        private Image GetCellImage(string value)
        {
            if (value == "") value = "Blank";
            value = value.Trim();
            if (mImages.ContainsKey(value)) return (Image)mImages[value];
            string ImgFolder = Application.StartupPath + "\\Images\\";
            string FileName = ImgFolder + value + ".gif";
            if (!File.Exists(FileName)) FileName = ImgFolder + "Blank.gif";
            if (!File.Exists(FileName))
            {
                throw new ApplicationException("Resource Not Found " + FileName);
            }
            Image img = Image.FromFile(FileName);
            mImages.Add(value, img);
            return img;
        }

    }
}
