using ClosedXML.Excel;
using ShareWatch.Common;
using ShareWatch.Const;
using ShareWatch.DataModel.Share.Pfol;
using ShareWatch.ExcelExport;
using ShareWatch.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace ShareWatch.Business
{
    public class PortfolioSummaryReportBL
    {
        public List<ExcelColumn> PortfolioColumns { get; set; } = null;
        public ReportType ViewType { get; set; } = ReportType.Excel;
        public PortfolioSummaryReportBL()
        {
            this.PortfolioColumns = InitPortfolioColumns();
        }

        private static List<ExcelColumn> InitPortfolioColumns()
        {
            List<ExcelColumn> output = new List<ExcelColumn>
            {
                new ExcelColumn() { ColumnName = "TradeCode", DisplayName="Trade", Width = 8.43f },
                new ExcelColumn() { ColumnName = "TradeName", DisplayName="TradeName", Width = 34.14f },
                new ExcelColumn() { ColumnName = "SharesCount", DisplayName ="Shares", Width =  8.43f,DataType = Type.GetType("System.Decimal"), Alignment ="right" },
                new ExcelColumn() { ColumnName = "CostBasisAmnt", DisplayName= "CostBasis", Width = 9f ,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "CurrentAmnt", DisplayName= "Now",Width = 9f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "CostBenefitAmnt", DisplayName= "Share Profit",Width = 11f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "TotalInvestAmnt", DisplayName="Invested", Width = 11f,DataType = Type.GetType("System.Decimal"), Alignment ="right"   },
                new ExcelColumn() { ColumnName = "TotalCurrentAmnt",DisplayName ="Current Value", Width = 13f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "TotalBenefitAmnt",DisplayName ="Profit", Width = 10.43f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "BenefitPercentage",DisplayName ="Percentage", Width = 10.43f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "BuyAtAmnt",DisplayName ="BuyAt", Width = 9f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "SellAtAmnt", DisplayName ="SellAt", Width =9f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "ProfitMargin", DisplayName ="Margin", Width =9f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "BuyAtMarginMetIndc", DisplayName ="BuyMet", Width =9f, Alignment ="right"  },
                new ExcelColumn() { ColumnName = "SellAtMarginMetIndc", DisplayName ="SellMet", Width =9f, Alignment ="right"  },
                new ExcelColumn() { ColumnName = "SoldAtAmnt", DisplayName ="SoldAt", Width =9f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "Week52LowAmnt",DisplayName ="Low52W", Width = 9f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "Week52HighAmnt", DisplayName ="High52W", Width =9f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "DividendPerShareAmnt",DisplayName ="Dividend",  Width = 8.43f },
                new ExcelColumn() { ColumnName = "DividendDate", DisplayName ="DividendDate",  Width = 10 },
                new ExcelColumn() { ColumnName = "BuyRecommendationIndc", DisplayName ="Reco",  Width = 5 , IndicatorColumn = true },
                new ExcelColumn() { ColumnName = "BuyRecommendationByName",DisplayName ="By",   Width = 15 },
                new ExcelColumn() { ColumnName = "BuyRecommendationDate",DisplayName ="On",Width = 10 },
            };
            return output;
        }

        public string ExportExcel(List<PortfolioData> input)
        {
            List<PortfolioData> output = new List<PortfolioData>();
            foreach(PortfolioData data in input)
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
                case "Share":
                    sheet.Tables.FirstOrDefault().ShowAutoFilter = false;
                    SetSheetComputation(sheet, rowUsed);
                    sheet.Cell($"B{lastRow}").Value = "Summary";
                    //Invested
                    sheet.Cell($"G{lastRow}").FormulaA1 = $"SUM(G2:G{rowUsed})";
                    //Current Value
                    sheet.Cell($"H{lastRow}").FormulaA1 = $"=SUM(H2:H{rowUsed})";
                    //Profit Value
                    sheet.Cell($"I{lastRow}").FormulaA1 = $"=SUM(I2:I{rowUsed})";
                    SetBorderAndBackground(sheet.Range($"B{lastRow}:I{lastRow}"));
                    SetNumberFormat(sheet.Range($"C2:C{rowUsed}"), "#,###,##0.00");
                    SetNumberFormat(sheet.Range($"D2:I{lastRow}"), "$ #,###,##0.00");
                    SetNumberFormat(sheet.Range($"J2:J{rowUsed}"), "0.00%");
                    SetNumberFormat(sheet.Range($"K2:L{lastRow}"), "$ #,###,##0.00");
                    SetNumberFormat(sheet.Range($"M2:M{rowUsed}"), "0.00%");
                    SetNumberFormat(sheet.Range($"P2:R{lastRow}"), "$ #,###,##0.00");
                    SetNumberFormat(sheet.Range($"S2:S{rowUsed}"), "#0.00");
                    SetProfitConditionalFormat(sheet.Range($"F2:F{lastRow}"));
                    SetProfitConditionalFormat(sheet.Range($"I2:I{lastRow}"));
                    SetProfitConditionalFormat(sheet.Range($"J2:J{lastRow}"));
                    SetTargetMetConditionalFormat(sheet.Range($"N2:O{lastRow}"));
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

        private  void SetSheetComputation(IXLWorksheet sheet, int rowUsed)
        {
            for (int row = 2; row <= rowUsed; row++)
            {
               
                if(ViewType == ReportType.GoogleSheet )
                {
                    sheet.Cell(row, "E").FormulaA1 = $"=GOOGLEFINANCE(A{row},\"PRICE\")";
                    sheet.Cell(row, "Q").FormulaA1 = $"=GOOGLEFINANCE(A{row},\"low52\")";
                    sheet.Cell(row, "R").FormulaA1 = $"=GOOGLEFINANCE(A{row},\"high52\")";
                }
                sheet.Cell(row, "F").FormulaA1 = $"E{row}-D{row}";
                sheet.Cell(row, "G").FormulaA1 = $"C{row}*D{row}";
                sheet.Cell(row, "H").FormulaA1 = $"C{row}*E{row}";
                sheet.Cell(row, "I").FormulaA1 = $"H{row}-G{row}";
                sheet.Cell(row, "J").FormulaA1 = $"I{row}/G{row}";
                sheet.Cell(row, "M").FormulaA1 = $"(L{row}-D{row})/D{row}";
                sheet.Cell(row, "N").FormulaA1 = $"IF(E{row} < K{row},\"Yes\",\"\")";
                sheet.Cell(row, "O").FormulaA1 = $"IF(E{row} >= L{row},\"Yes\",\"\")";
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

        private static void SetTargetMetConditionalFormat(IXLRange range)
        {
            if (range == null)
            {
                return;
            }
            range.AddConditionalFormat().WhenEquals("Yes").Font.FontColor = XLColor.Green;
           // range.AddConditionalFormat().WhenEquals("No").Font.FontColor = XLColor.Orange;
        }

        private static void SetBorder(IXLCell cell)
        {

            cell.Style.Border.TopBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.LeftBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.RightBorder = XLBorderStyleValues.Thin;
            cell.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        }
        private static void SetBorderAndBackground(IXLRange range )
        {
            range.Style.Fill.BackgroundColor = XLColor.LightGray;
            foreach (IXLCell c in range.Cells())
            {
                SetBorder(c);
            }
        }

        public  string GetExcelFileName()
        {
            string name = "Portfolio";
            if(ViewType ==  ReportType.GoogleSheet)
            {
                name = "PortfolioData";
            }
            string fileName = $@"{Settings.Default.LoggingFolder}\{name}.xlsx";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            return fileName;
        }

        private DataSet GetDataSet(List<PortfolioData> input)
        {
            DataSet ds = new DataSet("PortFolio");
            DataTable dt = UtilityHandler.ToDataTable(input, this.PortfolioColumns, "Share");
            ds.Tables.Add(dt);
            return ds;
        }
    }
}
