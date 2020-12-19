using ProDataGridViewColumns;
using ShareWatch.Business.Share.Reports;
using ShareWatch.Common;
using ShareWatch.Common.DataStore;
using ShareWatch.Const;
using ShareWatch.DataAccess.Share;
using ShareWatch.DataModels.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShareWatch.EntryScreen
{
    public partial class BankSummaryImport : Form
    {
        public BankSummaryImport()
        {
            InitializeComponent();
        }
        readonly BusinessBase businessBase = BusinessBase.GetInstance();
        private void BankSummaryImport_Load(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                DesignGrid();
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
            Grid.Columns.Add(ColumnSelector.LabelColumn("Account", "BankAccount_ID", 130, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 130, 130));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Trade", "Trade_CODE", 80, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 80, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Name", "Trade_NAME", 160, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 160, 200));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Share #", "Shares_CNT", 70, DataGridViewContentAlignment.MiddleRight, "0.00", DataGridViewAutoSizeColumnMode.None, 70, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Cost", "CostBasis_AMNT", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Value", "Value_AMNT", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Exp Date", "Export_DATE", 80, DataGridViewContentAlignment.MiddleRight, "MM/dd/yyyy", DataGridViewAutoSizeColumnMode.None, 80, 80));
            return;
        }


        private void ShowMessage(string msg)
        {
            lblMessage.Text = msg;
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                if(ValidataData())
                {
                    DataSet ds = GetAllReportData(FileName.Text);
                    Grid.DataSource = ds;
                    if(ds is null || ds.Tables.Count == 0)
                    {
                        return;
                    }
                    Grid.DataMember = ds.Tables[0].TableName;
                    List<string> accounts = GetAccounts(ds.Tables[0]);
                    BankPortfolioDA.SaveData(accounts, ds);
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

        private DataSet GetAllReportData(string fileName)
        {
            BankPortfolioDA da = new BankPortfolioDA(businessBase);
            DataSet ds = da.GetEmptyData();
            DataTable dt = ds.Tables[0];
            if(File.Exists(fileName ))
            {
                GetReportData(dt, fileName);
                ds.AcceptChanges();
                return ds;
            }
            if (Directory.Exists(fileName))
            {
                string[] files = Directory.GetFiles(fileName, "*.csv");
                foreach (string f in files)
                {
                    DataTable dtProcess = dt.Clone();
                    GetReportData(dtProcess, f);
                    foreach(DataRow r in dtProcess.Rows)
                    {
                        DataRow row = dt.NewRow();
                        foreach(DataColumn dc in r.Table.Columns)
                        {
                            row[dc.ColumnName] = r[dc.ColumnName];
                        }
                        dt.Rows.Add(row);
                    }
                }
            }
            ds.AcceptChanges();
            return ds;
        }

        private static DataTable GetReportData(DataTable dt, string fileName)
        {
            string bank = string.Empty;
       
            string [] lines = File.ReadAllLines(fileName);
            FileInfo fi = new FileInfo(fileName);
            string account = fi.Name.Replace(fi.Extension, string.Empty).Replace("_SUM", string.Empty);
            DateTime exportDate = DateTime.Today;
            if(fi.Name.StartsWith("RH")) 
            {
                bank = BrokerageAccount.ROBIN_HOOD;
            }

            //Auto discover the bank
            if (lines.Length  > 0)
            {
                string s = lines[0];
                if (s.Contains("Exported on:"))
                {
                    bank = BrokerageAccount.MERRIL_EDGE;
                    s = s.Replace("Exported on:", string.Empty)
                         .Replace(" ET",string.Empty).Trim();
                    _ = DateTime.TryParse(s, out exportDate);
                }
                else if (s.Contains("Account Name/Number"))
                {
                    bank = BrokerageAccount.FIDELITY;
                }
            }
            foreach(string line in lines)
            {
                if(string.IsNullOrEmpty(line) )
                {
                    continue;
                }
                if ( line.Contains("Date downloaded"))
                {
                  string  s =  line.Replace("\"",string.Empty )
                                   .Replace("Date downloaded",string.Empty)
                                   .Replace(" ET", string.Empty).Trim();
                   _ = DateTime.TryParse(s, out exportDate);
                }

                if(line.Contains("SPAXX**")
                   || line.Contains("Brokerage services")
                   || line.Contains("The data and information")
                   || line.Contains("Date downloaded")
                   || line.Contains("Pending Activity")
                   || line.Contains("Pending activity")
                   || line.Contains("Symbol")
                   || line.Contains("Selected account")
                   || line.Contains("Exported on")
                   || line.Contains("Balances")
                   || line.Contains("Money accounts")
                   || line.Contains("Cash balance")
                   || line.Contains("Total")
                   || line.Contains("Total Return")
                   || line.Contains("Average Cost")
                   )
                {
                    continue;
                }
                List<string> parts = UtilityHandler.GetSplitCsvLine(line);
                if(parts.Count == 1)
                {
                    continue;
                }
                switch(bank)
                {
                    case BrokerageAccount.MERRIL_EDGE:
                        if(parts.Count <= 1)
                        {
                            continue;
                        }
                        if (string.IsNullOrEmpty(parts[0]))
                        {
                            continue;
                        }
                        if (parts.Count == 4)
                        {
                            if (parts[0].Contains("CMA")
                               || parts[0].Contains("IRA")
                               )
                            {
                                account = parts[0].Replace("\"", string.Empty);
                            }
                            continue;
                        }
                        if(parts.Count > 6) 
                        { 
                            DataRow row = dt.NewRow();
                            row["BankAccount_ID"] = account;
                            row["Trade_CODE"] = parts[0]
                                                  .Replace("\"", string.Empty)
                                                  .Replace("!",string.Empty);
                            row["Trade_NAME"] = parts[1].Replace("\"", string.Empty);
                            row["Shares_CNT"] = GetDecimalNumber(parts[2]);
                            row["CostBasis_AMNT"] = GetDecimalNumber(parts[3]);
                            row["Value_AMNT"] = GetDecimalNumber(parts[5]);
                            dt.Rows.Add(row);
                        }
                        break;
                    case BrokerageAccount.FIDELITY:
                        if(parts[0].Contains("Account Name") )
                        {
                            continue;
                        }
                        if (parts.Count > 13)
                        {
                            DataRow row = dt.NewRow();
                            row["BankAccount_ID"] = parts[0].Replace("\"",string.Empty) ;
                            row["Trade_CODE"] = parts[1].Replace("\"", string.Empty);
                            row["Trade_NAME"] = parts[2].Replace("\"", string.Empty);
                            row["Shares_CNT"] = GetDecimalNumber(parts[3]);
                            row["CostBasis_AMNT"] = GetDecimalNumber(parts[12]);
                            row["Value_AMNT"] = GetDecimalNumber(parts[6]);
                            dt.Rows.Add(row);
                        }
                        break;
                    case BrokerageAccount.ROBIN_HOOD:
                        {
                            if (parts[0] == "Name")
                            {
                                continue;
                            }
                            DataRow row = dt.NewRow();
                            row["BankAccount_ID"] = account;
                            row["Trade_CODE"] = parts[1].Replace("\"", string.Empty);
                            row["Trade_NAME"] = parts[0].Replace("\"", string.Empty);
                            row["Shares_CNT"] = GetDecimalNumber(parts[2]);
                            row["CostBasis_AMNT"] = GetDecimalNumber(parts[4]);
                            row["Value_AMNT"] = GetDecimalNumber(parts[6]);
                            dt.Rows.Add(row);
                        }
                        break;
                }
            }
            foreach(DataRow row in dt.Rows )
            {
                row["Export_DATE"] = exportDate;
            }
            return dt;
        }

        private static decimal GetDecimalNumber(string input)
        {
            input = input.Trim()
                         .Replace("\"", string.Empty)
                         .Replace("$", string.Empty)
                         .Replace(",", string.Empty);
            _ = decimal.TryParse(input, out decimal d);
            return d;
        }

        

        private bool ValidataData()
        {
            bool res = true;
            if(string.IsNullOrEmpty( FileName.Text))
            {
                ShowMessage("Required file name");
                return false;
            }
            string fileName = FileName.Text.Trim();
            if(!( Directory.Exists(fileName) 
                 || File.Exists(fileName ))
                )
            {
                ShowMessage("Folder/File not exists");
                return false;
            }
            return res;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                DataSet ds = (DataSet)Grid.DataSource;
                if(ds is null 
                   || ds.Tables.Count == 0  )
                {
                    ShowMessage("No Data to Save");
                    return;
                }
                List<string> accounts = GetAccounts(ds.Tables[0]);
                BankPortfolioDA.SaveData(accounts, ds);
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

        private static List<string> GetAccounts(DataTable input)
        {
            List<string> output = new List<string>();
            foreach(DataRow row in input.Rows)
            {
                string account = row["BankAccount_ID"].ToString();
                if(!output.Contains(account))
                {
                    output.Add(account);
                }
            }
            return output;
        }

        private void btnTallyReport_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                AccountTallyReportBL report = new AccountTallyReportBL();
                report.ExportExcel();
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
