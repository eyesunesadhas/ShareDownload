using ShareMarketDownload.Business;
using ShareMarketDownload.Common;
using ShareMarketDownload.Properties;
using ShareWatch.API;
using ShareWatch.DataModel.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareMarketDownload
{
    public partial class ShareValueDownload : Form
    {
        public ShareValueDownload()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        private async void BtnStart_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                dt = GetDataSet(txtShareList.Text);
                ShowData(dt);
                currentRow = 0;
                maxRow = dt.Rows.Count;
                btnStop.Enabled = true;
                btnStart.Enabled = false;
                TimerDownload.Tag = dt;
                TimerDownload.Interval = 1000 * Settings.Default.WaitTime2Call;
                TimerDownload.Enabled = true;
                TimerDownload.Start();
                txtStartTime.Text = $"{DateTime.Now:HH:mm:ss.ffffff}";
                txtEndTime.Text = string.Empty;
                _ = await DownloadData();
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

        private void ShowData(DataTable dt)
        {
            Grid.DataSource = dt;
        }

        private DataTable GetDataSet(string input)
        {
            List<string> shares = input.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList<string>();

            using DataTable dt = new DataTable("Share");
            dt.Columns.Add("Sno");
            dt.Columns.Add("Share");
            dt.Columns.Add("StartTime");
            dt.Columns.Add("Status");
            dt.Columns.Add("Message");
            int i = 1;
            foreach (string share in shares)
            {
                DataRow row = dt.NewRow();
                row["Sno"] = i++;
                row["Share"] = share.Trim().ToUpper();
                dt.Rows.Add(row);
            }
            return dt;
        }

        private void ShowMessage(string msg)
        {
            lblMessage.Text = msg;
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            try
            {
                TimerDownload.Stop();
                btnStop.Enabled = false;
                btnStart.Enabled = true;
            }
            catch (Exception ex)
            {

                lblMessage.Text = ex.Message;
            }

        }
        int currentRow = 0;
        int maxRow = 0;
        private async void TimerDownload_Tick(object sender, EventArgs e)
        {
            _ = await DownloadData();
        }

        private async Task<bool> DownloadData()
        {
            DataRow row = null;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if(NoRecord2Porcess())
                {
                    return true;
                }
               
                PBar.Visible = true;
                row = dt.Rows[currentRow];
                string share = row["Share"].ToString();
                row["StartTime"] = DateTime.Now.ToString("HH:mm:ss.ffffff");
                PBar.Maximum = maxRow;
                PBar.Value = currentRow++;
                txtProcessRate.Text = $"{currentRow} / {maxRow}";
                if (string.IsNullOrEmpty(share))
                {
                    row["Status"] = "Fail";
                    row["Message"] = "Empty Code";
                    return true;
                }
                AlphaVantagAPI shareApi = new AlphaVantagAPI();
                ShowMessage($"Downloading Data {share}");
                OutData<string> output = await shareApi.GetShareIntradayCsv(share);
                string fileName = $@"{Settings.Default.LoggingFolder}\{share}.csv";
                if (output.StatusList.Count > 0)
                {
                    row["Status"] = "Fail";
                    row["Message"] = output.StatusList[0].Description;
                    return true;
                }
                row["Status"] = "Success";
                File.WriteAllText(fileName, output.Data);
                if (NoRecord2Porcess())
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                if (row is not null)
                {
                    row["Status"] = "Fail";
                    row["Message"] = ex.Message;
                }
                string msg = $"{ex.Message} {ex.StackTrace}";
                Logger.Log(msg);
                ShowMessage(ex.Message);
            }
            return true;
        }

        private bool NoRecord2Porcess()
        {
            if (dt is null || dt.Rows.Count == 0 || currentRow >= maxRow)
            {
                ShowMessage("No more Data to process");
                TimerDownload.Stop();
                TimerDownload.Enabled = true;
                PBar.Visible = false;
                btnStop.Enabled = false;
                btnStart.Enabled = true;
                txtEndTime.Text = $"{DateTime.Now:HH:mm:ss.ffffff}";
                return true;
            }
            return false;
        }
    }
}
