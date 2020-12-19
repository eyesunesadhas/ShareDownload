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
using System.Text;
using System.Threading.Tasks;

namespace ShareWatch.Business.Share.Reports
{
    public class PortfolioReportBL
    {
        public ReportType ViewType { get; set; } = ReportType.Excel;
        const string SUMMARY_SHEET = "Summary";
        public List<ExcelColumn> PortfolioColumns { get; set; }
        public List<ExcelColumn> SummaryColumns { get; set; }
        public PortfolioReportBL()
        {
            this.PortfolioColumns = InitPortfolioColumns();
            this.SummaryColumns = InitSummaryColumns();
        }

        private static List<ExcelColumn> InitSummaryColumns()
        {
            List<ExcelColumn> output = new List<ExcelColumn>
            {
                new ExcelColumn() { ColumnName = "OwnerName", DisplayName="Owner", Width = 11f },
                new ExcelColumn() { ColumnName = "AccountName", DisplayName="Account", Width = 25f },
                new ExcelColumn() { ColumnName = "AccountTypeText", DisplayName="Type", Width = 13f },
                new ExcelColumn() { ColumnName = "TotalInvestAmnt", DisplayName="Invested", Width = 13f,DataType = Type.GetType("System.Decimal"), Alignment ="right"   },
                new ExcelColumn() { ColumnName = "TotalCurrentAmnt",DisplayName ="Current Value", Width = 13f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "TotalBenefitAmnt",DisplayName ="Profit", Width = 12.43f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
                new ExcelColumn() { ColumnName = "BenefitPercentage",DisplayName ="Percentage", Width = 10.43f,DataType = Type.GetType("System.Decimal"), Alignment ="right"  },
            };
             return output;
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
            };
            return output;
        }

        public string ExportExcel(List<PortfolioData> input)
        {
            Dictionary<string, List<PortfolioData>> output = new Dictionary<string, List<PortfolioData>>();
            IEnumerable<PortfolioData> sorted = from sd in input
                                                orderby sd.OwnerName, sd.AccountTypeText, sd.BankAccountID, sd.TradeCode
                                                select sd;
            foreach (PortfolioData data in sorted)
            {
                if (!UtilityHandler.IsEmpty(data.TradeCode)
                    || data.HideAccountIndc != "Y")
                {
                    string account = $"{data.BankAccountID}";
                    List<PortfolioData> folio;
                    if (!output.ContainsKey(account))
                    {
                        folio = new List<PortfolioData>();
                        output.Add(account, folio);
                    }
                    else
                    {
                        folio = output[account];
                    }
                    folio.Add(data);
                }
            }
            List<PortfolioSummaryData> summary = GetPortfolioSummary(output);
            using DataSet ds = GetDataSet(summary,output);
            return BuildExcelReport(ds);

        }

        private static List<PortfolioSummaryData> GetPortfolioSummary(Dictionary<string, List<PortfolioData>> input)
        {
            List<PortfolioSummaryData> output = new List<PortfolioSummaryData>();
            foreach(KeyValuePair<string,List<PortfolioData>> data in input)
            {
                string account = data.Key;
                PortfolioSummaryData sumData = new PortfolioSummaryData()
                {
                    AccountName = account
                };
                sumData.OwnerName = data.Value[0].OwnerName;
                decimal totalInvestAmnt = 0;
                decimal totalCurrentAmnt = 0;

                string accountTypeText = string.Empty;
                string accountTypeCode = string.Empty;

                foreach (PortfolioData d in data.Value)
                {
                    totalInvestAmnt += d.TotalInvestAmnt;
                    totalCurrentAmnt += d.TotalCurrentAmnt;
                    accountTypeCode = d.AccountTypeCode;
                    accountTypeText = d.AccountTypeText;
                }
                sumData.TotalInvestAmnt = totalInvestAmnt;
                sumData.TotalCurrentAmnt = totalCurrentAmnt;
                sumData.AccountTypeCode = accountTypeCode;
                sumData.AccountTypeText = accountTypeText;
                output.Add(sumData);
            }
            return output;
        }

        private  string BuildExcelReport(DataSet ds)
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


       
        private  void FormatExcelSheet(XLWorkbook book)
        {
            Dictionary<string, int> sheetRows = new Dictionary<string, int>();
            IXLWorksheet summarySheet = null;
            foreach (IXLWorksheet sheet in book.Worksheets)
            {
                int colUsed = sheet.LastColumnUsed().ColumnNumber();
                int rowUsed = sheet.LastRowUsed().RowNumber();
                FormatWorkSheet(sheet, colUsed, rowUsed);
                switch(sheet.Name)
                {
                    case SUMMARY_SHEET:
                        summarySheet = sheet;
                        break;
                    default:
                        sheetRows.Add(sheet.Name, rowUsed + 1);
                        break;
                }
            }
            SetCrossSheetFormula(summarySheet, sheetRows);
        }

