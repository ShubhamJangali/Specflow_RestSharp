using NUnit.Framework;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowExample.EPPLUS
{
    public class epplus
    {

        public Dictionary<string, Dictionary<string, string>> exe = new Dictionary<string, Dictionary<string, string>>();
        public Dictionary<string,string> Name = new Dictionary<string,string>();
        public void readexcel()
        {
            string path = "C:\\Users\\HP\\source\\repos\\SpecFlowExample\\SpecFlowExample\\EPPLUS\\TestCases.xlsx";
            using (ExcelPackage excelpackage = new ExcelPackage(path))
            {
                ExcelWorksheet worksheet = excelpackage.Workbook.Worksheets["Sheet1"];
                int rows = worksheet.Dimension.Rows;
                int cols = worksheet.Dimension.Columns;
                Console.WriteLine(worksheet.Cells["A1"].Text);

                for (int row=2;row<=rows;row++)
                {
                    var username = worksheet.Cells[row,1].Text;
                    for(int col=2;col<=cols;col++)
                    {
                        var Head = worksheet.Cells[1, col].Text;
                        var val = worksheet.Cells[row,col].Text;
                        Name[Head]= val;
                        exe[username] = Name;
                        
                    }
                    Name = null;
                    Name = new Dictionary<string, string>();
                }
                foreach (var data in exe)
                {
                    foreach (var Data in data.Value)
                    {
                        Console.WriteLine(Data.Key+" "+Data.Value);
                    }
                }
               
            }
        }
    }

    [TestFixture]
    public class test
    {
        [Test]
        public void unittest()
        {
            epplus plus = new epplus();
            plus.readexcel();
            //Console.WriteLine(plus.exe["Shubham"]["Id"] + " And Password is " + plus.exe["Shubham"]["Password"]);
        }
    }
}
