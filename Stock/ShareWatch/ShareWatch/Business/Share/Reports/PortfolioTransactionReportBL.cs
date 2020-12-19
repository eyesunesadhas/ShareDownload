using ClosedXML.Excel;
using ShareWatch.Common;
using ShareWatch.DataModel.Share.Pfol;
using ShareWatch.DataModel.Share.Pfot;
using ShareWatch.ExcelExport;
using ShareWatch.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShareWatch.Business.Share.Reports
{
    public class PortfolioTransactionReportBL
    {
        public List<ExcelColumn> PortfolioColumns { get; set; } = null;

        public PortfolioTransactionReportBL()
        {
            this.PortfolioColumns = InitPortfolioColumns();
        }

        private static List<ExcelColumn> InitPortfolioColumns()
        {
            List<ExcelColumn> output = new List<ExcelColumn>
            {
                new ExcelColumn() { ColumnName = "TractionActionDate", DisplayName="Action Date", Width = 10.57f },
                new ExcelColumn() { ColumnName = "TradeCode", DisplayName="Trade", Width = 9f },
                new ExcelColumn() { ColumnName = "TradeName", DisplayName="TradeName", Width = 34.14f },
                new ExcelColumn() { ColumnName = "TractionActionCode", DisplayName="Action", Width = 34.14f },
                new ExcelColumn() { ColumnName = "SharesCount", DisplayName ="Shares", Width =  8.43f,DataType = Type.GetType("System.Decimal"), Alignment ="right" },
                new ExcelColumn() { ColumnName = "CostBasisAmnt", DisplayName= "CostBasis", Width = 9f ,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "TotalInvestAmnt", DisplayName="Invested", Width = 11f,DataType = Type.GetType("System.Decimal"), Alignment ="right"   },
                new ExcelColumn() { ColumnName = "SharesInHandCount", DisplayName="Shares InHand", Width = 11f,DataType = Type.GetType("System.Decimal"), Alignment ="right"   },
                new ExcelColumn() { ColumnName = "RunningInvestAmnt", DisplayName="Runn Invest", Width = 11f,DataType = Type.GetType("System.Decimal"), Alignment ="right"   },
                new ExcelColumn() { ColumnName = "WorthAmnt", DisplayName="Worth", Width = 11f,DataType = Type.GetType("System.Decimal"), Alignment ="right"   }
            };
            return output;
        }

        public string ExportExcel(List<PortfolioTransactionData> input)
        {
            List<PortfolioTransactionData> output = new List<PortfolioTransactionData>();
            foreach (PortfolioTransactionData data in input)
            {
                if (!UtilityHandler.IsEmpty(data.TradeCode))
                {
                    output.Add(data);
                }
            }
            using DataSet ds = GetDataSet(output);
            return BuildExcelReport(ds);

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
                case "Transaction":
                    sheet.Tables.FirstOrDefault().ShowAutoFilter = false;
                    SetSheetComputation(sheet, rowUsed);
                    sheet.Cell($"B{lastRow}").Value = "Summary";
                    //Invested
                    sheet.Cell($"G{lastRow}").FormulaA1 = $"SUM(G2:G{rowUsed})";
                    SetBorderAndBackground(sheet.Range($"B{lastRow}:I{lastRow}"));
                    SetNumberFormat(sheet.Range($"E2:E{rowUsed}"), "#,###,##0.00");
                    SetNumberFormat(sheet.Range($"F2:J{lastRow}"), "$ #,###,##0.00");
                    SetProfitConditionalFormat(sheet.Range($"I2:I{lastRow}"));
                    SetTradeConditionalFormat(sheet.Range($"D2:D{lastRow}"));
                    int i = 1;
                    foreach (ExcelColumn col in PortfolioColumns)
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
            string sheetName = sheet.Name;
            for (int row = 2; row <= rowUsed; row++)
            {
                sheet.Cell(row, "G").FormulaA1 = $"E{row}*F{row}";
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



        private static void SetProfitConditionalFormat(IXLRange range)
        {
            if (range == null)
            {
                return;
            }
            range.AddConditionalFormat().WhenLessThan(0).Font.FontColor = XLColor.Red;
            range.AddConditionalFormat().WhenEqualOrGreaterThan(0).Font.FontColor = XLColor.Green;
        }

        private static void SetTradeConditionalFormat(IXLRange range)
        {
            if (range == null)
            {
                return;
            }
            range.AddConditionalFormat().WhenEquals("BUY").Font.FontColor = XLColor.Green;
            range.AddConditionalFormat().WhenEquals("SELL").Font.FontColor = XLColor.Red;
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
            string fileName = $@"{Settings.Default.LoggingFolder}\PortfolioTransaction{DateTime.Today:yyyyMMdd}.xlsx";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            return fileName;
        }

        private DataSet GetDataSet(List<PortfolioTransactionData> input)
        {
            DataSet ds = new DataSet("PortfolioTransaction" +
                "");
            DataTable dt = UtilityHandler.ToDataTable(input, this.PortfolioColumns, "Transaction");
            ds.Tables.Add(dt);
            return ds;
        }
    }
}
