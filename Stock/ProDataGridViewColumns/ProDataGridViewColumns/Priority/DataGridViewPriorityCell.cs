using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace ProDataGridViewColumns
{
    public enum Priority { Low, Medium, High };
    public class DataGridViewPriorityCell : DataGridViewImageCell
    {
        static Image Medium, Low, High;
        const int IMAGEWIDTH = 16;

        public DataGridViewPriorityCell()
            : base()
        {
            // Value type is an integer.
            // Formatted value type is an image since we derive from the ImageCell
            this.ValueType = typeof(string);
        }

        protected override object GetFormattedValue(object value, int rowIndex, ref DataGridViewCellStyle cellStyle, TypeConverter valueTypeConverter, TypeConverter formattedValueTypeConverter, DataGridViewDataErrorContexts context)
        {
            if (value == null) return Medium;
            string priority = value as string;
            priority = priority.Trim().ToUpper();
            if (priority == "") return Medium;
            /* to work with old Standard */
            switch (priority)
            {
                case "MINOR": return Low;
                case "MEDIUM": return Medium;
                case "MAJOR": return High;
            }
            switch (priority[0])
            {
                case '0':
                case 'L':
                    return (Low);
                case '1':
                case 'M':
                    return (Medium);
                case '2':
                case 'H':
                    return (High);
            }
            return Medium;
        }

        public override object DefaultNewRowValue
        {
            get { return "N"; }
        }

        /*   protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates elementState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
           {
               Image cellImage = (Image)formattedValue;
               // surpress painting of selection
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

        #region Private Implementation



        #region PreLoad Images
        static DataGridViewPriorityCell()
        {
            Low = ProDataGridViewColumns.Properties.Resources.Low;
            High = ProDataGridViewColumns.Properties.Resources.High;
            Medium = ProDataGridViewColumns.Properties.Resources.Medium;

            /*
            string folder = Application.StartupPath + "\\Images\\";
            string Lowfile = folder + "Low.gif";
            if (!File.Exists(Lowfile))
            {
                throw new ApplicationException("Image file Missing on " + Lowfile);
            }
            Low = Image.FromFile(Lowfile);

            string Mediumfile = folder + "Medium.gif";
            if (!File.Exists(Mediumfile))
            {
                throw new ApplicationException("Image file Missing on " + Mediumfile);
            }
            Medium = Image.FromFile(Mediumfile);

            string Highfile = folder + "High.gif";
            if (!File.Exists(Highfile))
            {
                throw new ApplicationException("Image file Missing on " + Highfile);
            }
            High = Image.FromFile(Highfile); */
        }
        #endregion

        #endregion

    }
}
