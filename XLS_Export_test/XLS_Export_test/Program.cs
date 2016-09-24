using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace XLS_Export_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            xlApp.Visible = true;

            System.Data.DataTable dt = Repo.GetData();
            Microsoft.Office.Interop.Excel.Workbook wb = xlApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

            Worksheet wsh = (Worksheet)wb.Worksheets[1]; //wb.Worksheets.Add("MojShit");

            for (int i = 1; i <= Repo.People.Length; i++)
            {


                Person p = Repo.People[i - 1];
                Range r = wsh.get_Range("A" + i, "A" + i);

                // 2 načina ubacivanja u ćelije
                r.Value = p.Name;
                wsh.Cells[i, 2] = p.Age;
                wsh.Cells[i, 3] = p.City;
            }

            wb.SaveCopyAs(@"D:\test.xlsx");
        }
    }
}
