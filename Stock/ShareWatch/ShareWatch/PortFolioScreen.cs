using ProDataGridViewColumns;
using ShareWatch.Business.Share;
using ShareWatch.Business.Share.Reports;
using ShareWatch.Common;
using ShareWatch.Common.Utility;
using ShareWatch.Const;
using ShareWatch.DataModel.Share.Pfol;
using ShareWatch.DataModel.Share.Shrm;
using ShareWatch.DataModels.CoreDataModel;
using ShareWatch.EntryScreen;
using ShareWatch.Popup;
using ShareWatch.UiConstant;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ShareWatch
{
    public partial class PortFolioScreen : MDIChildBase
    {
        public PortFolioScreen()
        {
            InitializeComponent();
        }

        private void PortFolioScreen_Load(object sender, System.EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                DesignAllAccountGrid();
                UIUtility.FillAccountsListCombo(AccountID);
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



        private void DesignAllAccountGrid()
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
            Grid.Columns.Add(ColumnSelector.LabelColumn("Trade", "ShareName", 160, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 160, 200));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Share #", "SharesCount", 70, DataGridViewContentAlignment.MiddleRight, "0.00", DataGridViewAutoSizeColumnMode.None, 70, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Cost", "CostBasisAmnt", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Total", "TotalInvestAmnt", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Value", "CurrentAmnt", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Ben", "BenefitAmnt", 70, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 70, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Current", "TotalCurrentAmnt", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Total Value", "TotalBenefitAmnt", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("%Gain", "BenefitPercentage", 70, DataGridViewContentAlignment.MiddleRight, "PERCENTAGE", DataGridViewAutoSizeColumnMode.None, 70, 70));
            Grid.Columns.Add(ColumnSelector.LabelColumn("L52W", "Week52LowAmnt", 70, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 70, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("H52W", "Week52HighAmnt", 70, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 70, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Yeild", "DividendYieldNumb", 50, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 50, 60));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Div/Share", "DividendPerShareAmnt", 50, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 50, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Div Date", "DividendDate", 80, DataGridViewContentAlignment.MiddleRight, "MM/dd/yyyy", DataGridViewAutoSizeColumnMode.None, 80, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("PE", "PERationNumb", 50, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 50, 60));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Account", "AccountName", 150, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 150, 200));
            return;
        }

        private void DesignAccountGrid()
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
            Grid.Columns.Add(ColumnSelector.LabelColumn("Trade", "ShareName", 160, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 160, 200));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Share #", "SharesCount", 70, DataGridViewContentAlignment.MiddleRight, "0.00", DataGridViewAutoSizeColumnMode.None, 70, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Cost", "CostBasisAmnt", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Total", "TotalInvestAmnt", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Value", "CurrentAmnt", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Ben", "BenefitAmnt", 70, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 70, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Current", "TotalCurrentAmnt", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Total Value", "TotalBenefitAmnt", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("%Gain", "BenefitPercentage", 70, DataGridViewContentAlignment.MiddleRight, "PERCENTAGE", DataGridViewAutoSizeColumnMode.None, 70, 70));
            Grid.Columns.Add(ColumnSelector.LabelColumn("L52W", "Week52LowAmnt", 70, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 70, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("H52W", "Week52HighAmnt", 70, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 70, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Yeild", "DividendYieldNumb", 50, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 50, 60));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Div/Share", "DividendPerShareAmnt", 50, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 50, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Div Date", "DividendDate", 80, DataGridViewContentAlignment.MiddleRight, "MM/dd/yyyy", DataGridViewAutoSizeColumnMode.None, 80, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("PE", "PERationNumb", 50, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 50, 60));
            return;
        }

        private void ShowData()
        {
            PortfolioBL marketValueBL = new PortfolioBL(BusinessBase.GetInstance());
            int accountID = 0;
            if (AccountID.SelectedValue != null)
            {
                _ = int.TryParse(AccountID.SelectedValue.ToString(), out accountID);
            }
            if(accountID >0)
            {
                DesignAccountGrid();
            }
            else
            {
                DesignAllAccountGrid();
            }
            PortfolioData input = new PortfolioData()
            {
                AccountID = accountID,
                TradeCode = TradeCode.Text
            };
            OutRecordsListData<PortfolioData> output = marketValueBL.GetPortfolioData(input);
            Grid.DataSource = output.Data;
        }

        protected override void OnExcelExportClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DownloadReport(ReportType.Excel);
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

        protected override void OnGoolgeSheetExportClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                DownloadReport(ReportType.GoogleSheet);
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

        private static void DownloadReport(ReportType reportType)
        {
            PortfolioData input = new PortfolioData();
           
            PortfolioBL marketValueBL = new PortfolioBL(BusinessBase.GetInstance());
            OutRecordsListData<PortfolioData> output = marketValueBL.GetPortfolioData(input);
            PortfolioReportBL reportBL = new PortfolioReportBL()
            {
                ViewType = reportType
            };
            reportBL.ExportExcel(output.Data);
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

        private void BtnNew_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                int accountID = 0;
                if (AccountID.SelectedValue != null)
                {
                    accountID = (int)AccountID.SelectedValue;
                }
                PortfolioData input = new PortfolioData()
                {
                    AccountID = accountID,
                    TransActionCode = RefmConstants.TRADE_ACTION_BUY,
                    TransActionDate = DateTime.Today
                };
                PortFolioEntry frm = new PortFolioEntry
                {
                    Input = input
                };
                frm.ShowDialog();
                if (frm.IsDataChanged)
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

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                if (e.RowIndex < 0)
                {
                    return;
                }
                DataGridView dataGrid = (DataGridView)sender;
                PortfolioData input = (PortfolioData)Grid.CurrentRow.DataBoundItem;
                TransactionDetailScreen frm = new TransactionDetailScreen
                {
                    Input = input
                };
                frm.ShowDialog();
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

        private void Grid_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {


        }

        private void Grid_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                DataGridView grid = (DataGridView)sender;
                foreach (DataGridViewRow row in grid.Rows)
                {
                    PortfolioData data = (PortfolioData)row.DataBoundItem;
                    if (data.BenefitAmnt < 0)
                    {
                        row.Cells[PortFolioGridFieldConstant.BenefitAmnt].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        row.Cells[PortFolioGridFieldConstant.BenefitAmnt].Style.ForeColor = Color.Green;
                    }
                    if (data.TotalBenefitAmnt < 0)
                    {
                        row.Cells[PortFolioGridFieldConstant.TotalBenefitAmnt].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        row.Cells[PortFolioGridFieldConstant.TotalBenefitAmnt].Style.ForeColor = Color.Green;
                    }
                    if (data.BenefitPercentage < 0)
                    {
                        row.Cells[PortFolioGridFieldConstant.BenefitPercentage].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        row.Cells[PortFolioGridFieldConstant.BenefitPercentage].Style.ForeColor = Color.Green;
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void ToolSell_Click(object sender, EventArgs e)
        {
            ShowAction("SELL");
        }

        private void ToolBuy_Click(object sender, EventArgs e)
        {
            ShowAction("BUY");
        }

        public void ShowAction(string tradeAction)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                PortfolioData data = (PortfolioData)Grid.CurrentRow.DataBoundItem;
                PortfolioData param = new PortfolioData()
                {
                    TradeCode = data.TradeCode,
                    TradeName = data.TradeName,
                    AccountID = data.AccountID,
                    AccountTypeCode = data.AccountTypeCode,
                    AccountTypeText = data.AccountTypeText,
                    BankAccountID = data.BankAccountID,
                    BankName = data.BankName,
                    TransActionCode = tradeAction
                };
                PortFolioEntry frm = new PortFolioEntry
                {
                    Input = param
                };
                frm.ShowDialog();
                if (frm.IsDataChanged)
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

        private void AccountID_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ShowData();
            }
        }

        private void ToolTradeValue_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                if (Grid.CurrentRow is null)
                {
                    ShowMessage("Select a row to set trade value");
                    return;
                }
                PortfolioData input = (PortfolioData)Grid.CurrentRow.DataBoundItem;
                ShareKeyData data = new ShareKeyData()
                {
                    TradeCode = input.TradeCode
                };
                using TradeValueEstimate estimate = new TradeValueEstimate
                {
                    Input = data
                };
                estimate.ShowDialog();
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

        private void ToolACB_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                if(Grid.CurrentRow is null)
                {
                    ShowMessage("Select a row to set trade value");
                    return;
                }
                PortfolioData data = (PortfolioData)Grid.CurrentRow.DataBoundItem;
                PortfolioData param = new PortfolioData()
                {
                    TradeCode = data.TradeCode,
                    TradeName = data.TradeName,
                    AccountID = data.AccountID,
                    AccountTypeCode = data.AccountTypeCode,
                    AccountTypeText = data.AccountTypeText,
                    BankAccountID = data.BankAccountID,
                    CostBasisAmnt = data.CostBasisAmnt,
                    BankName = data.BankName
                };
                CostBaseAdjuster frm = new CostBaseAdjuster
                {
                    Input = param
                };
                frm.ShowDialog();
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
