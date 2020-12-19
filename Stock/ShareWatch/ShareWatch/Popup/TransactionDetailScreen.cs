using ProDataGridViewColumns;
using ShareWatch.Business.Share;
using ShareWatch.Common;
using ShareWatch.Common.Utility;
using ShareWatch.DataModel.Share.Pfol;
using ShareWatch.DataModels.CoreDataModel;
using System;
using System.Windows.Forms;

namespace ShareWatch.Popup
{
    public partial class TransactionDetailScreen : Form
    {
        public TransactionDetailScreen()
        {
            InitializeComponent();
        }

        public PortfolioData Input { get; set; } = new PortfolioData();

        private void TransactionDetailScreen_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                DesignGrid();
                LoadCombo();
                ShowHeader();
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

        private void DesignGrid()
        {
            Grid.ColumnHeadersVisible = true;
            Grid.RowHeadersVisible = false;
            Grid.BackgroundColor = this.BackColor;
            Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid.AutoGenerateColumns = false;
            Grid.ColumnHeadersHeight = 18;
            Grid.RowTemplate.Height = 18;
            Grid.RowTemplate.ReadOnly = true;
            Grid.AllowUserToAddRows = false;
            Grid.AllowUserToDeleteRows = false;
            Grid.AllowUserToOrderColumns = false;
            Grid.AllowUserToResizeRows = false;
            Grid.AllowUserToResizeColumns = true;
            Grid.Columns.Clear();
            Grid.Columns.Add(ColumnSelector.LabelColumn("Trade", "ShareName", 170, DataGridViewContentAlignment.MiddleLeft, ""));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Account", "BankAccountID", 60, DataGridViewContentAlignment.MiddleLeft, ""));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Share #", "SharesCount", 70, DataGridViewContentAlignment.MiddleRight, "AMOUNT"));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Cost", "CostBasisAmnt", 90, DataGridViewContentAlignment.MiddleRight, "DOLLAR"));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Total", "TotalInvestAmnt", 90, DataGridViewContentAlignment.MiddleRight, "DOLLAR"));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Value", "CurrentAmnt", 50, DataGridViewContentAlignment.MiddleRight, "DOLLAR"));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Ben", "BenefitAmnt", 50, DataGridViewContentAlignment.MiddleRight, "DOLLAR"));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Current", "TotalCurrentAmnt", 90, DataGridViewContentAlignment.MiddleRight, "DOLLAR"));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Total Value", "TotalBenefitAmnt", 90, DataGridViewContentAlignment.MiddleRight, "DOLLAR"));
            Grid.Columns.Add(ColumnSelector.LabelColumn("L52W", "Week52LowAmnt", 70, DataGridViewContentAlignment.MiddleRight, "DOLLAR"));
            Grid.Columns.Add(ColumnSelector.LabelColumn("H52W", "Week52HighAmnt", 70, DataGridViewContentAlignment.MiddleRight, "DOLLAR"));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Action", "TractionActionCode", 50, DataGridViewContentAlignment.MiddleRight, ""));
            Grid.Columns.Add(ColumnSelector.LabelColumn("ActedOn", "TractionActionDate", 80, DataGridViewContentAlignment.MiddleRight, "MM/dd/yyyy"));
            return;
        }

        private void ShowHeader()
        {
            TradeCode.Text = Input.TradeCode;
            AccountID.SelectedValue = Input.AccountID;
        }

        private void ShowData()
        {
            Input.TradeCode = TradeCode.Text;
            int accountID = (int)AccountID.SelectedValue;
            Input.AccountID = accountID;
            PortfolioTransactionBL transactionBL = new PortfolioTransactionBL(BusinessBase.GetInstance());
            OutRecordsListData<PortfolioData> output = transactionBL.GetPortfolio(Input);
            Grid.DataSource = output.Data;
        }

        private void LoadCombo()
        {
            UIUtility.FillAccountsCombo(AccountID);
            UIUtility.SetAutoComplete(TradeCode);
        }

        private void ShowMessage(string message)
        {
            lblMessage.Text = message;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
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
    }
}
