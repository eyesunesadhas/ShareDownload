using System;
using System.Windows.Forms;

namespace ProDataGridViewColumns
{


    public class DataGridViewCalenderColumn : DataGridViewColumn
    {
        public DataGridViewCalenderColumn() : base(new DataGridViewCalenderCell())
        {
        }

        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                // Ensure that the cell used for the template is a CalendarCell.
                if (value != null &&
                    !value.GetType().IsAssignableFrom(typeof(DataGridViewCalenderColumn)))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }
    }
}
