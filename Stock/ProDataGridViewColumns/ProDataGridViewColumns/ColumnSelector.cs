using System.Collections;
using System.Data;
using System.Windows.Forms;

namespace ProDataGridViewColumns
{
    public class ColumnSelector
    {
        private ColumnSelector()
        {

        }

        #region DataGridViewCheckBoxColumn
        public static DataGridViewCheckBoxColumn CheckBoxColumn(string Header, string DataField, int Width)
        {
            DataGridViewCheckBoxColumn chkcol = new DataGridViewCheckBoxColumn(false)
            {
                DataPropertyName = DataField,
                HeaderText = Header,
                Width = Width
            };
            return chkcol;
        }

        public static DataGridViewCheckBoxColumn CheckBoxColumn(string Header, string DataField, int Width, bool ReadOnly)
        {
            DataGridViewCheckBoxColumn chkcol = CheckBoxColumn(Header, DataField, Width);
            chkcol.ReadOnly = ReadOnly;
            return chkcol;
        }

        public static DataGridViewCheckBoxColumn CheckBoxColumn(string Header, string DataField, int Width
                    , string TrueValue, string FalseValue)
        {
            DataGridViewCheckBoxColumn chkcol = CheckBoxColumn(Header, DataField, Width);
            chkcol.TrueValue = TrueValue;
            chkcol.FalseValue = FalseValue;
            return chkcol;
        }

        /* Added by Muthu V ::  I0046553 - Timesheet view for Client  - Changes proposed by Claude & Arun */
        public static DataGridViewCheckBoxColumn CheckBoxColumn(string Header, string DataField, int Width, string TrueValue, string FalseValue
                      , DataGridViewAutoSizeColumnMode colmode, int Minimumwidth, int FillWeight)
        {

            DataGridViewCheckBoxColumn chkcol = CheckBoxColumn(Header, DataField, Width, TrueValue, FalseValue);
            return (DataGridViewCheckBoxColumn)ColumnType(chkcol, colmode, Minimumwidth, FillWeight);
        }


        #endregion

        public static DataGridViewComboBoxColumn ComboBoxColumn(string Header, string DataField, int Width
                                                                , DataTable Dt, string DisplayMember, string ValueMember)
        {
            DataGridViewComboBoxColumn cmbcol = new DataGridViewComboBoxColumn
            {
                HeaderText = Header,
                DataPropertyName = DataField,
                Width = Width,
                DataSource = Dt,
                ValueMember = ValueMember,
                DisplayMember = DisplayMember
            };
            return cmbcol;
        }

        public static DataGridViewComboBoxColumn ComboBoxColumn(string Header, string DataField, int Width
                                                               , DataTable Dt, string DisplayMember, string ValueMember
                                                               , bool ReadOnly)
        {
            DataGridViewComboBoxColumn cmbcol = ComboBoxColumn(Header, DataField, Width, Dt, DisplayMember, ValueMember);
            cmbcol.ReadOnly = ReadOnly;
            return cmbcol;
        }

        public static DataGridViewComboBoxColumn ComboBoxColumn(string Header, string DataField, int Width
                                                               , ArrayList Lookup)
        {
            DataGridViewComboBoxColumn cmbcol = new DataGridViewComboBoxColumn
            {
                HeaderText = Header,
                DataPropertyName = DataField,
                Width = Width
            };
            cmbcol.Items.Clear();
            foreach (string s in Lookup)
            {
                cmbcol.Items.Add(s);
            }
            return cmbcol;
        }


        public static DataGridViewTextBoxColumn TextBoxColumn(string Header, string DataField, int Width)
        {
            DataGridViewTextBoxColumn txtcol = new DataGridViewTextBoxColumn
            {
                HeaderText = Header,
                DataPropertyName = DataField,
                Width = Width
            };
            return txtcol;
        }

        public static DataGridViewTextBoxColumn TextBoxColumn(string Header, string DataField, int Width, bool ReadOnly
                                                             , DataGridViewContentAlignment Alignment)
        {
            DataGridViewTextBoxColumn txtcol = TextBoxColumn(Header, DataField, Width);
            txtcol.ReadOnly = ReadOnly;
            txtcol.DefaultCellStyle.Alignment = Alignment;
            return txtcol;
        }



