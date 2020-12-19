

using ShareWatch.Business.Share;
using ShareWatch.BusinessLogic.Common.Validation;
using ShareWatch.Common;
using ShareWatch.Common.DataStore;
using ShareWatch.Common.Utility;
using ShareWatch.Const;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModel.Share.Pfol;
using System;
using System.Windows.Forms;

namespace ShareWatch.EntryScreen
{
    public partial class PortFolioEntry : Form
    {
        public PortFolioEntry()
        {
            InitializeComponent();
        }

        public PortfolioData Input { get; set; } = new PortfolioData();
        public bool IsDataChanged { get; set; } = false;
        private void BtnSave_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                if (!IsValidateInput())
                {
                    return;
                }
                if (UpdateInput())
                {
                    PortfolioBL portfolioBL = new PortfolioBL(BusinessBase.GetInstance());
                    OutData<int> output = portfolioBL.SavePortfolio(Input);
                    Input.TransID = output.Data;
                    ShowData();
                    IsDataChanged = true;
                    ShowMessage("Successfully Saved");
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

        private bool IsValidateInput()
        {
            DateTime minDate = DateTime.Parse("1/1/1900");
            ClearError();
            bool isValid = true;
            if (BaseValidators.IsEmpty(TradeCode.Text))
            {
                EP.SetError(TradeCode, "Enter Required Field");
                isValid = false;
            }
            else if( string.IsNullOrEmpty(UIUtility.GetTradeName(TradeCode)))
            {
                EP.SetError(TradeCode, "Enter Required Field");
                isValid = false;
            }
            if (BaseValidators.IsEmpty(SharesCount.Text))
            {
                EP.SetError(SharesCount, "Enter Required Field");
                isValid = false;
            }
            else if (!decimal.TryParse(SharesCount.Text, out decimal shareCount))
            {
                EP.SetError(SharesCount, "Required Numberic");
                isValid = false;
            }
            else if (shareCount <= 0)
            {
                EP.SetError(SharesCount, "Enter Valid Share count");
                isValid = false;
            }

            if (BaseValidators.IsEmpty(CostBasisAmnt.Text))
            {
                EP.SetError(CostBasisAmnt, "Enter Required Field");
                isValid = false;
            }
            else if (!decimal.TryParse(CostBasisAmnt.Text, out decimal costBasis))
            {
                EP.SetError(CostBasisAmnt, "Required Numberic");
                isValid = false;
            }
            else if (costBasis <= 0)
            {
                EP.SetError(CostBasisAmnt, "Enter Valid Share amount");
                isValid = false;
            }
            if (TractionActionDate.Value <= minDate)
            {
                EP.SetError(TractionActionDate, "Enter Valid Date");
                isValid = false;
            }
            return isValid;
        }

        private void ClearError()
        {
            EP.SetError(TradeCode, string.Empty);
            EP.SetError(AccountID, string.Empty);
            EP.SetError(SharesCount, string.Empty);
            EP.SetError(CostBasisAmnt, string.Empty);
            EP.SetError(TractionActionCode, string.Empty);
            EP.SetError(TractionActionDate, string.Empty);
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                Input.TransID = 0;
                Input.TradeCode = string.Empty;
                Input.TradeName = string.Empty;
                Input.SharesCount = 0;
                Input.CostBasisAmnt = 0;
                Input.TransActionCode = RefmConstants.TRADE_ACTION_BUY;
                Input.TransActionDate = DateTime.Today;
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

        private void BtnBuyMore_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShowMessage("Please Wait...");
            Input.TransID = 0;
            Input.SharesCount = 0;
            Input.CostBasisAmnt = 0;
            ShowData();
            ShowMessage("Done");
        }

        private bool UpdateInput()
        {
            if (AccountID.SelectedIndex < 0)
            {
                return false;
            }
            _ = int.TryParse(AccountID.SelectedValue.ToString(), out int accountID);
            _ = decimal.TryParse(SharesCount.Text, out decimal sharesCount);
            _ = decimal.TryParse(CostBasisAmnt.Text, out decimal costBasisAmnt);
            Input.TradeCode = TradeCode.Text;
            Input.AccountID = accountID;
            Input.SharesCount = sharesCount;
            Input.CostBasisAmnt = costBasisAmnt;
            Input.TransActionCode = TractionActionCode.SelectedValue.ToString();
            Input.TransActionDate = TractionActionDate.Value.Date;
            return true;
        }

        private void PortFolioEntry_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                UIUtility.FillAccountsCombo(AccountID);
                UIUtility.SetAutoComplete(TradeCode);
                TractionActionCode.DataSource = RefmStore.Instance.GetCodeAndDescriptionMap(
                  RefmTableConstants.TABLE_TRADE_ACTION,
                  RefmTableConstants.SUB_TABLE_TRADE_ACTION
                  );
                TractionActionCode.ValueMember = "Code";
                TractionActionCode.DisplayMember = "Description";
                Input.TransActionDate = DateTime.Today;
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

        private void ShowData()
        {
            ClearError();
            if (Input.AccountID > 0)
            {
                if(string.IsNullOrEmpty(Input.TransActionCode ))
                {
                    Input.TransActionCode = "BUY";
                }
                AccountID.SelectedValue = Input.AccountID;
                TransID.Text = $"{Input.TransID}";
                TradeCode.Text = Input.TradeCode;
                TradeName.Text = UIUtility.GetTradeName(TradeCode);
                SharesCount.Text = $"{Input.SharesCount}";
                CostBasisAmnt.Text = Input.CostBasisAmnt.ToString();
                TotalAmnt.Text = Input.TotalInvestAmnt.ToString();
                TractionActionCode.SelectedValue = Input.TransActionCode;
                TractionActionDate.Value = UtilityHandler.GetBindableDate(Input.TransActionDate);
            }
        }


        private void ShowMessage(string msg)
        {
            lblMessage.Text = msg;
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

        private void SharesCount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                decimal sharesCnt = 0;
                decimal costBasisAmount = 0;
                decimal totalAmount = 0;
                decimal.TryParse(SharesCount.Text.Trim(), out sharesCnt);
                decimal.TryParse(CostBasisAmnt.Text.Trim(), out costBasisAmount);
                totalAmount = sharesCnt * costBasisAmount;
                TotalAmnt.Text = totalAmount.ToString("0.00");
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

   
    }
}