        private static void SetCrossSheetFormula(IXLWorksheet sheet, Dictionary<string, int> input)
        {
           
            if(sheet is null)
            {
                return;
            }
            int row = 2;
            foreach (KeyValuePair<string,int> kv in input)
            {
                //invested
                sheet.Cell($"D{row}").FormulaA1 = $@"'{kv.Key}'!G{kv.Value}";
                //current Value
                sheet.Cell($"E{row}").FormulaA1 = $@"'{kv.Key}'!H{kv.Value}";
                row++;
            }
        }

        private void FormatWorkSheet(IXLWorksheet sheet, int colUsed, int rowUsed)
        {
            int lastRow = rowUsed + 1;
            string sheetName = sheet.Name;
            int i;
            switch (sheetName)
            {
                case SUMMARY_SHEET:
                    sheet.Tables.FirstOrDefault().ShowAutoFilter = false;
                    SetSummarySheetComputation(sheet, rowUsed);
                    sheet.Cell($"B{lastRow}").Value = "Summary";
                    //Invested
                    sheet.Cell($"D{lastRow}").FormulaA1 = $"=SUBTOTAL(9,D2:D{rowUsed})";
                    //Current Value
                    sheet.Cell($"E{lastRow}").FormulaA1 = $"=SUBTOTAL(9,E2:E{rowUsed})";
                    //Profit Value
                    sheet.Cell($"F{lastRow}").FormulaA1 = $"=SUBTOTAL(9,F2:F{rowUsed})";
                    SetBorderAndBackground(sheet.Range($"B{lastRow}:F{lastRow}"));
                    SetNumberFormat(sheet.Range($"D2:F{lastRow}"), "$ #,###,##0.00");
                    SetNumberFormat(sheet.Range($"G2:G{rowUsed}"), "0.00%");
                    SetProfitConditionalFormat(sheet.Range($"F2:F{lastRow}"));
                    i = 1;
                    foreach (ExcelColumn col in SummaryColumns)
                    {
                        sheet.Column(i).Width = col.Width;
                        i++;
                    }
                    break;
                default:
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
                    SetProfitConditionalFormat(sheet.Range($"F2:F{lastRow}"));
                    SetProfitConditionalFormat(sheet.Range($"I2:J{lastRow}"));
                    i = 1;
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

        private static void SetSummarySheetComputation(IXLWorksheet sheet, int rowUsed)
        {
            for (int row = 2; row <= rowUsed; row++)
            {
                sheet.Cell(row, "F").FormulaA1 = $"E{row}-D{row}";
                sheet.Cell(row, "G").FormulaA1 = $"F{row}/D{row}";
            }
        }

        private  void SetSheetComputation(IXLWorksheet sheet, int rowUsed)
        {
            for (int row = 2; row <= rowUsed; row++)
            {

                if (ViewType == ReportType.GoogleSheet)
                {
                    sheet.Cell(row, "E").FormulaA1 = $"=GOOGLEFINANCE(A{row},\"PRICE\")";
                }
                sheet.Cell(row, "F").FormulaA1 = $"E{row}-D{row}";
                sheet.Cell(row, "G").FormulaA1 = $"C{row}*D{row}";
                sheet.Cell(row, "H").FormulaA1 = $"C{row}*E{row}";
                sheet.Cell(row, "I").FormulaA1 = $"H{row}-G{row}";
                sheet.Cell(row, "J").FormulaA1 = $"I{row}/G{row}";
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

        public  string GetExcelFileName()
        {
            string name = "AccountReport";
            if (ViewType == ReportType.GoogleSheet)
            {
                name = "AccountReportData";
            }
            string fileName = $@"{Settings.Default.LoggingFolder}\{name}.xlsx";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            return fileName;
        }

        private DataSet GetDataSet(List<PortfolioSummaryData> summary, Dictionary<string, List<PortfolioData>> input)
        {
            DataSet ds = new DataSet("PortFolio");
            DataTable sum = UtilityHandler.ToDataTable(summary, this.SummaryColumns, "Summary");
            ds.Tables.Add(sum);
            foreach (KeyValuePair<string, List<PortfolioData>> data in input)
            {
                DataTable dt = UtilityHandler.ToDataTable(data.Value, this.PortfolioColumns, data.Key);
                ds.Tables.Add(dt);
            }
            return ds;
        }
    }
}
