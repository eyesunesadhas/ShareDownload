using ClosedXML.Excel;
using ShareWatch.Common;
using ShareWatch.DataAccess.Share;
using ShareWatch.ExcelExport;
using ShareWatch.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWatch.Business.Share.Reports
{
    public class AccountTallyReportBL
    {
        public List<ExcelColumn> ReportColumns { get; set; } = null;
        
        public AccountTallyReportBL()
        {
            this.ReportColumns = InitPortfolioColumns();
        }

        private static List<ExcelColumn> InitPortfolioColumns()
        {
            List<ExcelColumn> output = new List<ExcelColumn>
            {
                new ExcelColumn() { ColumnName = "BankAccount_ID", DisplayName="Account", Width = 20f },
                new ExcelColumn() { ColumnName = "Owner_NAME", DisplayName="Owner", Width = 12f },
                new ExcelColumn() { ColumnName = "Trade_CODE", DisplayName="Trade", Width = 8.43f },
                new ExcelColumn() { ColumnName = "Trade_NAME", DisplayName="TradeName", Width = 34.14f },
                new ExcelColumn() { ColumnName = "Shares_CNT", DisplayName ="Shares", Width =  8.43f,DataType = Type.GetType("System.Decimal"), Alignment ="right" },
                new ExcelColumn() { ColumnName = "AccountShares_CNT", DisplayName ="AccountShare", Width =  8.43f,DataType = Type.GetType("System.Decimal"), Alignment ="right" },
                new ExcelColumn() { ColumnName = "ShareMismatch_INDC", DisplayName="Tally", Width = 6f },
                new ExcelColumn() { ColumnName = "CostBasis_AMNT", DisplayName= "CostBasis", Width = 9f ,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "TotalInvest_AMNT", DisplayName="Invested", Width = 11f,DataType = Type.GetType("System.Decimal"), Alignment ="right"   },
                new ExcelColumn() { ColumnName = "Export_DATE", DisplayName ="ExportedOn",  Width = 10,DataType = Type.GetType("System.DateTime") },
            };
            return output;
        }

        public string ExportExcel()
        {
            using DataSet ds = GetDataSet(BankPortfolioDA.GetAccountTallyReport() , ReportColumns); 
            return BuildExcelReport(ds);
        }

        public static DataSet GetDataSet(DataSet ds, List<ExcelColumn> columns)
        {
            if (ds == null || ds.Tables.Count == 0)
            {
                return null;
            }
            DataTable src = ds.Tables[0];
            using DataSet output = new DataSet();
            DataTable des = output.Tables.Add("AccountTally");
            foreach(ExcelColumn rc in columns)
            {
                des.Columns.Add(rc.ColumnName,rc.DataType);
            }
          
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                DataRow r = des.NewRow();
                foreach(DataColumn dc in des.Columns)
                {
                    if(src.Columns.Contains(dc.ColumnName))
                    {
                        r[dc.ColumnName] = row[dc.ColumnName];
                    }
                }
                des.Rows.Add(r);
            }

            //Change the display Name 
            foreach (ExcelColumn col in columns)
            {
                if (UtilityHandler.IsEmpty(col.DisplayName))
                {
                    continue;
                }
                if (col.ColumnName != col.DisplayName
                    && des.Columns.Contains(col.ColumnName))
                {
                    des.Columns[col.ColumnName].ColumnName = col.DisplayName;
                }
            }
            output.AcceptChanges(); 
            return output;
        }

        private string BuildExcelReport(DataSet ds)
        {
            string fileName = GetExcelFileName();
            using (XLWorkbook book = new XLWorkbook())
            {
                foreach (DataTable dt in ds.Tables)
                {
                    string sheetName = dt.TableName;

                    DataTable dtc = UtilityHandler.CleanData(dt);
                    book.Worksheets.Add(dtc, sheetName);
                }
                FormatExcelSheet(book);
                book.SaveAs(fileName);
            }
            return fileName;
        }



        private void FormatExcelSheet(XLWorkbook book)
        {
            foreach (IXLWorksheet sheet in book.Worksheets)
            {
                int colUsed = sheet.LastColumnUsed().ColumnNumber();
                int rowUsed = sheet.LastRowUsed().RowNumber();
                FormatWorkSheet(sheet, colUsed, rowUsed);
            }

        }

        private void FormatWorkSheet(IXLWorksheet sheet, int colUsed, int rowUsed)
        {
            int lastRow = rowUsed + 1;
            string sheetName = sheet.Name;
            switch (sheetName)
            {
                case "AccountTally":
                    sheet.Tables.FirstOrDefault().ShowAutoFilter = false;
                    SetSheetComputation(sheet, rowUsed);
                    SetNumberFormat(sheet.Range($"E2:F{rowUsed}"), "#,###,##0.00");
                    SetNumberFormat(sheet.Range($"H2:I{rowUsed}"), "$ #,###,##0.00");
                    SetAccountTallyConditionalFormat(sheet.Range($"G2:G{rowUsed}"));
                    int i = 1;
                    foreach (ExcelColumn col in ReportColumns)
                    {
                        sheet.Column(i).Width = col.Width;
                        i++;
                    }
                    break;
            }
            foreach (IXLCell c in sheet.Range(1, 1, rowUsed, colUsed).Cells())
            {
                SetBorder(c);
            }

        }

        private static void SetSheetComputation(IXLWorksheet sheet, int rowUsed)
        {
            for (int row = 2; row <= rowUsed; row++)
            {
                sheet.Cell(row, "G").FormulaA1 = $"IF(E{row} = F{row},\"Yes\",\"No\")";
            }
        }

        private static void SetNumberFormat(IXLRange range, string format)
        {
            if (range == null)
            {
                return;
            }
            range.Style.NumberFormat.Format = format;
            range.DataType = XLDataType.Number;
        }

        

        private static void SetAccountTallyConditionalFormat(IXLRange range)
        {
            if (range == null)
            {
                return;
            }
            range.AddConditionalFormat().WhenEquals("Yes").Font.FontColor = XLColor.Green;
            range.AddConditionalFormat().WhenEquals("No").Font.FontColor = XLColor.Red;
        }

        private static void SetBorder(IXLCell cell)
        {

            cell.Style.Border.TopBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.RightBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        }
        private static void SetBorderAndBackground(IXLRange range)
        {
            range.Style.Fill.BackgroundColor = XLColor.LightGray;
            foreach (IXLCell c in range.Cells())
            {
                SetBorder(c);
            }
        }

        public static string GetExcelFileName()
        {
            string name = "AccountTally";
            string fileName = $@"{Settings.Default.LoggingFolder}\{name}.xlsx";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            return fileName;
        }

     
    }
}
