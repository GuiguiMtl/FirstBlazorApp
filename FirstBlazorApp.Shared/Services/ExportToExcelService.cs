using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace FirstBlazorApp.Shared.Services
{
    public class ExportStockValuesToExcelService
    {
        public ExportStockValuesToExcelService()
        {

        }

        public byte[] GenerateFile(List<GraphStockValues> data)
        {
            using (var package = new OfficeOpenXml.ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("StockValues");
                var currentRow = 1;
                
                foreach(var stock in data)
                {
                    var dateCollection = stock.StockValues.Select(s => s.Date);

                    foreach (var date in dateCollection)
                    {
                        Console.WriteLine(date);
                    }

                    worksheet.Cells[$"C{currentRow}:C{ currentRow}"].LoadFromCollection(dateCollection);
                    worksheet.Cells[2,currentRow, dateCollection.Count(),2].Style.Numberformat.Format = "h:mm:s";
                    currentRow++;
                    worksheet.Cells[$"B{currentRow}:B{ currentRow}"].Value = stock.Symbol;

                    var stockCollection = stock.StockValues.Select(s => s.StockValue);
                    foreach (var value in stockCollection)
                    {
                        Console.WriteLine(value);
                    }

                    worksheet.Cells[$"C{currentRow}:C{ currentRow}"].LoadFromCollection(stock.StockValues.Select(s => s.StockValue));
                    currentRow += 2;
                }

                return package.GetAsByteArray();
            }
        }

    }
}
