using ShareWatch.Common;
using ShareWatch.Common.Utility;
using ShareWatch.DataAccess.Share;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModel.Share.Shrm;
using ShareWatch.DataModel.Share.Stdv;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareWatch.EntryScreen
{
    public partial class TradeValueEstimate : Form
    {
        public ShareKeyData Input { get; set; } = new ShareKeyData();

        
        public bool IsDataChanged { get; set; } = false;
        public TradeValueEstimate()
        {
            InitializeComponent();
        }

        private void TradeValueEstimate_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                TradeCode.Text = Input.TradeCode;
                UIUtility.SetAutoComplete(TradeCode);
                ShowData();
                ShowMessage("Done");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void TradeCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    ShowData();
                    ShowMessage("Done");
                }

            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void TradeCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                TextBox textBox = (TextBox)sender;
                TradeName.Text = UIUtility.GetTradeName(textBox);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }


        }

        private void ShowData()
        {
            ClearData();
            if (string.IsNullOrEmpty(TradeCode.Text.Trim())) 
            {
                ShowMessage("Required Trade code");
                return;
            }
            ShareTradeValueDA shareTradeValueDA = new ShareTradeValueDA(BusinessBase.GetInstance());
            Input.TradeCode = TradeCode.Text.Trim();
          
            OutData<ShareTradeValueData> output = shareTradeValueDA.GetShareTradeValue(Input);
            ShareTradeValueData data = output.Data;
            TradeName.Text = data.TradeName;
            CurrentAmnt.Text = $"{ UIUtility.GetAmountValue(data.CurrentAmnt):0.0000}";
            Week52HighAmnt.Text = $"{UIUtility.GetAmountValue(data.Week52HighAmnt):0.0000}";
            Week8HighAmnt.Text = $"{UIUtility.GetAmountValue(data.Week8HighAmnt):0.0000}";
            Week8LowAmnt.Text = $"{UIUtility.GetAmountValue(data.Week8LowAmnt):0.0000}";
            SoldAtAmnt.Text = $"{UIUtility.GetAmountValue(data.SoldAtAmnt):0.0000}";
            SoldOnDate.Text = $"{UIUtility.GetDateValue(data.SoldOnDate):MM/dd/yyyy}";
            BuyAtAmnt.Text = $"{UIUtility.GetAmountValue(data.BuyAtAmnt):0.0000}";
            SellAtAmnt.Text = $"{UIUtility.GetAmountValue(data.SellAtAmnt):0.0000}";
        }

        private void ClearData()
        {
            TradeName.Text = string.Empty;
            CurrentAmnt.Text = string.Empty;
            Week52HighAmnt.Text = string.Empty;
            Week8HighAmnt.Text = string.Empty;
            Week8LowAmnt.Text = string.Empty;
            BuyAtAmnt.Text = string.Empty;
            SellAtAmnt.Text = string.Empty;
            SoldAtAmnt.Text = string.Empty;
            SoldOnDate.Text = string.Empty;
        }

        private void ShowMessage(string msg)
        {
            lblMessage.Text = msg;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                decimal.TryParse(BuyAtAmnt.Text, out decimal buyAtAmnt);
                decimal.TryParse(SellAtAmnt.Text, out decimal sellAtAmnt);
                ShareTradeValueData input = new ShareTradeValueData
                {
                    TradeCode = TradeCode.Text.Trim(),
                    BuyAtAmnt = buyAtAmnt,
                    SellAtAmnt = sellAtAmnt
                };
                ShareTradeValueDA shareTradeValueDA = new ShareTradeValueDA(BusinessBase.GetInstance());
                int rowAffected = shareTradeValueDA.SaveShareTradeValue(input);
                ShowMessage("Successfully Saved");
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }


        }
    }
}
