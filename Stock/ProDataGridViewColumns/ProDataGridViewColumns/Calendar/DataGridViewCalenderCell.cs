using System;
using System.Windows.Forms;

namespace ProDataGridViewColumns
{
    public class DataGridViewCalenderCell : DataGridViewTextBoxCell
    {
        public DataGridViewCalenderCell() : base()
        {
            // Use the short date format.
            this.Style.Format = "MM/dd/yyyy";
        }

        public override void InitializeEditingControl(int rowIndex, object
            initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            // Set the value of the editing control to the current cell value.
            DateTime dt = DateTime.Today;
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            CalendarEditingControl ctl = DataGridView.EditingControl as CalendarEditingControl;
            ctl.CustomFormat = this.Style.Format;
            ctl.Format = DateTimePickerFormat.Custom;
            if (initialFormattedValue != null)
            {
                string s = initialFormattedValue.ToString();
                DateTime.TryParse(s, out dt);
            }
            ctl.Value = (DateTime)dt;
        }

        public override Type EditType
        {
            get
            {
                // Return the type of the editing contol that CalendarCell uses.
                return typeof(CalendarEditingControl);
            }
        }

        public override Type ValueType
        {
            get
            {
                // Return the type of the value that CalendarCell contains.
                return typeof(DateTime);
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                // Use the current date and time as the default value.
                return DateTime.Now;
            }
        }

    }
}
