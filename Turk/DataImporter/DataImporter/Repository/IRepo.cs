using DataImporter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataImporter.Repository
{
    interface IRepo
    {
        DateTime GetLatestImportTime();
        void SaveDataToDatabase(List<SIO2_Logs> importData);
    }
}
