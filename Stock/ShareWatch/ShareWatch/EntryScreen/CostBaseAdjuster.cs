using ShareWatch.Business.Share;
using ShareWatch.BusinessLogic.Common.Validation;
using ShareWatch.Common;
using ShareWatch.Common.Utility;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModel.Share.Pfol;
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
    public partial class CostBaseAdjuster : Form
    {
        public PortfolioData Input { get; set; } = new PortfolioData();
        public bool IsDataChanged { get; set; } = false;
        public CostBaseAdjuster()
        {
            InitializeComponent();
        }

        private void Split_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void CostBaseAdjuster_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                UIUtility.FillAccountsCombo(AccountID);
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
                    StatusOut output = portfolioBL.SavePortfolioCostBasis(Input);
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

        private void ShowData()
        {
            ClearError();
            if (Input.AccountID > 0)
            {
                AccountID.SelectedValue = Input.AccountID;
                TradeCode.Text = Input.TradeCode;
                TradeName.Text = UIUtility.GetTradeName(TradeCode);
                CostBasisAmnt.Text = Input.CostBasisAmnt.ToString();
            }
        }

        private bool UpdateInput()
        {
            decimal.TryParse(CostBasisAmnt.Text, out decimal costBasisAmnt);
            Input.TradeCode = TradeCode.Text;
            Input.CostBasisAmnt = costBasisAmnt;
            return true;
          
        }

        private bool IsValidateInput()
        {
            ClearError();
            bool isValid = true;
            if (BaseValidators.IsEmpty(TradeCode.Text))
            {
                EP.SetError(TradeCode, "Enter Required Field");
                isValid = false;
            }
            else if (string.IsNullOrEmpty(UIUtility.GetTradeName(TradeCode)))
            {
                EP.SetError(TradeCode, "Enter Required Field");
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
           
            return isValid;
        }

        private void ClearError()
        {
            EP.SetError(TradeCode, string.Empty);
            EP.SetError(AccountID, string.Empty);
            EP.SetError(CostBasisAmnt, string.Empty);
          
        }

        private void ShowMessage(string msg)
        {
            lblMessage.Text = msg;
        }

      
    }
}
