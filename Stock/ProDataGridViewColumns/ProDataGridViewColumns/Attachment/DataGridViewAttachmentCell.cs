using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProDataGridViewColumns
{

    public class DataGridViewAttachmentCell : DataGridViewImageCell
    {
        static Image Attachment, NoAttachment;
        const int IMAGEWIDTH = 16;

        public DataGridViewAttachmentCell()
            : base()
        {
            // Value type is an integer.
            // Formatted value type is an image since we derive from the ImageCell
            this.ValueType = typeof(string);
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value is DBNull || value == null) return NoAttachment;
            string attchment = value as string;
            attchment = attchment.Trim().ToUpper();
            if (attchment == "Y" || attchment == "ATTACH" || attchment == "TRUE") return Attachment;
            return NoAttachment;
        }

        public override object DefaultNewRowValue
        {
            get { return "N"; }
        }


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

        // setup star images
        #region Load images
        static DataGridViewAttachmentCell()
        {
            Attachment = ProDataGridViewColumns.Properties.Resources.Attach;
            NoAttachment = ProDataGridViewColumns.Properties.Resources.Noattach;
            /*
             string folder = Application.StartupPath + "\\Images\\";
             string Attachfile = folder + "Attach.gif";
             if (!File.Exists(Attachfile))
             {
                    throw new ApplicationException("Image file Missing on " + Attachfile);
             }
             Image att = Image.FromFile(Attachfile);
             Attachment = att;

             string NoAttachfile = folder + "NoAttach.gif";
             if (!File.Exists(Attachfile))
             {
                 throw new ApplicationException("Image file Missing on " + Attachfile);
             }
             Image noatt = Image.FromFile(NoAttachfile);
             NoAttachment = noatt; 
             */
        }
        #endregion

        #endregion

    }
}