        public static DataGridViewTextBoxColumn TextBoxColumn(string Header, string DataField, int Width
                         , bool ReadOnly, DataGridViewContentAlignment Alignment, int MaxLength)
        {
            DataGridViewTextBoxColumn txtcol = TextBoxColumn(Header, DataField, Width, ReadOnly, Alignment);
            txtcol.MaxInputLength = MaxLength;
            return txtcol;
        }

        public static DataGridViewLabelColumn LabelColumn(string Header, string DataField, int Width
                        , DataGridViewContentAlignment Alignment, string Format)
        {
            DataGridViewLabelColumn lblcol = new DataGridViewLabelColumn
            {
                HeaderText = Header,
                DataPropertyName = DataField,
                Width = Width,
                Format = Format,
                ReadOnly = true
            };
            lblcol.DefaultCellStyle.Alignment = Alignment;

            return lblcol;
        }
        public static DataGridViewLabelColumn LabelColumn(string Header, string DataField, int Width
                       , DataGridViewContentAlignment Alignment, string Format, DataGridViewAutoSizeColumnMode colmode, int Minimumwidth, int FillWeight)
        {

            DataGridViewLabelColumn lblcol = LabelColumn(Header, DataField, Width, Alignment, Format);
            return (DataGridViewLabelColumn)ColumnType(lblcol, colmode, Minimumwidth, FillWeight);
        }

        public static DataGridViewLinkColumn LinkColumn(string Header, string DataField, int Width
                        , DataGridViewContentAlignment Alignment)
        {
            DataGridViewLinkColumn lnkCol = new DataGridViewLinkColumn
            {
                HeaderText = Header,
                DataPropertyName = DataField,
                Width = Width
            };
            lnkCol.DefaultCellStyle.Alignment = Alignment;
            return lnkCol;
        }

        public static DataGridViewLinkColumn LinkColumn(string Header, string DataField
                      , int Width
                      , DataGridViewContentAlignment Alignment
                      , string LinkText)
        {
            DataGridViewLinkColumn lnkCol = new DataGridViewLinkColumn
            {
                HeaderText = Header,
                DataPropertyName = DataField,
                Text = LinkText,
                Width = Width,
                UseColumnTextForLinkValue = true
            };
            lnkCol.DefaultCellStyle.Alignment = Alignment;

            return lnkCol;
        }


        public static DataGridViewProgressColumn ProgressBarColumn(string Header, string DataField, int Width)
        {
            DataGridViewProgressColumn pbar = new DataGridViewProgressColumn
            {
                HeaderText = Header,
                DataPropertyName = DataField,
                Width = Width
            };
            return pbar;
        }

        public static DataGridViewProgressColumn ProgressBarColumn(string Header, string DataField, int Width, DataGridViewAutoSizeColumnMode colmode, int Minimumwidth, int FillWeight)
        {
            DataGridViewProgressColumn pbar = ProgressBarColumn(Header, DataField, Width);
            pbar.HeaderText = Header;
            pbar.DataPropertyName = DataField;
            pbar.Width = Width;
            return (DataGridViewProgressColumn)ColumnType(pbar, colmode, Minimumwidth, FillWeight);
        }



        public static DataGridViewCalenderColumn CalenderColumn(string Header, string DataField, int Width
                     , DataGridViewAutoSizeColumnMode colmode, int Minimumwidth, int FillWeight)
        {

            DataGridViewCalenderColumn calcol = CalenderColumn(Header, DataField, Width);
            return (DataGridViewCalenderColumn)ColumnType(calcol, colmode, Minimumwidth, FillWeight);
        }



        public static DataGridViewCalenderColumn CalenderColumn(string Header, string DataField, int Width)
        {
            DataGridViewCalenderColumn cc = new DataGridViewCalenderColumn
            {
                HeaderText = Header,
                DataPropertyName = DataField,
                Width = Width
            };
            return cc;
        }

        public static MaskedTextBoxColumn MaskedColumn(string Header, string DataField, int Width, string Mask)
        {
            MaskedTextBoxColumn meb = new MaskedTextBoxColumn
            {
                HeaderText = Header,
                DataPropertyName = DataField,
                Width = Width,
                Mask = Mask
            };
            return meb;
        }


        public static DataGridViewAttachmentColumn AttachmentColumn(string Header, string DataField, int Width)
        {
            DataGridViewAttachmentColumn att = new DataGridViewAttachmentColumn
            {
                HeaderText = Header,
                DataPropertyName = DataField,
                Width = Width
            };
            return att;
        }

