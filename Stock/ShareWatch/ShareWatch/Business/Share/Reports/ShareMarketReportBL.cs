using ClosedXML.Excel;
using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataModel.Share.Shrv;
using ShareWatch.ExcelExport;
using ShareWatch.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace ShareWatch.Business.Share
{
    public class ShareMarketReportBL
    {
        public ReportType ViewType { get; set; } = ReportType.Excel;
        public List<ExcelColumn> ExcelColumns { get; set; } = null;

        public ShareMarketReportBL()
        {
            this.ExcelColumns = InitExcelColumns();
        }

        private static List<ExcelColumn> InitExcelColumns()
        {
            List<ExcelColumn> output = new List<ExcelColumn>
            {
                new ExcelColumn() { ColumnName = "TradeCode", DisplayName="Trade", Width = 8.43f },
                new ExcelColumn() { ColumnName = "TradeName", DisplayName="TradeName", Width = 34.14f },
                new ExcelColumn() { ColumnName = "ExchangeCode", DisplayName="Exchange", Width = 10f },
                new ExcelColumn() { ColumnName = "SectorName", DisplayName="Sector", Width = 34.14f },
                new ExcelColumn() { ColumnName = "IndustryName", DisplayName="Industry", Width = 34.14f },
                new ExcelColumn() { ColumnName = "CurrentAmnt", DisplayName= "Now", Width = 8.57f ,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "BuyAtAmnt",DisplayName ="BuyAt", Width = 9f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "SellAtAmnt", DisplayName ="SellAt", Width =9f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "BuyAtMarginMetIndc", DisplayName ="BuyMet", Width =9f, Alignment ="right"  },
                new ExcelColumn() { ColumnName = "SellAtMarginMetIndc", DisplayName ="SellMet", Width =9f, Alignment ="right"  },
                new ExcelColumn() { ColumnName = "SoldAtAmnt", DisplayName ="SoldAt", Width =9f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "Week52LowAmnt",DisplayName ="Low52W", Width = 9f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "Week52HighAmnt", DisplayName ="High52W", Width =9f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "DividendPerShareAmnt",DisplayName ="Dividend",  Width = 8.43f },
                new ExcelColumn() { ColumnName = "DividendDate", DisplayName ="Div. Date",  Width = 10 },
                new ExcelColumn() { ColumnName = "HaveShareIndc", DisplayName ="Own",  Width = 5 , IndicatorColumn = true },
                new ExcelColumn() { ColumnName = "BuyRecommendationIndc", DisplayName ="Reco",  Width = 5 , IndicatorColumn = true },
                new ExcelColumn() { ColumnName = "BuyRecommendationByName",DisplayName ="By",   Width = 15 },
                new ExcelColumn() { ColumnName = "BuyRecommendationDate",DisplayName ="On",Width = 10 },
            };
            return output;
        }

        public string ExportExcel(List<ShareMarketValueData> input)
        {
            using DataSet ds = GetDataSet(input);
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
            //   int lastRow = rowUsed + 1;
            string sheetName = sheet.Name;
            switch (sheetName)
            {
                case "Share":
                    SetSheetComputation(sheet, rowUsed);
                    sheet.Tables.FirstOrDefault().ShowAutoFilter = false;
                    SetNumberFormat(sheet.Range($"F2:H{rowUsed}"), "$ #,###,##0.00");
                    SetNumberFormat(sheet.Range($"K2:M{rowUsed}"), "$ #,###,##0.00");
                    SetTargetMetConditionalFormat(sheet.Range($"I2:J{rowUsed}"));
                    int i = 1;
                    foreach (ExcelColumn col in ExcelColumns)
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

        private void SetSheetComputation(IXLWorksheet sheet, int rowUsed)
        {
            for (int row = 2; row <= rowUsed; row++)
            {
                if (ViewType == ReportType.GoogleSheet)
                {
                    sheet.Cell(row, "F").FormulaA1 = $"=GOOGLEFINANCE(A{row},\"PRICE\")";
                    sheet.Cell(row, "J").FormulaA1 = $"=GOOGLEFINANCE(A{row},\"low52\")";
                    sheet.Cell(row, "K").FormulaA1 = $"=GOOGLEFINANCE(A{row},\"high52\")";
                }
                sheet.Cell(row, "I").FormulaA1 = $"IF(F{row} < G{row},\"Yes\",\"\")";
                sheet.Cell(row, "J").FormulaA1 = $"IF(F{row} >= H{row},\"Yes\",\"\")";
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


        private static void SetBorder(IXLCell cell)
        {

            cell.Style.Border.TopBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.RightBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        }
        private void SetBorderAndBackground(IXLCell cell)
        {
            cell.Style.Fill.BackgroundColor = XLColor.LightGray;
            SetBorder(cell);
        }

        private static void SetTargetMetConditionalFormat(IXLRange range)
        {
            if (range == null)
            {
                return;
            }
            range.AddConditionalFormat().WhenEquals("Yes").Font.FontColor = XLColor.Green;
            // range.AddConditionalFormat().WhenEquals("No").Font.FontColor = XLColor.Orange;
        }

        public string GetExcelFileName()
        {
            string fileName = string.Empty;
            switch(ViewType)
            {
                case ReportType.Excel:
                    fileName = $@"{Settings.Default.LoggingFolder}\Shares.xlsx";
                    break;
                case ReportType.GoogleSheet:
                    fileName = $@"{Settings.Default.LoggingFolder}\SharesData.xlsx";
                    break;
            }
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            return fileName;
        }

        private DataSet GetDataSet(List<ShareMarketValueData> input)
        {
            DataSet ds = new DataSet("ShareMarket");
            ds.Tables.Add(UtilityHandler.ToDataTable(input, this.ExcelColumns, "Share"));
            return ds;
        }
    }
}
