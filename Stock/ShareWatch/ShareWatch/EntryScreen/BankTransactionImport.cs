using ProDataGridViewColumns;
using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataAccess.Share;
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
    public partial class BankTransactionImport : Form
    {
        public BankTransactionImport()
        {
            InitializeComponent();
        }

        readonly BusinessBase businessBase = BusinessBase.GetInstance();
        private void BankTransactionImport_Load(object sender, EventArgs e)
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

     
        private void ShowMessage(string msg)
        {
            lblMessage.Text = msg;
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
            Grid.Columns.Add(ColumnSelector.LabelColumn("Name", "Trade_NAME", 120, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 120, 160));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Action", "TransAction_CODE", 80, DataGridViewContentAlignment.MiddleLeft, "", DataGridViewAutoSizeColumnMode.None, 80, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("On", "TransAction_DATE", 80, DataGridViewContentAlignment.MiddleLeft, "MM/dd/yyyy", DataGridViewAutoSizeColumnMode.None, 80, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Share #", "Shares_CNT", 70, DataGridViewContentAlignment.MiddleRight, "0.00", DataGridViewAutoSizeColumnMode.None, 70, 80));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Cost", "CostBasis_AMNT", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("ID", "Trade_ID", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Value", "Value_AMNT", 90, DataGridViewContentAlignment.MiddleRight, "AMOUNT", DataGridViewAutoSizeColumnMode.None, 90, 90));
            Grid.Columns.Add(ColumnSelector.LabelColumn("Exp Date", "Export_DATE", 80, DataGridViewContentAlignment.MiddleRight, "MM/dd/yyyy", DataGridViewAutoSizeColumnMode.None, 80, 80));
            return;
        }

        private void BtnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ShowMessage("Please Wait...");
                if (ValidataData())
                {
                    DataSet ds = GetAllReportData(FileName.Text);
                    Grid.DataSource = ds;
                    if (ds is null || ds.Tables.Count == 0)
                    {
                        return;
                    }
                    List<string> accounts = GetAccounts(ds.Tables[0]);
                    BankPortfolioTransDA.SaveData(accounts, ds);
                    Grid.DataMember = ds.Tables[0].TableName;
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
            BankPortfolioTransDA da = new BankPortfolioTransDA(businessBase);
            DataSet ds = da.GetEmptyData();
            DataTable dt = ds.Tables[0];
            if (File.Exists(fileName))
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
                    foreach (DataRow r in dtProcess.Rows)
                    {
                        DataRow row = dt.NewRow();
                        foreach (DataColumn dc in r.Table.Columns)
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
          
            FileInfo fi = new FileInfo(fileName);
            string account = fi.Name.Replace(fi.Extension, string.Empty).Replace("_TRAN", string.Empty);
            if(account.StartsWith("X"))
            {
                bank = BrokerageAccount.FIDELITY;
            }
            else if (account.StartsWith("IRA") || account.StartsWith("CMA"))
            {
                bank = BrokerageAccount.MERRIL_EDGE;
            }
            else if (account.StartsWith("RH") )
            {
                bank = BrokerageAccount.ROBIN_HOOD;
            }
            string[] lines = File.ReadAllLines(fileName);
          
            DateTime exportDate = DateTime.Today;
         
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }
                if (line.Contains("Date downloaded"))
                {
                    string s = line.Replace("\"", string.Empty)
                                     .Replace("Date downloaded", string.Empty)
                                     .Replace(" ET", string.Empty).Trim();
                    _ = DateTime.TryParse(s, out exportDate);
                    continue;
                }
                 if (line.Contains("Exported on:"))
                {
                    string s = line.Replace("\"", string.Empty)
                                     .Replace("Exported on:", string.Empty)
                                     .Replace(" ET", string.Empty).Trim();
                    _ = DateTime.TryParse(s, out exportDate);
                    continue;
                }

                if (line.Contains("Selected account(s):"))
                {
                    account = line.Replace("\"", string.Empty)
                                  .Replace("Selected account(s):", string.Empty);
                    continue;
                }
                if (line.Contains("Run Date") 
                  && line.Contains("Security Description"))
                {
                    bank = BrokerageAccount.FIDELITY;
                    continue;
                }
                if (line.Contains("Trade Date")
                  && line.Contains("Description"))
                {
                    bank = BrokerageAccount.MERRIL_EDGE;
                    continue;
                }
                if ( line.Contains("Run Date")
                   || line.Contains("Security Description")
                   || line.Contains("Trade Date")
                   || line.Contains("Description")
                   )
                {
                    continue;
                }
                List<string> parts = UtilityHandler.GetSplitCsvLine(line);
                if ( parts.Count <= 7)
                {
                    continue;
                }
                switch (bank)
                {
                    case BrokerageAccount.MERRIL_EDGE:
                     
                        if (string.IsNullOrEmpty(parts[0]))
                        {
                            continue;
                        }
                        if (parts[0].Contains("Trade Date"))
                        {
                            continue;
                        }
                        /*
                          0- Trade Date       - TractionAction_DATE
                          1- Settlement Date  - Settlement_DATE
                          2- Description      - Trade_NAME
                          3- Type 
                          4- Symbol/CUSIP     - Trade_CODE
                          5- Quantity         - Shares_CNT
                          6- Price            - CostBasis_AMNT
                          7- Amount           - Value_AMNT
                         */
                        if (parts.Count >= 8)
                        {
                            string actionCode = string.Empty;
                            if (parts[2].StartsWith("Buy ") 
                                || parts[2].StartsWith("Pending Purchase ")
                                || parts[2].StartsWith("Purchase ")
                                )
                            {
                                actionCode = "BUY";
                            }
                            if( parts[2].StartsWith("Sell ")
                                || parts[2].StartsWith("Pending Sale ")
                                || parts[2].StartsWith("Sale "))
                            {
                                actionCode = "SELL";
                            }
                            if (string.IsNullOrEmpty(actionCode))
                            {
                                continue;
                            }
                            DataRow row = dt.NewRow();
                            row["BankAccount_ID"] = account;
                            row["TransAction_CODE"] = actionCode;
                            row["TransAction_DATE"] = GetDateValue(parts[0]) ;
                            row["Settlement_DATE"] = GetDateValue(parts[1].Replace("Pending",string.Empty));
                            row["Trade_CODE"] = parts[4].Trim();
                            row["Trade_NAME"] = parts[2].Trim();
                            row["Shares_CNT"] = GetDecimalNumber(parts[5]);
                            row["CostBasis_AMNT"] = GetDecimalNumber(parts[6]);
                            row["Value_AMNT"] = GetDecimalNumber(parts[7]);
                            dt.Rows.Add(row);
                        }
                        break;
                    case "FEDE":
                        /*
                         0- Run Date         - TractionAction_DATE
                         1- Action          - YOU BOUGHT ,  YOU SOLD
                         2- Symbol                - Trade_CODE
                         3- Security Description  - Trade_NAME
                         4- Security Type
                         5- Quantity	- Shares_CNT
                         6- Price ($)   - CostBasis_AMNT
                         7- Commission ($)
                         8- Fees ($)
                         9- Accrued Interest ($)
                         10- Amount ($)     - Value_AMNT
                         11- Settlement Date - Settlement_DATE
                     
                        */
                        if (parts[0].Contains("Run Date"))
                        {
                            continue;
                        }
                        if (parts.Count >= 11)
                        {
                            string actionCode = string.Empty;
                            if (parts[1].StartsWith("YOU BOUGHT"))
                            {
                                actionCode = "BUY";
                            }
                            else if (parts[1].StartsWith("YOU SOLD"))
                            {
                                actionCode = "SELL";
                            }
                            if(string.IsNullOrEmpty(actionCode))
                            {
                                continue;
                            }
                            DataRow row = dt.NewRow();
                            row["BankAccount_ID"] = account;
                            row["TransAction_DATE"] = GetDateValue(parts[0]);
                            row["TransAction_CODE"] = actionCode;
                            row["Settlement_DATE"] = GetDateValue(parts[11]);
                            row["Trade_CODE"] = parts[2].Trim();
                            row["Trade_NAME"] = parts[3].Trim();
                            row["Shares_CNT"] = GetDecimalNumber(parts[5]);
                            row["CostBasis_AMNT"] = GetDecimalNumber(parts[6]);
                            row["Value_AMNT"] = GetDecimalNumber(parts[10]);
                            dt.Rows.Add(row);
                        }
                        break;
                  
                }
            }
            int seqNumb = dt.Rows.Count;
            foreach (DataRow row in dt.Rows)
            {
                row["Export_DATE"] = exportDate;
                row["Seq_NUMB"] = seqNumb; seqNumb--;
            }
            return dt;
        }

        private static DateTime GetDateValue(string input)
        {
            _ = DateTime.TryParse(input, out DateTime dt);
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
            if (string.IsNullOrEmpty(FileName.Text))
            {
                ShowMessage("Required file name");
                return false;
            }
            string fileName = FileName.Text.Trim();
            if (!(Directory.Exists(fileName)
                 || File.Exists(fileName))
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
                if (ds is null
                   || ds.Tables.Count == 0)
                {
                    ShowMessage("No Data to Save");
                    return;
                }
                List<string> accounts = GetAccounts(ds.Tables[0]);
                BankPortfolioTransDA.SaveData(accounts, ds);
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
            foreach (DataRow row in input.Rows)
            {
                string account = row["BankAccount_ID"].ToString();
                if (!output.Contains(account))
                {
                    output.Add(account);
                }
            }
            return output;
        }

    }
}