        public static DataGridViewAttachmentColumn AttachmentColumn(string Header, string DataField, int Width, DataGridViewAutoSizeColumnMode colmode, int Minimumwidth, int FillWeight)
        {
            DataGridViewAttachmentColumn att = AttachmentColumn(Header, DataField, Width);
            att.HeaderText = Header;
            att.DataPropertyName = DataField;
            att.Width = Width;
            return (DataGridViewAttachmentColumn)ColumnType(att, colmode, Minimumwidth, FillWeight);
        }

        public static DataGridViewValueImageColumn ValueImageColumn(string Header, string DataField, int Width)
        {
            DataGridViewValueImageColumn vim = new DataGridViewValueImageColumn
            {
                HeaderText = Header,
                DataPropertyName = DataField,
                Width = Width
            };
            return vim;
        }

        public static DataGridViewValueImageColumn ValueImageColumn(string Header, string DataField, int Width, DataGridViewAutoSizeColumnMode colmode, int Minimumwidth, int FillWeight)
        {
            DataGridViewValueImageColumn vim = ValueImageColumn(Header, DataField, Width);
            return (DataGridViewValueImageColumn)ColumnType(vim, colmode, Minimumwidth, FillWeight);
        }

        public static DataGridViewPriorityColumn PriorityColumn(string Header, string DataField, int Width)
        {
            DataGridViewPriorityColumn pir = new DataGridViewPriorityColumn
            {
                HeaderText = Header,
                DataPropertyName = DataField,
                Width = Width
            };
            return pir;
        }

        public static DataGridViewPriorityColumn PriorityColumn(string Header, string DataField, int Width, DataGridViewAutoSizeColumnMode colmode, int Minimumwidth, int FillWeight)
        {
            DataGridViewPriorityColumn pir = PriorityColumn(Header, DataField, Width);
            pir.HeaderText = Header;
            pir.DataPropertyName = DataField;
            pir.Width = Width;
            return (DataGridViewPriorityColumn)ColumnType(pir, colmode, Minimumwidth, FillWeight);
        }


        public static FlagImageColumn FlagColumn(string Header, string DataField, int Width)
        {
            FlagImageColumn pir = new FlagImageColumn(Header, DataField, Width);
            return pir;
        }

        public static FlagImageColumn FlagColumn(string Header, string DataField, int Width, DataGridViewAutoSizeColumnMode colmode, int Minimumwidth, int FillWeight)
        {
            FlagImageColumn pir = FlagColumn(Header, DataField, Width);
            return (FlagImageColumn)ColumnType(pir, colmode, Minimumwidth, FillWeight);
        }

        public static DataGridViewLabelColumn DateColumn(string Header, string DataField, int Width
                       , DataGridViewAutoSizeColumnMode colmode, int Minimumwidth, int FillWeight)
        {
            DataGridViewLabelColumn Datecol = new DataGridViewLabelColumn
            {
                HeaderText = Header,
                DataPropertyName = DataField,
                Width = Width,
                Format = "MM/dd/yyyy",
                ReadOnly = true
            };
            Datecol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            return (DataGridViewLabelColumn)ColumnType(Datecol, colmode, Minimumwidth, FillWeight);
        }

        private static DataGridViewColumn ColumnType(DataGridViewColumn col,
            DataGridViewAutoSizeColumnMode colmode,
            int Minimumwidth,
            int FillWeight)
        {
            /*To Identify Various Class Types*/
            /*
            switch (col.GetType().Name)
            {
                case "DataGridViewLabelColumn":
                    col = (DataGridViewLabelColumn)col;
                    break;

                case "FlagImageColumn":
                    col = (FlagImageColumn)col;
                    break;

                case "DataGridViewPriorityColumn":
                    col = (DataGridViewPriorityColumn)col;
                    break;

                case "DataGridViewValueImageColumn":
                    col = (DataGridViewValueImageColumn)col;
                    break;

                case "DataGridViewAttachmentColumn":
                    col = (DataGridViewAttachmentColumn)col;
                    break;

                case "DataGridViewProgressColumn":
                    col = (DataGridViewProgressColumn)col;
                    break;
            }*/


            if (colmode == DataGridViewAutoSizeColumnMode.None && FillWeight > 0)
            {
                if (Minimumwidth <= 1)
                {
                    Minimumwidth = 2;
                }
                col.MinimumWidth = Minimumwidth;
                col.FillWeight = FillWeight;
            }
            else
            {
                col.AutoSizeMode = colmode;
            }
            return col;
        }
    }


}
