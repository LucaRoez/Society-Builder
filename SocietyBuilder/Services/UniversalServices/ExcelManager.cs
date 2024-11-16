using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Text.RegularExpressions;

namespace SocietyBuilder.Services.UniversalServices
{
    public class ExcelManager : IExcelManager
    {
        private readonly IConfiguration _configuration;
        private string _excelFile;
        public ExcelManager(IConfiguration configuration)
        {
            _configuration = configuration;
            _excelFile = _configuration["UniversalSettings:ExcelFile"];
        }

        public (int, float) GetProductData(string product)
        {
            NormalizeSearch(product);
            string currentSearch = "Product";
            using (XLWorkbook workbook = new(_excelFile))
            {
                while (true)
                {
                    IXLWorksheet worksheet = workbook.Worksheet(1);
                    IXLTable? worktable = workbook.Table("Products");
                    if (worktable != null)
                    {
                        IXLTableRow? productFound = worktable.DataRange.RowsUsed().FirstOrDefault(
                            r => r.Cell(2).Equals(product)
                        );

                        if (productFound != null)
                            return (productFound.Cell(1).GetValue<int>(), productFound.Cell(10).GetValue<float>());
                        else
                            Console.WriteLine(
                                string.Format("Error Loop: {0} Id not found with {0} Name sent. Fail to search: {1}.", currentSearch, product)
                            );
                    }
                }
            }
        }

        public int GetActivityId(string activity)
        {
            NormalizeSearch(activity);
            string currentSearch = "Activity";
            using (XLWorkbook workbook = new(_excelFile))
            {
                while (true)
                {
                    IXLWorksheet worksheet = workbook.Worksheet(2);
                    IXLTable? worktable = workbook.Table("Activities");
                    if (worktable != null)
                    {
                        IXLTableRow? activityFound = worktable.DataRange.RowsUsed().FirstOrDefault(
                            r => r.Cell(2).Equals(activity)
                        );

                        if (activityFound != null)
                            return activityFound.Cell(1).GetValue<int>();
                        else
                            Console.WriteLine(
                                string.Format("Error Loop: {0} Id not found with {0} Name sent. Fail to search: {1}.", currentSearch, activity)
                            );
                    }
                    else
                        Console.WriteLine(
                            string.Format("Error Loop: {0} Id not found with {0} Name sent. Fail to search: {1}.", currentSearch, activity)
                        );
                }
            }
        }

        private string NormalizeSearch(string search) => Regex.Replace(search, "(?<!^)([A-Z])", " $1");
    }
}
