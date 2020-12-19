using ProDataGridViewColumns;
using ShareWatch.Business;
using ShareWatch.Business.Share;
using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataModel.Share.Pfol;
using ShareWatch.DataModel.Share.Shrm;
using ShareWatch.DataModels.CoreDataModel;
using ShareWatch.EntryScreen;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ShareWatch
{
    public partial class TrendScreen : MDIChildBase
    {
        public TrendScreen()
        {
            InitializeComponent();
        }

        private void TrendScreen_Load(object sender, System.EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                DesignGrid();
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
            Grid.Columns.Add(ColumnSelector.LabelColumn("Trade", "ShareName", 180, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 180, 260));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Share #", "SharesCount", 70, DataGridViewContentAlignment.MiddleRight, "0.00", DataGridViewAutoSizeColumnMode.None, 70, 70));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Cost", "CostBasisAmnt", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 100));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Total", "TotalInvestAmnt", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 100));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Value", "CurrentAmnt", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 100));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Ben", "BenefitAmnt", 70, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 70, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Current", "TotalCurrentAmnt", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 100));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Total Value", "TotalBenefitAmnt", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 100));
            Grid.Columns.Add(ColumnSelector.LabelColumn("%Gain", "BenefitPercentage", 70, DataGridViewContentAlignment.MiddleRight, "PERCENTAGE", DataGridViewAutoSizeColumnMode.None, 70, 70));
            Grid.Columns.Add(ColumnSelector.LabelColumn("L52W", "Week52LowAmnt", 70, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 70, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("H52W", "Week52HighAmnt", 70, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 70, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Yeild", "DividendYieldNumb", 50, DataGridViewContentAlignment.MiddleRight, "0.00", DataGridViewAutoSizeColumnMode.None, 50, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Div/Share", "DividendPerShareAmnt", 50, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 50, 70));
            Grid.Columns.Add(ColumnSelector.LabelColumn("DivDate", "DividendDate", 70, DataGridViewContentAlignment.MiddleRight, "MM/dd/yyyy", DataGridViewAutoSizeColumnMode.None, 70, 70));
            Grid.Columns.Add(ColumnSelector.CheckBoxColumn("Re", "BuyRecommendationIndc", 20, "Y", "N", DataGridViewAutoSizeColumnMode.None, 20, 20));
            Grid.Columns.Add(ColumnSelector.LabelColumn("By", "BuyRecommendationByName", 100, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 100, 175));
            Grid.Columns.Add(ColumnSelector.LabelColumn("On", "BuyRecommendationDate", 70, DataGridViewContentAlignment.MiddleCenter, "MM/dd/yyyy", DataGridViewAutoSizeColumnMode.None, 70, 70));
            return;
        }

        private void ShowData()
        {
            PortfolioTransactionBL marketValueBL = new PortfolioTransactionBL(BusinessBase.GetInstance());
            OutRecordsListData<PortfolioData> output = marketValueBL.GetPortfolioSummary();
            Grid.DataSource = output.Data;
            Application.DoEvents();
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
                        row.Cells[5].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        row.Cells[5].Style.ForeColor = Color.Green;
                    }
                    if (data.TotalBenefitAmnt < 0)
                    {
                        row.Cells[7].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        row.Cells[7].Style.ForeColor = Color.Green;
                    }
                    if (data.BenefitPercentage < 0)
                    {
                        row.Cells[8].Style.ForeColor = Color.Red;
                    }
                    else
                    {
                        row.Cells[8].Style.ForeColor = Color.Green;
                    }
                    string value = row.Cells[""].Value.ToString();
                }
            }
            catch (Exception ex)
            {

                ShowMessage(ex.Message);
            }
        }

        protected override void OnExcelExportClick(object sender, EventArgs e)
        {
            try
            {
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

        private void DownloadReport(ReportType input)
        {
            Cursor.Current = Cursors.WaitCursor;
            ShowMessage("Please Wait...");
            List<PortfolioData> data = (List<PortfolioData>)Grid.DataSource;
            if (data is null)
            {
                ShowMessage("No data to export");
                return;
            }
            PortfolioSummaryReportBL reportBL = new PortfolioSummaryReportBL
            {
                ViewType = input
            };
            reportBL.ExportExcel(data);
          
        }

        protected override void OnGoolgeSheetExportClick(object sender, EventArgs e)
        {
            try
            {
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

        private void CMnuTradeValue_Click(object sender, EventArgs e)
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
    }
}
