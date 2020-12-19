using ProDataGridViewColumns;
using ShareWatch.API;
using ShareWatch.API.Models;
using ShareWatch.Business.Share;
using ShareWatch.Common;
using ShareWatch.Common.Utility;
using ShareWatch.Const;
using ShareWatch.DataAccess.Share;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModel.Share.Shrm;
using ShareWatch.DataModel.Share.Shrv;
using ShareWatch.DataModel.Share.Stdv;
using ShareWatch.DataModels.CoreDataModel;
using ShareWatch.EntryScreen;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareWatch
{
    public partial class StockScreen : MDIChildBase
    {
        public StockScreen()
        {
            InitializeComponent();
        }

        ShareMarketValueData input = new ShareMarketValueData();

        private void StockScreen_Load(object sender, System.EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                DesignGrid();
                ShowData();
                RefreshedTime.Text = string.Empty;
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


        private void BtnRefresh_Click(object sender, EventArgs e)
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
                TradeCode.Text = string.Empty;
                TradeName.Text = string.Empty;
                RefreshedTime.Text = string.Empty;
                input = new ShareMarketValueData()
                {
                    TradeDate = DateTime.Today
                };
                ShowHeaderData(input);
                RefreshedTime.Text = string.Empty;
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
                ShowMessage("Please wait ...");
                ClearError();
                if (!ValidateData())
                {
                    ShowMessage("Check Errors");
                    return;
                }
                input.TradeCode = TradeCode.Text.Trim(); 
                input.TradeName = TradeName.Text.Trim();
                input.BuyRecommendationIndc = UtilityHandler.GetIndcValue(BuyRecommendationIndc.Checked);
                input.BuyRecommendationByName = BuyRecommendationByName.Text;
                input.BuyRecommendationDate = UtilityHandler.GetDataBaseDate(BuyRecommendationDate.Value);
               
                ShareTradeValueData value = new ShareTradeValueData()
                {
                    TradeCode = input.TradeCode,
                    BuyAtAmnt = UIUtility.GetAmountValue(BuyAtAmnt),
                    SellAtAmnt = UIUtility.GetAmountValue(SellAtAmnt)
                };

                ShareMasterBL shareMasterBL = new ShareMasterBL(BusinessBase.GetInstance());
                ShareData shareData = new ShareData()
                {
                    TradeCode = input.TradeCode,
                    MarketValue = input,
                    TraderValue = value 
                };
                shareMasterBL.SaveShare(shareData);
                ShowData();
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

        private void ClearError()
        {
            EP.Clear();
        }

        private bool ValidateData()
        {
            bool result = true;
            if(UtilityHandler.IsEmpty(TradeCode.Text))
            {
                EP.SetError(TradeCode, "Enter Trade Code");
                result = false;
            }
            if (UtilityHandler.IsEmpty(TradeName.Text))
            {
                EP.SetError(TradeCode, "Enter Trade Name");
                result = false;
            }
            return result;
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
            Grid.Columns.Add(ColumnSelector.LabelColumn("Trade", "TradeCode", 60, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 60, 60));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Company", "TradeName", 150, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 150, 250));
           // Grid.Columns.Add(ColumnSelector.LabelColumn("Region", "RegionName", 90, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 90, 175));
           // Grid.Columns.Add(ColumnSelector.LabelColumn("Type", "TypeCode", 60, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 60, 75));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Open", "OpenAmnt", 70, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 70, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Low", "LowAmnt", 70, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 70, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Current", "CurrentAmnt", 70, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 70, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("BuyAt", "BuyAtAmnt", 70, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 70, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("SellAt", "SellAtAmnt", 70, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 70, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("SoldAt", "SoldAtAmnt", 70, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 70, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("SoldOn", "SoldOnDate", 70, DataGridViewContentAlignment.MiddleRight, "MM/dd/yyyy", DataGridViewAutoSizeColumnMode.None, 70, 70));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Low52W", "Week52LowAmnt", 70, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 70, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("High52W", "Week52HighAmnt", 70, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 70, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Volume", "VolumeCount", 50, DataGridViewContentAlignment.MiddleRight, "", DataGridViewAutoSizeColumnMode.None, 50, 120));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Dividend", "DividendYieldNumb", 50, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 50, 70));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Div.Date", "DividendDate", 70, DataGridViewContentAlignment.MiddleRight, "MM/dd/yyyy", DataGridViewAutoSizeColumnMode.None, 70, 70));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Ex.Date", "ExDividendDate", 70, DataGridViewContentAlignment.MiddleRight, "MM/dd/yyyy", DataGridViewAutoSizeColumnMode.None, 70, 70));
            Grid.Columns.Add(ColumnSelector.CheckBoxColumn("Own", "HaveShareIndc", 50, "Y", "N", DataGridViewAutoSizeColumnMode.None, 50, 50));
            Grid.Columns.Add(ColumnSelector.CheckBoxColumn("Re", "BuyRecommendationIndc", 20, "Y", "N", DataGridViewAutoSizeColumnMode.None, 20, 20));
            Grid.Columns.Add(ColumnSelector.LabelColumn("By", "BuyRecommendationByName", 90, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 90, 120));
            Grid.Columns.Add(ColumnSelector.LabelColumn("On", "BuyRecommendationDate", 70, DataGridViewContentAlignment.MiddleCenter, "MM/dd/yyyy", DataGridViewAutoSizeColumnMode.None, 70, 70));
            return;
        }


        private void ShowData()
        {
            ShareMarketValueBL marketValueBL = new ShareMarketValueBL(BusinessBase.GetInstance());
            ShareKeyData allData = new ShareKeyData();
            OutRecordsListData<ShareMarketValueData> output = marketValueBL.GetShareValue(allData);
            Grid.DataSource = output.Data;
        }

        private async Task<bool> SearchTrade(string tradeCode)
        {
            if (UtilityHandler.IsEmpty(tradeCode))
            {
                return false;
            }
            List<ShareMarketValueData> datas = (List<ShareMarketValueData>)Grid.DataSource;
            if (datas is null)
            {
                return false;
            }
            foreach (ShareMarketValueData data in datas)
            {
                if (string.Compare(data.TradeCode, tradeCode, true) == 0)
                {
                    input = data;
                    ShowHeaderData(input);
                    return true;
                }
            }
            return await SearchOnLineTrade(tradeCode);
        }


        private async Task<bool> SearchOnLineTrade(string symbol)
        {
            if (UtilityHandler.IsEmpty(symbol))
            {
                return false; 
            }
            AlphaVantagAPI shareApi = new AlphaVantagAPI();
            OutData<CompanyOverviewData> coData = await shareApi.GetCompanyOverview(symbol);
            UtilityHandler.UpdateCompanyData(input, coData);
            OutData<GlobalQuoteData> qData = await shareApi.GetCurrentQuote(symbol);
            UtilityHandler.UpdateCurrentQuote(input, qData);
            ShowHeaderData(input);
            return true;
        }
        private void Grid_CellClick(object sender, DataGridViewCellEventArgs e)
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
                input = (ShareMarketValueData)Grid.CurrentRow.DataBoundItem;
                ShowHeaderData(input);

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

        private void ShowHeaderData(ShareMarketValueData input)
        {
            TradeCode.Text = input.TradeCode;
            TypeCode.Text = input.TypeCode;
            TradeName.Text = input.TradeName;
            MarketGapNumb.Text = $"{input.MarketGapNumb}";
            AvgVolCount.Text = $"{input.AvgVolCount}";
            OpenAmnt.Text = $"$ {input.OpenAmnt}";
            CurrentAmnt.Text = $"$ {input.CurrentAmnt}";
            DayRange.Text = $"{input.LowAmnt} -  {input.HighAmnt}";
            Week52Range.Text = $"{input.Week52LowAmnt} -  {input.Week52HighAmnt}";
            YieldNumb.Text = input.DividendYieldNumb.ToString();
            ExDividendDate.Text = UtilityHandler.GetDisplayDate(input.ExDividendDate);
            DividendDate.Text = UtilityHandler.GetDisplayDate(input.DividendDate);
            CurrencyCode.Text = input.CurrencyCode;
            RegionName.Text = input.RegionName;
            TypeCode.Text = input.TypeCode;
            CurrencyCode.Text = input.CurrencyCode;
            BuyRecommendationIndc.Checked = UtilityHandler.GetBooleanValue(input.BuyRecommendationIndc);
            BuyRecommendationByName.Text = input.BuyRecommendationByName;
            BuyRecommendationDate.Value = UtilityHandler.GetBindableDate(input.BuyRecommendationDate);
            RefreshedTime.Text = $"Data Refreshed on {input.TradeDate:MM/dd/yyyy}";
            ShowTradeEstimate(input.TradeCode);
            ShowMessage("Done");
        }

        private void ShowTradeEstimate(string tradeCode)
        {
            ClearTradeEstimateData();
            if (string.IsNullOrEmpty(tradeCode))
            {
                ShowMessage("Required Trade code");
                return;
            }
            ShareTradeValueDA shareTradeValueDA = new ShareTradeValueDA(BusinessBase.GetInstance());
            ShareKeyData input = new ShareKeyData()
            {
                TradeCode = tradeCode
            };
            OutData<ShareTradeValueData> output = shareTradeValueDA.GetShareTradeValue(input);
            ShareTradeValueData data = output.Data;
            SoldAtAmnt.Text = $"{UIUtility.GetAmountValue(data.SoldAtAmnt):0.0000}";
            SoldOnDate.Text = $"{UIUtility.GetDateValue(data.SoldOnDate):MM/dd/yyyy}";
            BuyAtAmnt.Text = $"{UIUtility.GetAmountValue(data.BuyAtAmnt):0.0000}";
            SellAtAmnt.Text = $"{UIUtility.GetAmountValue(data.SellAtAmnt):0.0000}";
        }

        private void ClearTradeEstimateData()
        {
            //  Week52HighAmnt.Text = string.Empty;
            //  Week8HighAmnt.Text = string.Empty;
            //  Week8LowAmnt.Text = string.Empty;
            BuyAtAmnt.Text = string.Empty;
            SellAtAmnt.Text = string.Empty;
            SoldAtAmnt.Text = string.Empty;
            SoldOnDate.Text = string.Empty;
        }

        private async void BtnLookup_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                string symbol = TradeCode.Text;
                if (!UtilityHandler.IsEmpty(symbol))
                {
                  bool res = await SearchOnLineTrade(symbol);
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



        private void TradeCode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string tradeCode = TradeCode.Text.Trim().ToUpper();
                if (!tradeCode.Equals(input.TradeCode))
                {
                    input = new ShareMarketValueData()
                    {
                        TradeCode = tradeCode
                    };
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



        private async void TradeCode_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    TextBox tbox = (TextBox)sender;
                   bool  res = await  SearchTrade(tbox.Text);
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


        protected override void OnExcelExportClick(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
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

        private void DownloadReport(ReportType input)
        {
            List<ShareMarketValueData> data = (List<ShareMarketValueData>)Grid.DataSource;
            if (data is null)
            {
                ShowMessage("No data to export");
                return;
            }
            ShareMarketReportBL reportBL = new ShareMarketReportBL()
            {
                ViewType = input
            };
            reportBL.ExportExcel(data);
        }

        private void CMnuTradeValue_Click(object sender, EventArgs e)
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
                input = (ShareMarketValueData)Grid.CurrentRow.DataBoundItem;
                using  TradeValueEstimate estimate = new TradeValueEstimate
                {
                    Input = input
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

        private void LnkShareTrade_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if(string.IsNullOrEmpty(TradeCode.Text ))
                {
                    ShowMessage("Trade Code required");
                    return;
                }
                ShowMessage("Please Wait...");
                ShareKeyData data = new ShareKeyData()
                                    {
                                        TradeCode = TradeCode.Text.Trim()
                                    };
                using TradeValueEstimate estimate = new TradeValueEstimate
                {
                    Input = input
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
