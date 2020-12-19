using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ProDataGridViewColumns
{
    public class DataGridViewLabelCell : DataGridViewTextBoxCell
    {
        private readonly string newrowvalue = string.Empty;
        public string Format { get; set; } = string.Empty;

        public DataGridViewLabelCell() : base()
        {
            this.ValueType = typeof(string);
        }

        public override object Clone()
        {
            DataGridViewLabelCell cell = (DataGridViewLabelCell)base.Clone();
            cell.Format = this.Format;
            return cell;
        }

        
        protected override void Paint(Graphics graphics, 
                                      Rectangle clipBounds,
                                      Rectangle cellBounds, 
                                      int rowIndex,
                                      DataGridViewElementStates cellState,
                                      object value, 
                                      object formattedValue,
                                      string errorText,
                                      DataGridViewCellStyle cellStyle,
                                      DataGridViewAdvancedBorderStyle advancedBorderStyle,
                                      DataGridViewPaintParts paintParts)
        {
            // Paint the base content
            base.Paint(graphics, 
                       clipBounds,
                       cellBounds,
                       rowIndex,
                       cellState,
                       value,
                       formattedValue, 
                       errorText, 
                       cellStyle,
                       advancedBorderStyle,
                       paintParts);
           
        }

        protected override object GetFormattedValue(
            object value,
            int rowIndex,
            ref DataGridViewCellStyle cellStyle,
            TypeConverter valueTypeConverter,
            TypeConverter formattedValueTypeConverter,
            DataGridViewDataErrorContexts context)
        {
            try
            {
                if (value is null)
                {
                    return string.Empty;
                }
                string val = value.ToString();
                if (string.IsNullOrEmpty(val)
                    || string.IsNullOrEmpty(Format)
                    )
                {
                    return val;
                }


                DateTime dt;
                switch (this.Format)
                {
                    /*  
                   case "USPHONE":
                     return   val.ToString("(###) ### - ####");
                        */
                    case "MM/dd/yyyy":
                    case "MMM yyyy":
                    case "MMMM yyyy":
                    case "hh:mm tt":
                        if (DateTime.TryParse(val, out dt))
                        {
                            if (dt.CompareTo(DataConstants.BLANK_DATE) == 0
                            || dt.CompareTo(DataConstants.MAX_DATE) == 0
                            || dt.Date == DateTime.MinValue)
                            {
                                return (string.Empty);
                            }
                            return dt.ToString(this.Format);
                        }
                        return "";
                    case "MONTH":
                        if (DateTime.TryParse(val, out dt))
                        {
                            if (dt.CompareTo(DataConstants.BLANK_DATE) == 0
                               || dt.CompareTo(DataConstants.MAX_DATE) == 0
                               || dt.Date == DateTime.MinValue)
                            {
                                return (string.Empty);
                            }
                            return dt.ToString("MMMM");
                        }
                        return "";
                    case "hh:mm:ss":
                        if (DateTime.TryParse(val, out dt))
                        {
                            if (dt.CompareTo(DataConstants.BLANK_DATE) == 0
                             || dt.CompareTo(DataConstants.MAX_DATE) == 0
                             || dt.Date == DateTime.MinValue)
                            {
                                return (string.Empty);
                            }
                            return dt.ToString("HH:mm:ss");
                        }
                        return "";
                    case "hh:mm":
                    case "HRSMIN":
                        return HrsMin(val);
                    case "C":
                    case "CURRENCY":
                        {
                            if (val == string.Empty)
                            {
                                return string.Empty;
                            }
                            if (!double.TryParse(val, out double cur))
                            {
                                return string.Empty;
                            }
                            return cur.ToString("C");
                        }
                    case "0.00":
                        {
                            if (val == string.Empty)
                            {
                                return string.Empty;
                            }
                            if (!double.TryParse(val, out double cur))
                            {
                                return string.Empty;
                            }
                            return $"{cur:0.00}";
                        }
                    case "DOLLAR":
                    case "AMOUNT":
                        {
                            if (val == string.Empty)
                            {
                                return string.Empty;
                            }
                            if (!double.TryParse(val, out double cur))
                            {
                                return string.Empty;
                            }
                            return $"$ {cur:0.00}";
                        }
                    case "%":
                    case "PERCENTAGE":
                        {
                            if (val == string.Empty)
                            {
                                return string.Empty;
                            }
                            if (!double.TryParse(val, out double cur))
                            {
                                return string.Empty;
                            }
                            return $"{cur:0.00} %";
                        }
                    case "TIMEFORMAT":
                        double Hrs1 = 0.00;
                        if (val != ".00")
                        {
                            string[] sHrs = val.Split('.');
                            if (sHrs.Length == 2)
                            {
                                Hrs1 = double.Parse(sHrs[0]);
                                double Min = double.Parse(sHrs[1]) / 60.0;
                                Hrs1 += Min;
                            }
                        }
                        int iHrs = (int)Math.Floor((double)Hrs1);
                        int iMin = (int)((Hrs1 - iHrs) * 60.0);
                        string sMin = iMin.ToString("d");
                        sMin = sMin.PadLeft(2, '0');
                        val = iHrs.ToString("d") + ":" + sMin;
                        return val;
                }
                return "";
            }
            catch (Exception ex)
            {
                _ = ex.Message;
                return "";
            }
        }

        public override object DefaultNewRowValue
        {
            get
            {
                return newrowvalue;
            }

        }

        private string HrsMin(string Hrs)
        {
            if (Hrs == "")
            {
                return "";
            }
            if (Hrs.IndexOf(":") > 0)
            {
                return Hrs;
            }
            double hrsmin = double.Parse(Hrs);
            int hrs = (int)hrsmin;
            double min = (hrsmin - hrs) * 100;
            min *= .6;
            int imin = (int)min;
            return (hrs.ToString() + ":" + imin.ToString().PadLeft(2, '0'));
        }

    }

}
