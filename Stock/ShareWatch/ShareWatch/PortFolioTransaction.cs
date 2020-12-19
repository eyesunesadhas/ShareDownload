using ProDataGridViewColumns;
using ShareWatch.Business.Share;
using ShareWatch.Business.Share.Reports;
using ShareWatch.Common;
using ShareWatch.Common.Utility;
using ShareWatch.DataModel.Share.Pfol;
using ShareWatch.DataModel.Share.Pfot;
using ShareWatch.DataModels.CoreDataModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareWatch
{
    public partial class PortFolioTransaction : MDIChildBase
    {
        public PortFolioTransaction()
        {
            InitializeComponent();
        }

        private void PortFolioTransaction_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                DesignGrid();
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

        private void DesignGrid()
        {
            Grid.ColumnHeadersVisible = true;
            Grid.RowHeadersVisible = false;
            Grid.BackgroundColor = this.BackColor;
            Grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
            Grid.Columns.Add(ColumnSelector.LabelColumn("TranDate", "TransActionDate", 70, DataGridViewContentAlignment.MiddleLeft, "MM/dd/yyyy", DataGridViewAutoSizeColumnMode.None, 70, 70));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Symbol", "TradeCode", 80, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 80, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Name", "TradeName", 280, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 280, 800));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Action", "TransActionCode", 90, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 90, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Share #", "SharesCount", 80, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 80, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Cost", "CostBasisAmnt", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Invested", "TotalInvestAmnt", 100, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 100, 100));
            Grid.Columns.Add(ColumnSelector.LabelColumn("InHand", "SharesInHandCount", 80, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 80, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Investment", "RunningInvestAmnt", 100, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 100, 100));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Worth", "WorthAmnt", 100, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 100, 100));
            return;
        }


        private void ShowData()
        {
            PortfolioTransactionBL marketValueBL = new PortfolioTransactionBL(BusinessBase.GetInstance());
            int accountID = 0;
            if (AccountID.SelectedValue != null)
            {
                _ = int.TryParse(AccountID.SelectedValue.ToString(), out accountID);
            }
            PortfolioData input = new PortfolioData()
            {
                AccountID = accountID,
                TradeCode = TradeCode.Text 
            };
            OutRecordsListData<PortfolioTransactionData> output = marketValueBL.GetPortfolioTransaction(input);
            Grid.DataSource = output.Data;
        }

        private void AccountID_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                if (e.KeyCode == Keys.Enter)
                {
                    ShowData();
                }
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

        private void Grid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                DataGridView grid = (DataGridView)sender;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    PortfolioTransactionData data = (PortfolioTransactionData)row.DataBoundItem;
                    if (data.TransActionCode == "BUY")
                    {
                        row.Cells[3].Style.ForeColor = Color.Green;
                        row.Cells[6].Style.ForeColor = Color.Green;
                        row.Cells[7].Style.ForeColor = Color.Green;
                    }
                    else
                    {
                        row.Cells[3].Style.ForeColor = Color.Red;
                        row.Cells[6].Style.ForeColor = Color.Red;
                        row.Cells[7].Style.ForeColor = Color.Red;
                    }
                  
                }
            }
            catch (Exception ex)
            {

                ShowMessage(ex.Message);
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

        private void BtnRefresh_Click(object sender, System.EventArgs e)
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

        protected override void OnExcelExportClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                PortfolioTransactionBL marketValueBL = new PortfolioTransactionBL(BusinessBase.GetInstance());
                int accountID = 0;
                if (AccountID.SelectedValue != null)
                {
                    _ = int.TryParse(AccountID.SelectedValue.ToString(), out accountID);
                }
                PortfolioData input = new PortfolioData()
                {
                    AccountID = accountID
                };
                OutRecordsListData<PortfolioTransactionData> output = marketValueBL.GetPortfolioTransaction(input);
                PortfolioTransactionReportBL reportBL = new PortfolioTransactionReportBL();
                reportBL.ExportExcel(output.Data);
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
