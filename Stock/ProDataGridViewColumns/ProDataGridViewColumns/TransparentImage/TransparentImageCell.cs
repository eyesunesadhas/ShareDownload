using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProDataGridViewColumns
{

    public class TransparentImageCell : DataGridViewImageCell
    {
        private static Hashtable mImages = new Hashtable();

        public static void AddImage(string key, Image img)
        {
            mImages.Add(key, img);
        }

        public TransparentImageCell()
            : base()
        {
            this.ValueType = typeof(string);
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value is DBNull || value == null)
            {
                return getCellImage("Blank");
            }
            string val = value as string;
            val = val.Trim();
            if (val == "")
            {
                return getCellImage("Blank");
            }
            return getCellImage(val);
        }

        public override object DefaultNewRowValue
        {
            get { return "Blank"; }
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

        private Image getCellImage(string value)
        {
            if (value == "") value = "Blank";
            value = value.Trim();
            if (mImages.ContainsKey(value)) return (Image)mImages[value];
            return ProDataGridViewColumns.Properties.Resources.blank;
        }

    }
}
