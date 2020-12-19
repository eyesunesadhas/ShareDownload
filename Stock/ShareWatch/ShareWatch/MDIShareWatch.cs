using ShareWatch.API;
using ShareWatch.API.Models;
using ShareWatch.BackgroundTask;
using ShareWatch.Business.Share;
using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataModel.Common;
using ShareWatch.DataModel.Share.Shrm;
using ShareWatch.DataModel.Share.Shrv;
using ShareWatch.DataModels.CoreDataModel;
using ShareWatch.EntryScreen;
using ShareWatch.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ShareWatch
{
    public partial class MDIShareWatch : Form
    {
        public delegate void ToolBarClickHandler(object sender, EventArgs e);
        public delegate void ContextMenuClickHandler(string key);
        public delegate bool RUReady2CloseHandler();

        public List<string> ChildForms = new List<string>()
        {
             AppScreens.BANK,
             AppScreens.STOCK,
             AppScreens.PORT_FOLIO,
             AppScreens.TRANSACTION,
             AppScreens.TREND
        };

        public List<string> ToolsList = new List<string>()
        {
             ToolConstants.TOOL_DELETE,
             ToolConstants.TOOL_REFRESH,
             ToolConstants.TOOL_SAVE,
             ToolConstants.TOOL_SYNC_SHARE,
             ToolConstants.TOOL_SYNC_COMP
        };
        public void ShowMessage(string message)
        {
            lblStatus.Text = message;
        }

        public void ShowClock(string display)
        {
            lblClock.Text = display;
        }

        public bool ShowProcessBar { get; set; } = false;
        #region ToolBar Event Handlers

        public event ToolBarClickHandler ToolNewClick;
        public event ToolBarClickHandler ToolOpenClick;
        public event ToolBarClickHandler ToolSaveClick;
        public event ToolBarClickHandler ToolDeleteClick;
        public event ToolBarClickHandler ToolRefreshClick;
        public event ToolBarClickHandler ToolPrintClick;
        public event ToolBarClickHandler ToolExcelExportClick;
        public event ToolBarClickHandler ToolGoolgeSheetExportClick;
        public event ToolBarClickHandler ToolWordExportClick;

        public event ContextMenuClickHandler ContextMenuClick;

        public event RUReady2CloseHandler IsReady2Close;

        private void MDIShareWatch_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClockTimer.Interval = 1000;
                ClockTimer.Enabled = true;
                ClockTimer.Start();
                PBar.Visible = false;
                ShowMessage("Please Wait...");
                ShowScreen(AppScreens.HOME);
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
        private void ContextMenu_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (ContextMenuClick != null)
                {
                    ToolStripMenuItem mnu = (ToolStripMenuItem)sender;
                    if (mnu.Tag == null)
                    {
                        throw new ApplicationException("Tag not defined for context menu");
                    }
                    string key = mnu.Tag.ToString();
                    ContextMenuClick(key);
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

        private void ToolNew_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ToolNewClick?.Invoke(sender, e);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }


        private void ToolOpen_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ToolOpenClick?.Invoke(sender, e);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void ToolSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ToolSaveClick?.Invoke(sender, e);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }

        }


        private void ToolRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ToolRefreshClick?.Invoke(sender, e);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }

        }

        private void ToolDelete_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ToolDeleteClick?.Invoke(sender, e);
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }

        }

        private void ToolPrint_Click(object sender, EventArgs e)
        {
            try
            {
                ToolPrintClick?.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }

        }

        private void ToolExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                ToolExcelExportClick?.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void ToolGoogleSheet_Click(object sender, EventArgs e)
        {
            try
            {
                ToolGoolgeSheetExportClick?.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }

        private void ToolExportWord_Click(object sender, EventArgs e)
        {
            try
            {
                ToolWordExportClick?.Invoke(sender, e);
            }
            catch (Exception ex)
            {
                ShowMessage(ex.Message);
            }
        }



        private bool IsChildReady2Close()
        {
            if (IsReady2Close != null)
            {
                return IsReady2Close();
            }
            return true;
        }
        #endregion

        private int childFormNumber = 0;

        public MDIShareWatch()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form
            {
                MdiParent = this,
                Text = "Window " + childFormNumber++
            };
            childForm.Show();
        }




        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TBar.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SBar.Visible = statusBarToolStripMenuItem.Checked;
        }



        private bool IsFormShowInProgress = false;
        private string CurrentForm = "";
        private MDIChildBase mdichild = null;

        private void CloseAllChildForm()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        public static bool SyncCompanyBasicData()
        {

            return true;
        }

        private void ToolExcel_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                ToolSaveClick?.Invoke(sender, e);
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


        //public void ToolAction(string toolName, object sender, ToolStripItemClickedEventArgs e)
        //{
        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;
        //        ShowMessage("Please Wait...");
        //        switch (toolName)
        //        {
        //            case ToolConstants.TOOL_SYNC_COMP:
        //                SyncCompanyBasicData();
        //                break;
        //            case ToolConstants.TOOL_SAVE:
        //                ToolSaveClick?.Invoke(sender, e);
        //                break;
        //            case ToolConstants.TOOL_REFRESH:
        //                ToolRefreshClick?.Invoke(sender, e);
        //                break;
        //            case ToolConstants.TOOL_DELETE:
        //                ToolDeleteClick?.Invoke(sender, e);
        //                break;
        //        }
        //        ShowMessage("Done");
        //    }
        //    catch (Exception ex)
        //    {
        //        ShowMessage(ex.Message);
        //    }
        //    finally
        //    {
        //        Cursor.Current = Cursors.Default;
        //    }


        //}
        public void ShowScreen(string ScreenName)
        {
            try
            {
                if (IsFormShowInProgress) return;

                if (CurrentForm == ScreenName && this.MdiChildren.Length > 0)
                {
                    return;
                }
                CloseAllChildForm();
                CurrentForm = ScreenName;
                IsFormShowInProgress = true;
                mdichild = AppScreens.GetScreenForm(ScreenName);
                if (mdichild != null)
                {
                    mdichild.MdiParent = this;
                    mdichild.WindowState = FormWindowState.Maximized;
                    mdichild.Show();
                }
                IsFormShowInProgress = false;
            }
            catch (Exception ex)
            {
                IsFormShowInProgress = false;
                ShowMessage(ex.Message);
            }
        }



        private void TBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                string tag = string.Empty;
                Cursor.Current = Cursors.WaitCursor;
                if (e.ClickedItem.Tag != null)
                {
                    tag = e.ClickedItem.Tag.ToString();
                }
                if (ChildForms.Contains(tag))
                {
                    ShowScreen(tag);
                    return;
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

        private async void TimerCompanyUpdate_Tick(object sender, EventArgs e)
        {
            ShareMarketValueData data = null;
            try
            {
                Timer timer = (Timer)sender;
                TaskData<ShareMarketValueData> input = (TaskData<ShareMarketValueData>)timer.Tag;
                if (input.Processed >= input.Max)
                {
                    TimerCompanyUpdate.Stop();
                    ToolSyncCompany.Enabled = true;
                    ShowMessage("Done");
                    return;
                }
                PBar.Maximum = input.Max;
                PBar.Value = input.Processed;
                data = input.Data[input.Processed];
                input.Processed++;
                if (data.UpdateDttm.Date >= DateTime.Today)
                {
                    ShowMessage($"{data.TradeCode} - {data.TradeName} - Skipped");
                    return;
                }
                ShowMessage($"{data.TradeCode} - {data.TradeName} - Processing");
                AlphaVantagAPI shareApi = new AlphaVantagAPI();
                if (UtilityHandler.IsEmpty(data.TradeCode)) { return; }
                Application.DoEvents();
                OutData<CompanyOverviewData> company = await shareApi.GetCompanyOverview(data.TradeCode);
                if (UtilityHandler.UpdateCompanyData(data, company))
                {
                    ShareMasterBL shareMasterBL = new ShareMasterBL(BusinessBase.GetInstance());
                    shareMasterBL.SaveShareMaster(data);
                }

            }
            catch (Exception ex)
            {
                string msg = $"TimerCompanyUpdate_Tick {data?.TradeCode}-{data.TradeName} {ex.Message} {ex.StackTrace}";
                Logger.Log(msg);
            }


        }

        private void ToolSyncCompany_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                ShareMarketValueBL marketValueBL = new ShareMarketValueBL(BusinessBase.GetInstance());
                ShareKeyData myShare = new ShareKeyData();
                OutRecordsListData<ShareMarketValueData> output = marketValueBL.GetShareValue(myShare);
                TaskData<ShareMarketValueData> input = new TaskData<ShareMarketValueData>()
                {
                    Data = output.Data,
                    Processed = 0
                };
                TimerCompanyUpdate.Tag = input;
                TimerCompanyUpdate.Interval = 1000 * Settings.Default.WaitTime2Call;
                TimerCompanyUpdate.Enabled = true;
                TimerCompanyUpdate.Start();
                ToolSyncCompany.Enabled = false;
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

        private void ToolSyncShare_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                ShareMarketValueBL marketValueBL = new ShareMarketValueBL(BusinessBase.GetInstance());
                ShareKeyData allData = new ShareKeyData();
                OutRecordsListData<ShareMarketValueData> output = marketValueBL.GetShareValue(allData);
                TaskData<ShareMarketValueData> input = new TaskData<ShareMarketValueData>()
                {
                    Data = output.Data,
                    Processed = 0
                };
                TimerMarketUpdate.Tag = input;
                TimerMarketUpdate.Interval = 1000 * Settings.Default.WaitTime2Call;
                TimerMarketUpdate.Enabled = true;
                TimerMarketUpdate.Start();
                ToolSyncShare.Enabled = false;
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

        private async void TimerMarketUpdate_Tick(object sender, EventArgs e)
        {
            ShareMarketValueData data = null;
            try
            {
                Timer timer = (Timer)sender;
                TaskData<ShareMarketValueData> input = (TaskData<ShareMarketValueData>)timer.Tag;
                if (input is null)
                {
                    return;
                }
                if (input.Processed >= input.Max)
                {
                    TimerMarketUpdate.Stop();
                    TimerMarketUpdate.Enabled = true;
                    PBar.Visible = false;
                    ShowMessage("Done");
                    return;
                }
                PBar.Visible = true;
                data = input.Data[input.Processed];
                PBar.Maximum = input.Max;
                PBar.Value = input.Processed;
                PBar.ToolTipText = $"{input.Processed}/{input.Max}";
                input.Processed++;
                if (data.TradeDate.Date >= DateTime.Today)
                {
                    ShowMessage($"{data.TradeCode} - {data.TradeName} - Skipped");
                    return;
                }
                ShowMessage($"{data.TradeCode} - {data.TradeName} - Processing");
                AlphaVantagAPI shareApi = new AlphaVantagAPI();
                if (UtilityHandler.IsEmpty(data.TradeCode)) { return; }
                Application.DoEvents();
                OutData<TimeSeriesIntradayData> output = await shareApi.GetShareDailyAdjusted(data.TradeCode);
                if (UtilityHandler.IsValidStatus(output))
                {
                    List<ShareMarketValueData> shareValueData = new List<ShareMarketValueData>();
                    foreach(TimeSeriesData tsd in output.Data.Data) {
                        ShareMarketValueData newData = new ShareMarketValueData
                        {
                            TradeCode = data.TradeCode,
                            TradeDate = tsd.TradeDate,
                            OpenAmnt = tsd.Open,
                            HighAmnt = tsd.High,
                            LowAmnt = tsd.Low,
                            CloseAmnt = tsd.Close ,
                            CurrentAmnt = tsd.Current,
                            VolumeCount = tsd.Volume
                        };
                        if(newData.CurrentAmnt == 0)
                        {
                            newData.CurrentAmnt = tsd.Close;
                        }
                        shareValueData.Add(newData);
                    }
                    ShareMarketValueBL marketValue = new ShareMarketValueBL(BusinessBase.GetInstance());
                    marketValue.SaveShareMarketValueTrend(shareValueData);
                }
                }
            catch (Exception ex)
            {
                string msg = $"TimerMarketUpdate_Tick {data?.TradeCode} - {data?.TradeName} {ex.Message} {ex.StackTrace}";
                Logger.Log(msg);
            }
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
              
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

        private void ToolHelp_Click(object sender, EventArgs e)
        {

        }

        private void ToolImportUtility_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                BankSummaryImport frm = new BankSummaryImport();
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

        private void ToolImportTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                BankTransactionImport frm = new BankTransactionImport();
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
