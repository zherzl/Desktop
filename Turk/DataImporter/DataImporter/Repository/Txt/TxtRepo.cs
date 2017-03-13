using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataImporter.Models;
using System.IO;

namespace DataImporter.Repository.Txt
{
    class TxtRepo : IRepo
    {
        public DateTime GetLatestImportTime()
        {
            return new DateTime(2016, 7, 20, 00, 00, 01);
        }

        public void SaveDataToDatabase(List<SIO2_Logs> importData)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                sb.Append(importData[0].HeadersForTxtExport());

                foreach (var item in importData)
                {
                    sb.Append(item + Environment.NewLine);
                }

                File.WriteAllText("D:\\HistoricalData.txt", sb.ToString());
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show("Error writing to text file\n\n" + ex.Message);
            }
        }
    }
}
